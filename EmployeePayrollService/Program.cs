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
            Console.WriteLine("6. Add details int multiple tables");
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
                case 6:
                    AddingDataInMultipleTable();
                    employeeRepo.GetEmployees();
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
            employeeModel.PhoneNumber = 9512367409;
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

        public static void AddingDataInMultipleTable()
        {
            //initializing employeemodel
            EmployeeModel employeeModel = new EmployeeModel();
            //adding values to variables
            employeeModel.EmployeeId = 1;
            employeeModel.EmployeeName = "John";
            employeeModel.Gender = 'M';
            employeeModel.PhoneNumber = 9876543210;
            employeeModel.StartDate = Convert.ToDateTime("2018-06-15");
            employeeModel.BasicPay = 500000;
            employeeModel.Deductions = 50000;
            employeeModel.TaxablePay = 450000;
            employeeModel.Tax = 50000;
            employeeModel.NetPay = 400000;
            employeeModel.Address = "Mumbai";
            employeeModel.companyId = 125;
            employeeModel.salaryid = 25;
            employeeModel.companyName = "Google";
            employeeModel.departmentid = 6;
            employeeModel.Department = "IT";
            employeeModel.headOfDepartment = "Gunther";
            employeeModel.noOfEmployees = 34;
            //instatiating employee repository
            EmployeeRepo employeeRepo = new EmployeeRepo();
            //passing employee model into method of employee repository class
            bool result = employeeRepo.InsertingDataIntoMultipleTables(employeeModel);
            //printing message on the basis of bool result using ternary condition
            Console.WriteLine(result == true ? "Data inserted in database" : "Data is not inserted in database");
        }
    }
}