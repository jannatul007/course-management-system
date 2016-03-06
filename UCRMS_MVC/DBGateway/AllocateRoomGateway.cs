using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using UCRMS_MVC.Models;

namespace UCRMS_MVC.DBGateway
{
    public class AllocateRoomGateway
    {
        public string connectionString =
            ConfigurationManager.ConnectionStrings["UCRMS_DBConnection"].ConnectionString;

        public List<Day> GetAllDays()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * From Day";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Day> aDays = new List<Day>();

            while (reader.Read())
            {
                Day day = new Day();

                day.DayId = Convert.ToInt32(reader["DayId"]);
                day.DayName = reader["DayName"].ToString();

                aDays.Add(day);
            }

            reader.Close();
            connection.Close();
            return aDays;
        }
        public List<Course> GetCourseByDepartmentId(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select CourseID,CourseCode,CourseName from Course where DeptId=" + departmentId;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Course> aCourses = new List<Course>();
            while (reader.Read())
            {
                Course aCourse = new Course();

                aCourse.CourseId = Convert.ToInt32(reader["CourseID"]);
                aCourse.CourseCode = reader["CourseCode"].ToString();
                aCourse.CourseName = reader["CourseName"].ToString();
                aCourses.Add(aCourse);
            }

            reader.Close();
            connection.Close();
            return aCourses;
        }
        public List<Room> GetAllRoom()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * From Room";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Room> aRooms = new List<Room>();

            while (reader.Read())
            {
                Room room = new Room();

                room.RoomId = Convert.ToInt32(reader["RoomId"]);
                room.RoomNo = reader["RoomNo"].ToString();

                aRooms.Add(room);
            }

            reader.Close();
            connection.Close();
            return aRooms;
        }
        DateTime getTime(string time) {
            string st = time.Replace(" ", "").Replace(":PM", ":00 PM").Replace(":AM", ":00 AM");
            string dtime = ("1/1/2016 " + st);
            DateTime dt = Convert.ToDateTime(dtime);
            return dt;
        }

        public int Save(AllocationClassRoom allocationClass)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            int rowAffected = -1;
            if (IsAssainged(allocationClass.RoomId, allocationClass.DayId, allocationClass.StartTime,
                allocationClass.EndTime))
            {
                string query =
                    "INSERT INTO AllocationRoom(DeptId,CourseId,RoomId,DayId,StartTime,EndTime,ActiveState) VALUES (" +
                    allocationClass.DeptId + "," + allocationClass.CourseId + "," + allocationClass.RoomId + "," +
                    allocationClass.DayId + ",'" +
                    getTime(allocationClass.StartTime).AddSeconds(-1).ToString("hh:mm:ss tt") + "','" +
                    (getTime(allocationClass.EndTime).AddSeconds(-1)).ToString("hh:mm:ss tt") + "',1)";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                 rowAffected = command.ExecuteNonQuery();
                connection.Close();
            }
            return rowAffected;
        }

        public bool IsAssainged(int roomId, int dayid, string startDate, string endDate)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            AllocationClassRoom allocationClassRoom = new AllocationClassRoom();


            string selectQuery = string.Format("SELECT RoomId,DayId,StartTime, EndTime FROM  AllocationRoom ");
            SqlCommand command = new SqlCommand(selectQuery, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                AllocationClassRoom aAllocation = new AllocationClassRoom()
                {
                   
                   
                    RoomId = Convert.ToInt32(reader["RoomId"]),
                     DayId = Convert.ToInt32(reader["DayId"]),
                     StartTime = Convert.ToString(reader["StartTime"]),
                    EndTime = Convert.ToString(reader["EndTime"]),
                };


                DateTime ab = getTime(aAllocation.StartTime);
                DateTime st = getTime(startDate);
                DateTime ed = getTime(endDate);

                var res = st.ToString("tt");
                var res1 = ab.ToString("tt");

                if (res1 == res && ab.Hour <= st.Hour && st.Hour <= ed.Hour && ab.Minute <= st.Minute &&
                    st.Minute <= ed.Minute && aAllocation.RoomId == roomId && aAllocation.DayId == dayid)
                {
                    reader.Close();
                    connection.Close();
                    return false;
                }

            }
            reader.Close();
            connection.Close();

            return true;
        }

        public List<AllocationClassRoom> GetClassSchedule(int departmentId, int courseId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM AllocationRoom where DeptId=" + departmentId + " and CourseId=" + courseId + " and ActiveState=1";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<AllocationClassRoom> allocationsList=new List<AllocationClassRoom>();
            while (reader.Read())
            {
                AllocationClassRoom allocation=new AllocationClassRoom();

                allocation.RoomId = Convert.ToInt32(reader["RoomId"]);
                allocation.DayId = Convert.ToInt32(reader["DayId"]);
                allocation.StartTime = reader["StartTime"].ToString();
                allocation.EndTime = reader["EndTime"].ToString();

                allocationsList.Add(allocation);
            }
            reader.Close();
            connection.Close();
            return allocationsList;
        }

        public Room GelRoomById(int roomId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * From Room where RoomId="+roomId+"";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            Room room = new Room();

            while (reader.Read())
            {
                 room.RoomId = Convert.ToInt32(reader["RoomId"]);
                room.RoomNo = reader["RoomNo"].ToString();

                }

            reader.Close();
            connection.Close();
            return room;
        }

        public Day GetDayByDayId(int dayId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * From Day where DayId="+dayId+"";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Day day = new Day();
            while (reader.Read())
            {
                day.DayId = Convert.ToInt32(reader["DayId"]);
                day.DayName = reader["DayName"].ToString();
            }

            reader.Close();
            connection.Close();
            return day;
        }

        public string UnAssignAllCourses()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string updateQuery = "UPDATE AllocationRoom SET ActiveState = 0";
            SqlCommand command = new SqlCommand(updateQuery, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowAffected > 0)
            {
                return "UnAllocation Room Successfully";
            }
            else
            {
                return "UnAllocation Room Failed";
            }
        }
    }
}