using Data_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Models
{
    // Klasa koja pruža funkcionalnost za rad sa podacima o studentima.
    public class StudentRepository
    {
        // Metoda koja vraća listu svih studenata iz baze podataka.
        public List<Student> GetAllStudent() 
        { 
            List<Student> result = new List<Student>();

            // Korišćenje SqlConnection za povezivanje sa bazom podataka.
            using (SqlConnection sqlConnection = new SqlConnection(Constant.connectionString)) 
            {
                // Kreiranje SQL upita za selektovanje svih studenata.
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Students";

                // Otvaranje veze sa bazom podataka.
                sqlConnection.Open();

                // Izvršavanje SQL upita i čitanje rezultata.
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                // Čitanje podataka iz rezultata upita i popunjavanje liste studenata.
                while (sqlDataReader.Read()) 
                { 
                    Student s = new Student();
                    s.Id = sqlDataReader.GetInt32(0);
                    s.Name = sqlDataReader.GetString(1);
                    s.IndexNumber = sqlDataReader.GetString(2);
                    s.AverageMark = sqlDataReader.GetDecimal(3);

                    result.Add(s);
                }
            }

            // Vraćanje rezultata.
            return result;
        }

        // Metoda za unos novog studenta u bazu podataka.
        // Vraća broj redova koji su promenjeni (trebalo bi da bude 1 ako je unos uspeo).
        public int InserStudent(Student s) 
        {
            // Korišćenje SqlConnection za povezivanje sa bazom podataka.
            using (SqlConnection sqlConnection = new SqlConnection(Constant.connectionString))
            {
                // Kreiranje SQL upita za unos novog studenta.
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = 
                    string.Format("INSERT INTO Students VALUES('{0}','{1}',{2})",
                    s.Name,s.IndexNumber,s.AverageMark);

                // Izvršavanje SQL upita za unos i vraćanje broja promenjenih redova.
                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
