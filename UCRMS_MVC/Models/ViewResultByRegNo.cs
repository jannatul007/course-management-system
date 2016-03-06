using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCRMS_MVC.Models
{
    public class ViewResultByRegNo
    {
        public string RegistationNo { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail  { get; set; }
        public string DeptCode { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string GradeLetter { get; set; }
    }
}