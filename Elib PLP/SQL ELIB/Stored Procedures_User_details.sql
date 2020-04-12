----------------------------------------------------------------------------------------------------------------------
------------------------Stored Procedure to Display Records in ELIB MANAGEMENT SYSTEM--------------------------------- 
----------------------------------------------------------------------------------------------------------------------
create proc ELIB_Management_System.uspSelectFromUser_Details
(
@User_ID varchar(15)
)
as
begin
if(datalength(@User_ID)<8 or datalength(@User_ID)>15)
	throw 60000,'User_ID should be minimun 8 characters and maximum 15 characters',16;
else if((select User_ID from ELIB_Management_System.User_details where User_ID=@User_ID)!=@User_ID)
	throw 60001,'User_ID Doesnt Matches',17
else
select * from ELIB_Management_System.User_details where User_ID=@User_ID
end
go
----------------------------------------------------------------------------------------------------------------------
----------------------------EXEC to Display Records in ELIB MANAGEMENT SYSTEM------------------------------------------ 
----------------------------------------------------------------------------------------------------------------------
begin try
	exec ELIB_Management_System.uspSelectFromUser_Details '12345679'
end try
begin catch
print	error_number();
print	error_message();
print	error_severity();
end catch
go
----------------------------------------------------------------------------------------------------------------------
------------------------Stored Procedure to Delete Records in ELIB MANAGEMENT SYSTEM---------------------------------- 
----------------------------------------------------------------------------------------------------------------------
create proc ELIB_Management_System.uspDeleteFromUser_Details
(
@User_ID varchar(15)
)
as
begin
if(datalength(@User_ID)<8 or datalength(@User_ID)>15)
	throw 60000,'User_ID should be minimun 8 characters and maximum 15 characters',16;
else if((select User_ID from ELIB_Management_System.User_details where User_ID=@User_ID)!=@User_ID)
	throw 60001,'User_ID Doesnt Matches',17;
else
delete from ELIB_Management_System.User_details where User_ID=@User_ID
end
go

----------------------------------------------------------------------------------------------------------------------
----------------------------EXEC to Delete Records in ELIB MANAGEMENT SYSTEM------------------------------------------ 
----------------------------------------------------------------------------------------------------------------------
begin try
	exec ELIB_Management_System.uspDeleteFromUser_Details '12345679'
end try
begin catch
print	error_number();
print	error_message();
print	error_severity();
end catch
go
----------------------------------------------------------------------------------------------------------------------
------------------------Stored Procedure to LOG IN in ELIB MANAGEMENT SYSTEM------------------------------------------
----------------------------------------------------------------------------------------------------------------------
alter proc ELIB_Management_System.uspLogInELIB
(
@User_ID varchar(30),
@Password varchar(30)
)
as
begin 
if(exists(select * from ELIB_Management_System.User_details where User_ID=@User_ID))
		Select * from ELIB_Management_System.User_details where User_ID=@User_ID;
		 
else
	throw 79999,'Invalid User ID or Password',18;
end
go
exec ELIB_Management_System.uspLogInELIB 'Akhil55ram','Alekya@1674'
----------------------------------------------------------------------------------------------------------------------
-------------------------------EXEC to LOG IN in ELIB MANAGEMENT SYSTEM----------------------------------------------- 
----------------------------------------------------------------------------------------------------------------------
begin try
	exec ELIB_Management_System.uspLogInELIB '12345678','sri@123'
end try
begin catch
print error_number();
print error_message();
print error_severity();
end catch
----------------------------------------------------------------------------------------------------------------------

select * from ELIB_Management_System.User_details

-------------------------------------------------------------
create Proc ELIB_Management_System.uspFind_User_details
(
 @User_ID varchar(15)
)
 AS
 BEGIN
		select * from ELIB_Management_System.User_details where User_Id=@User_Id
END
