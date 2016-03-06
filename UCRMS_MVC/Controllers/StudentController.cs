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
    public class StudentController : Controller
    {
       DepartmentGateway aDepartmentGateway=new DepartmentGateway();
        StudentManager aStudentManager=new StudentManager();
        StudentGateway aStudentGateway=new StudentGateway();
        EnrollManager aEnrollManager = new EnrollManager();
        EnrollGateway aEnrollGateway = new EnrollGateway();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RegisterStudent()
        {
            List<Department> aDepartments = aDepartmentGateway.ViewAllDepartments();
            ViewBag.aDepartments = aDepartments;
            return View();
        }

        public ActionResult RegisterStudent(Student student)
        {
            List<Department> aDepartments = aDepartmentGateway.ViewAllDepartments();
            ViewBag.aDepartments = aDepartments;
            ViewBag.message = aStudentManager.RegisterStudent(student);
            return View();
        }

        public ActionResult StudentResult()
        {
            ViewBag.allStudents = aEnrollManager.GetAllStudent();
            ViewBag.allGrade = aEnrollGateway.GetAllGradeLetter();
            return View();
        }
        [HttpPost]
        public ActionResult StudentResult(StudentResult studentResult)
        {
            ViewBag.allStudents = aEnrollManager.GetAllStudent();
            ViewBag.allGrade = aEnrollGateway.GetAllGradeLetter();
            ViewBag.message = aStudentGateway.SaveStudentResult(studentResult);
            ModelState.Clear();
            
            return View();
        }
        public JsonResult GetStudentDetailByRegNo(string regNo)
        {
            List<GetStudentByRegNo> aStudents = aEnrollGateway.GetStudentDetailByRegNo(regNo);
            return Json(aStudents, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseIdByEnroll(string regNo)
        {
            List<EnrollCoursesByRegNo> aEnrolls = aEnrollGateway.GetCourseIdByEnroll(regNo);
            return Json(aEnrolls, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewStudentResult()
        {
            ViewBag.allStudents = aEnrollManager.GetAllStudent();
            return View();
        }

        public JsonResult GetResultDetailByRegNo(string regNo)
        {
            List<ViewResultByRegNo> aViewResult = aEnrollGateway.GetResultDetailByRegNo(regNo);
            return Json(aViewResult, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ViewStudentResult(string regNo)
        {
            ViewBag.allStudents = aEnrollManager.GetAllStudent();
            ViewBag.ViewResult = aEnrollGateway.GetResultDetailByRegNo(regNo);
            return View();
        }
	}
}