using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Model.Model;
using  WebApp.BLL.BLL;
using WebApp.Models;
using  AutoMapper;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        StudentManager _studentManager = new StudentManager();
        DepartmentManager _departmentManager = new DepartmentManager();

        //public string Add(string rollNo, string name, string address, int ? age, int ? departmentId)
        [HttpGet]
        public ActionResult Add()
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Students = _studentManager.GetAll();
            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(), Text = c.Name

                    }
                ).ToList();

            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentViewModel studentViewModel)
        {
            string message = "";

            //Student student = new Student();
            //student.RollNo = studentViewModel.RollNo;
            //student.Name = studentViewModel.Name;
            //student.Address = studentViewModel.Address;
            //student.Age = studentViewModel.Age;
            //student.DepartmentId = studentViewModel.DepartmentId;

            if (ModelState.IsValid)
            {
                Student student = Mapper.Map<Student>(studentViewModel);

                if (_studentManager.Add(student))
                {
                    message = "Saved";
                }
                else
                {
                    message = "Not Saved";
                }
            }
            else
            {
                message = "Model State False!!";
            }

            ViewBag.Message = message;
            studentViewModel.Students = _studentManager.GetAll();
            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name

                    }
                ).ToList();


            return View(studentViewModel);
        }

        [HttpGet]
        public ActionResult Search()
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Students = _studentManager.GetAll();
            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name

                    }
                ).ToList();

            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult Search(StudentViewModel studentViewModel)
        {
            var students = _studentManager.GetAll();

            if (studentViewModel.RollNo != null)
            {
                students = students.Where(c=>c.RollNo.Contains(studentViewModel.RollNo)).ToList();

            }

            if (studentViewModel.Name != null)
            {
                students = students.Where(c => c.Name.ToLower().Contains(studentViewModel.Name.ToLower())).ToList();
            }

            studentViewModel.Students = students;
            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }
                ).ToList();

            return View(studentViewModel);
        }
    }
}
