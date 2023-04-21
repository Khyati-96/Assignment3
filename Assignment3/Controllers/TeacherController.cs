using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment3.Models;
using System.Net;

namespace Assignment3.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        // GET: Teachers/List
        public ActionResult List(string SearchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
            return View(Teachers);
        }

        // GET: /Teacher/Show/{id}
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id.Value);

            return View(NewTeacher);
        }

        // GET: /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id.Value);

            return View(NewTeacher);
        }

        // POST: /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id.Value);
            return RedirectToAction("List");
        }

        // GET: /Teacher/New
        public ActionResult New()
        {
            return View();
        }

        // POST: /Teacher/Create
        [HttpPost]
        public ActionResult Create(string Teacherfname, string Teacherlname, DateTime Hiredate, string Employeenumber, decimal Salary)
        {
            // Identify that this method is running
            // Identify the inputs provided from the form

            Debug.WriteLine("I have accessed the Create Method");
            Debug.WriteLine(Teacherfname);
            Debug.WriteLine(Teacherlname);

            Teacher NewTeacher = new Teacher();
            NewTeacher.Teacherfname = Teacherfname;
            NewTeacher.Teacherlname = Teacherlname;
            NewTeacher.Hiredate = Hiredate;
            NewTeacher.Employeenumber = Employeenumber;
            NewTeacher.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }


        //POST : Teacher/Update/{id}
        /// <summary>
        /// Receives a POST request containting information about an existing teacher in the system, with new values.
        /// Convesy this information to the API, and redirects to the "Teacher Show" page of our updated teacher.
        /// </summary>
        /// <param name="id">id of teacher to update</param>
        /// <param name="Teacherfname">updated first name of teacher</param>
        /// <param name="TeacherLlname">updated last name of teacher</param>
        /// <param name="Employeenumber">updated bio of teacher</param>
        /// <param name="Hiredate">updated email of teacher</param>
        /// <param name="Salary">updated salary of teacher</param>
        /// <returns>
        /// dynamic webpage which provides current info of teacher
        /// </returns>
        [HttpPost]
        public ActionResult Update(int id, string TeacherFname, string TeacherLname, string EmployeeNum, DateTime HireDate, decimal Salary)
        {
            //debug
            Debug.WriteLine("Input received from 'Add Teacher' form!");
            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(TeacherLname);
            Debug.WriteLine(EmployeeNum);
            Debug.WriteLine(HireDate);
            Debug.WriteLine(Salary);

            //instantiate new teacher and assign values to object properties
            Teacher TeachrInfo = new Teacher();

            TeachrInfo.Teacherfname = TeacherFname;
            TeachrInfo.Teacherlname = TeacherLname;
            TeachrInfo.Employeenumber = EmployeeNum;
            TeachrInfo.Hiredate = HireDate;
            TeachrInfo.Salary = Salary;

            //pass new data to AddTeacher method in TeacherDataController
            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id, TeachrInfo);

            //redirect to show/id
            return RedirectToAction("Show/" + id);
        }

    }
 }


