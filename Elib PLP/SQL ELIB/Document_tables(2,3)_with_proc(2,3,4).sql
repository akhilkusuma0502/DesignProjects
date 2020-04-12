--creating table Document_Details
create table [ELIB_Management_System].[Document_Details]
(
[Document_ID] [int]  Primary Key NOT NULL,
	[Document_Name] [varchar](20) NOT NULL,
	[Document_Description] [varchar](200) NOT NULL,
	[Document_Path] [varchar](50) NOT NULL,
	[Document_Type_ID] [int] NOT NULL constraint FK_Document_Type_ID Foreign Key references [ELIB_Management_System].[Document_Type_Details](Document_Type_ID),
	[Discipline_ID] [int] Not NULL constraint FK_Discipline_ID Foreign Key references [ELIB_Management_System].[Disciplines](Discipline_ID),
	[Title] [varchar](30) NOT NULL,
	[Author] [varchar](50) NOT NULL,
	[Upload_Date] [date] NOT NULL,
	[Price] [money] NOT NULL,
	)

--creating table Disciplines
create table [ELIB_Management_System].[Disciplines]
(
[Discipline_ID] [int] Primary Key NOT NULL,
[Discipline_Name] [varchar](20) NOT NULL,
)

--creating sequence ELIB_Management_System.Discipline_ID
create sequence ELIB_Management_System.Discipline_ID as int
start with 1
increment by 1
cache 10
go

--creating sequence ELIB_Management_System.Document_ID
create sequence ELIB_Management_System.Document_ID as int
start with 1
increment by 1
cache 10
go
 

--stored procedure for Document_details table (insert)
alter procedure ELIB_Management_System.uspInsertDocument_Details
(
@document_name varchar(20),
@document_description varchar(200),
@document_path varchar(50),
@document_type_id int,
@discipline_id int,
@title varchar(30),
@author varchar(50),
@price money 
) 
as 
begin


insert into ELIB_Management_System.Document_Details values(next value for ELIB_Management_System.Document_ID,@document_name,@document_description,@document_path,@document_type_id,
@discipline_id,@title,@author,getdate(),@price)

if(@document_name IS NULL OR @document_description IS NULL OR @document_path IS NULL OR @document_type_id IS NULL OR
@discipline_id  IS NULL OR @title IS NULL OR @author IS NULL OR @price IS NULL )
		throw 51000,'Fields cannot be left blank',17;
	
end

select * from ELIB_Management_System.Disciplines

BEGIN TRY
exec  ELIB_Management_System.uspInsertDocument_Details 'abc','abcde','abcfdwgd',7,6,'dfads','da',2000
END TRY 
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_MESSAGE() AS ErrorMessage
		,ERROR_SEVERITY() AS ErrorSeverity;
END CATCH;  
select * from  ELIB_Management_System.Document_Details 
drop proc ELIB_Management_System.uspInsertDocument_Details

select * from ELIB_Management_System.User_Details



--stored procedure for Document_details table (update)
alter procedure ELIB_Management_System.uspUpdateDocument_Details
(
@document_id int,
@document_name varchar(20),
@document_description varchar(200),
@document_path varchar(50),
@document_type_id int,
@discipline_id int,
@title varchar(30),
@author varchar(50),
@price money 
) 
as 
begin
update ELIB_Management_System.Document_Details set [Document_Name]=@document_name,[Document_Description]=@document_description,[Document_Path]=@document_path,[Document_Type_ID]=@document_type_id,
[Discipline_ID]=@discipline_id,[Title]=@title,[Author]=@author,[Upload_Date]=getdate(),[Price]=@price where [Document_ID]=@document_id

if(@document_name IS NULL OR @document_description IS NULL OR @document_path IS NULL OR @document_type_id IS NULL OR
 @discipline_id IS NULL OR @title IS NULL OR @author IS NULL OR @price IS NULL )
		throw 51000,'Fields cannot be left blank',17;
	
end

BEGIN TRY
exec  ELIB_Management_System.uspUpdateDocument_Details 4,'abcdef'
END TRY 
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_MESSAGE() AS ErrorMessage
		,ERROR_SEVERITY() AS ErrorSeverity;
END CATCH;  
drop proc ELIB_Management_System.uspUpdateDocument_Details



