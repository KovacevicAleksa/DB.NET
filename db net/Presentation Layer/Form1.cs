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
    // Glavna forma koja prikazuje podatke o studentima.
    public partial class Form1 : Form
    {
        // Poslovna logika za rad sa studentima.
        private readonly StudentBussiness studentBussiness;

        // Konstruktor forme.
        public Form1()
        {
            // Inicijalizacija poslovne logike za rad sa studentima.
            this.studentBussiness = new StudentBussiness();
            InitializeComponent();
        }

        // Event handler koji se poziva kada se promeni selektovani element u listBox-u.
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implementacija po potrebi.
        }

        // Event handler koji se poziva kada se klikne na određeni button ili labelu.
        private void button1_Click(object sender, EventArgs e)
        {
            // Implementacija po potrebi.
        }

        // Metoda koja osvežava podatke na formi pri njenom učitavanju.
        private void refreshData() 
        {
            // Dobavljanje liste svih studenata kroz poslovni sloj.
            List<Student> students = this.studentBussiness.GetAllStudent();

            // Čišćenje listBox-a.
            listBoxStudents.Items.Clear();

            // Dodavanje svakog studenta u listBox za prikaz na formi.
            foreach (Student s in students) 
            { 
                listBoxStudents.Items.Add(s.Id+" "+s.Name+" "+s.IndexNumber+" "+
                    s.AverageMark);
            }
        }

        // Event handler koji se poziva kada se forma učita.
        private void Form1_Load(object sender, EventArgs e)
        {
            // Osvežavanje podataka pri učitavanju forme.
            refreshData();
        }
    }
}
