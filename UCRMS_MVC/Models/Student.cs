using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UCRMS_MVC.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(200, ErrorMessage = "Please enter maximum 200 characters")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Please enter Email")]
        [StringLength(100, ErrorMessage = "Please enter maximum 100 characters")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid email adress")]
        public string StudentEmail { get; set; }
        [DisplayName("Contact Number")]
        [Required(ErrorMessage = "Please enter Contact Number")]
        [StringLength(20, ErrorMessage = "Please enter maximum 20 characters")]
        public string ContactNo { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Address { get; set; }

        [DisplayName("Department")]
        [Required(ErrorMessage = "Please Select Department")]
        public int DeptId { get; set; }
        public string RegistationNo { get; set; }
    }
}