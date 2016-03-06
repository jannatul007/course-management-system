using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UCRMS_MVC.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }

        [Required(ErrorMessage = "Please Enter Department Name")]
        [DisplayName("Department Name")]
        public string DeptName { get; set; }
        [Required(ErrorMessage = "Please Enter Department Code")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Department Code should be 2 to 7 charcters.")]
        public string DeptCode { get; set; }
    }
}