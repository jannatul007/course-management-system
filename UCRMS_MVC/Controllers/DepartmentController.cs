using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCRMS_MVC.DBManager;
using UCRMS_MVC.Models;

namespace UCRMS_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager=new DepartmentManager();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
          return View();
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            ViewBag.message = departmentManager.Create(department);
            ModelState.Clear();
            return View();
        }

      public ActionResult ViewAllDepartment()
        {
            List<Department> departments = departmentManager.GetAllDepartment();
            return View(departments);
        }
	}
}