create procedure SPAddEmployeeDetails
(
	@EmployeeName varchar(150),
	@PhoneNumber varchar(15),
	@Address varchar(150),
	@Department varchar(50),
	@Gender char,
	@BasicPay float,
	@Deductions float,
	@TaxablePay float,
	@Tax float,
	@NetPay float,
	@StartDate date,
	@City varchar(50),
	@Country varchar(50)
)
as
begin
	insert into employee_payroll values(@EmployeeName, @PhoneNumber, @Address, @Department, @Gender, 
	@BasicPay, @Deductions, @TaxablePay, @Tax, @NetPay, @StartDate, @City, @Country);
end