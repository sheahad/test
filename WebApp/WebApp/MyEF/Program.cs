using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using  WebApp.Model.Model;
using WebApp.BLL.BLL;

namespace MyEF
{
    class Program
    {
        
        static void Main(string[] args)
        {
            StudentManager _studentManager = new StudentManager();
            DepartmentManager _departmentManager = new DepartmentManager();

            //Department department = new Department()
            //{
            //    Name = "ENG",
            //    Students = new List<Student>()
            //    {
            //        new Student()
            //        {
            //                RollNo = "009",
            //                Name = "Mehedi",
            //                Address = "Mogbazar",
            //                Age = 25
            //        },
            //        new Student()
            //        {
            //        RollNo = "010",
            //        Name = "Doipayion",
            //        Address = "Tikatoly",
            //        Age = 30
            //        }
            //    }

            //};

            //Student student = new Student()
            //{
            //    RollNo = "011",
            //    Name = "Rahman",
            //    Address = "Mirpur",
            //    Age = 20,

            //};
            //department.Students.Add(student);

            //_departmentManager.Add(department);


            //Console.WriteLine("\t\tDepartment");
            //foreach (var department in _departmentManager.GetAll())
            //{
            //    Console.WriteLine("\nDepartment Name:\t" + department.Name + "\n\t\t\t\tStudents");
            //    if (department.Students != null && department.Students.Any())
            //    {

            //        foreach (var student in department.Students)
            //        {
            //            Console.WriteLine("Student RollNo:\t" + student.RollNo + "\tName:\t" + student.Name + "\t\tAge:\t" + student.Age);
            //        }

            //    }
            //    else
            //    {
            //        Console.WriteLine("\t\tNo Student Found!!!");
            //    }
            //}


            /////////////////////////////////////////////////////////
            //if (_studentManager.Add(student))
            //    Console.WriteLine("Saved");
            //else
            //{
            //    Console.WriteLine("Not Saved");
            //}

            ////if (_studentManager.Delete(student.Id))
            ////    Console.WriteLine("Deleted");
            ////else
            ////{
            ////    Console.WriteLine("Not Deleted");
            ////}
            //Student student = new Student();

            //Student aStudent = dbContext.Students.FirstOrDefault(c => c.Id == student.Id);
            //var student = _studentManager.GetByID(2);

            //if (student != null)
            //{

            //    student.RollNo = "002";
            //    student.Name = "Arif";
            //    student.Address = "Uttora";
            //    student.Age = 25;
            //}

            //if (_studentManager.Update(student))
            //    Console.WriteLine("Updated");
            //else
            //{
            //    Console.WriteLine("Not Updated");
            //}

            Console.WriteLine("-----------------------------------------------------------");
            int i = 1;
            Console.WriteLine("Sl\t Name \t\t Roll No \t Address \t Age \t\tDepartment");
            foreach (var std in _studentManager.GetAll())
            {

                Console.WriteLine(i + "\t" + std.Name + "\t\t" + std.RollNo + " \t\t " + std.Address + " \t\t " + std.Age + "\t\t" + std.DepartmentId);
                i++;
            }

            Console.WriteLine("-----------------------LINQ Classic--------------------------");
            i = 1;
            var students = _studentManager.GetAll();
            // SELECT * FROM Studens WHERE Age >20
            //var qResult = from s in students where s.Age>20 select s;
            var qResult = students.Where(c => c.Age > 20).ToList();

            

            Console.WriteLine("Sl\t Name \t\t Roll No \t Address \t Age \t\tDepartment");
            foreach (var std in qResult)
            {

                Console.WriteLine(i + "\t" + std.Name + "\t\t" + std.RollNo + " \t\t " + std.Address + " \t\t " + std.Age + "\t\t" + std.DepartmentId);
                i++;
            }

            Console.ReadKey();


        }
    }
}
