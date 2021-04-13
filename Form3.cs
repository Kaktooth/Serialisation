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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            comboBox1.Items.Add(Appointment.AppointmentValue.Agricultural);
            comboBox1.Items.Add(Appointment.AppointmentValue.Reserved);
            comboBox1.Items.Add(Appointment.AppointmentValue.UnderBuilding);

            comboBox2.Items.Add(Description.SoilType.Chalk);
            comboBox2.Items.Add(Description.SoilType.Clay);
            comboBox2.Items.Add(Description.SoilType.Loam);
            comboBox2.Items.Add(Description.SoilType.Peat);
            comboBox2.Items.Add(Description.SoilType.Sandy);
            comboBox2.Items.Add(Description.SoilType.Silt);

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Locality l = ((Locality)((ListBox)Application.OpenForms["Form1"].Controls["listBox1"]).SelectedItem);
            
            ListBox plist = ((ListBox)Application.OpenForms["Form2"].Controls["listBox1"]);
            Appointment a = new Appointment((Appointment.AppointmentValue)comboBox1.SelectedItem);
            Owner o = new Owner(textBox1.Text, textBox2.Text, dateTimePicker1.Value);
            Description d = new Description(Convert.ToInt32(textBox4.Text),(Description.SoilType)comboBox2.SelectedItem);
            double price = Convert.ToInt32(textBox5.Text);
            Property p = new Property(a,o,d,price);
            plist.Items.Add(p);
            l.AddProperty(p);
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
