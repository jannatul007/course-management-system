using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCRMS_MVC.Models
{
    public class EnrollCoursesByRegNo
    {
        public string RegistrationId { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }

    }
}