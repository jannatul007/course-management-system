using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace UCRMS_MVC.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Provide Course Code")]
        [DisplayName("Course Code")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Course Code should be 5 to 10 charcters.")]
        public string CourseCode { get; set; }
        [Required(ErrorMessage = "Provide Course Name")]
        [DisplayName("Course Name")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Provide Course Credit")]
        [DisplayName("Course Credit")]
        [Range(.5,5 ,ErrorMessage = "Course Credit should be .5 to 5 in reange")]
        public decimal CourseCredit { get; set; }
        public string Description { get; set; }
        [DisplayName("Department")]
        public int DeptId { get; set; }
        [DisplayName("Semester")]
        public int SemesterId { get; set; }

    }

    }