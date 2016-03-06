using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCRMS_MVC.DBGateway;
using UCRMS_MVC.DBManager;
using UCRMS_MVC.Models;

namespace UCRMS_MVC.Controllers
{
    public class EnrollController : Controller
    {
        EnrollManager aEnrollManager=new EnrollManager();
        CourseManager aCourseManager=new CourseManager();
        EnrollGateway aEnrollGateway=new EnrollGateway();
        public ActionResult Enroll()
        {
            ViewBag.allStudents = aEnrollManager.GetAllStudent();
            
            return View();
        }
        [HttpPost]
        public ActionResult Enroll(Enroll enroll)
        {
            ViewBag.allStudents = aEnrollManager.GetAllStudent();
            ViewBag.message = aEnrollManager.EnroolStudent(enroll);
            ModelState.Clear();
            return View();
        }
       public JsonResult GetStudentDetailByRegNo(string regNo)
        {
            List<GetStudentByRegNo> aStudents = aEnrollGateway.GetStudentDetailByRegNo(regNo);
            return Json(aStudents, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllCoursesByRegNo(string regNo)
        {
            List<Course> courses = aEnrollGateway.GetAllCoursesByRegNo(regNo);
            return Json(courses, JsonRequestBehavior.AllowGet);

       }

      
	}
}