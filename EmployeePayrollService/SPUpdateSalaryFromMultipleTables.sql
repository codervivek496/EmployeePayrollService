create procedure SPUpdateSalaryFromMultipleTables
(
@salary float,
@id int,
@name varchar(50)
)
as
begin
	update payroll
	set payroll.basepay=@salary
	from payroll 
	join employee
	on employee.salaryid= payroll.salary_id
	where employee.id= @id and employee.name= @name
end