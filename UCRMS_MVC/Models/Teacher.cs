using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UCRMS_MVC.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required(ErrorMessage = "Provide Teacher name.")]
        [DisplayName("Teacher Name")]
        public string TeacherName { get; set; }
        public string Address { get; set; }
        [Required]
        [DisplayName("Email Address")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",ErrorMessage = "Provide Correct Format.")]
        public string Email { get; set; }
        public string ContactNo { get; set; }
        [DisplayName("Designation")]
        [Required(ErrorMessage = "please Select Designation")]
        public int DesignationId { get; set; }
        [DisplayName("Department")]
        [Required(ErrorMessage = "please Select Department")]
        public int DeptId { get; set; }
        [Required(ErrorMessage = "Provide Course Credit")]
        [DisplayName("Credit to be taken")]
        //[Range(1,20, ErrorMessage = "Credit to be taken contain non negetive value.")]
        public float CreditToBeTaken { get; set; }
    }
}