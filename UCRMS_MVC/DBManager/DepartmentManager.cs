using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using UCRMS_MVC.DBGateway;
using UCRMS_MVC.Models;

namespace UCRMS_MVC.DBManager
{
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway=new DepartmentGateway();
        public string Create(Department department)
        {
            if (departmentGateway.IsCodeIsUniqe(department))
            {
                if (departmentGateway.ISNameIsUniqe(department))
                {
                    string message = departmentGateway.Create(department);
                    return message;
                }
                else
                {
                    return "Department Name is already Exist.";
                }
            }
            else
            {
                return "Department Code is already Exist.";

            }

        }

        public List<Department> GetAllDepartment()
        {
            List<Department> departments = departmentGateway.ViewAllDepartments();
            return departments;

        }
    }
}