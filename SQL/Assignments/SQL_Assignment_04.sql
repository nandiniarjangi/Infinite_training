--1. Write a T-SQL Program to find the factorial of a given number.
 
begin
declare @number int=5
declare @c int=1
declare @fact int =1
while @c<=@number
begin
   set @fact=@fact*@c
   set @c=@c+1
end
print 'The factotial of the number ' + cast(@number as varchar(10)) +' is '+cast(@fact as varchar(10))
end
 
--2.Create a stored procedure to generate multiplication table that accepts a number
--and generates up to a given number.
 
create or alter proc Multiplication (@number int,@range int)
as
begin
declare @inc int=1
declare @result int
  while @inc<=@range
  begin
     set @result=@number*@inc
     print cast(@number as varchar(5)) +' * ' +cast(@inc as varchar(5))+ ' = '+cast(@result as varchar(5))
set @inc=@inc+1
  end
end
 
exec Multiplication 5,10
 
--3. Create a function to calculate the status of the student.
--If student score >=50 then pass, else fail. Display the data neatly

use assignment2
 
--Creating students table
create table student
(
sid int primary key,
sname varchar(10),
)
--Creating Marks table
create table Marks
(
mid int primary key,
sid int references student(sid),
score int,
)
 
--inserting data into student table
insert into student values(1,'Jack'),
(2,'Rithvik'),(3,'Jaspreeth'),(4,'Praveen'),(5,'Bisa'),(6,'Suraj')
 
select * from student
 
--inserting data into Marks table
insert into Marks values(1,1,23),
(2,6,95),(3,4,98),(4,2,17),(5,3,53),(6,5,13)
 
select * from Marks
 
--function
create or alter function Student_Score (@sscore int)
returns varchar(10)
as
begin
declare @result varchar(10)
  if @sscore>=50
  begin
    set @result='Pass'
  end
  else
  begin
    set @result='Fail'
  end
return @result
end
 
select s.sid,m.mid,s.sname,m.score,dbo.Student_Score(m.score) as 'Student_Status' from student s
inner join Marks m on s.sid=m.sid order by s.sid