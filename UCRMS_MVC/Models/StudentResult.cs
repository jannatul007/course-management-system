using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCRMS_MVC.Models
{
    public class StudentResult
    {
        public int ResultId { get; set; }
        public string RegistrationId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string DeptCode { get; set; }
        public int CourseId { get; set; }
        public int GradeId { get; set; }
        //public string GradeLetter { get; set; }

    }
}