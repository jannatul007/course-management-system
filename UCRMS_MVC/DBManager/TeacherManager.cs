using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS_MVC.DBGateway;
using UCRMS_MVC.Models;

namespace UCRMS_MVC.DBManager
{
    public class TeacherManager
    {
        TeacherGateway aTeacherGateway=new TeacherGateway();
        public List<Department> GetAllDepartment()
        {
            List<Department> aDepartments = aTeacherGateway.GetAllDepartment();
            return aDepartments;
        }

        public List<Designation> GetAllDesignation()
        {
            List<Designation> aTeachers = aTeacherGateway.GetAllDesignation();
            return aTeachers;
        }

        public List<Teacher> GetAllTeacher()
        {
            List<Teacher> aTeachers = aTeacherGateway.GetAllTeacher();
            return aTeachers;
        }
        public string SaveTeacher(Teacher teacher)
        {
            if (aTeacherGateway.IsEmailEnique(teacher))
            {
                string message = aTeacherGateway.SaveTeacher(teacher);
                return message;
            }
            else
            {
                return "Email Address Alreay Exists.";
            }
        }
    }
}