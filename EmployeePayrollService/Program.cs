namespace EmployeePayrollService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t\tWelcome to Employee Payroll Program\n\n");
            EmployeeRepo employeeRepo = new EmployeeRepo();

            Console.WriteLine("1. Get details from database");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    employeeRepo.GetEmployees();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Please enter correct choice");
                    break;
            }
        }
    }
}