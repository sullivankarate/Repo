USE [master]
GO
/****** Object:  Database [Karate]    Script Date: 4/15/2016 4:21:16 PM ******/
CREATE DATABASE [Karate]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Karate', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Karate.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Karate_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Karate_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Karate] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Karate].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Karate] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Karate] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Karate] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Karate] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Karate] SET ARITHABORT OFF 
GO
ALTER DATABASE [Karate] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Karate] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Karate] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Karate] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Karate] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Karate] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Karate] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Karate] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Karate] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Karate] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Karate] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Karate] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Karate] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Karate] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Karate] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Karate] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Karate] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Karate] SET RECOVERY FULL 
GO
ALTER DATABASE [Karate] SET  MULTI_USER 
GO
ALTER DATABASE [Karate] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Karate] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Karate] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Karate] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Karate] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Karate', N'ON'
GO
USE [Karate]
GO
/****** Object:  User [SJ\sjeya]    Script Date: 4/15/2016 4:21:16 PM ******/
CREATE USER [SJ\sjeya] FOR LOGIN [SJ\sjeya] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Level]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Level](
	[LevelID] [int] IDENTITY(1,1) NOT NULL,
	[LevelName] [varchar](100) NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_Level] PRIMARY KEY CLUSTERED 
(
	[LevelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Location]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Location](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [varchar](255) NOT NULL,
	[Address1] [varchar](255) NULL,
	[Address2] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[Zip] [varchar](255) NULL,
	[State] [varchar](255) NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Skill](
	[SkillID] [int] IDENTITY(1,1) NOT NULL,
	[SkillName] [varchar](255) NULL,
	[SortOrder] [int] NOT NULL,
	[SkillCaegoryID] [int] NULL,
 CONSTRAINT [PK_Skill] PRIMARY KEY CLUSTERED 
(
	[SkillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SkillCategory]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SkillCategory](
	[SkillCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[SkillCategoryName] [varchar](100) NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_SkillCategory] PRIMARY KEY CLUSTERED 
(
	[SkillCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SkillLevel]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SkillLevel](
	[SkillLevelID] [int] IDENTITY(1,1) NOT NULL,
	[LevelID] [int] NULL,
	[SkillID] [int] NULL,
	[SortOrder] [int] NULL,
 CONSTRAINT [PK_SkillLevel] PRIMARY KEY CLUSTERED 
(
	[SkillLevelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Email] [varchar](255) NULL,
	[DOB] [datetime] NULL,
	[Address1] [varchar](255) NULL,
	[Address2] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[Zip] [varchar](255) NULL,
	[State] [varchar](255) NULL,
	[LocationID] [int] NULL,
	[LevelID] [int] NULL,
	[IsDeleted] [int] NULL CONSTRAINT [DF_Student_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentAssesment]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentAssesment](
	[StudentAssesmentID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NULL,
	[LevelID] [int] NULL,
	[Note] [varchar](255) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
	[FirstAssessmentDateTime] [datetime] NULL,
	[CompletedDateTime] [datetime] NULL,
 CONSTRAINT [PK_StudentAssesment] PRIMARY KEY CLUSTERED 
(
	[StudentAssesmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentAssesmentDetail]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentAssesmentDetail](
	[StudentAssesmentDetailID] [int] IDENTITY(1,1) NOT NULL,
	[StudentAssesmentID] [int] NOT NULL,
	[SkillLevelID] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[LastModifiedDateTime] [datetime] NULL,
	[Taught] [bit] NULL,
	[TaughtUser] [varchar](100) NULL,
	[TaughtDateTime] [datetime] NULL,
	[Practiced] [bit] NULL,
	[PracticedUser] [varchar](100) NULL,
	[PracticedDateTime] [datetime] NULL,
	[Stripe] [bit] NULL,
	[StripeUser] [varchar](100) NULL,
	[StripeDteTime] [datetime] NULL,
 CONSTRAINT [PK_StudentAssesmentDetail] PRIMARY KEY CLUSTERED 
(
	[StudentAssesmentDetailID] ASC,
	[StudentAssesmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[UserCategoryID] [int] NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_User_CreatedDate]  DEFAULT (getdate()),
	[DisplayName] [varchar](255) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserCategory]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserCategory](
	[UserCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
 CONSTRAINT [PK_UserCategory] PRIMARY KEY CLUSTERED 
(
	[UserCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[StudentAssesment] ADD  CONSTRAINT [DF_Table1_DateCreated]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Skill]  WITH CHECK ADD  CONSTRAINT [FK_Skill_SkillCategory] FOREIGN KEY([SkillCaegoryID])
REFERENCES [dbo].[SkillCategory] ([SkillCategoryID])
GO
ALTER TABLE [dbo].[Skill] CHECK CONSTRAINT [FK_Skill_SkillCategory]
GO
ALTER TABLE [dbo].[SkillLevel]  WITH CHECK ADD  CONSTRAINT [FK_SkillLevel_Level] FOREIGN KEY([LevelID])
REFERENCES [dbo].[Level] ([LevelID])
GO
ALTER TABLE [dbo].[SkillLevel] CHECK CONSTRAINT [FK_SkillLevel_Level]
GO
ALTER TABLE [dbo].[SkillLevel]  WITH CHECK ADD  CONSTRAINT [FK_SkillLevel_Skill] FOREIGN KEY([SkillID])
REFERENCES [dbo].[Skill] ([SkillID])
GO
ALTER TABLE [dbo].[SkillLevel] CHECK CONSTRAINT [FK_SkillLevel_Skill]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Level] FOREIGN KEY([LevelID])
REFERENCES [dbo].[Level] ([LevelID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Level]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Location] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Location] ([LocationID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Location]
GO
ALTER TABLE [dbo].[StudentAssesment]  WITH CHECK ADD  CONSTRAINT [FK_StudentAssesment_Level] FOREIGN KEY([LevelID])
REFERENCES [dbo].[Level] ([LevelID])
GO
ALTER TABLE [dbo].[StudentAssesment] CHECK CONSTRAINT [FK_StudentAssesment_Level]
GO
ALTER TABLE [dbo].[StudentAssesment]  WITH CHECK ADD  CONSTRAINT [FK_StudentAssesment_StudentAssesment] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[StudentAssesment] CHECK CONSTRAINT [FK_StudentAssesment_StudentAssesment]
GO
ALTER TABLE [dbo].[StudentAssesmentDetail]  WITH CHECK ADD  CONSTRAINT [FK_StudentAssesmentDetail_SkillLevel] FOREIGN KEY([SkillLevelID])
REFERENCES [dbo].[SkillLevel] ([SkillLevelID])
GO
ALTER TABLE [dbo].[StudentAssesmentDetail] CHECK CONSTRAINT [FK_StudentAssesmentDetail_SkillLevel]
GO
ALTER TABLE [dbo].[StudentAssesmentDetail]  WITH CHECK ADD  CONSTRAINT [FK_StudentAssesmentDetail_StudentAssesment] FOREIGN KEY([StudentAssesmentID])
REFERENCES [dbo].[StudentAssesment] ([StudentAssesmentID])
GO
ALTER TABLE [dbo].[StudentAssesmentDetail] CHECK CONSTRAINT [FK_StudentAssesmentDetail_StudentAssesment]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserCategory] FOREIGN KEY([UserCategoryID])
REFERENCES [dbo].[UserCategory] ([UserCategoryID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserCategory]
GO
/****** Object:  StoredProcedure [dbo].[SP_DelStudent]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_DelStudent]
(
	 @StudentID int
)
as
--Declare @FirstName varchar(100)
--Declare @LastName varchar(100)
--Declare @Email varchar(255)
--Declare @DOB dateTime
--DEclare @Address1 varchar(255)
--DEclare @Address2 varchar(255)
--DEclare @City varchar(255)
--DEclare @Zip varchar(255)
--DEclare @State varchar(255)
--DEclare @LocationID int
--Declare @LevelID int


Begin
UPDATE [dbo].[Student]
   SET IsDeleted = 1 
 WHERE StudentID = @StudentID
End

GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllSkillCategory]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[SP_GetAllSkillCategory]
As  
BEGIN

SELECT 
	SkillCategoryID,
	SkillCategoryName,
	SortOrder 
FROM 
	SkillCategory  order by SortOrder

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllUsers]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_GetAllUsers]
As 

Begin
SELECT *
FROM    UserCategory INNER JOIN
	[User] ON UserCategory.UserCategoryID = [User].UserCategoryID 

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetLevels]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[SP_GetLevels]
as 

Begin
SELECT LevelID
      ,LevelName
      ,SortOrder
  FROM [Level] (nolock)

  END
GO
/****** Object:  StoredProcedure [dbo].[sp_getLocations]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_getLocations]
AS
BEGIN	
	SET NOCOUNT ON;
	SElect * from Location(nolock);
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetSkillCategory]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[SP_GetSkillCategory]
as 

Begin
SELECT [SkillCategoryID]
      ,[SkillCategoryName]
      ,[SortOrder]
  FROM [SkillCategory] (nolock)

  END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetSkills]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[SP_GetSkills]
as 

Begin
SELECT 
	SkillID,
	SkillName,
	SortOrder,
	SkillCaegoryID
  FROM Skill (nolock)

  END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetSkillsByLevel]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Procedure [dbo].[SP_GetSkillsByLevel]
(
	@LevelID int
)
As
BEGIN
Select 
	[Level].LevelName,
	SkillCategory.SkillCategoryName,
	Skill.SkillName,
	Skill.SortOrder,
	[Level].LevelID,
	SkillLevel.SkillLevelID,
	Skill.SkillID,
	SkillCategory.SkillCategoryID
 from 
	[Level] 
	inner join SkillLevel on [Level].LevelID = SkillLevel.LevelID
	inner join Skill ON Skill.SkillID = SkillLevel.SkillID 
	inner join SkillCategory on SkillCategory.SkillCategoryID = Skill.SkillCaegoryID
where 
	[Level].LevelID = @LevelID
order by 
	SkillCategory.SortOrder,
	Skill.SortOrder
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_getStudent]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getStudent]
AS
BEGIN	
	SET NOCOUNT ON;
	SElect * from Student(nolock);
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetStudents]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetStudents]
AS
BEGIN	
	SET NOCOUNT ON;
	SElect * from Student(nolock);
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetStudentsByLocation]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_GetStudentsByLocation]
(
 @LocationID int
)
AS 

Begin

SELECT 	
	Location.LocationName,
	[Level].LevelName,
	[Level].LevelID,
	Location.LocationID,
	Student.StudentID,
	Student.FirstName,
	Student.LastName
FROM
	Location 
	INNER JOIN Student ON Location.LocationID = Student.LocationID 
	INNER JOIN [Level]  on [Level].levelid= Student.LevelID  		
Where 
	Location.LocationID = @LocationID
	and Student.isDeleted = 0


--SELECT * FROM
--	Location  
--	inner Join Student on Location.LocationID = Student.LocationID
--	inner join [Level] on [Level].LevelID = Student.LevelID 
--	inner join SkillLevel on Student.LevelID = SkillLevel.LevelID
--	inner join Skill ON Skill.SkillID = SkillLevel.SkillID 
--	inner join SkillCategory on SkillCategory.SkillCategoryID = Skill.SkillCaegoryID
--where 
--	Student.StudentID = 2



END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetStudentSkillLevel]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[SP_GetStudentSkillLevel]
(
	@StudentID int
)
AS 
BEGIN

Select 
	Student.StudentID,
	[Level].LevelName,
	SkillCategory.SkillCategoryName,
	Skill.SkillName,
	Skill.SortOrder,
	[Level].LevelID,
	SkillLevel.SkillLevelID,
	Skill.SkillID,
	SkillCategory.SkillCategoryID
 from
	Student  
	inner join [Level] on Student.LevelID = [Level].LevelID
	inner join SkillLevel on [Level].LevelID = SkillLevel.LevelID
	inner join Skill ON Skill.SkillID = SkillLevel.SkillID 
	inner join SkillCategory on SkillCategory.SkillCategoryID = Skill.SkillCaegoryID
where 
	Student.StudentID = @StudentID
order by 
	SkillCategory.SortOrder,
	Skill.SortOrder
END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsStudent]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_InsStudent]
(
	 @FirstName varchar(100),
	 @LastName varchar(100),
	 @Email varchar(255),
	 @DOB dateTime,
	 @Address1 varchar(255),
	 @Address2 varchar(255),
	 @City varchar(255),
	 @Zip varchar(255),
	 @State varchar(255),
	 @LocationID int,
	 @LevelID int
)
as
--Declare @FirstName varchar(100)
--Declare @LastName varchar(100)
--Declare @Email varchar(255)
--Declare @DOB dateTime
--DEclare @Address1 varchar(255)
--DEclare @Address2 varchar(255)
--DEclare @City varchar(255)
--DEclare @Zip varchar(255)
--DEclare @State varchar(255)
--DEclare @LocationID int
--Declare @LevelID int


Begin
INSERT INTO [dbo].[Student]
           ([FirstName]
           ,[LastName]
           ,[Email]
           ,[DOB]
           ,[Address1]
           ,[Address2]
           ,[City]
           ,[Zip]
           ,[State]
           ,[LocationID]
           ,[LevelID])
     VALUES
           (@FirstName
           ,@LastName
           ,@Email
           ,@DOB
           ,@Address1
           ,@Address2
           ,@City
           ,@Zip
           ,@State
           ,@LocationID
           ,@LevelID)
End

GO
/****** Object:  StoredProcedure [dbo].[SP_InsUpdStudent]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_InsUpdStudent]
(
	 @StudentID int,
	 @FirstName varchar(100),
	 @LastName varchar(100),
	 @Email varchar(255),
	 @DOB dateTime,
	 @Address1 varchar(255),
	 @Address2 varchar(255),
	 @City varchar(255),
	 @Zip varchar(255),
	 @State varchar(255),
	 @LocationID int,
	 @LevelID int
)
as

Begin
--Declare @FirstName varchar(100)
--Declare @LastName varchar(100)
--Declare @Email varchar(255)
--Declare @DOB dateTime
--DEclare @Address1 varchar(255)
--DEclare @Address2 varchar(255)
--DEclare @City varchar(255)
--DEclare @Zip varchar(255)
--DEclare @State varchar(255)
--DEclare @LocationID int
--Declare @LevelID int

IF (ISNULL(@StudentID, 0) = 0)
	BEGIN
		INSERT INTO [dbo].[Student]
				   ([FirstName]
				   ,[LastName]
				   ,[Email]
				   ,[DOB]
				   ,[Address1]
				   ,[Address2]
				   ,[City]
				   ,[Zip]
				   ,[State]
				   ,[LocationID]
				   ,[LevelID])
			 VALUES
				   (@FirstName
				   ,@LastName
				   ,@Email
				   ,@DOB
				   ,@Address1
				   ,@Address2
				   ,@City
				   ,@Zip
				   ,@State
				   ,@LocationID
				   ,@LevelID)
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Student]
		   SET [FirstName] = @FirstName
			  ,[LastName] = @LastName
			  ,[Email] = @Email
			  ,[DOB] = @DOB
			  ,[Address1] = @Address1
			  ,[Address2] = @Address2
			  ,[City] = @City
			  ,[Zip] = @Zip
			  ,[State] = @State
			  ,[LocationID] = @LocationID
			  ,[LevelID] = @LevelID 
		 WHERE StudentID = @StudentID
	END


End

GO
/****** Object:  StoredProcedure [dbo].[SP_UpdStudent]    Script Date: 4/15/2016 4:21:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_UpdStudent]
(
	 @StudentID int,
	 @FirstName varchar(100),
	 @LastName varchar(100),
	 @Email varchar(255),
	 @DOB dateTime,
	 @Address1 varchar(255),
	 @Address2 varchar(255),
	 @City varchar(255),
	 @Zip varchar(255),
	 @State varchar(255),
	 @LocationID int,
	 @LevelID int
)
as
--Declare @FirstName varchar(100)
--Declare @LastName varchar(100)
--Declare @Email varchar(255)
--Declare @DOB dateTime
--DEclare @Address1 varchar(255)
--DEclare @Address2 varchar(255)
--DEclare @City varchar(255)
--DEclare @Zip varchar(255)
--DEclare @State varchar(255)
--DEclare @LocationID int
--Declare @LevelID int


Begin
UPDATE [dbo].[Student]
   SET [FirstName] = @FirstName
      ,[LastName] = @LastName
      ,[Email] = @Email
      ,[DOB] = @DOB
      ,[Address1] = @Address1
      ,[Address2] = @Address2
      ,[City] = @City
      ,[Zip] = @Zip
      ,[State] = @State
      ,[LocationID] = @LocationID
      ,[LevelID] = @LevelID 
 WHERE StudentID = @StudentID
End

GO
USE [master]
GO
ALTER DATABASE [Karate] SET  READ_WRITE 
GO
