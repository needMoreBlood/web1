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

        //private void pictureBox1_Click(object sender, EventArgs e)
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
            textBox1.Text = Registration.VisitorName;
            textBox2.Text = Registration.Age;
            textBox3.Text = Registration.Contacts;
            dateTimePicker1.Value = Registration.DateToVisit;
            textBox4.Text = Registration.Gender;
            comboBox2.SelectedItem = Registration.BodyPart;
            comboBox4.SelectedItem = Registration.Master;
            comboBox3.SelectedItem = Registration.TatooStyles;

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration.VisitorName = textBox1.Text;
            Registration.Age = textBox2.Text;
            Registration.Contacts = textBox3.Text;
            Registration.Gender = textBox4.Text;
            Registration.DateToVisit = dateTimePicker1.Value;
            Registration.BodyPart = comboBox2.SelectedItem.ToString();
            Registration.Master = comboBox4.SelectedItem.ToString();
            Registration.TatooStyles = comboBox3.SelectedItem.ToString();

            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
