using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UCRMS_MVC.Models
{
    public class Enroll
    {
        public int EnroolId { get; set; }
        public string RegistrationId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string DeptCode { get; set; }
        public int CourseId { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime EnrollDate { get; set; }
    }
}