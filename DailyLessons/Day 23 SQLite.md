# Day 23 - SQLite

# SQLITE

SQL is used on MICROSOFT SYSTEMS
SQLITE is one database which can be used on MOBILE SYSTEMS (very small)

Download from [sqlite.org](http://sqlite.org/)

    sqlite3.exe  (best to run in CMD environment)

Download SQLiteStudio graphic environment

## Commands

sqlite3	Environment
sqlite3 MyDatabase.db create database
.quit	Exit Environment
.databases	Show databases
.open MyDatabase.db Use this database
.tables	Show tables

create table Table01(
id int primary key,
name varchar(10)
); // fussy with semi-colon

data types

    int
    varchar
    text
    real   (floating point)

insert into Table01 values (1,'bob');
insert into Table01 values (2,'rina');
insert into Table01 values (3,'charlie');
select * from Table01

## AutoIncrement

At the moment the table is manual increment of Id

Autoincrement : declare the id as integer primary key (not 'int')

create table Table02(id integer primary key,name varchar(50));
insert into Table02 (name) values ('bob');
insert into Table02 (name) values ('tina');
insert into Table02 (name) values ('james');
update Table02 set name='new name' where id=2;
delete from Table02 where id=3;

## Create Northwind database from sqlite script

Download .sql script for SQLite to install Northwind

[https://github.com/markjprice/cs7dotnetcore2/blob/master/sql-scripts/Northwind4SQLite.sql](https://github.com/markjprice/cs7dotnetcore2/blob/master/sql-scripts/Northwind4SQLite.sql)

Run script using

CMD>sqlite3 Northwind.db < InstallNorthwindSQLite.sql

Access data using

CMD>sqlite3

> .open Northwind.db
select * from customers;

## Talking to SQLITE database using C# !!!

We can upgrade our code to use SQLite by doing the following

1. Nuget

    install-package microsoft.entityframeworkcore.sqlite -v 2.1.1

2. builder.UseSqlite(@"Data Source=PATH")

    PATH = C:\Engineering45\SQLite\Northwind.db

    builder.UseSqlite(@"Data Source=C:\Engineering45\SQLite\Northwind.db")

Lab : Create Lab_07_Northwind_SQLite using .NET Core Console app

    Create DBContext and Customer.cs class (use Lab05 Customer class)
    
    << Repeat Lab06 but not use Rabbits from RabbitDb, Use Customers from Northwind.db >>
    
    Libraries
    
    		install-package microsoft.entityframeworkcore        -v 2.1.1
    		install-package microsoft.entityframeworkcore.design -v 2.1.1
    		install-package microsoft.entityframeworkcore.sqlite -v 2.1.1