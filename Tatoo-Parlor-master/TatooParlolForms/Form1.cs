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
using System.Xml.Serialization;
using TatooParlor;


namespace TatooParlolForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Master1_Click(object sender, EventArgs e)
        {
            Master1.Image = Properties.Resources.Anatoliy;
        }

        private void Master3_Click(object sender, EventArgs e)
        {
            Master3.Image = Properties.Resources.Rusana;
        }

        int index = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            index++;
            tabControl1.SelectedIndex = index;
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var ff = new Form2();
            if (ff.ShowDialog(this) == DialogResult.OK)
            {
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var ff = new Form2();
            if (ff.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var ff = new Form3(new TatooParlor.Comments { VisitDate = DateTime.Now });
            if (ff.ShowDialog(this) == DialogResult.OK)
            {
                listBox1.Items.Add(ff.Comments);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ff = new Form4(new TatooParlor.Registration { DateToVisit = DateTime.Now });
            if (ff.ShowDialog(this) == DialogResult.OK)
            {
                listBox2.Items.Add(ff.Registration);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            index--;
            tabControl1.SelectedIndex = index;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem is Registration)
            {
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = listBox2.SelectedItem is Registration;
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "Тату|*.spaceship" };

            if (sfd.ShowDialog(this) != DialogResult.OK)
                return;

            var tatooSalon = new TatooSalon()
            {
                VisitorName = textBox8.Text,
                Age = textBox7.Text,
                CommetsPage = listBox1.Items.OfType<Comments>().ToList(),
                Journal = listBox2.Items.OfType<Registration>().ToList(),
            };

            var stream = new MemoryStream();
            pictureBox2.Image.Save(stream, ImageFormat.Jpeg);
            tatooSalon.Photo = stream.ToArray();

            var xs = new XmlSerializer(typeof(TatooSalon));            
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, tatooSalon);            
            file.Close();
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Тату|*.spaceship" };

            if (ofd.ShowDialog(this) != DialogResult.OK)
                return;
            var xs = new XmlSerializer(typeof(TatooSalon));            
            var file = File.OpenRead(ofd.FileName);           
            var tatooSalon = (TatooSalon)xs.Deserialize(file);            
            file.Close();

            textBox8.Text = tatooSalon.VisitorName;
            textBox7.Text = tatooSalon.Age;

            var ms = new MemoryStream(tatooSalon.Photo);
            pictureBox2.Image = Image.FromStream(ms);

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (var comment in tatooSalon.CommetsPage)
            {
                listBox1.Items.Add(comment);
            }
            foreach (var custumer in tatooSalon.Journal)
            {
                listBox2.Items.Add(custumer);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Фотография|*.jpg" };
            var dr = ofd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Фотография|*.jpg" };
            var dr = ofd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}
