using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UCRMS_MVC.Models
{
    public class AllocationClassRoom
    {
        public int ACRoomId { get; set; }
        [DisplayName("Department")]
        [Required(ErrorMessage = "Please select from option.")]
        public int DeptId { get; set; }
        [DisplayName("Course Code")]
        [Required(ErrorMessage = "Please select from option.")]
        public int CourseId { get; set; }
        [DisplayName("Room No.")]
        [Required(ErrorMessage = "Please select from option.")]
        public int RoomId { get; set; }
        [DisplayName("Day")]
        [Required(ErrorMessage = "Please select from option.")]
        public int DayId { get; set; }
        [DisplayName("From")]
        [Required(ErrorMessage = "Please select Time.")]
        public string StartTime { get; set; }

        [DisplayName("To")]
        [Required(ErrorMessage = "Please select Time.")]
        public string EndTime { get; set; }
      
    }
}