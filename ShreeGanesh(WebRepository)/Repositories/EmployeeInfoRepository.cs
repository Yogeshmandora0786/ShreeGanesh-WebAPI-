using Microsoft.Extensions.Configuration;
using OperationDomian.Entities;
using System.Data;
using System.Data.SqlClient;

namespace OperationRepository.Repositories
{
    public class EmployeeInfoRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IConfiguration configuration;
        public EmployeeInfoRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public EmployeeInfoRepository()
        {

        }

        string connectionString = "Data Source=YOGESH;Initial Catalog=ShreeGanesh;User ID=sa;Password=sql2014;Integrated Security=True;";

        // To View All Employee Details..............
        public IEnumerable<EmployeeInfo> GetEntity()
        {
            try
            {
                List<EmployeeInfo> employees = new List<EmployeeInfo>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("EmployeeInfo_SelectSearch", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EmployeeInfo employeeInfo = new EmployeeInfo();

                        employeeInfo.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                        employeeInfo.EmployeeName = rdr["EmployeeName"].ToString();
                        employeeInfo.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                        employeeInfo.EmailId = rdr["EmailId"].ToString();
                        employeeInfo.Department = rdr["Department"].ToString();
                        employeeInfo.City = rdr["City"].ToString();

                        employees.Add(employeeInfo);
                    }
                    con.Close();
                }
                return employees;
            }
            catch
            {
                throw;
            }
        }

        // To Add New Employee Details............
        public int AddEntity(EmployeeInfo employeeInfo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("EmployeeInfo_Insert", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    cmd.Parameters.AddWithValue("@EmployeeName", employeeInfo.EmployeeName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", employeeInfo.DateOfBirth);
                    cmd.Parameters.AddWithValue("@EmailId", employeeInfo.EmailId);
                    cmd.Parameters.AddWithValue("@Department", employeeInfo.Department);
                    cmd.Parameters.AddWithValue("@City", employeeInfo.City);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        // To Update the Records of a Employee Details............
        public int UpdateEntity(EmployeeInfo employeeInfo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("EmployeeInfo_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeInfo.EmployeeId);
                    cmd.Parameters.AddWithValue("@EmployeeName", employeeInfo.EmployeeName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", employeeInfo.DateOfBirth);
                    cmd.Parameters.AddWithValue("@EmailId", employeeInfo.EmailId);
                    cmd.Parameters.AddWithValue("@Department", employeeInfo.Department);
                    cmd.Parameters.AddWithValue("@City", employeeInfo.City);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        // To Delete the Record on a Employee Details............
        public int DeleteEntity(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("EmployeeInfo_Delete", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeId", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}

