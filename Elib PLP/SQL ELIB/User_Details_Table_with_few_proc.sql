create schema ELIB_Management_System
go



--Table-UserDetails


create table  ELIB_Management_System.User_details
(User_ID varchar(15) not null primary key check((datalength(User_ID)>=8 and datalength(User_ID)<=15)),
First_Name varchar(50) not null,
Last_Name varchar(50) ,
Date_Of_Birth date not null check(datediff(year,Date_of_Birth,getdate())>=18),
Address varchar(1000) not null,
Land_Line_Number varchar(15),
Mobile_Number varchar(15) ,
Area_Of_Interests varchar(100) not null,
Gender varchar(1) not null,
User_Type varchar(30) not null check (User_Type in('Subscriber','Non_Subscriber','Administrator')),
Date_Of_Registration date check(Date_Of_Registration= CONVERT(date,getdate())),
Password varchar(50) not null
);

go





--Procedure For Insert in User Details


 Create proc ELIB_Management_System.uspInsert_User_details
 (
 @User_ID varchar(15),
 @First_Name varchar(50),
 @Last_Name varchar(50),
 @Date_Of_Birth date,
 @Address varchar(1000),
 @Land_Line_Number varchar(15),
 @Mobile_Number varchar(15) ,
 @Area_Of_Interests varchar(100),
 @Gender varchar(1),
 @User_Type varchar(30),
 @Date_Of_Registration date,
 @Password varchar(50)
 )
 AS
 BEGIN
 if((datalength(@User_ID)<8 and datalength(@User_ID)>15)) 
		 throw 60000,'User ID Should be between 8 and 15 characters',18;
if((@First_Name is null or @First_Name='')  or  (@Last_Name is null or @Last_Name=''))
		 throw 60001,'Name Should Not be NULL',18;
 if((datediff(year,@Date_of_Birth,getdate())<=18))
		 throw 60002,'Age Should be greater than 18 years',18
if((@Address is null or @Address=''))
		throw 60003,'Address Should not be empty',18;
if((@Area_Of_Interests is null or @Area_Of_Interests=''))
		throw 60004,'Area of interest Should not be empty',18;
if((@Gender is null or @Gender='') or @Gender NOT IN ('M','F'))
		throw 60005,'Gender Should be M or F',18;
if(@User_Type NOT IN('Subscriber','Non_Subscriber','Administrator'))
		throw 60006,'User_Type Should be Subscriber,Non-Subscriber or Administrator',18;

if(@Date_Of_Registration!=CONVERT(date, getdate()))
		throw 60007,'Date Of registration should be current date',18;
if(@Password is null or @Password='')
		throw 60008,'Password Should not be empty',18;



 insert into ELIB_Management_System.User_details values(@User_ID, @First_Name, @Last_Name, @Date_Of_Birth, @Address,@Land_Line_Number, @Mobile_Number ,
 @Area_Of_Interests,@Gender ,@User_Type , @Date_Of_Registration, @Password);

 UPDATE ELIB_Management_System.User_details
SET Mobile_Number = SUBSTRING(@Mobile_Number, 1, 3) + '-' + 
              SUBSTRING(@Mobile_Number, 4, 4) + '-' + 
              SUBSTRING(@Mobile_Number, 7, 4) 

			  END
 go


 --Exec Insert Procedure_User_Details
 begin try
 EXEC ELIB_Management_System.uspInsert_User_details 12345671,'Akhil','Kusuma','05-02-1995','5-B,Vimal House,Poonamalle','044-2449966','09866102438',
'Engineering','M','Subscriber','2017-10-21','akhil@123'
 EXEC ELIB_Management_System.uspInsert_User_details 12345672,'Vijay','Kris','05-03-1995','5-B,Vimal House,Poonamalle','044-2449966','09866102438',
'Engineering','M','Subscriber','2017-10-21','vijay2123'
 EXEC ELIB_Management_System.uspInsert_User_details 12345673,'Prudvi','Raj','05-04-1995','5-B,Vimal House,Poonamalle','044-2449966','09866102438',
'Engineering','M','Subscriber','2017-10-21','Th!$I$mYpAssWoRd'
 EXEC ELIB_Management_System.uspInsert_User_details 12345674,'Abishek','Agarwal','05-05-1995','5-B,Vimal House,Poonamalle','044-2449966','09866102438',
