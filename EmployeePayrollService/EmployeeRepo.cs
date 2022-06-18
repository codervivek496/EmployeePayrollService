using System;
using System.Collections.Generic;
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
    }
}
