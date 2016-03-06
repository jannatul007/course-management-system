using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UCRMS_MVC.Models;

namespace UCRMS_MVC.DBGateway
{
    public class TeacherGateway
    {
        public string connectionString =
            WebConfigurationManager.ConnectionStrings["UCRMS_DBConnection"].ConnectionString;
        public List<Department> GetAllDepartment()
        {
            SqlConnection connection=new SqlConnection(connectionString);
            string query = "Select * from Department";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Department> departments = new List<Department>();
            while (reader.Read())
            {
                Department department = new Department();
                department.DeptId = Convert.ToInt32(reader["DeptId"]);
                department.DeptCode = reader["DeptCode"].ToString();
                //department.DeptName = reader["DeptName"].ToString();
                departments.Add(department);
            }
            reader.Close();
            connection.Close();
            return departments;
        }

        public List<Designation> GetAllDesignation()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Designation";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Designation> designations = new List<Designation>();
            while (reader.Read())
            {
                Designation designation = new Designation();
                designation.DesignationId = Convert.ToInt32(reader["DesignationId"]);
                designation.DesignationName = reader["DesignationName"].ToString();
                designations.Add(designation);
            }
            reader.Close();
            connection.Close();
            return designations;
        }

        public bool IsEmailEnique(Teacher teacher)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT *From Teacher  WHERE Email='" + teacher.Email + "' ";

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

        public string SaveTeacher(Teacher teacher)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Teacher(TeacherName,Address,Email,ContactNo,DesignationId,DeptId,CreditToBeTaken) VALUES ('" + teacher.TeacherName + "','" + teacher.Address + "'" +
                           ",'"+teacher.Email+"','"+teacher.ContactNo+"',"+teacher.DesignationId+","+teacher.DeptId+","+teacher.CreditToBeTaken+")";
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

        public List<Teacher> GetAllTeacher()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Teacher";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Teacher> aTeachers = new List<Teacher>();
            while (reader.Read())
            {
                Teacher teacher = new Teacher();
                teacher.TeacherId = Convert.ToInt32(reader["TeacherId"]);
                teacher.TeacherName = reader["TeacherName"].ToString();
                //department.DeptName = reader["DeptName"].ToString();
                aTeachers.Add(teacher);
            }
            reader.Close();
            connection.Close();
            return aTeachers;
        }

        public List<Teacher> GetTeacherByDeptId(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Teacher where DeptId="+departmentId+"";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Teacher> aTeachers = new List<Teacher>();
            while (reader.Read())
            {
                Teacher aTeacher=new Teacher();

                aTeacher.TeacherId = Convert.ToInt32(reader["TeacherId"]);
                aTeacher.TeacherName = reader["TeacherName"].ToString();
                aTeacher.Address = reader["Address"].ToString();
                aTeacher.Email = reader["Email"].ToString();
                aTeacher.ContactNo = reader["ContactNo"].ToString();
                aTeacher.DesignationId = Convert.ToInt32(reader["DesignationId"]);
                aTeacher.DeptId = Convert.ToInt32(reader["DeptId"]);
                aTeacher.CreditToBeTaken = Convert.ToInt32(reader["CreditToBeTaken"]);

                aTeachers.Add(aTeacher);
            }

            reader.Close();
            connection.Close();
            return aTeachers;
        }
    }
}