--stored procedure for Document_Details table (delete)
create procedure ELIB_Management_System.uspDeleteDocument_Details
(
@document_id int
) 
as 
begin
delete from ELIB_Management_System.Document_Details where Document_ID=@document_id;
	
end

BEGIN TRY
exec  ELIB_Management_System.uspDeleteDocument_Details
END TRY 
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_MESSAGE() AS ErrorMessage
		,ERROR_SEVERITY() AS ErrorSeverity;
END CATCH;  
drop proc ELIB_Management_System.uspDeleteDocument_Details 


drop proc ELIB_Management_System.uspSelectDocument_Details 
--stored procedure for Document_Details table (select)
create procedure ELIB_Management_System.uspSelectDocument_DetailsbyName 
(
@document_name varchar(30)
) 
as 
begin
select * from [ELIB_Management_System].[Document_Details] where Document_Name Like '%'+@document_name+'%'
end

BEGIN TRY
exec  ELIB_Management_System.uspSelectDocument_DetailsByName  'abcd'
END TRY 
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_MESSAGE() AS ErrorMessage
		,ERROR_SEVERITY() AS ErrorSeverity;
END CATCH;  
drop proc ELIB_Management_System.uspSelectDocument_Details  

drop procedure ELIB_Management_System.uspSelectDocument_DetailsById
create procedure ELIB_Management_System.uspSelectDocument_DetailsById
(
@document_id int
) 
as 
begin
select Doc_Details.*,Type_Details.Document_Type_Name,Disc.Discipline_Name 
from [ELIB_Management_System].[Document_Details] Doc_Details 
join ELIB_Management_System.Document_Type_Details Type_Details 
on Doc_Details.Document_Type_Id=Type_Details.Document_Type_id  
join ELIB_Management_System.Disciplines Disc 
on Doc_Details.Discipline_Id=Disc.Discipline_ID
where Doc_Details.Document_ID=@document_id
end

BEGIN TRY
exec  ELIB_Management_System.uspSelectDocument_DetailsById  10
END TRY 
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_MESSAGE() AS ErrorMessage
		,ERROR_SEVERITY() AS ErrorSeverity;
END CATCH; 
select * from ELIB_Management_System.Document_Details

--stored procedure for Disciplines table (insert)
create procedure ELIB_Management_System.uspInsertDisciplines
(
@discipline_name varchar(20) 
) 
as 
begin
insert into ELIB_Management_System.Disciplines values(next value for ELIB_Management_System.Discipline_ID,@discipline_name)
if(@discipline_name IS NULL )
	throw 51000,'Discipline Name cannot be left blank',17;
end

BEGIN TRY
exec  ELIB_Management_System.uspInsertDisciplines 'abc'
END TRY 
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_MESSAGE() AS ErrorMessage
		,ERROR_SEVERITY() AS ErrorSeverity;
END CATCH;  
select * from ELIB_Management_System.Disciplines
delete from ELIB_Management_System.Disciplines
drop proc ELIB_Management_System.uspInsertDisciplines



--stored procedure for Disciplines table (update)
create procedure ELIB_Management_System.uspUpdateDisciplines
(
@discipline_id int,
@discipline_name varchar(20) 
) 
as 
begin
	update ELIB_Management_System.Disciplines set Discipline_Name=@discipline_name where Discipline_ID=@discipline_id;
end

BEGIN TRY
exec  ELIB_Management_System.uspUpdateDisciplines
END TRY 
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_MESSAGE() AS ErrorMessage
		,ERROR_SEVERITY() AS ErrorSeverity;
END CATCH;  
drop proc ELIB_Management_System.uspUpdateDisciplines




--stored procedure for Disciplines table (delete)
create procedure ELIB_Management_System.uspDeleteDisciplines
(
@discipline_id int
) 
as 
begin
delete from ELIB_Management_System.Disciplines where Discipline_ID=@discipline_id;
	
end

BEGIN TRY
exec  ELIB_Management_System.uspDeleteDisciplines  3
END TRY 
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_MESSAGE() AS ErrorMessage
		,ERROR_SEVERITY() AS ErrorSeverity;
END CATCH;  
drop proc ELIB_Management_System.uspDeleteDisciplines  



--stored procedure for Disciplines table (select)
create procedure ELIB_Management_System.uspSelectDisciplines 
(
@discipline_id int
) 
as 
begin
select * from ELIB_Management_System.Disciplines where Discipline_ID=@discipline_id;
end

