using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCRMS_MVC.DBManager;
using UCRMS_MVC.Models;

namespace UCRMS_MVC.Controllers
{
    public class TeacherController : Controller
    {
     TeacherManager aTeacherManager=new TeacherManager();
        [HttpGet]
     public ActionResult Index()
     {
         return View();
     }
        public ActionResult SaveTeacher()
        {
            List<Designation> aDesignations = aTeacherManager.GetAllDesignation();
            List<Department> aDepartments = aTeacherManager.GetAllDepartment();
            ViewBag.aDesignations = aDesignations;
            ViewBag.aDepartments = aDepartments;
            return View();
        }
        [HttpPost]
        public ActionResult SaveTeacher(Teacher teacher)
        {
            ViewBag.message = aTeacherManager.SaveTeacher(teacher);
            List<Designation> aDesignations = aTeacherManager.GetAllDesignation();
            List<Department> aDepartments = aTeacherManager.GetAllDepartment();
            ViewBag.aDesignations = aDesignations;
            ViewBag.aDepartments = aDepartments;
            ModelState.Clear();
            return View();
        }
	}
}