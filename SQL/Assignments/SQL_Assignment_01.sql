create database sqlAssignment_1
--creating Clients Table
create table Clients
(
Client_ID int primary key,
Cname varchar(40) not null,
Address varchar(30),
Email varchar(30) unique,
Phone bigint,
Business varchar(20),
)

--Inserting data in clients table
insert into Clients values(1001,'ACME Utilities','Noida','contact@acmeutil.com',9567880032,'Manfacturing')
insert into Clients values(1002,'Trackon Consultants','Mumbai','contact@trackon.com',8734210090,'Consultant'),
(1003,'MoneySaver Distributers','Kolkata','save@moneysaver.com',7799886655,'Reseller'),
(1004,'Lawful Corp','Chennai','justice@lawful.com',9210342219,'Professional')

--Displaying data in clients table
select * from Clients;

--Creating Depatments table
create table Departments
(
Deptno int primary key,
Dname varchar(15) not null,
Loc varchar(20),
)

--Inserting data in departments table
insert into Departments values(10,'Design','Pune'),
(20,'Development','Pune'),
(30,'Testing','Mumbai'),
(40,'Document','Mumbai')

--Displaying data in departments table
select * from Departments

--creating Employees table
create table Employees
(
Empno  int primary key,
Ename varchar(20) not null,
Job varchar(15),
Salary bigint,
Deptno int references Departments(Deptno),
)

--adding check constraint
alter table Employees
add constraint checksal check(salary >0)

sp_help 'Employees'

--Inserting data in Employees table
insert into Employees values(7001,'Sandeep','Analyst',25000,10),
(7002,'Rajesh','Designer',30000,10),
(7003,'Madhav','Developer',40000,20),
(7004,'Manoj','Developer',40000,20),
(7005,'Abhay','Designer',35000,10),
(7006,'Uma','Tester',30000,30),
(7007,'Gita','Tech.Writer',30000,40),
(7008,'Priya','Tester',35000,30),
(7009,'Nutan','Developer',45000,20),
(7010,'Smitha','Analyst',20000,10),
(7011,'Anand','Project Manager',65000,10)

--Displaying data in Employees table
select * from Employees

--creating Projects table
create table Projects
(
Project_ID int primary key,
Descr varchar(30) not null,
Start_Date date,
Planned_End_Date date,
Actual_End_Date date,
Budget bigint,
Client_ID int references Clients(Client_ID),
)

--adding check constraints
alter table Projects
add constraint checkdate check(Actual_End_Date>Planned_End_Date)

alter table Projects
add constraint checkbudget check(budget>0)

--Inserting data into Projects table
insert into Projects values(401,'Inventory','2011-04-01','2011-10-01','2011-10-31',150000,1001)
insert into Projects values(402,'Accounting','2011-08-01','2012-01-01',null,500000,1002),
(403,'Payroll','2011-10-01','2011-12-31',null,75000,1003),
(404,'Contact Management','2011-11-01','2011-12-31',null,50000,1004)

--displaying data from Projects table
select * from Projects

 sp_help 'Projects'

--creating Employee Project Tasks table
create table EmpProjectTasks
(
Project_ID int  references Projects(Project_ID),
Empno int  references Employees(Empno),
Start_Date date,
End_Date date,
Task varchar(25) not null,
Status varchar(15) not null,
constraint composite_key primary key(Project_ID,Empno),
)

 sp_help 'EmpProjectTasks'

--Inserting data into Employee Project Task table
insert into EmpProjectTasks values(401,7001,'2011-04-01','2011-04-20','System Analysis','Completed'),
(401,7002,'2011-04-21','2011-05-30','System Design','Completed')
insert into EmpProjectTasks values(401,7003,'2011-06-01','2011-07-15','Coding','Completed'),
(401,7004,'2011-07-18','2011-09-01','Coding','Completed'),
(401,7006,'2011-09-03','2011-09-15','Testing','Completed'),
(401,7009,'2011-09-18','2011-10-05','Code Change','Completed'),
(401,7008,'2011-10-06','2011-10-16','Testing','Completed'),
(401,7007,'2011-10-06','2011-10-22','Documentation','Completed'),
(401,7011,'2011-10-22','2011-10-31','Sign off','Completed'),
(402,7010,'2011-08-01','2011-08-20','System Analysis','Completed'),
(402,7002,'2011-08-22','2011-09-30','System Design','Completed'),
(402,7004,'2011-10-01',null,'Coding','In Progress')

--Displaying Employee Project Task table
select * from EmpProjectTasks;