using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public char Gender { get; set; }
        public double BasicPay { get; set; }
        public double Deductions { get; set; }
        public double TaxablePay { get; set; }
        public double Tax { get; set; }
        public double NetPay { get; set; }
        public DateTime StartDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int companyId { get; set; }
        public int salaryid { get; set; }
        public string companyName { get; set; }
        public int departmentid { get; set; }
        public string headOfDepartment { get; set; }
        public int noOfEmployees { get; set; }

        public double TotalSalary { get; set; }
        public double AvgSalary { get; set; }
        public double MaxSalary { get; set; }
        public double MinSalary { get; set; }
        public int CountGender { get; set; }
    }
}
