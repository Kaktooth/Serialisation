using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serialisation
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        
            
        }
        private void Refresh(object sender, EventArgs e)
        {
            Locality l = (Locality)((ListBox)Application.OpenForms["Form1"].Controls["listBox1"]).SelectedItem;
            if (l.plots != null)
            {
                foreach (var plot in l.plots)
                {
                    listBox1.Items.Add(plot);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        { 
            Form3 f3 = new Form3();
            f3.ShowDialog();
           
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Locality l = ((Locality)((ListBox)Application.OpenForms["Form1"].Controls["listBox1"]).SelectedItem);
            
            l.RemoveProperty((Property)listBox1.SelectedItem);
            listBox1.Items.Remove((Property)listBox1.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Locality l = ((Locality)((ListBox)Application.OpenForms["Form1"].Controls["listBox1"]).SelectedItem);
            l.ClearProperty();
            listBox1.Items.Clear();
        }
    }
}
