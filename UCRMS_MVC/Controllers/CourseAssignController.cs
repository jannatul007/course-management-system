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
    public class CourseAssignController : Controller
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        TeacherGateway aTeacherGateway=new TeacherGateway();
        CourseGateway aCourseGateway=new CourseGateway();
        CourseManager aCourseManager=new CourseManager();
       [HttpGet]
        public ActionResult AssignToTeacher()
        {
            ViewBag.AllDepartment = aDepartmentManager.GetAllDepartment();
            return View();
        }
       public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            List<Teacher> listTeachers = aTeacherGateway.GetTeacherByDeptId(departmentId);
            return Json(listTeachers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            List<Course> listCourses = aCourseGateway.GetCourseByDepartmentId(departmentId);
            return Json(listCourses, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTeacherDeTailById(int teacherId)
        {
           CreditToBeTakenRemaining teacher = aCourseGateway.GetTeacherDeyId(teacherId);
            return Json(teacher, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseDetails(int courseId)
        {
            List<Course> aCourses = aCourseGateway.GetCourseDetails(courseId);
            return Json(aCourses, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AssignToTeacher(CourseAssignToTeacher courseAssignToTeacher)
        {
            ViewBag.AllDepartment = aDepartmentManager.GetAllDepartment();

            string message = aCourseManager.CourseAssignToTeacher(courseAssignToTeacher);
            ViewBag.message = message;

            return View();   // not completed only design completed
        }

        [HttpGet]
        public ActionResult CourseStatics()
        {
            List<Department> allDepartment = aDepartmentManager.GetAllDepartment();
            ViewBag.allDepartment = allDepartment;

            return View();
        }

        public JsonResult ViewAllCourseStatic(int deptId)
        {
            List<ViewCourseStatic> courseStatic = aCourseGateway.ViewAllCourseStatic(deptId);
            return Json(courseStatic, JsonRequestBehavior.AllowGet);
        }
       
	}
}