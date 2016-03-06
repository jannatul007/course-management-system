using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCRMS_MVC.DBManager;
using UCRMS_MVC.Models;

namespace UCRMS_MVC.Controllers
{
    public class CourseController : Controller
    {
        CourseManager aCourseManager=new CourseManager();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SaveCourse()
        {
            List<Semester> aSemesters = aCourseManager.GetAllSemester();
            List<Department> aDepartments = aCourseManager.GetAllDepartment();
            ViewBag.aSemesters = aSemesters;
            ViewBag.aDepartments = aDepartments;
            return View();
        }
        [HttpPost]
        public ActionResult SaveCourse(Course course)
        {
           
            List<Semester> aSemesters = aCourseManager.GetAllSemester();
            List<Department> aDepartments = aCourseManager.GetAllDepartment();
            ViewBag.aSemesters = aSemesters;
            ViewBag.aDepartments = aDepartments;
            ViewBag.message = aCourseManager.SaveCourse(course);
            ModelState.Clear();
            return View();
        }

        public ActionResult UnAssignAllCourses()
        {
            return View();
        }

        public JsonResult AjaxUnAssignAllCourses()
        {
            var result = aCourseManager.UnAssignAllCourses();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}