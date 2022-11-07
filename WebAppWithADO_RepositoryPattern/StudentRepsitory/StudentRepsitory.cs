using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppWithADO_RepositoryPattern.IStudentRepo;
using WebAppWithADO_RepositoryPattern.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace WebAppWithADO_RepositoryPattern.StudentRepo
{
    public class StudentRepsitory : IStudentRepository
    {
        IConfiguration _config;

        public StudentRepsitory(IConfiguration config)
        {
            _config = config;

        }
        SqlConnection connection;
        SqlCommand command;
        List<Student> listStudents = null;
         
        
        public List<Student> GetStudents()
        {
            try
            {
                connection = GetConnection();
                command = new SqlCommand("Select * from Employee");
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    listStudents = new List<Student>();
                    while (reader.Read())
                    {
                        Student student = new Student() { Id = (int)reader[0], Name = reader[1].ToString(), Batch = reader[2].ToString(), StartDate = Convert.ToDateTime(reader[3]) };
                        listStudents.Add(student);
                    }

                }
            }
            catch (Exception ex)
            {

            }

            finally
            {
                connection.Close();
                command.Dispose();
                connection.Dispose();
            }
            return listStudents;



        }

        public Student Create(Student student)
        {

           
            connection = GetConnection();
            command = new SqlCommand("Insert into student(name, batch, start_date)values(@name, @batch,@startdate)");
            command.Parameters.AddWithValue("@name", student.Name);
            command.Parameters.AddWithValue("@dept", student.Batch);
            command.Parameters.AddWithValue("@salary", student.StartDate);
            command.Connection = connection;
            connection.Open();
            int flag = command.ExecuteNonQuery();
            return student  ;

        }

        public int DeleteStudent(int id)
        {
            return 1;
        }

        public int EditStudent (int id, Student student)
        {
            return 1;
        }
        
        public Student SearchStudent(int id)
        {
            return new Student();
        }

        private SqlConnection GetConnection()
        {
            connection = new SqlConnection(_config.GetConnectionString("MyConnection"));
            return connection;





        }
    }
}
