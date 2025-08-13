create database MiniProject

use MiniProject

create table admins (
    adminid int primary key identity(1,1),
    username varchar(50) unique not null,
    password varchar(50) not null -- in production, use hashed passwords
);

-- step 2: customer table
create table customers (
    custid int primary key identity(1,1),
    custname varchar(50),
    phone varchar(15),
    mailid varchar(50),
    isactive bit default 1
);
 

-- step 3: trains table
create table trains (
    train_no int primary key,
    train_name varchar(50),
    source varchar(50),
    destination varchar(50),
    isactive bit default 1
);

-- step 4: class-wise info
create table trainclass (
    train_no int,
    class varchar(20),
    availability int,
    cost decimal(10,2),
    primary key (train_no, class),
    foreign key (train_no) references trains(train_no)
);

-- step 5: booking table
create table bookings (
    bookingid int primary key identity(1,1),
    train_no int,
    customerid int,
    class varchar(20),
    nooftickets int,
    totalcost decimal(10,2),
    bookingdate datetime default getdate(),
    traveldate date,
    iscancelled bit default 0,
    cancellationdate datetime null,
    refundamount decimal(10,2) null,
    foreign key (train_no) references trains(train_no),
    foreign key (customerid) references customers(custid)
);


CREATE TABLE Passengers (
    PassengerId INT PRIMARY KEY IDENTITY(1,1),
    BookingId INT,
    Name VARCHAR(50),
    Gender VARCHAR(10),
    Age INT,
    FOREIGN KEY (BookingId) REFERENCES Bookings(BookingId)
);


-- step 6: book ticket procedure
create or alter procedure booktickets
    @tno int, @cid int, @tclass varchar(20), @seats int, @traveldate date, @status varchar(100) output
as
begin
    declare @available int, @cost decimal(10,2), @total decimal(10,2);
    select @available = availability, @cost = cost
    from trainclass where train_no = @tno and class = @tclass;

    if @available >= @seats
    begin
        set @total = @seats * @cost;
        insert into bookings (train_no, customerid, class, nooftickets, totalcost, traveldate)
        values (@tno, @cid, @tclass, @seats, @total, @traveldate);

        update trainclass
        set availability = availability - @seats
        where train_no = @tno and class = @tclass;

        set @status = 'booking confirmed! total cost: ' + cast(@total as varchar);
    end
    else
    begin
        set @status = 'seats not available or invalid class.';
    end
end
-- step 7: cancel booking procedure
create or alter procedure cancelbooking @bid int
as
begin
    declare @tno int, @seats int, @class varchar(20), @total decimal(10,2);
    select @tno = train_no, @seats = nooftickets, @class = class, @total = totalcost
    from bookings where bookingid = @bid and iscancelled = 0;

    if @tno is not null
    begin
        update bookings
        set iscancelled = 1,
            cancellationdate = getdate(),
            refundamount = @total * 0.5
        where bookingid = @bid;

        update trainclass
        set availability = availability + @seats
        where train_no = @tno and class = @class;
    end
end

-- step 8: show all trains
create or alter procedure showtrains
as
begin
    select t.train_no, t.train_name, t.source, t.destination,
           tc.class, tc.availability, tc.cost
    from trains t
    join trainclass tc on t.train_no = tc.train_no
    where t.isactive = 1;
end

-- step 9: selecttrain
create or alter procedure selecttrain @tsource varchar(50), @tdestination varchar(50)
as
begin
    select t.train_no, t.train_name, tc.class, tc.availability, tc.cost
    from trains t
    join trainclass tc on t.train_no = tc.train_no
    where t.source = @tsource and t.destination = @tdestination and t.isactive = 1;
end

CREATE PROCEDURE GetTicketReport
    @bookingId INT
AS
BEGIN
    SELECT b.BookingId, b.Train_No, t.Train_Name, b.Class, b.NoOfTickets, b.TotalCost,
           b.BookingDate, b.TravelDate, b.IsCancelled, b.RefundAmount,
           p.Name AS PassengerName, p.Gender, p.Age
    FROM Bookings b
    JOIN Trains t ON b.Train_No = t.Train_No
    JOIN Passengers p ON b.BookingId = p.BookingId
    WHERE b.BookingId = @bookingId;
END



CREATE PROCEDURE UpdateCustomerProfile
    @custid INT,
    @name VARCHAR(50),
    @phone VARCHAR(15),
    @password VARCHAR(50)
AS
BEGIN
    UPDATE Customers
    SET CustName = @name,
        Phone = @phone,
        Password = @password
    WHERE CustId = @custid;
END


CREATE PROCEDURE SearchTrainsByDate
    @source VARCHAR(50),
    @destination VARCHAR(50),
    @travelDate DATE
AS
BEGIN
    SELECT t.train_no, t.train_name, tc.class, tc.availability, tc.cost
    FROM trains t
    JOIN trainclass tc ON t.train_no = tc.train_no
    WHERE t.source = @source AND t.destination = @destination AND t.isactive = 1;
    -- You can enhance this by checking availability for the given date if needed
END


CREATE PROCEDURE GetBookingHistory
    @custid INT
AS
BEGIN
    SELECT * FROM Bookings
    WHERE CustomerId = @custid
    ORDER BY BookingDate DESC;
END


CREATE PROCEDURE GetTrainDetails
    @train_no INT
AS
BEGIN
    SELECT t.train_no, t.train_name, t.source, t.destination, tc.class, tc.availability, tc.cost
    FROM trains t
    JOIN trainclass tc ON t.train_no = tc.train_no
    WHERE t.train_no = @train_no;
END


CREATE PROCEDURE GetUpcomingTravel
    @custid INT
AS
BEGIN
    SELECT * FROM Bookings
    WHERE CustomerId = @custid AND TravelDate >= CAST(GETDATE() AS DATE) AND IsCancelled = 0;
END





-- step 10: insert sample data
insert into trains values (100, 'superfast express', 'hyderabad', 'chennai', 1);
insert into trainclass values (100, 'sleeper', 100, 150);
insert into trainclass values (100, '2ac', 50, 500);
insert into trainclass values (100, '3ac', 75, 350);

ALTER TABLE customers ADD password VARCHAR(50);

INSERT INTO customers (custname, phone, mailid, password)
VALUES ('Nandini', '9876543210', 'nandini@gmail.com', 'pass123');
INSERT INTO customers (custname, phone, mailid, password)
VALUES ('Nithya', '9999999999', 'nithya@gmail.com', 'pass1234');
INSERT INTO customers (custname, phone, mailid, password)
VALUES ('nisha', '8888888888', 'nisha@gmail.com', 'pass12345');

INSERT INTO customers (custname, phone, mailid, password)
VALUES ('nandu', '7777777777', 'nandu@gmail.com', 'nand123');


INSERT INTO admins (username, password) VALUES ('admin', 'admin123')

select*from Customers


