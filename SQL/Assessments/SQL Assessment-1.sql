create database assessments

use assessments

--creating books table
create table Books(
Book_id int primary key,
Title varchar(30),
Author varchar(30),
Isbn_no bigint unique,
Published_date dateTime,
)

--inserting data into books table
insert into Books values(1,'MY First SQL book','Mary Parker',981483029127,'2012-02-22 12:08:17')
insert into Books values(2,'MY Second SQL book','Jhon Mayer',857300923713,'1972-07-03 09:22:45')
insert into Books values(3,'My Third SQL book','Cary Flint',523120967812,'2015-10-18 14:05:44')

select * from Books

--Write a query to fetch the details of the books written by author whose name ends with er.
select* from Books where Author like '%er'

--creating reviews table

create table Reviews(
Id int primary key,
Book_id int references Books(Book_id),
Reviewer_name varchar(30),
Content varchar(30),
Rating int,
Published_date dateTime,
)

--inserting into reviews table

insert into Reviews values(1,1,'Jhon Smith','MY First review',4,'2017-12-10 05:50:11'),
(2,2,'Jhon Smith','MY Second review',5,'2017-10-13 15:05:12'),
(3,2,'Alice Walker','Another Review',1,'2017-10-22 23:47:10')

select * from Reviews

--Display the Title ,Author and ReviewerName for all the books from the above table
select b.Title ,b.Author,r.Reviewer_name from Books b join Reviews r on b.Book_id=r.Book_id

--Display the  reviewer name who reviewed more than one book.
select Reviewer_name from Reviews group by Reviewer_name having count(Book_id)>1

--creating Customer table

create table Customer(
Id int primary key,
Customer_name varchar(20),
Age int,
Address varchar(20),
Salary float,
)
--inserting data into customers table

insert into Customer values(1,'Ramesh',32,'Ahmedabad',2000.00)
insert into Customer values(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP',4500.00),
(7,'Muffy',24,'Indore',10000.00)

select * from Customer

--Display the Name for the customer from above customer table  who live in same address which has character o anywhere in address

select Customer_name,Address from Customer where Address like '%o%'

--creating table 
create table Orders(
OId int primary key,
Date DateTime,
Customer_Id int references Customer(Id),
Amount int,
)

--inserting data into Orders table
insert into Orders values(102,'2009-10-08 00:00:00',3,3000)
insert into Orders values(100,'2009-10-08 00:00:00',3,1500),
(101,'2009-11-20 00:00:00',2,1560),
(103,'2008-05-20 00:00:00',4,2060)

select *from Orders

--Write a query to display the   Date,Total no of customer  placed order on same Date

select Date,Count(Customer_Id) [Total no of customer] from Orders group by Date

--creating Customer table 2

create table Customer2(
Id int primary key,
Customer_name varchar(20),
Age int,
Address varchar(20),
Salary float,
)
--inserting data into customers table 2
insert into Customer2 values(1,'Ramesh',32,'Ahmedabad',2000.00)
insert into Customer2 values(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP',null),
(7,'Muffy',24,'Indore',null)

select * from Customer2

--Display the Names of the Employee in lower case, whose salary is null

select Lower(Customer_name) from Customer2 where Salary is null


--creating Students table

create table Students(
RegNo int primary key,
Sname varchar(20),
Age int,
Qualification varchar(10),
MobileNo bigint,
Mail varchar(30),
Location varchar(20),
Gender varchar(10),
)

--inserting data into customers table 2
insert into Students values(2,'Sai',22,'B.E',9952836777,'Sai@gmail.com','Chennai','M'),
(3,'Kumar',20,'BSC',7890125648,'Kumar@gmail.com','Madurai','M'),
(4,'Selvi',22,'B.Tech',8904567342,'selvi@gmail.com','Selam','F'),
(5,'Nisha',25,'M.E',7835672310,'Nisha@gmail.com','Theni','F'),
(6,'SaiSaran',21,'B.A',7890345678,'saran@gmail.com','Madurai','F'),
(7,'Tom',23,'BCA',8901234675,'To@gmail.com','Pune','M')

select * from Students

--Write a sql server query to display the Gender,Total no of male and female from the above relation
select Gender,count(*) as 'Total no of male and female' from Students group by Gender




 

 



 