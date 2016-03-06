using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS_MVC.DBGateway;
using UCRMS_MVC.Models;

namespace UCRMS_MVC.DBManager
{
    public class EnrollManager
    {
        EnrollGateway aEnrollGateway=new EnrollGateway();
        public List<Student> GetAllStudent()
        {
            List<Student> asStudents = aEnrollGateway.GetAllStudent();
            return asStudents;
        }

        //public List<Course> GetAllCourses()
        //{
        //    List<Course> aCourses = aEnrollGateway.GetAllCourses();
        //    return aCourses;
        //}
        public string EnroolStudent(Enroll enroll)
        {
            if (aEnrollGateway.IsEnrollCourseIdUnique(enroll))
            {
                string message = aEnrollGateway.SaveEnrollStudent(enroll);
                return message;
            }
            else
            {
                return "Student Alredy enroll this course";
            }
        }


        //public List<ViewResultByRegNo> GetAllEnrollStudent()
        //{
        //    List<ViewResultByRegNo> aEnrolls = aEnrollGateway.GetAllEnrollStudent();
        //    return aEnrolls;
        //}
    }
}