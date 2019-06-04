using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TatooParlor;

namespace TatooParlolForms
{
    public partial class Form4 : Form
    {
        public Registration Registration { get; }
        //public Tatoo Tatoo { get; }
        

        public Form4(Registration registration)
        {
            Registration = registration;
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var ofd = new OpenFileDialog() { Filter = "Фотография|*.jpg" };
        //    var dr = ofd.ShowDialog(this);
        //    if (dr == DialogResult.OK)
        //    {
        //        pictureBox1.Image = Image.FromFile(ofd.FileName);
        //    }
        //}

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = Registration.Contacts;
            dateTimePicker1.Value = Registration.DateToVisit;
            textBox2.Text = Registration.Gender;
            comboBox2.SelectedItem = Registration.BodyPart;
            comboBox4.SelectedItem = Registration.Master;
            comboBox3.SelectedItem = Registration.TatooStyles;

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration.Contacts = textBox1.Text;
            Registration.Gender = textBox2.Text;
            Registration.DateToVisit = dateTimePicker1.Value;
            Registration.BodyPart = comboBox2.SelectedItem.ToString();
            Registration.Master = comboBox4.SelectedItem.ToString();
            Registration.TatooStyles = comboBox3.SelectedItem.ToString();

            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
