
-------------------------------------------------------------------------------------------------------
-------------------------- Document_Type_details TABLE-------------------------------------------------
-------------------------------------------------------------------------------------------------------

Create table ELIB_Management_System.Document_Type_Details
(Document_Type_Id int primary key ,
Document_Type_Name varchar(20) not null
)
go


-------------------------------------------------------------------------------------------------------
-------------------------Sequence FOR Document_Type_Id-------------------------------------------------
-------------------------------------------------------------------------------------------------------
CREATE SEQUENCE ELIB_Management_System.Document_Type_Id 
    START WITH 1  
    INCREMENT BY 1 ;  
GO


-------------------------------------------------------------------------------------------------------
-------------INSERT STORED PROCEDURE FOR Document_Type_details TABLE-----------------------------------
-------------------------------------------------------------------------------------------------------

CREATE proc ELIB_Management_System.uspINSERTDocument_Type_Details
(
@Document_Type_Name varchar(20)
)
AS
BEGIN
IF(@Document_Type_Name is null or @Document_Type_Name = '')
	throw 61000,'Document Type should not be null',18;
INSERT into ELIB_Management_System.Document_Type_Details VALUES(NEXT VALUE FOR ELIB_Management_System.Document_Type_Id,@Document_Type_Name)
END
go

begin try
exec  ELIB_Management_System.uspINSERTDocument_Type_Details 'PDF'
exec  ELIB_Management_System.uspINSERTDocument_Type_Details 'doc'
exec  ELIB_Management_System.uspINSERTDocument_Type_Details ''
end try

begin catch
print error_number();
print error_message();
print error_severity();
end catch
go


-------------------------------------------------------------------------------------------------------
-------------UPDATE STORED PROCEDURE FOR Document_Type_details TABLE-----------------------------------
-------------------------------------------------------------------------------------------------------
CREATE proc ELIB_Management_System.uspUPDATEDocument_Type_Details
(
@Document_Type_Name varchar(20),
@Document_Type_Id INT
)
AS
BEGIN
IF(@Document_Type_Name is null or @Document_Type_Name = '')
	throw 61000,'Document Type should not be null',18;
IF(@Document_Type_Id IS NULL )
	THROW 61001,'Document Type Id should Not Be Null',18;
update ELIB_Management_System.Document_Type_Details set Document_Type_Name=@Document_Type_Name
where Document_Type_Id = @Document_Type_Id
END
go

begin try
exec  ELIB_Management_System.uspUPDATEDocument_Type_Details 'PDF',2
exec  ELIB_Management_System.uspUPDATEDocument_Type_Details 'doc',1
exec  ELIB_Management_System.uspUPDATEDocument_Type_Details 'XML',null
end try

begin catch
print error_number();
print error_message();
print error_severity();
end catch
go
-------------------------------------------------------------------------------------------------------
-------------DELETE STORED PROCEDURE FOR Document_Type_details TABLE-----------------------------------
-------------------------------------------------------------------------------------------------------

CREATE proc ELIB_Management_System.uspDELETEDocument_Type_Details
(
@Document_Type_Id INT
)
AS
BEGIN
IF(@Document_Type_Id IS NULL )
	THROW 61001,'Document Type Id should Not Be Null',18;
DELETE from ELIB_Management_System.Document_Type_Details
WHERE Document_Type_Id=@Document_Type_Id
END
go

begin try
exec ELIB_Management_System.uspDELETEDocument_Type_Details null
end try

begin catch
print error_number();
print error_message();
print error_severity();
end catch
go

-------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------



