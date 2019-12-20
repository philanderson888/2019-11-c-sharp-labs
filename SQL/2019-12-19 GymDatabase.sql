use master
go

drop database if exists GymDatabase 
go

create database GymDatabase
go

use GymDatabase
go 

drop table if exists Users 
drop table if exists Exercises
drop table if exists Categories

go

create table Categories(
	CategoryId INT NOT NULL PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) NULL
)

create table Users(
	UserId INT NOT NULL PRIMARY KEY IDENTITY,
	UserName VARCHAR(50) NULL
)

CREATE TABLE Exercises(
	ExerciseId INT NOT NULL IDENTITY PRIMARY KEY,
	ExerciseName VARCHAR(50) NULL,
	CategoryId INT NULL,
	FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
)

INSERT INTO Categories VALUES ('Cardio')
INSERT INTO Categories VALUES ('Weights')
INSERT INTO Categories VALUES ('Bodyweight')

INSERT INTO Exercises VALUES ('Running',1)
INSERT INTO Exercises VALUES ('Skipping',1)
INSERT INTO Exercises VALUES ('Squat',2)
INSERT INTO Exercises VALUES ('PushUp',3)

INSERT INTO Users VALUES ('Bob')
INSERT INTO Users VALUES ('Bill')
INSERT INTO Users VALUES ('Ben')
INSERT INTO Users VALUES ('Tara')

SELECT * FROM Users
SELECT * FROM Categories
SELECT * FROM Exercises
