create database assignment2

use assignment2

--Creating department Table
create table Department
(
DeptNo int primary key,
DName varchar(20),
Location varchar(20)
)

--Creating Employee table
create table Employee
(
EmpNo int primary key,
EmpName varchar(30),
Job varchar(20),
MGR_ID int,
Hire_date date,
Salary int,
Commision int,
DeptNo int references Department(DeptNo)
)

--Inserting data into Department table
insert into Department values(10,'Accounting','New York'),
(20,'Research','Dallas'),
(30,'Sales','Chicago'),
(40,'Operations','Boston')

select * from Department

--Inserting data into Employee table
insert into Employee values(7369,'Smith','Clerk',7902,'17-Dec-80',800,null,20)
insert into Employee values(7499,'Allen','Salesman',7698,'20-Feb-81',1600,300,30),
(7521,'Ward','Salesman',7698,'22-Feb-81',1250,500,30),
(7566,'Jones','Manager',7839,'02-Apr-81',2975,null,20),
(7654,'Martin','Salesman',7698,'28-Sep-81',1250,1400,30),
(7698,'Blake','Manager',7839,'01-May-81',2850,null,30),
(7782,'Clark','Manager',7839,'09-Jun-81',2450,null,10),
(7788,'Scott','Analyst',7566,'19-Apr-87',3000,null,20),
(7839,'King','President',null,'17-Nov-81',5000,null,10),
(7844,'Turner','Salesman',7698,'08-SEP-81', 1500,0,30),
(7876 ,'Adams','Clerk',7788,'23-MAY-87',1100,null,20),
(7900,'James','Clerk',7698,'03-DEC-81',950,null,30),
(7902,'Ford','Analyst',7566,'03-DEC-81',3000,null,20),
(7934 ,'Miller','Clerk',7782,'23-JAN-82',1300,null,10)

select * from Employee

--1. List all employees whose name begins with 'A'.
select * from Employee where EmpName like 'A%'

--2. Select all those employees who don't have a manager.
select * from Employee where MGR_ID is null

--3. List employee name, number and salary for those employees who earn in the range 1200 to 1400.
select EmpNo,EmpName,Salary from Employee where Salary between 1200 and 1400

--4. Give all the employees in the RESEARCH department a 10% pay rise. Verify that this has been done by listing all their details before and after the rise.
select D.DeptNo,E.EmpNo,E.EmpName,E.Job,E.Salary,E.MGR_ID,E.Hire_Date,E.Commision,(Salary+(Salary*0.1)) 'PayRise'
from Department D inner join Employee E on D.DeptNo=E.DeptNo where D.DName='Research'

--5. Find the number of CLERKS employed. Give it a descriptive heading.
select Count(*) as 'Number of Clerks' from Employee where Job='Clerk'

--6. Find the average salary for each job type and the number of people employed in each job.
select Job,avg(Salary) [Average Salary],count(*) [No.of People] from Employee group by Job

--7.List the employees with the lowest and highest salary.
select EmpNo,EmpName,Salary from Employee where Salary=(select min(Salary) as 'Lowest salary' from Employee)
or Salary=(select max(Salary) as 'Highest salary' from Employee)

--8. List full details of departments that don't have any employees.
select * from Department  where DeptNo not in(select DeptNo from Employee)

--9. Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort the answer by ascending order of name.
select EmpName,salary from Employee where Job='Analyst' and Salary>1200 and DeptNo=20 order by EmpName asc

--10. For each department, list its name and number together with the total salary paid to employees in that department.
select D.DeptNo,D.DName,sum(E.Salary) 'Total salary paid to employees'
from Department D left join Employee E on D.DeptNo=E.DeptNo group by D.DeptNo,DName

--11.Find out salary of both MILLER and SMITH.
select EmpName,Salary from Employee where EmpName='Miller' or EmpName='Smith'

--12. Find out the names of the employees whose name begin with ‘A’ or ‘M’.
select EmpName from Employee where EmpName like 'A%' or EmpName like 'M%'

--13.Compute yearly salary of SMITH.
select EmpName,(Salary*12) as 'Annual Salary' from Employee where EmpName='Smith'

--14.List the name and salary for all employees whose salary is not in the range of 1500 and 2850.
select EmpName,Salary from Employee where Salary not between 1500 and 2850

--15. Find all managers who have more than 2 employees reporting to them
select MGR_ID,count(*) from Employee group by MGR_ID having count(*)>2
 
