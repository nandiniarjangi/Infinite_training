use assignment2

--1. Retrieve a list of MANAGERS.
select distinct e2.EmpName as 'Managers List' from Employee e1 join Employee e2 on e1.MGR_ID=e2.EmpNo
 
--2. Find out the names and salaries of all employees earning more than 1000 per month.
select EmpName,Salary from Employee where Salary>1000
 
--3. Display the names and salaries of all employees except JAMES.
select EmpName,Salary from Employee where EmpName<>'James'
 
--4. Find out the details of employees whose names begin with ‘S’.
select * from Employee where EmpName like 'S%'
 
--5. Find out the names of all employees that have ‘A’ anywhere in their name.
select EmpName from Employee where Lower(EmpName) like '%A%'
 
--6. Find out the names of all employees that have ‘L’ as their third character in their name.
select EmpName from Employee where EmpName like '__L%'
 
--7. Compute daily salary of JONES.
select (Salary/30) as 'Daily salary' from Employee where EmpName='Jones'
 
--8. Calculate the total monthly salary of all employees.
select sum(Salary) [total monthly salary of all employees] from Employee
 
--9. Print the average annual salary .
select AVG(Salary*12) "average annual salary" from Employee
 
--10. Select the name, job, salary, department number of all employees except SALESMAN from department number 30.
select EmpName,Job,Salary,DeptNo from Employee where EmpNo not in
(select EmpNo from Employee where Job='Salesman' and DeptNo=30)
 
--11. List unique departments of the EMP table.
select DeptNo,DName from Department where DeptNo in(select distinct  DeptNo from Employee)
 
--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
select EmpName as 'Employee' ,Salary as 'Monthly Salary' from Employee where Salary >1500 and DeptNo in(10,30)
 
--13. Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000.
select EmpName,Job,Salary from Employee where Job in('Manager','Analyst') and Salary not in(1000,3000,5000)
 
--14. Display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%.
select EmpName,Salary,Commision from Employee where Commision>Salary * 1.1
 
--15. Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782.
select EmpName from Employee where Lower(EmpName) like '%l%l%' and DeptNo=30 or MGR_ID=7782
 
--16. Display the names of employees with experience of over 30 years and under 40 yrs.Count the total number of employees.
 
select EmpName from Employee where DATEDIFF(year,Hire_date,getdate())>30 and DATEDIFF(year,Hire_date,getdate())<40
 
select count(EmpName) [total number of employees]
from Employee where DATEDIFF(year,Hire_date,getdate())>30 and DATEDIFF(year,Hire_date,getdate())<40
 
--17. Retrieve the names of departments in ascending order and their employees in descending order.
select d.DName,e.EmpName from Department d join Employee e on d.DeptNo=e.DeptNo order by d.DName asc,e.EmpName desc
 
--18. Find out experience of MILLER.
select DATEDIFF(year,Hire_date,getdate()) as 'Experience' from Employee where EmpName='Miller'