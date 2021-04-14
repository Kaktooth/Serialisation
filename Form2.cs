using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void button5_Click(object sender, EventArgs e)
        {
            string p = (listBox1.SelectedItem).ToString();
            string[] str = p.Trim().Split(' ');
            MessageBox.Show(p);
            Form3 f3 = new Form3();
            (f3.Controls["comboBox1"]).Text = str[1];
            (f3.Controls["textBox1"]).Text = str[3];
            (f3.Controls["textBox2"]).Text = str[5];
            int year, month, day, hour, minute, seconds;
            string time = str[7] + " " + str[8];
            string[] s = time.Split('.', ':', ' ');
            int i = 0;
            foreach (string st in s)
            {
                if (st[0] == '0')
                {
                    s[i] = st.Remove(0, 1);
                }
                i++;
            }
            year = Convert.ToInt32(s[2]);
            month = Convert.ToInt32(s[1]);
            day = Convert.ToInt32(s[0].Replace(" ",""));
            hour = Convert.ToInt32(s[3]);
            minute = Convert.ToInt32(s[4]);
            seconds = Convert.ToInt32(s[5]);
            
            ((DateTimePicker)f3.Controls["dateTimePicker1"]).Value = new DateTime(year,month,day,hour,minute,seconds,0);
            (f3.Controls["textBox4"]).Text = str[14];
            (f3.Controls["comboBox2"]).Text = str[17];
        

            for (int j = 18; j < str.Length; j++)
            {
                string[] st = str[j].Split(',');
                st[0] = st[0].Replace("{X=", "");
                st[1] = st[1].Replace("Y=", "");
                st[1] = st[1].Replace("}", "");
                ((ListBox)f3.Controls["listBox1"]).Items.Add(new Point(Convert.ToInt32(st[0]), Convert.ToInt32(st[1])));
            }
            (f3.Controls["textBox5"]).Text = str[10];

            f3.ShowDialog();

        }
    }
}
