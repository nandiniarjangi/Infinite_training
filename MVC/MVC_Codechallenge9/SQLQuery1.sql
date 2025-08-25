-- Create the database
CREATE DATABASE MoviesDB;

-- Use the database
USE MoviesDB;

-- Create the Movies table
CREATE TABLE Movies (
    Mid INT PRIMARY KEY IDENTITY(1,1), -- Auto-incrementing Movie ID
    Moviename NVARCHAR(100) NOT NULL,
    DirectorName NVARCHAR(100) NOT NULL,
    DateofRelease DATE NOT NULL
);
