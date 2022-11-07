using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppWithADO_RepositoryPattern.IStudentRepo;
using WebAppWithADO_RepositoryPattern.Models;
using WebAppWithADO_RepositoryPattern.StudentRepo;

namespace WebAppWithADO_RepositoryPattern.Controllers
{
    public class StudentController : Controller
    {
        IStudentRepository _repo;
        public StudentController(IStudentRepository repo)
        {
            _repo = repo;

        }
        public IActionResult Index()
        {
            return View(_repo.GetStudents());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(Student student)
        {
            _repo.Create(student);
            return RedirectToAction("Index");
        }
    }
}
