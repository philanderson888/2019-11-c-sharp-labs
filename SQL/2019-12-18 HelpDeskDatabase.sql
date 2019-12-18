USE master
Go

DROP DATABASE IF EXISTS HelpdeskDatabase
GO

CREATE DATABASE HelpdeskDatabase
GO

USE HelpdeskDatabase 
GO

DROP TABLE IF EXISTS Users 
DROP TABLE IF EXISTS Categories 
GO


CREATE TABLE Categories(
	CategoryId INT NOT NULL IDENTITY PRIMARY KEY,
	CategoryName VARCHAR(50) NULL
)

CREATE TABLE Users(
	UserId INT NOT NULL IDENTITY PRIMARY KEY,
	UserName VARCHAR(50) NULL,
	CategoryId INT NULL, 
	FOREIGN KEY (CategoryId) REFERENCES Categories (CategoryId)
)

INSERT INTO Categories VALUES ('Admin')
INSERT INTO Categories VALUES ('TechSupport')
INSERT INTO Categories VALUES ('User')
INSERT INTO Users VALUES ('Bob',1)
INSERT INTO Users VALUES ('Bill',3)
INSERT INTO Users VALUES ('Ben',2)
SELECT * FROM Categories
SELECT * FROM Users
