namespace EmployeePayrollService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t\tWelcome to Employee Payroll Program\n\n");
            EmployeeRepo employeeRepo = new EmployeeRepo();

            Console.WriteLine("1. Get details from database");
            Console.WriteLine("2. Add details to database");
            Console.WriteLine("3. Update details to database");
            Console.WriteLine("4. Get details between specific date range from database");
            Console.WriteLine("5. Get details in aggregate manner from database");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    employeeRepo.GetEmployees();
                    break;
                case 2:
                    AddDataToDataBase();
                    employeeRepo.GetEmployees();
                    break;
                case 3:
                    Update();
                    employeeRepo.GetEmployees();
                    break;
                case 4:
                    employeeRepo.GetEmployeesInDateRange();
                    break;
                case 5:
                    employeeRepo.AggregateAndGrouping();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Please enter correct choice");
                    break;
            }
        }

        //For adding the data into the database
        public static void AddDataToDataBase()
        {
            EmployeeModel employeeModel = new EmployeeModel();

            employeeModel.EmployeeName = "John";
            employeeModel.Gender = Convert.ToChar("M");
            employeeModel.PhoneNumber = "9512367409";
            employeeModel.Department = "Marketing";
            employeeModel.Address = "Andheri";
            employeeModel.BasicPay = 50000;
            employeeModel.Deductions = 500;
            employeeModel.TaxablePay = 1000;
            employeeModel.Tax = 5000;
            employeeModel.NetPay = 45000;
            employeeModel.StartDate = Convert.ToDateTime("2021-06-14");
            employeeModel.City = "Mumbai";
            employeeModel.Country = "India";

            EmployeeRepo employeeRepo = new EmployeeRepo();

            bool result = employeeRepo.AddEmployee(employeeModel);

            if (result == true)
            {
                Console.WriteLine("Data is inserted into database");
            }
            else
            {
                Console.WriteLine("Data is not inserted into database");
            }
        }

        //For updating the data in the database
        public static void Update()
        {
            EmployeeModel employeeModel = new EmployeeModel();

            employeeModel.EmployeeId = 9;
            employeeModel.BasicPay = 3000000;

            EmployeeRepo employeeRepo = new EmployeeRepo();

            bool result = employeeRepo.UpdateEmployee(employeeModel);

            Console.WriteLine(result == true ? "Data is updated into database" : "Data is not updated into database");
        }
    }
}