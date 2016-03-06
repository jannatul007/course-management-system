using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UCRMS_MVC.Models;

namespace UCRMS_MVC.DBGateway
{
    public class StudentGateway
    {
        private string connectionString =
        ConfigurationManager.ConnectionStrings["UCRMS_DBConnection"].ConnectionString;
        public bool IsEmailIsUnique(Student student)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT *From Student  WHERE StudentEmail='" + student.StudentEmail + "' ";

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

        public string RegisterStudent(Student student)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Student(StudentName,StudentEmail,ContactNo,Date,Address,DeptId,RegistationNo) VALUES ('" + student.StudentName + "','" + student.StudentEmail + "','" + student.ContactNo + "'" +
                           ",'" + student.Date + "','" + student.Address + "'," + student.DeptId + ",'" + student.RegistationNo + "')";

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

        public int CountAllStudent(int deptId, string year)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select Counter from RegNo_Info where DeptId=" + deptId + " and Year="+year+"";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            int flag = 0;
            int counter = 0;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                flag =1;
                counter = Convert.ToInt32(reader["Counter"].ToString());
            }
            reader.Close();
            connection.Close();
            if (flag==1)
            {
                counter += 1;
                string updateQuery = "UPDATE RegNo_Info SET Counter = " + counter + " WHERE DeptId = " + deptId + " AND Year = '" + year + "'";
                command = new SqlCommand(updateQuery, connection);
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                connection.Close();
                if (rowAffected > 0)
                    return counter;   
            }
            else
            {
                string insertQuery = string.Format("INSERT INTO RegNo_Info(DeptId, Year, Counter) VALUES('{0}', '{1}', '{2}')", deptId, year, 1);
                command = new SqlCommand(insertQuery, connection);
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                connection.Close();
                if (rowAffected > 0)
                    return 1;
            }
            connection.Close();
            return 0;
        }

        public string SaveStudentResult(StudentResult studentResult)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Result(RegistrationId,StudentName,StudentEmail,DeptCode,CourseId,GradeId) VALUES ('" + studentResult.RegistrationId + "','" + studentResult.StudentName + "','" + studentResult.StudentEmail + "'" +
                           ",'" + studentResult.DeptCode + "'," + studentResult.CourseId + "," + studentResult.GradeId + ")";

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
    }
}