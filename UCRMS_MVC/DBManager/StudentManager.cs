using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS_MVC.DBGateway;
using UCRMS_MVC.Models;

namespace UCRMS_MVC.DBManager
{
    public class StudentManager
    {
        StudentGateway aStudentGateway=new StudentGateway();
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();
        public string RegisterStudent(Student student)
        {
            if (aStudentGateway.IsEmailIsUnique(student))
            {
               
                student.RegistationNo =GetRegNoStudent(student);
                string message = aStudentGateway.RegisterStudent(student);
                return message;
            }
            else
            {
                return "Email Address is already Exist.";
            }
        }

        private string GetRegNoStudent(Student student)
        {
            string deptCode = aDepartmentGateway.GetDepartmentCode(student.DeptId);
            //string Year = student.Date.Year.ToeString();
            DateTime date = Convert.ToDateTime(student.Date);
            string year = date.Year.ToString();
            int Count = aStudentGateway.CountAllStudent(Convert.ToInt32(student.DeptId),Convert.ToString(year));
            string RegNo = deptCode + "-" + year + "-" + Count.ToString("D3");
            return RegNo;
        }
    }
}