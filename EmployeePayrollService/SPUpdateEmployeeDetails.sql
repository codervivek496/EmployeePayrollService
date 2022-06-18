create procedure SPUpdateEmployeeDetails
(
	@EmployeeId int,
	@BasicPay float
)
as
begin
	update employee_payroll set BasicPay = @BasicPay where EmployeeId = @EmployeeId;
end