using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TatooParlor;

namespace TatooParlolForms
{
    public partial class Form3 : Form
    {
        public Form3(Comments comments )
        {
            Comments = comments;
            InitializeComponent();
        }

        public Comments Comments { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Comments.CustumersName = textBox1.Text;
            Comments.MastersName = textBox2.Text;
            Comments.Comment = textBox3.Text;
            Comments.VisitDate = dateTimePicker1.Value;           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = Comments.CustumersName;
            textBox2.Text = Comments.MastersName;
            textBox3.Text = Comments.Comment;
            dateTimePicker1.Value = Comments.VisitDate;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
