using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace DataAccessLayer
{
    public class EmployeeDAL
    {
        public List<EmployeeDto> GetAllEmployess()
        {
            try
            {
                List<EmployeeDto> empList = new List<EmployeeDto>();
                string connectionString = "Server=LAPTOP-MLJI1OM9;Database=TestDB;Integrated Security=true;";

                SqlConnection conn = null;
                conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetEmployees";
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                EmployeeDto employeeDto;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employeeDto = new EmployeeDto();
                        employeeDto.EmpId = reader.GetInt32(reader.GetOrdinal("EmpId"));
                        employeeDto.EmpFirstName = reader.GetString(reader.GetOrdinal("EmpFirstName"));
                        employeeDto.EmpLastName = reader.GetString(reader.GetOrdinal("EmpLastName"));

                        if (!reader.IsDBNull(reader.GetOrdinal("EmpGender")))
                        {
                            employeeDto.EmpGender = reader.GetInt32(reader.GetOrdinal("EmpGender"));
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("EmpDOB")))
                        {
                            employeeDto.EmpDOB = reader.GetDateTime(reader.GetOrdinal("EmpDOB"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("EmpSalary")))
                        {
                            employeeDto.EmpDOJ = reader.GetDateTime(reader.GetOrdinal("EmpDOJ"));
                        }

                        employeeDto.EmpSalary = reader.GetInt32(reader.GetOrdinal("EmpSalary"));
                        employeeDto.EmpAddress = reader.GetString(reader.GetOrdinal("EmpAddress"));

                        if (!reader.IsDBNull(reader.GetOrdinal("EmpSalary")))
                        {
                            employeeDto.EmpSalary = reader.GetInt32(reader.GetOrdinal("EmpSalary"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("EmpStatus")))
                        {
                            employeeDto.EmpStatus = reader.GetInt32(reader.GetOrdinal("EmpStatus"));
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("EmpDept")))
                        {
                            employeeDto.EmpDept = reader.GetInt32(reader.GetOrdinal("EmpDept"));
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("ManagerId")))
                        {
                            employeeDto.ManagerId = reader.GetInt32(reader.GetOrdinal("ManagerId"));
                        }

                        employeeDto.EmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress"));

                        empList.Add(employeeDto);
                    }

                    conn.Close();
                }
                return empList;
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public EmployeeDto GetEmployesById(int empId)
        {
            EmployeeDto employeeDto = new EmployeeDto();
            try
            {
                string connectionString = "Server=LAPTOP-MLJI1OM9;Database=TestDB;Integrated Security=true;";

                SqlConnection conn = null;
                conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetEmployeeById";
                cmd.Parameters.Add(new SqlParameter("@EmpId", SqlDbType.Int)).Value = empId;

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        employeeDto.EmpId = reader.GetInt32(reader.GetOrdinal("EmpId"));
                        employeeDto.EmpFirstName = reader.GetString(reader.GetOrdinal("EmpFirstName"));
                        employeeDto.EmpLastName = reader.GetString(reader.GetOrdinal("EmpLastName"));

                        if (!reader.IsDBNull(reader.GetOrdinal("EmpGender")))
                        {
                            employeeDto.EmpGender = reader.GetInt32(reader.GetOrdinal("EmpGender"));
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("EmpDOB")))
                        {
                            employeeDto.EmpDOB = reader.GetDateTime(reader.GetOrdinal("EmpDOB"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("EmpSalary")))
                        {
                            employeeDto.EmpDOJ = reader.GetDateTime(reader.GetOrdinal("EmpDOJ"));
                        }

                        employeeDto.EmpSalary = reader.GetInt32(reader.GetOrdinal("EmpSalary"));
                        employeeDto.EmpAddress = reader.GetString(reader.GetOrdinal("EmpAddress"));

                        if (!reader.IsDBNull(reader.GetOrdinal("EmpSalary")))
                        {
                            employeeDto.EmpSalary = reader.GetInt32(reader.GetOrdinal("EmpSalary"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("EmpStatus")))
                        {
                            employeeDto.EmpStatus = reader.GetInt32(reader.GetOrdinal("EmpStatus"));
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("EmpDept")))
                        {
                            employeeDto.EmpDept = reader.GetInt32(reader.GetOrdinal("EmpDept"));
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("ManagerId")))
                        {
                            employeeDto.ManagerId = reader.GetInt32(reader.GetOrdinal("ManagerId"));
                        }

                        employeeDto.EmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress"));
                    }
                    conn.Close();
                }
                return employeeDto;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
