using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serialisation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            Locality l = new Locality(listBox1.Items.Count);
            listBox1.Items.Add(l);

            listBox1.SetSelected(listBox1.Items.Count - 1, true);
            f.ShowDialog();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items != null && listBox1.SelectedItem!= null)
            {
                Locality l = (Locality)listBox1.SelectedItem;
                Form2 f = new Form2();
                f.ShowDialog();
            }
           
        }
        private String fileName = Directory.GetCurrentDirectory() + "\\SerializedData.txt";
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Do you want to save changes?", "Serialisation",
               MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                    List<Locality> list = new List<Locality>();
                    foreach (var loc in listBox1.Items)
                    {
                        list.Add((Locality)loc);
                    }
                FileStream fs = new FileStream(fileName, FileMode.Create);

                // Construct a BinaryFormatter and use it to serialize the data to the stream.
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fs, list);
                }
                catch (SerializationException ex)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            try
            {
                if (!(File.Exists(fileName)))
                {
                    File.Create(fileName);
                }
                FileStream fileStream2 = new FileStream(fileName, FileMode.Open);
                BinaryFormatter bf2 = new BinaryFormatter();

                List<Locality> l = new List<Locality>();
                try
                {
                     l = bf2.Deserialize(fileStream2) as List<Locality>;
                }
                catch (SerializationException ex)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
                    throw;
                }
                finally
                {
                    fileStream2.Close();
                }
                foreach (var locality in l)
                {
                    listBox1.Items.Add(locality);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + " " + fileName);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
}