BEGIN TRY
exec  ELIB_Management_System.uspSelectDisciplines  5
END TRY 
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_MESSAGE() AS ErrorMessage
		,ERROR_SEVERITY() AS ErrorSeverity;
END CATCH;  
drop proc ELIB_Management_System.uspSelectDisciplines  

--stored procedure for Disciplines table (select All)
create procedure ELIB_Management_System.uspSelectAllDisciplines 
as 
begin
select * from ELIB_Management_System.Disciplines 
end

BEGIN TRY
exec  ELIB_Management_System.uspSelectAllDisciplines  
END TRY 
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_MESSAGE() AS ErrorMessage
		,ERROR_SEVERITY() AS ErrorSeverity;
END CATCH;  




--stored procedure for Document_type_details table (insert)
create procedure ELIB_Management_System.uspInsertDocument_Type_Details
(
@document_type_name varchar(20) 
) 
as 
begin
insert into [ELIB_Management_System].[Document_Type_Details] values(next value for ELIB_Management_System.Discipline_ID,@document_type_name)
if(@document_type_name IS NULL )
	throw 51000,'Document Type Name cannot be left blank',17;
end

BEGIN TRY
exec  ELIB_Management_System.uspInsertDocument_Type_Details 'abc'
END TRY 
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_MESSAGE() AS ErrorMessage
		,ERROR_SEVERITY() AS ErrorSeverity;
END CATCH; 

select * from  [ELIB_Management_System].[Document_Type_Details] 
delete from  [ELIB_Management_System].[Document_Type_Details] 
drop proc ELIB_Management_System.uspInsertDocument_Type_Details 


--stored procedure for Document_Type_Details table (update)
create procedure ELIB_Management_System.uspUpdateDocument_Type_Details 
(
@document_type_id int,
@document_type_name varchar(20) 
) 
as 
begin
update ELIB_Management_System.Document_Type_Details set Document_Type_Name=@document_type_name where Document_Type_ID=@document_type_id;
	
end

BEGIN TRY
exec  ELIB_Management_System.uspUpdateDocument_Type_Details 
END TRY 
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_MESSAGE() AS ErrorMessage
		,ERROR_SEVERITY() AS ErrorSeverity;
END CATCH;  
drop proc ELIB_Management_System.uspUpdateDocument_Type_Details 




--stored procedure for Document_Type_Details table (delete)
create procedure ELIB_Management_System.uspDeleteDocument_Type_Details 
(
@document_type_id int
) 
as 
begin
delete from ELIB_Management_System.Document_Type_Details where Document_Type_ID=@document_type_id;
end

BEGIN TRY
exec  ELIB_Management_System.uspDeleteDocument_Type_Details  5
END TRY 
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_MESSAGE() AS ErrorMessage
		,ERROR_SEVERITY() AS ErrorSeverity;
END CATCH;  
drop proc ELIB_Management_System.uspDeleteDocument_Type_Details  



--stored procedure for Document_Type_Details table (select)
create procedure ELIB_Management_System.uspSelectDocument_Type_Details 
(
@document_type_id int
) 
as 
begin
select * from ELIB_Management_System.Document_Type_Details where Document_Type_ID=@document_type_id;
end

BEGIN TRY
exec  ELIB_Management_System.uspSelectDocument_Type_Details  5
END TRY 
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_MESSAGE() AS ErrorMessage
		,ERROR_SEVERITY() AS ErrorSeverity;
END CATCH;  
drop proc ELIB_Management_System.uspSelectDocument_Type_Details  

--stored procedure for Document_Type_Details table (select All)
create procedure ELIB_Management_System.uspSelectAllDocument_Type_Details 
as 
begin
select * from ELIB_Management_System.Document_Type_Details 
end

BEGIN TRY
exec  ELIB_Management_System.uspSelectAllDocument_Type_Details  
END TRY 
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_MESSAGE() AS ErrorMessage
		,ERROR_SEVERITY() AS ErrorSeverity;
END CATCH;  
drop proc ELIB_Management_System.uspSelectAllDocument_Type_Details  



select * from  [ELIB_Management_System].[Document_Details]
select * from  [ELIB_Management_System].[User_details]
select * from  [ELIB_Management_System].[Document_Type_Details]
select * from  ELIB_Management_System.Disciplines 





