use assignment2
--1. Write a query to display your birthday( day of week)
 
select DATENAME(weekday,'2002-11-10') as Birthday     
 
--2. Write a query to display your age in days
select DATEDIFF(DAY,'2002-11-10',getdate()) as AGE

--3. Write a query to display all employees information those who joined before 5 years in the current month

select * from Employee where Hire_date <=DATEADD(year,-5,getdate()) and month(Hire_date)=month(getdate())

update Employee set hire_date='1983-07-22' where empno=7521

--4.transaction
begin tran
create table Employee2
(
Empno  int primary key,
Ename varchar(20) ,
Salary bigint,
doj date,
)
select * from Employee2
insert into Employee2 values(1,'Nandini',30000,'2024-10-16'),
(2,'Sirisha',28000,'2024-09-10'),
(3,'Deepika',35000,'2023-11-22')


update Employee2 set Salary=Salary+Salary*0.15 where Empno=2

save tran t1

delete from Employee2 where Empno=1

rollback tran t1
 

 --user defined function
 
create Function Calculated_Bonus                
(
  @deptno int,
  @sal decimal(18,2)
  )
  returns decimal(18,2)
  as
  begin
  declare @Bonus float;
  if  @deptno=10
     set  @bonus=@sal*0.15;
  else if @deptno=20
     set @bonus=@sal*0.20;
  else
       set @bonus=@sal*0.05;
  return @bonus;
  end;
 
select EmpNo, EmpName, dbo.Calculated_Bonus(deptno,Salary) as BONUS from Employee

-- Create a procedure to update the salary of employee by 500
--whose dept name is Sales and current salary is below 1500 (use emp table)
 
 create or alter proc Update_salary
as
begin
  update Employee set Salary=Salary+500 where DeptNo=(select DeptNo from Department where DName='Sales')
  and Salary<1500
  end
 
exec Update_salary
select * from Employee
select * from Department





