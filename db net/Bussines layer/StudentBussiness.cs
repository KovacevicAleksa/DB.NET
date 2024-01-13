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
    public class StudentBussiness
    {
        private readonly StudentRepository studentRepository;

        public StudentBussiness() 
        { 
            this.studentRepository = new StudentRepository();
        }

        public List<Student> GetAllStudent()
        { 
            return this.studentRepository.GetAllStudent();
        }

        public bool InserStudent(Student s) 
        {
            if (this.studentRepository.InserStudent(s) > 0) 
            { 
                return true;
            }
            return false;
        }
        public List<Student> GetStudentsGTAvgMark(decimal average) 
        {
            return this.studentRepository.GetAllStudent()
                .Where(s => s.AverageMark > s.AverageMark).ToList();
        }
    }
}
