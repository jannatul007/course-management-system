using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS_MVC.DBGateway;
using UCRMS_MVC.Models;


namespace UCRMS_MVC.DBManager
{
    public class CourseManager
    {
        CourseGateway courseGateway=new CourseGateway();

        public List<Semester> GetAllSemester()
        {
            List<Semester> asSemester = courseGateway.GetAllSemester();
            return asSemester;
        }

        public List<Department> GetAllDepartment()
        {
            List<Department> aDepartment = courseGateway.GetAllDepartment();
            return aDepartment;
        }

        public string SaveCourse(Course course)
        {
         if (courseGateway.IsCodeIsUniqe(course))
            {
                if (courseGateway.ISNameIsUniqe(course))
                {
                    string message = courseGateway.SaveCourse(course);
                    return message;
                }
                else
                {
                    return "Course Name is already Exist.";
                }
            }
            else
            {
                return "Course Code is already Exist.";

            }
        }

        public string CourseAssignToTeacher(CourseAssignToTeacher courseAssignToTeacher)
        {
            if (courseGateway.IsAssaigned(courseAssignToTeacher))
            {
                int rowAffected = courseGateway.CourseAssignToTeacher(courseAssignToTeacher);

                if (rowAffected > 0)
                {
                    return "Course assigned successfully";
                }
                else
                {
                    return "Sorry couldn't assign course";
                }  
            }
            else
            {
                return "Course already assigned to a teacher";
            }

        }
        
        public string UnAssignAllCourses()
        {
            string message = courseGateway.UnAssignAllCourses();
            return message;
        }
    }
}