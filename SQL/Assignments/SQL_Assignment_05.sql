use assignment2

--1. Write a T-Sql based procedure to generate complete payslip of a given employee
 
create or alter proc PaySlip(@EmpId int)
as
begin
declare @Ename varchar(20),@Sal int
declare @HRA float
declare @DA float
declare @PF float
declare @IT float
declare @Deduction float
declare @Gross_Salary float
declare @Net_Salary float
 
select @Ename=EmpName,@Sal=Salary from Employee where EmpNo=@EmpId
 
set @HRA=@sal*0.10
set @DA=@sal*0.20
set @PF=@sal*0.08
set @IT=@sal*0.05
set @Deduction=@PF+@IT
set @Gross_Salary=@sal+@HRA+@DA
set @Net_Salary=@Gross_Salary-@Deduction
 
print 'Payslip for Employee : ' +@Ename
print 'Basic Salary : '+cast(@Sal as varchar(10))
print 'HRA : ' +cast(@HRA as varchar(10))
print 'DA : ' +cast(@DA as varchar(10))
print 'PF : ' +cast(@PF as varchar(10))
print 'IT : ' +cast(@IT as varchar(10))
print 'Deduction : ' +cast(@Deduction as varchar(10))
print 'Gross salary : ' +cast(@Gross_Salary as varchar(10))
print 'Net salary : ' +cast(@Net_Salary as varchar(10))
end
 
exec PaySlip 7788
 
select * from Employee
 
--2.  Create a trigger to restrict data manipulation on EMP table during General holidays.
 
create table Holidays
(
holiday_date date,
Holiday_name varchar(20)
)
 
insert into Holidays values('2024-01-26','Republic day'),
('2024-08-15','Independence Day'),('2024-09-05','Teachers day'),('2024-11-14','Childerens day')
insert into Holidays values('2024-12-06','Today is  Holiday')
 
 
select * from Holidays
--trigger
create or alter trigger Restrict_Employee_Data
on Employee
for insert,update,delete
as
begin
  declare @holiday_name varchar(20)
  select @holiday_name=Holiday_name from Holidays where holiday_date=cast(Getdate() as date)
  if @holiday_name is not null
  begin
      raiserror('you cannot manipulate data due to %s',16,1,@holiday_name)
  rollback
   end
end
select * from Employee

--Testing triggers
insert into Employee values(9998,'Nandini','developer',7788,'2025-07-24',5000,800,20)
 
delete from Employee where EmpNo=7788
 
update Employee set Salary=3000 where EmpNo=7788