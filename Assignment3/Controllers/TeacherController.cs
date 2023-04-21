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
    }
}
