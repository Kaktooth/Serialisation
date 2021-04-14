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

        readonly Regex NameReg = new Regex(@"^[a-zA-Z]+\s?$");
        readonly Regex NumReg = new Regex(@"^[\d]+$");
        readonly Regex PriceReg = new Regex(@"^[\d]+(,|.)[\d]+?$");
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var control in this.Controls)
            {
                if (control is TextBox)
                {
                    if (((TextBox)control).BackColor == Color.Red)
                    {
                        MessageBox.Show("You have red text fields!");
                        return;
                    }
                }
            }
            Locality l = ((Locality)((ListBox)Application.OpenForms["Form1"].Controls["listBox1"]).SelectedItem);
            
            ListBox plist = ((ListBox)Application.OpenForms["Form2"].Controls["listBox1"]);
            Appointment a = new Appointment((Appointment.AppointmentValue)comboBox1.SelectedItem);
            Owner o = new Owner(textBox1.Text, textBox2.Text, dateTimePicker1.Value);
            List<Point> geo = new List<Point>();
            foreach (var point in listBox1.Items)
            {
                geo.Add((Point)point);
            }
            Description d = new Description(Convert.ToInt32(textBox4.Text), (Description.SoilType)comboBox2.SelectedItem, geo);
            
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (NameReg.IsMatch(textBox1.Text))
            {
                textBox1.BackColor = Color.LightGreen;
            }
            else
            {
                textBox1.BackColor = Color.Red;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (NameReg.IsMatch(textBox2.Text))
            {
                textBox2.BackColor = Color.LightGreen;
            }
            else
            {
                textBox2.BackColor = Color.Red;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (NumReg.IsMatch(textBox4.Text))
            {
                textBox4.BackColor = Color.LightGreen;
            }
            else
            {
                textBox4.BackColor = Color.Red;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (PriceReg.IsMatch(textBox5.Text))
            {
                textBox5.BackColor = Color.LightGreen;
            }
            else
            {
                textBox5.BackColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(new Point(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox6.Text)));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

      
    }
}
