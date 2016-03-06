using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UCRMS_MVC.DBGateway;
using UCRMS_MVC.Models;

namespace UCRMS_MVC.DBManager
{

    public class AllocateRoomManager
    {
        AllocateRoomGateway allocateRoom=new AllocateRoomGateway();
        public List<Room> GetAllRoom()
        {
            List<Room> aRooms = allocateRoom.GetAllRoom();
            return aRooms;
        }

        public List<Day> GetAllDays()
        {
            List<Day> aDays = allocateRoom.GetAllDays();
            return aDays;
        }

        public bool Allocate(AllocationClassRoom allocationClass)
        {
            return allocateRoom.Save(allocationClass)>0;
               
        }

        public string GetClassSchedule(int departmentId, int courseId)
        {
            List<AllocationClassRoom> allocationClassRooms = allocateRoom.GetClassSchedule(departmentId, courseId);
             string output= "";

            foreach (var allocation in allocationClassRooms)
            {
                var roomNo = allocateRoom.GelRoomById(Convert.ToInt32(allocation.RoomId));
                var dayName = allocateRoom.GetDayByDayId(allocation.DayId);
                if (dayName!=null)
                {
                    output += "Room No: " + roomNo.RoomNo + ", " + dayName.DayName + ", " + allocation.StartTime + " - " +
                              allocation.EndTime + "<br />";
                }
              }
              return output;
        }


        public List<Course> GetCourseByDepartmentId(int departmentId)
        {
            List<Course> aCourses = allocateRoom.GetCourseByDepartmentId(departmentId);
            return aCourses;
        }

        public String UnAllocationAllRoom()
        {
            string message = allocateRoom.UnAssignAllCourses();
            return message;
        }
    }
}