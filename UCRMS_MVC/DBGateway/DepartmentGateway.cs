using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UCRMS_MVC.Models;

namespace UCRMS_MVC.DBGateway
{
    public class DepartmentGateway
    {
        private string connectionString =
           ConfigurationManager.ConnectionStrings["UCRMS_DBConnection"].ConnectionString;

        public bool ISNameIsUniqe(Department department)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT *From Department  WHERE DeptName='" + department.DeptName + "' ";

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

        public string Create(Department department)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Department(DeptName,DeptCode) VALUES ('" + department.DeptName + "','" + department.DeptCode + "' )";

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

        public bool IsCodeIsUniqe(Department department)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT *From Department  WHERE DeptCode='" + department.DeptCode + "' ";

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

        public List<Department> ViewAllDepartments()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT *From Department";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Department> departments=new List<Department>();
           while(reader.Read())
            {
                Department department=new Department();
                department.DeptId = Convert.ToInt32(reader["DeptId"]);
                department.DeptCode = reader["DeptCode"].ToString();
                department.DeptName = reader["DeptName"].ToString();
                departments.Add(department);
            }
            reader.Close();
            connection.Close();
            return departments;
        }

        public string GetDepartmentCode(int DeptId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT DeptCode From Department  WHERE DeptId='" + DeptId + "' ";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            string DeptCode="";
            if(reader.Read())
            {
             DeptCode = reader["DeptCode"].ToString();
            reader.Close();
            connection.Close();
            }
            return DeptCode;
                 
        }
    }
}