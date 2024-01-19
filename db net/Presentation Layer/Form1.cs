using Bussines_layer;
using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer
{
    public partial class Form1 : Form
    {

        private readonly StudentBussiness studentBussiness;
        public Form1()
        {
            this.studentBussiness = new StudentBussiness();
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.Name = TextBoxName.Text;
            s.IndexNumber = TextBoxIndx.Text;
            s.AverageMark = Convert.ToDecimal(TextBoxProsOcena.Text);

            if (this.studentBussiness.InserStudent(s)) {

                refreshData();
            }
        }

        private void refreshData() 
        {
            List<Student> students = this.studentBussiness.GetAllStudent();
            listBoxStudents.Items.Clear();

            foreach (Student s in students) 
            { 
                listBoxStudents.Items.Add(s.Id+" "+s.Name+" "+s.IndexNumber+" "+
                    s.AverageMark);
            }
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
