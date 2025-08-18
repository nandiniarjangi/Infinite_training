-- Create DB
IF DB_ID('ElectricityBillDB') IS NULL
    CREATE DATABASE ElectricityBillDB;
GO
USE ElectricityBillDB;
GO
 

IF OBJECT_ID('dbo.ElectricityBill','U') IS NULL
BEGIN
    CREATE TABLE dbo.ElectricityBill (
        consumer_number   VARCHAR(20)  NOT NULL,
        consumer_name     VARCHAR(50)  NOT NULL,
        units_consumed    INT          NOT NULL,
        bill_amount       FLOAT        NOT NULL,
       
        bill_id           INT IDENTITY(1,1) PRIMARY KEY,
        created_at        DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME()
    );
END
GO
 
IF OBJECT_ID('dbo.AdminUsers','U') IS NULL
BEGIN
    CREATE TABLE dbo.AdminUsers(
        AdminId   INT IDENTITY(1,1) PRIMARY KEY,
        Username  VARCHAR(50) NOT NULL UNIQUE,
       
        Password  VARCHAR(200) NOT NULL
    );
    INSERT INTO dbo.AdminUsers(Username, Password)
    VALUES ('admin', 'admin@123');
END
GO

SELECT * FROM dbo.AdminUsers;
SELECT * FROM dbo.ElectricityBill;

SELECT name FROM sys.databases WHERE name='ElectricityBillDB';