'Engineering','M','Subscriber','2017-10-21','abi@123'
 EXEC ELIB_Management_System.uspInsert_User_details 12345675,'Shruti','Diman','05-06-1995','5-B,Vimal House,Poonamalle','044-2449966','09866102438',
'Engineering','F','Subscriber','2017-10-21','sakthiman'
 EXEC ELIB_Management_System.uspInsert_User_details 12345676,'kanwal','Kaur','05-07-1995','5-B,Vimal House,Poonamalle','044-2449966','09866102438',
'Engineering','F','Subscriber','2017-10-21','kanwalorkawal'
 EXEC ELIB_Management_System.uspInsert_User_details 12345677,'Joydip','Ghosh','05-08-1995','5-B,Vimal House,Poonamalle','044-2449966','09866102438',
'Engineering','M','Subscriber','2017-10-21','hellohello'
 EXEC ELIB_Management_System.uspInsert_User_details 12345678,'Srikanth','Sri','05-09-1995','5-B,Vimal House,Poonamalle','044-2449966','09866102438',
'Engineering','M','Non_Subscriber','2017-10-21','sri@123'
 EXEC ELIB_Management_System.uspInsert_User_details 12345679,'Vinay','Vinay','05-10-1995','5-B,Vimal House,Poonamalle','044-2449966','09866102438',
'Engineering','M','Non_Subscriber','2017-10-21','vinay@123'
end try
begin catch
print error_number();
print error_message();
print error_severity();
end catch

go













--Procedure For Update in User Details

Create Proc ELIB_Management_System.uspUpdate_User_details
(
 @User_ID varchar(15),
 @First_Name varchar(50),
 @Last_Name varchar(50),
 @Date_Of_Birth date,
 @Address varchar(1000),
 @Land_Line_Number varchar(15),
 @Mobile_Number varchar(15) ,
 @Area_Of_Interests varchar(100),
 @Gender varchar(1),
 @User_Type varchar(30),
 @Date_Of_Registration date,
 @Password varchar(50)
)
 AS
 BEGIN
 if((datalength(@User_ID)<8 and datalength(@User_ID)>15)) 
		 throw 60000,'User ID Should be between 8 and 15 characters',18;
if((@First_Name is null or @First_Name='')  or  (@Last_Name is null or @Last_Name=''))
		 throw 60001,'Name Should Not be NULL',18;
 if((datediff(year,@Date_of_Birth,getdate())<=18))
		 throw 60002,'Age Should be greater than 18 years',18
if((@Address is null or @Address=''))
		throw 60003,'Address Should not be empty',18;
if((@Area_Of_Interests is null or @Area_Of_Interests=''))
		throw 60004,'Area of interest Should not be empty',18;
if((@Gender is null or @Gender='') or @Gender NOT IN ('M','F'))
		throw 60005,'Gender Should be M or F',18;
if(@User_Type NOT IN('Subscriber','Non_Subscriber','Administrator'))
		throw 60006,'User_Type Should be Subscriber,Non-Subscriber or Administrator',18;

if(@Date_Of_Registration!=CONVERT(date, getdate()))
		throw 60007,'Date Of registration should be current date',18;
if(@Password is null or @Password='')
		throw 60008,'Password Should not be empty',18;

		Update ELIB_Management_System.User_details Set   First_Name=@First_Name, Last_Name=@Last_Name,
		 Date_of_Birth=@Date_of_Birth,
		Address=@Address,  Land_Line_Number=@Land_Line_Number, Mobile_Number=@Mobile_Number,
		 Area_Of_Interests=@Area_Of_Interests,Gender=@Gender, User_Type=@User_Type,
		  Date_Of_Registration=@Date_Of_Registration,
		 Password=@Password where User_Id=@User_Id
		 END
		 go




--Exec Update Stored Procedure_User Details
		  begin try
 EXEC ELIB_Management_System.uspUpdate_User_details 12345679,'Akhil','Kusuma','05-02-1995','5-B,Vimal House,Poonamalle','044-2449966','09866102438',
'Engineering','M','Non_Subscriber','2017-10-21','********'
end try
begin catch
print error_number();
print error_message();
print error_severity();
end catch
go
















--Other Statements for checking and modifying
 drop table  ELIB_Management_System.User_details
truncate table ELIB_Management_System.User_details
drop proc ELIB_Management_System.uspInsert_User_details
drop proc ELIB_Management_System.uspUpdate_User_details
select *from ELIB_Management_System.User_details

go
