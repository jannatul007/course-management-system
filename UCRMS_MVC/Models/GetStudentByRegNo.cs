using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCRMS_MVC.Models
{
    public class GetStudentByRegNo
    {
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string DeptCode { get; set; }
        public int DeptId { get; set; }
        public string RegistationNo { get; set; }
      }
}