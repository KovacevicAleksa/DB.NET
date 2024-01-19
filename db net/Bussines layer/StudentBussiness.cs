using Data_Layer.Models;
using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace Bussines_layer
{
    // Poslovni sloj koji upravlja operacijama sa studentima.
    public class StudentBussiness
    {
        // Repozitorijum za rad sa podacima o studentima.
        private readonly StudentRepository studentRepository;

        // Konstruktor koji inicijalizuje repozitorijum za studente.
        public StudentBussiness() 
        { 
            this.studentRepository = new StudentRepository();
        }

        // Metoda koja vraća sve studente.
        public List<Student> GetAllStudent()
        { 
            return this.studentRepository.GetAllStudent();
        }

        // Metoda za unos novog studenta. Vraća true ako je uspešno unet, inače false.
        public bool InserStudent(Student s) 
        {
            if (this.studentRepository.InserStudent(s) > 0) 
            { 
                return true;
            }
            return false;
        }

        // Metoda koja vraća listu studenata sa ocenom iznad prosleđenog proseka.
        public List<Student> GetStudentsGTAvgMark(decimal average) 
        {
            return this.studentRepository.GetAllStudent()
                .Where(s => s.AverageMark > average).ToList();
        }
    }
}
