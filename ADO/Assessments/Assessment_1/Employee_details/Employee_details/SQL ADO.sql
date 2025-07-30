use assessments

create table employee_details (
    empid int identity(1,1) primary key,
    name nvarchar(100),
    salary decimal(10,2),
    gender char(1)
);

drop table employee_details

--1. Write a stored Procedure that inserts records in the Employee_Details table
create procedure insert_employee_details
    @name nvarchar(100),@givensalary decimal(10,2),@gender char(1), @generatedempid int output
as
begin
  set nocount on;

 declare @salary decimal(10,2) = @givensalary * 0.90;
 declare @netsalary decimal(10,2) = @salary * 0.90;
insert into employee_details (name, salary, gender)
 values (@name, @netsalary, @gender);
set @generatedempid = scope_identity();
end;


drop procedure insert_employee_details;


declare @newempid int;

exec insert_employee_details 
    @name = 'nandini arjangi',
    @givensalary = 50000,
    @gender = 'f',
    @generatedempid = @newempid output;

select @newempid as new_employee_id;

-- Write a procedure that takes empid as input and outputs the updated salary as current salary + 100 for the give employee.
 
create procedure update_employee_salary
 @empid int, @updatedsalary decimal(10,2) output
as begin set nocount on;

update employee_details
set salary = salary + 100
where empid = @empid;

select @updatedsalary = salary
from employee_details
where empid = @empid;
end;

drop procedure update_employee_salary

declare @newsalary decimal(10,2);

exec update_employee_salary 
@empid = 2,@updatedsalary = @newsalary output;

select @newsalary as updated_salary;


select empid, name, salary from employee_details where empid = 2;


select * from employee_details order by empid;



