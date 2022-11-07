using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppWithADO_RepositoryPattern.Models;
namespace WebAppWithADO_RepositoryPattern.IStudentRepo
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
        Student Create(Student student);
        int EditStudent(int id, Student student);
        int DeleteStudent(int id);
        Student SearchStudent(int id);

    }
}
