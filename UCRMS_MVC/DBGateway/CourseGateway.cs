using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UCRMS_MVC.Models;

namespace UCRMS_MVC.DBGateway
{
    public class CourseGateway
    {
        private string connectionString =
           ConfigurationManager.ConnectionStrings["UCRMS_DBConnection"].ConnectionString;
        public List<Semester> GetAllSemester()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * From Semester";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Semester> aSemesters = new List<Semester>();

            while (reader.Read())
            {
                Semester semester = new Semester();

                semester.SemesterId = Convert.ToInt32(reader["SemesterId"]);
                semester.SemesterName = reader["SemesterName"].ToString();

                aSemesters.Add(semester);
            }

            reader.Close();
            connection.Close();
            return aSemesters;
        }

        public List<Department> GetAllDepartment()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * From Department";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Department> aDepartment = new List<Department>();

            while (reader.Read())
            {
                Department department = new Department();

                department.DeptId = Convert.ToInt32(reader["DeptId"]);
                department.DeptCode = reader["DeptCode"].ToString();

                aDepartment.Add(department);
            }

            reader.Close();
            connection.Close();
            return aDepartment;
        }

        public bool IsCodeIsUniqe(Course course)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT *From Course  WHERE CourseCode='" + course.CourseCode + "' ";

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

        public bool ISNameIsUniqe(Course course)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT *From Course  WHERE CourseName='" + course.CourseName + "' ";

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

        public string SaveCourse(Course course)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Course(CourseCode,CourseName,CourseCredit,Description,DeptId,SemesterId) VALUES ('" + course.CourseCode + "','" + course.CourseName + "','"+course.CourseCredit+"'" +
                           ",'"+course.Description+"',"+course.DeptId+","+course.SemesterId+" )";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowEffected = command.ExecuteNonQuery();
            if (rowEffected > 0)
            {
                return "Information Saved";
            }
            else
            {
                return "Saved Failed";
            }
        }

        public List<Course> GetCourseByDepartmentId(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Course where DeptId=" + departmentId + "";
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
                aCourse.CourseCredit = Convert.ToDecimal(reader["CourseCredit"]);
                aCourse.Description = reader["Description"].ToString();
                aCourse.DeptId = Convert.ToInt32(reader["DeptId"]);
                aCourse.SemesterId = Convert.ToInt32(reader["SemesterId"]);

                aCourses.Add(aCourse);
            }

            reader.Close();
            connection.Close();
            return aCourses;
        }

        public List<Course> GetCourseDetails(int courseId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select *from Course where CourseID=" + courseId + "";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Course> aCourses = new List<Course>();
            while (reader.Read())
            {
                Course aCourse = new Course();

                //aCourse.CourseId = Convert.ToInt32(reader["CourseID"]);
                //aCourse.CourseCode = reader["CourseCode"].ToString();
                aCourse.CourseName = reader["CourseName"].ToString();
                aCourse.CourseCredit = Convert.ToDecimal(reader["CourseCredit"]);
                //aCourse.Description = reader["Description"].ToString();
                //aCourse.DeptId = Convert.ToInt32(reader["DeptId"]);
                //aCourse.SemesterId = Convert.ToInt32(reader["SemesterId"]);

                aCourses.Add(aCourse);
            }

            reader.Close();
            connection.Close();
            return aCourses;
        }

        public List<ViewCourseStatic> ViewAllCourseStatic(int deptId)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "Select * from ViewCourseStatic where DeptId=" + deptId;
						
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ViewCourseStatic> aViewCourseStatics = new List<ViewCourseStatic>();
            while (reader.Read())
            {
                ViewCourseStatic aCourseStatic = new ViewCourseStatic();

                aCourseStatic.CourseCode = reader["CourseCode"].ToString();
                aCourseStatic.CourseName = reader["CourseName"].ToString();
                aCourseStatic.SemesterName = reader["SemesterName"].ToString();
                aCourseStatic.AssignedTo = reader["AssignedTo"].ToString();
                
                aViewCourseStatics.Add(aCourseStatic);
            }

            reader.Close();
            connection.Close();
            return aViewCourseStatics;
        }

        public CreditToBeTakenRemaining GetTeacherDeyId(int teacherId)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "(select Teacher.TeacherId as TeacherId,Teacher.CreditToBeTaken,Teacher.CreditToBeTaken - ISNULL(sum(T1.CourseCredit),0) as RemainingCredit from Course AS T1 Right Join Teacher on T1.AssignedTeacherId=Teacher.TeacherId Where Teacher.TeacherId=" + teacherId + " group by T1.AssignedTeacherId,Teacher.CreditToBeTaken,Teacher.TeacherId)";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            CreditToBeTakenRemaining creditToBeTakenRemaining = new CreditToBeTakenRemaining();
            while (reader.Read())
            {

                creditToBeTakenRemaining.Id = Convert.ToInt32(reader["TeacherId"]);
                creditToBeTakenRemaining.CreditToBeTaken = Convert.ToDouble(reader["CreditToBeTaken"]);
                creditToBeTakenRemaining.CreditRemaining = Convert.ToDouble(reader["RemainingCredit"]);
            }
            reader.Close();
            return creditToBeTakenRemaining;
        }

        public bool IsAssaigned(CourseAssignToTeacher courseAssignToTeacher)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT ISNULL(AssignedTeacherId,0) as AssignedTeacherId FROM Course WHERE CourseId=" + courseAssignToTeacher.CourseCode + "";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            //Course course = new Course();

            if (reader.Read())/////////////////////////////////////// problem hote pare
            {
                if (Convert.ToInt32(reader["AssignedTeacherId"]) > 0)
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
            else
            {
                reader.Close();
                connection.Close();
                return false;
            }
        }

        public int CourseAssignToTeacher(CourseAssignToTeacher courseAssignToTeacher)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "UPDATE Course SET AssignedTeacherId=" + courseAssignToTeacher.Teacher + " WHERE CourseId=" + courseAssignToTeacher.CourseCode + "";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;
        }

        public List<Course> GetAllCourse()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select *from Course";
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
                aCourse.CourseCredit = Convert.ToDecimal(reader["CourseCredit"]);
                aCourse.Description = reader["Description"].ToString();
                aCourse.DeptId = Convert.ToInt32(reader["DeptId"]);
                aCourse.SemesterId = Convert.ToInt32(reader["SemesterId"]);

                aCourses.Add(aCourse);
            }

            reader.Close();
            connection.Close();
            return aCourses;
        }

        public string UnAssignAllCourses()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string updateQuery = "UPDATE Course SET AssignedTeacherId = 0";
            SqlCommand command = new SqlCommand(updateQuery, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowAffected > 0)
            {
                return "UnAssign Crouse Successfully";
            }
            else
            {
                return "UnAssign Course Failed";
            }
        }
    }
}