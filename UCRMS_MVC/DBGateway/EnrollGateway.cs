using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UCRMS_MVC.Models;

namespace UCRMS_MVC.DBGateway
{
    public class EnrollGateway
    {
        private string connectionString =
           ConfigurationManager.ConnectionStrings["UCRMS_DBConnection"].ConnectionString;
        public List<Student> GetAllStudent()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT StudentId,RegistationNo From Student";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Student> aStudents = new List<Student>();
            while (reader.Read())
            {
                Student student = new Student();
                student.StudentId = Convert.ToInt32(reader["StudentId"]);
                student.RegistationNo = reader["RegistationNo"].ToString();
                //department.StudentEmail = reader["StudentEmail"].ToString();
                //department.DeptId = Convert.ToInt32(reader["DeptId"]);
                aStudents.Add(student);
            }
            reader.Close();
            connection.Close();
            return aStudents;
        }

      
        public List<GetStudentByRegNo> GetStudentDetailByRegNo(string regNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select StudentName,StudentEmail,DeptCode,RegistationNo from GetStudentByRegNo where RegistationNo='" + regNo + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<GetStudentByRegNo> aStudents = new List<GetStudentByRegNo>();
            while (reader.Read())
            {
                GetStudentByRegNo aStudent = new GetStudentByRegNo();

                aStudent.StudentName = reader["StudentName"].ToString();
                aStudent.StudentEmail = reader["StudentEmail"].ToString();
                aStudent.DeptCode = reader["DeptCode"].ToString();
                aStudent.RegistationNo = reader["RegistationNo"].ToString();
                aStudents.Add(aStudent);
            }

            reader.Close();
            connection.Close();
            return aStudents;
        }

        public List<Course> GetAllCoursesByRegNo(string regNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT Student.RegistationNo, Course.DeptId,Course.CourseId, Course.CourseCode FROM Course LEFT OUTER JOIN Student ON Course.DeptId =Student.DeptId where RegistationNo= '"+regNo+"'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Course> aCourses = new List<Course>();
            while (reader.Read())
            {
                Course aCourse = new Course();
                aCourse.CourseId = Convert.ToInt32(reader["CourseId"]);
                aCourse.CourseCode = reader["CourseCode"].ToString();
                //aCourse.DeptId = Convert.ToInt32(reader["DeptId"]);
                aCourses.Add(aCourse);
            }
            reader.Close();
            connection.Close();
            return aCourses;
        }

        public bool IsEnrollCourseIdUnique(Enroll enroll)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * From EnrollCourse  WHERE CourseId=" + enroll.CourseId;

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {

                reader.Close();
                connection.Close();
                return false;
            }
            else
            {
                reader.Close();
                connection.Close();
                return true;
            }
        }

        public string SaveEnrollStudent(Enroll enroll)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Insert INTO EnrollCourse(RegistrationId,StudentName,StudentEmail,DeptCode,CourseId,EnrollDate) values ('" + enroll.RegistrationId + "'," +
                           "'" + enroll.StudentName + "', '" + enroll.StudentEmail + "','" + enroll.DeptCode + "'," + enroll.CourseId + ",'" + enroll.EnrollDate + "')";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int roeEffected = command.ExecuteNonQuery();
            if (roeEffected>0)
            {
                return "Enrolled Student";
            }
            else
            {
                return "Saved Failed";
            }
        }

        public List<EnrollCoursesByRegNo> GetCourseIdByEnroll(string regNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * From EnrollCoursesByRegNo  WHERE RegistationNo='" + regNo + "'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<EnrollCoursesByRegNo> aEnrolls = new List<EnrollCoursesByRegNo>();
            while(reader.Read())
            {
                EnrollCoursesByRegNo enroll = new EnrollCoursesByRegNo();
                enroll.RegistrationId = reader["RegistationNo"].ToString();
                enroll.CourseId = Convert.ToInt32(reader["CourseId"]);
                enroll.CourseCode = reader["CourseCode"].ToString();

                aEnrolls.Add(enroll);
            }
            reader.Close();
            connection.Close();
            return aEnrolls;
        }

        public List<Grade> GetAllGradeLetter()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * From Grade";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Grade> aGrades = new List<Grade>();
            while (reader.Read())
            {
                Grade grade = new Grade();
                grade.GradeId = Convert.ToInt32(reader["GradeId"]);
                grade.GradeLetter = reader["GradeLetter"].ToString();
                aGrades.Add(grade);
            }
            reader.Close();
            connection.Close();
            return aGrades;
        }

        public List<ViewResultByRegNo> GetResultDetailByRegNo(string regNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * From ViewResultByRegNo  WHERE RegistationNo='" + regNo + "'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ViewResultByRegNo> viewResults = new List<ViewResultByRegNo>();
           while (reader.Read())
            {
                ViewResultByRegNo result = new ViewResultByRegNo();
                result.RegistationNo = reader["RegistationNo"].ToString();
                result.StudentName = reader["StudentName"].ToString();
                result.StudentEmail = reader["StudentEmail"].ToString();
                result.DeptCode = reader["DeptCode"].ToString();
                result.CourseCode = reader["CourseCode"].ToString();
                result.CourseName = reader["CourseName"].ToString();
                result.GradeLetter = reader["GradeLetter"].ToString();

                viewResults.Add(result);
            }
            reader.Close();
            connection.Close();
            return viewResults;
        }

        //public List<ViewResultByRegNo> GetAllEnrollStudent()
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string query = "SELECT * From ViewResultByRegNo";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    List<ViewResultByRegNo> viewResults = new List<ViewResultByRegNo>();
        //    if (reader.Read())
        //    {
        //        ViewResultByRegNo result = new ViewResultByRegNo();

        //        result.RegistrationId = reader["RegistrationId"].ToString();
        //        result.StudentName = reader["StudentName"].ToString();
        //        result.StudentEmail = reader["StudentEmail"].ToString();
        //        result.DeptCode = reader["DeptCode"].ToString();
        //        result.CourseName = reader["CourseName"].ToString();
        //        result.GradeLetter = reader["GradeLetter"].ToString();
         
        //        viewResults.Add(result);
        //    }
        //    reader.Close();
        //    connection.Close();
        //    return viewResults;
        //}
    }
}