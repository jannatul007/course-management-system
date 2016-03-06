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
    public class AllocateClassRoomController : Controller
    {
        DepartmentGateway aDepartmentGateway=new DepartmentGateway();
        CourseGateway aCourseGateway=new CourseGateway();
        AllocateRoomManager allocateRoomManager=new AllocateRoomManager();
        //private object dynamic;
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Allocate()
        {
            ViewBag.AllDepartment = aCourseGateway.GetAllDepartment();
            ViewBag.allCourses = aCourseGateway.GetAllCourse();
            ViewBag.allRoom = allocateRoomManager.GetAllRoom();
            ViewBag.allDays = allocateRoomManager.GetAllDays();
            return View();
        }
        [HttpPost]
        public ActionResult Allocate(AllocationClassRoom allocationClass)
        {
            ViewBag.AllDepartment = aCourseGateway.GetAllDepartment();
            ViewBag.allCourses = aCourseGateway.GetAllCourse();
            ViewBag.allRoom = allocateRoomManager.GetAllRoom();
            ViewBag.allDays = allocateRoomManager.GetAllDays();
            ViewBag.message = allocateRoomManager.Allocate(allocationClass)
             ? (dynamic)new HtmlString("<div class='alert alert-success'><strong>Success!</strong> Classroom has been allocated successfully. </div>")
             : (dynamic)new HtmlString("<div class='alert alert-danger'><strong>Error!</strong> Failed to save Information.</div>");
            ModelState.Clear();
           return View();
        }
        public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            List<Course> listCourses = aCourseGateway.GetCourseByDepartmentId(departmentId);
            return Json(listCourses, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ViewClassSchedule()
        {
            ViewBag.AllDepartment = aCourseGateway.GetAllDepartment();
            return View();
        }

        public JsonResult GetClassScheduleDepartmentId(int departmentId)
        {
            var courses = allocateRoomManager.GetCourseByDepartmentId(departmentId);
             List<object> ClsSchedule= new List<object>();
            foreach (var data in courses)
            {
                var scheduleInfo = allocateRoomManager.GetClassSchedule(departmentId, data.CourseId);
                scheduleInfo = (scheduleInfo == "") ? "Not Scheduled Yet" : scheduleInfo;

                var ClassSche = new
                {
                    CourseCode = data.CourseCode,
                    CourseName = data.CourseName,
                    ScheduleInfo = scheduleInfo
                };
                ClsSchedule.Add(ClassSche);
               
            }
            return Json(ClsSchedule, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UnAllocationAllRoom()
        {
            return View();
        }

        public JsonResult AjaxUnAllocationAllRoom()
        {
            var result = allocateRoomManager.UnAllocationAllRoom();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}