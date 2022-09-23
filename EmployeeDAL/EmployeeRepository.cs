using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace EmployeeDAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        SqlConnection connection = null;
        SqlCommand cmd;
        public EmployeeRepository()
        {
            connection = new SqlConnection();
            connection.ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=cgiwave5DB;Integrated Security=True;";
            cmd = new SqlCommand();
        }
        public string AddNewEmployee(Employee employee)
        {
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"insert into Employee values ('{employee.Name}','{employee.Gender}','{employee.Location}',{employee.Salary})";
            connection.Open();
            int rowcount=cmd.ExecuteNonQuery();
            connection.Close();
            if(rowcount > 0)
            {
                return employee.Name +"details added in the database";
            }
            else
            {
                return "Sorry!. Something went wrong";
            }
        
          
        }

        public string Deleteemployee(int id)
        {
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"delete from Employee where  EmployeeId={id}";
            connection.Open();
            int rowcount = cmd.ExecuteNonQuery();
            connection.Close();
            if (rowcount > 0)
            {
                return  "details Deleted in the database";
            }
            else
            {
                return "Sorry!. Something went wrong";
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            
            cmd.Connection=connection;
            cmd.CommandType=System.Data.CommandType.Text;
            cmd.CommandText = "Select * from Employee";
            connection.Open();
           SqlDataReader reader= cmd.ExecuteReader();
            while(reader.Read())
            {
                Employee employee = new Employee() { 
                    EmployeeId=(int)reader["EmployeeId"],
                    Name=reader[1].ToString(),
                    Gender=reader[2].ToString(),
                    Location=reader[3].ToString(),
                    Salary=(decimal)reader[4]
                };
                employees.Add(employee);
            }
            reader.Close();
            connection.Close();
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
          Employee employee = new Employee();

            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"Select * from Employee where EmployeeId={id}";
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee employee1 = new Employee()
                {

                    EmployeeId = (int)reader["EmployeeId"],
                    Name = reader[1].ToString(),
                    Gender = reader[2].ToString(),
                    Location = reader[3].ToString(),
                    Salary = (decimal)reader[4]
                };
                employee = employee1;
            }
               
                reader.Close();
                connection.Close();
                return employee;
            
        }

        public string Updateemployee(Employee employee)
        {
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"update Employee set Name= '{employee.Name}',Gender='{employee.Gender}',Location='{employee.Location}'," +
                $"Salary={employee.Salary} where EmployeeId={employee.EmployeeId}";
            connection.Open();
            int rowcount = cmd.ExecuteNonQuery();
            connection.Close();
            if (rowcount > 0)
            {
                return employee.Name + "details Update in the database";
            }
            else
            {
                return "Sorry!. Something went wrong";
            }
        }
    }
}
