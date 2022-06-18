using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class EmployeeRepo
    {
        //Declaring connection string for connecting with the database
        public static string connectionString = "data source = .; database = payroll_service; integrated security = true";

        //SqlConnection represents a connection to the SQL server database
        SqlConnection connection = new SqlConnection(connectionString);

        public void GetEmployees()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();

                using (connection)
                {
                    //SQL query to retrieve all data from the table employee_payroll
                    string query = @"select * from employee_payroll";

                    //Executing the query
                    SqlCommand cmd = new SqlCommand(query, connection);

                    //Opens the database connection with property settings specified
                    connection.Open();

                    //SqlDataReader for reading the stream of rows from an SQL server database
                    //ExecuteReader sends cmd text to connection and builds an SQL SqlDataReader
                    SqlDataReader reader = cmd.ExecuteReader();

                    //Checking if reader contains one or more rows
                    if (reader.HasRows)
                    {
                        //Reading next record
                        while (reader.Read())
                        {
                            employeeModel.EmployeeId = reader.GetInt32(0);
                            employeeModel.EmployeeName = reader.GetString(1);
                            employeeModel.PhoneNumber = reader.GetString(2);
                            employeeModel.Address = reader.GetString(3);
                            employeeModel.Department = reader.GetString(4);
                            employeeModel.Gender = Convert.ToChar(reader.GetString(5));
                            employeeModel.BasicPay = reader.GetDouble(6);
                            employeeModel.Deductions = reader.GetDouble(7);
                            employeeModel.TaxablePay = reader.GetDouble(8);
                            employeeModel.Tax = reader.GetDouble(9);
                            employeeModel.NetPay = reader.GetDouble(10);
                            employeeModel.StartDate = reader.GetDateTime(11);
                            employeeModel.City = reader.GetString(12);
                            employeeModel.Country = reader.GetString(13);

                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", employeeModel.EmployeeId, employeeModel.EmployeeName, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Gender, employeeModel.BasicPay, employeeModel.StartDate, employeeModel.City);
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No records");
                    }

                    //Closing the database reader object
                    reader.Close();

                    //Closes the connection to the database
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                //Closes the connection to the database
                connection.Close();
            }
        }

        public bool AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                using (connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("SPAddEmployeeDetails", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", employeeModel.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Address", employeeModel.Address);
                    sqlCommand.Parameters.AddWithValue("@Department", employeeModel.Department);
                    sqlCommand.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    sqlCommand.Parameters.AddWithValue("@BasicPay", employeeModel.BasicPay);
                    sqlCommand.Parameters.AddWithValue("@Deductions", employeeModel.Deductions);
                    sqlCommand.Parameters.AddWithValue("@TaxablePay", employeeModel.TaxablePay);
                    sqlCommand.Parameters.AddWithValue("@Tax", employeeModel.Tax);
                    sqlCommand.Parameters.AddWithValue("@NetPay", employeeModel.NetPay);
                    sqlCommand.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    sqlCommand.Parameters.AddWithValue("@City", employeeModel.City);
                    sqlCommand.Parameters.AddWithValue("@Country", employeeModel.Country);

                    //Opens the database connection with property settings specified
                    connection.Open();

                    var result = sqlCommand.ExecuteNonQuery();

                    //Closes the connection to the database
                    connection.Close();

                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                //Closes the connection to the database
                connection.Close();
            }
        }

        public bool UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                using (connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("SPUpdateEmployeeDetails", connection);

                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@EmployeeId", employeeModel.EmployeeId);
                    sqlCommand.Parameters.AddWithValue("@BasicPay", employeeModel.BasicPay);

                    connection.Open();

                    var result = sqlCommand.ExecuteNonQuery();

                    connection.Close();

                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                //Closes the connection to the database
                connection.Close();
            }
        }

        public void GetEmployeesInDateRange()
        {
            using (connection)
            {
                string query = @"select * from employee_payroll where StartDate between cast('2019-04-12' as date) and getdate()";

                SqlCommand sqlCommand = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    //Reading next record
                    while (sqlDataReader.Read())
                    {
                        EmployeeModel employeeModel = new EmployeeModel();

                        employeeModel.EmployeeId = sqlDataReader.GetInt32(0);
                        employeeModel.EmployeeName = sqlDataReader.GetString(1);
                        employeeModel.PhoneNumber = sqlDataReader.GetString(2);
                        employeeModel.Address = sqlDataReader.GetString(3);
                        employeeModel.Department = sqlDataReader.GetString(4);
                        employeeModel.Gender = Convert.ToChar(sqlDataReader.GetString(5));
                        employeeModel.BasicPay = sqlDataReader.GetDouble(6);
                        employeeModel.Deductions = sqlDataReader.GetDouble(7);
                        employeeModel.TaxablePay = sqlDataReader.GetDouble(8);
                        employeeModel.Tax = sqlDataReader.GetDouble(9);
                        employeeModel.NetPay = sqlDataReader.GetDouble(10);
                        employeeModel.StartDate = sqlDataReader.GetDateTime(11);
                        employeeModel.City = sqlDataReader.GetString(12);
                        employeeModel.Country = sqlDataReader.GetString(13);

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", employeeModel.EmployeeId, employeeModel.EmployeeName, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Gender, employeeModel.BasicPay, employeeModel.StartDate, employeeModel.City);
                        Console.WriteLine();
                    }

                    //Closing the database reader object
                    sqlDataReader.Close();

                    //Closes the connection to the database
                    connection.Close();
                }
                else
                {
                    Console.WriteLine("No records");
                }
            }
        }

        public void AggregateAndGrouping()
        {
            string query = @"select gender, sum(BasicPay) TotalSalary, max(BasicPay) MaxSalary, min(BasicPay) MinSalary, avg(BasicPay) AvgSalary, count(BasicPay) CountGender from employee_payroll group by Gender";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                //Reading next record
                while (sqlDataReader.Read())
                {
                    EmployeeModel employeeModel = new EmployeeModel();

                    employeeModel.Gender = Convert.ToChar(sqlDataReader.GetString(0));
                    employeeModel.TotalSalary = sqlDataReader.GetDouble(1);
                    employeeModel.MaxSalary = sqlDataReader.GetDouble(2);
                    employeeModel.MinSalary = sqlDataReader.GetDouble(3);
                    employeeModel.AvgSalary = sqlDataReader.GetDouble(4);
                    employeeModel.CountGender = sqlDataReader.GetInt32(5);

                    Console.WriteLine("{0} {1} {2} {3} {4} {5}", employeeModel.Gender, employeeModel.TotalSalary, employeeModel.MaxSalary, employeeModel.MinSalary, employeeModel.AvgSalary, employeeModel.CountGender);
                    Console.WriteLine();
                }

                //Closing the database reader object
                sqlDataReader.Close();

                //Closes the connection to the database
                connection.Close();
            }
            else
            {
                Console.WriteLine("No records");
            }
        }
    }
}
