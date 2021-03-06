USE [master]
GO
/****** Object:  Database [UCRMS_DB]    Script Date: 2/16/2016 3:40:50 AM ******/
CREATE DATABASE [UCRMS_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UCRMS_DB', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UCRMS_DB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UCRMS_DB_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UCRMS_DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UCRMS_DB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UCRMS_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UCRMS_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UCRMS_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UCRMS_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UCRMS_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UCRMS_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UCRMS_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UCRMS_DB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UCRMS_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UCRMS_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UCRMS_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UCRMS_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UCRMS_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UCRMS_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UCRMS_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UCRMS_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UCRMS_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UCRMS_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UCRMS_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UCRMS_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UCRMS_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UCRMS_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UCRMS_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UCRMS_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UCRMS_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UCRMS_DB] SET  MULTI_USER 
GO
ALTER DATABASE [UCRMS_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UCRMS_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UCRMS_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UCRMS_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UCRMS_DB]
GO
/****** Object:  Table [dbo].[AllocationRoom]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllocationRoom](
	[ACRoomId] [int] IDENTITY(1,1) NOT NULL,
	[DeptId] [int] NULL,
	[CourseId] [int] NULL,
	[RoomId] [int] NULL,
	[DayId] [int] NULL,
	[StartTime] [nvarchar](50) NULL,
	[EndTime] [nvarchar](50) NULL,
	[ActiveState] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Course]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [nvarchar](50) NULL,
	[CourseName] [nvarchar](50) NULL,
	[CourseCredit] [decimal](18, 0) NULL,
	[Description] [nvarchar](50) NULL,
	[DeptId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
	[AssignedTeacherId] [int] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Day]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Day](
	[DayId] [int] IDENTITY(1,1) NOT NULL,
	[DayName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Day] PRIMARY KEY CLUSTERED 
(
	[DayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DeptId] [int] IDENTITY(1,1) NOT NULL,
	[DeptName] [nvarchar](50) NULL,
	[DeptCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DeptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Designation]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[DesignationId] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EnrollCourse]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnrollCourse](
	[EnroolId] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationId] [nvarchar](50) NULL,
	[StudentName] [nvarchar](50) NULL,
	[StudentEmail] [nvarchar](50) NULL,
	[DeptCode] [nvarchar](50) NULL,
	[CourseId] [int] NOT NULL,
	[EnrollDate] [datetime] NULL,
 CONSTRAINT [PK_EnrollCourse] PRIMARY KEY CLUSTERED 
(
	[EnroolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Grade]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grade](
	[GradeId] [int] IDENTITY(1,1) NOT NULL,
	[GradeLetter] [nvarchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RegNo_Info]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegNo_Info](
	[DeptId] [nvarchar](10) NULL,
	[Counter] [decimal](3, 0) NULL,
	[Year] [nvarchar](5) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Result]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[ResultId] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationId] [nvarchar](50) NULL,
	[StudentName] [nvarchar](50) NULL,
	[StudentEmail] [nvarchar](50) NULL,
	[DeptCode] [nvarchar](50) NULL,
	[CourseId] [int] NOT NULL,
	[GradeId] [int] NOT NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[ResultId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [nvarchar](50) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Semester]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semester](
	[SemesterId] [int] IDENTITY(1,1) NOT NULL,
	[SemesterName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [nvarchar](50) NULL,
	[StudentEmail] [nvarchar](50) NULL,
	[ContactNo] [nvarchar](20) NULL,
	[Date] [datetime] NULL,
	[Address] [nvarchar](50) NULL,
	[DeptId] [int] NOT NULL,
	[RegistationNo] [nvarchar](20) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[ContactNo] [nvarchar](50) NULL,
	[DesignationId] [int] NOT NULL,
	[DeptId] [int] NOT NULL,
	[CreditToBeTaken] [float] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[EnrollCoursesByRegNo]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[EnrollCoursesByRegNo]
AS
SELECT        dbo.Student.RegistationNo, dbo.Course.CourseCode, dbo.EnrollCourse.StudentName, dbo.EnrollCourse.CourseId, dbo.EnrollCourse.StudentEmail
FROM            dbo.EnrollCourse LEFT OUTER JOIN
                         dbo.Course ON dbo.EnrollCourse.CourseId = dbo.Course.CourseId INNER JOIN
                         dbo.Student ON dbo.EnrollCourse.RegistrationId = dbo.Student.RegistationNo

GO
/****** Object:  View [dbo].[GetCourseCodeByRegNo]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GetCourseCodeByRegNo]
AS
SELECT        dbo.Student.RegistationNo, dbo.Course.DeptId, dbo.Course.CourseCode
FROM            dbo.Course LEFT OUTER JOIN
                         dbo.Student ON dbo.Course.DeptId = dbo.Student.DeptId
WHERE        (dbo.Student.RegistationNo = 'ICE-2015-006')




GO
/****** Object:  View [dbo].[GetStudentByRegNo]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GetStudentByRegNo]
AS
SELECT        dbo.Student.StudentName, dbo.Student.StudentEmail, dbo.Department.DeptCode, dbo.Student.DeptId, dbo.Student.RegistationNo
FROM            dbo.Student LEFT OUTER JOIN
                         dbo.Department ON dbo.Student.DeptId = dbo.Department.DeptId




GO
/****** Object:  View [dbo].[ViewClassSchedule]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewClassSchedule]
AS
SELECT        dbo.Day.DayName, dbo.Room.RoomNo, dbo.AllocationRoom.StartTime, dbo.AllocationRoom.EndTime
FROM            dbo.AllocationRoom LEFT OUTER JOIN
                         dbo.Day ON dbo.AllocationRoom.DayId = dbo.Day.DayId INNER JOIN
                         dbo.Room ON dbo.AllocationRoom.RoomId = dbo.Room.RoomId

GO
/****** Object:  View [dbo].[ViewCourseStatic]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewCourseStatic]
AS
SELECT        dbo.Course.CourseCode, dbo.Course.CourseName, dbo.Semester.SemesterName, ISNULL(dbo.Teacher.TeacherName, 'Not Assigned Yet') AS AssignedTo, 
                         dbo.Course.DeptId
FROM            dbo.Course LEFT OUTER JOIN
                         dbo.Semester ON dbo.Course.SemesterId = dbo.Semester.SemesterId INNER JOIN
                         dbo.Teacher ON dbo.Teacher.TeacherId = dbo.Course.AssignedTeacherId

GO
/****** Object:  View [dbo].[ViewResultByRegNo]    Script Date: 2/16/2016 3:40:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewResultByRegNo]
AS
SELECT        dbo.Result.RegistrationId AS RegistationNo, dbo.Result.StudentName, dbo.Result.StudentEmail, dbo.Result.DeptCode, dbo.Course.CourseCode, 
                         dbo.Course.CourseName, ISNULL(dbo.Grade.GradeLetter, 'Not Graded Yet') AS GradeLetter
FROM            dbo.EnrollCourse LEFT OUTER JOIN
                         dbo.Course ON dbo.EnrollCourse.CourseId = dbo.Course.CourseId LEFT OUTER JOIN
                         dbo.Result ON dbo.EnrollCourse.CourseId = dbo.Result.CourseId LEFT OUTER JOIN
                         dbo.Grade ON dbo.Result.GradeId = dbo.Grade.GradeId

GO
SET IDENTITY_INSERT [dbo].[AllocationRoom] ON 

INSERT [dbo].[AllocationRoom] ([ACRoomId], [DeptId], [CourseId], [RoomId], [DayId], [StartTime], [EndTime], [ActiveState]) VALUES (1, 1, 1, 1, 1, N'03:36:59 AM', N'04:36:59 AM', 1)
INSERT [dbo].[AllocationRoom] ([ACRoomId], [DeptId], [CourseId], [RoomId], [DayId], [StartTime], [EndTime], [ActiveState]) VALUES (2, 1, 2, 1, 1, N'02:36:59 AM', N'03:35:59 AM', 1)
INSERT [dbo].[AllocationRoom] ([ACRoomId], [DeptId], [CourseId], [RoomId], [DayId], [StartTime], [EndTime], [ActiveState]) VALUES (3, 4, 8, 2, 1, N'03:36:59 AM', N'04:36:59 AM', 1)
SET IDENTITY_INSERT [dbo].[AllocationRoom] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [CourseCredit], [Description], [DeptId], [SemesterId], [AssignedTeacherId]) VALUES (1, N'CSE001', N'Programming C', CAST(3 AS Decimal(18, 0)), N'', 1, 1, 0)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [CourseCredit], [Description], [DeptId], [SemesterId], [AssignedTeacherId]) VALUES (2, N'CSE002', N'OOP', CAST(3 AS Decimal(18, 0)), N'Object Oriented Programing', 1, 1, 0)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [CourseCredit], [Description], [DeptId], [SemesterId], [AssignedTeacherId]) VALUES (3, N'ICE-101', N'C++', CAST(4 AS Decimal(18, 0)), N'Advance', 3, 1, 0)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [CourseCredit], [Description], [DeptId], [SemesterId], [AssignedTeacherId]) VALUES (4, N'ICE-102', N'Java', CAST(4 AS Decimal(18, 0)), N'Advance JAva', 3, 2, 0)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [CourseCredit], [Description], [DeptId], [SemesterId], [AssignedTeacherId]) VALUES (5, N'ICE-103', N'Advance OOP', CAST(3 AS Decimal(18, 0)), N'Advance Programming', 3, 2, 0)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [CourseCredit], [Description], [DeptId], [SemesterId], [AssignedTeacherId]) VALUES (6, N'CSE003', N'DataStructure', CAST(4 AS Decimal(18, 0)), N'Advance DataStructure', 1, 2, 0)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [CourseCredit], [Description], [DeptId], [SemesterId], [AssignedTeacherId]) VALUES (7, N'BBA102', N'Accounting', CAST(5 AS Decimal(18, 0)), N'advance', 4, 1, NULL)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [CourseCredit], [Description], [DeptId], [SemesterId], [AssignedTeacherId]) VALUES (8, N'BBA103', N'AAC', CAST(3 AS Decimal(18, 0)), N'high', 4, 2, NULL)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Day] ON 

INSERT [dbo].[Day] ([DayId], [DayName]) VALUES (1, N'Saterday')
INSERT [dbo].[Day] ([DayId], [DayName]) VALUES (2, N'Sunday')
INSERT [dbo].[Day] ([DayId], [DayName]) VALUES (3, N'Monday')
INSERT [dbo].[Day] ([DayId], [DayName]) VALUES (4, N'Tuesday')
INSERT [dbo].[Day] ([DayId], [DayName]) VALUES (5, N'Wednesday')
INSERT [dbo].[Day] ([DayId], [DayName]) VALUES (6, N'Thuseday')
INSERT [dbo].[Day] ([DayId], [DayName]) VALUES (7, N'Friday')
SET IDENTITY_INSERT [dbo].[Day] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DeptId], [DeptName], [DeptCode]) VALUES (1, N'Computer Science & Engineering', N'CSE')
INSERT [dbo].[Department] ([DeptId], [DeptName], [DeptCode]) VALUES (3, N'Information & Communication Engg.', N'ICE')
INSERT [dbo].[Department] ([DeptId], [DeptName], [DeptCode]) VALUES (4, N'Bachelor of Business Administration', N'BBA')
INSERT [dbo].[Department] ([DeptId], [DeptName], [DeptCode]) VALUES (5, N'Biotechnology and Genetic engineering', N'BGE')
INSERT [dbo].[Department] ([DeptId], [DeptName], [DeptCode]) VALUES (6, N' Master of Business Administration', N'MBA')
INSERT [dbo].[Department] ([DeptId], [DeptName], [DeptCode]) VALUES (7, N'aaa', N'aaa')
INSERT [dbo].[Department] ([DeptId], [DeptName], [DeptCode]) VALUES (8, N'ddd', N'ddd')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([DesignationId], [DesignationName]) VALUES (1, N'Lecturer')
INSERT [dbo].[Designation] ([DesignationId], [DesignationName]) VALUES (2, N'Assistant Professor')
INSERT [dbo].[Designation] ([DesignationId], [DesignationName]) VALUES (3, N'Associate Professor')
INSERT [dbo].[Designation] ([DesignationId], [DesignationName]) VALUES (4, N'Professor')
INSERT [dbo].[Designation] ([DesignationId], [DesignationName]) VALUES (5, N'Chairman')
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[EnrollCourse] ON 

INSERT [dbo].[EnrollCourse] ([EnroolId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [EnrollDate]) VALUES (1, N'ICE-2015-005', N'Afef', N'Afef101@gmail.com', N'ICE', 3, CAST(0x0000A5A700000000 AS DateTime))
INSERT [dbo].[EnrollCourse] ([EnroolId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [EnrollDate]) VALUES (2, N'ICE-2015-001', N'Cheryl Herba', N'sefnj@verizon.net', N'ICE', 4, CAST(0x0000A5AE00000000 AS DateTime))
INSERT [dbo].[EnrollCourse] ([EnroolId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [EnrollDate]) VALUES (3, N'CSE-2016-002', N'Brian Kramer', N'qcaboard@queencity.edu', N'CSE', 2, CAST(0x0000A5A700000000 AS DateTime))
INSERT [dbo].[EnrollCourse] ([EnroolId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [EnrollDate]) VALUES (4, N'CSE-2016-002', N'Brian Kramer', N'qcaboard@queencity.edu', N'CSE', 1, CAST(0x0000A5AE00000000 AS DateTime))
INSERT [dbo].[EnrollCourse] ([EnroolId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [EnrollDate]) VALUES (5, N'BBA-2016-002', N'Rose Johnson', N'dlaf@ramseybank.com', N'BBA', 7, CAST(0x0000A59F00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[EnrollCourse] OFF
SET IDENTITY_INSERT [dbo].[Grade] ON 

INSERT [dbo].[Grade] ([GradeId], [GradeLetter]) VALUES (1, N'A+')
INSERT [dbo].[Grade] ([GradeId], [GradeLetter]) VALUES (2, N'A')
INSERT [dbo].[Grade] ([GradeId], [GradeLetter]) VALUES (3, N'A-')
INSERT [dbo].[Grade] ([GradeId], [GradeLetter]) VALUES (4, N'B+')
INSERT [dbo].[Grade] ([GradeId], [GradeLetter]) VALUES (5, N'B')
INSERT [dbo].[Grade] ([GradeId], [GradeLetter]) VALUES (6, N'B-')
INSERT [dbo].[Grade] ([GradeId], [GradeLetter]) VALUES (7, N'C+')
INSERT [dbo].[Grade] ([GradeId], [GradeLetter]) VALUES (8, N'C')
INSERT [dbo].[Grade] ([GradeId], [GradeLetter]) VALUES (9, N'C-')
INSERT [dbo].[Grade] ([GradeId], [GradeLetter]) VALUES (10, N'D+')
INSERT [dbo].[Grade] ([GradeId], [GradeLetter]) VALUES (11, N'D')
INSERT [dbo].[Grade] ([GradeId], [GradeLetter]) VALUES (12, N'D-')
INSERT [dbo].[Grade] ([GradeId], [GradeLetter]) VALUES (13, N'F')
SET IDENTITY_INSERT [dbo].[Grade] OFF
INSERT [dbo].[RegNo_Info] ([DeptId], [Counter], [Year]) VALUES (N'1', CAST(2 AS Decimal(3, 0)), N'2016')
INSERT [dbo].[RegNo_Info] ([DeptId], [Counter], [Year]) VALUES (N'0', CAST(1 AS Decimal(3, 0)), N'2015')
INSERT [dbo].[RegNo_Info] ([DeptId], [Counter], [Year]) VALUES (N'3', CAST(3 AS Decimal(3, 0)), N'2016')
INSERT [dbo].[RegNo_Info] ([DeptId], [Counter], [Year]) VALUES (N'3', CAST(1 AS Decimal(3, 0)), N'2015')
SET IDENTITY_INSERT [dbo].[Result] ON 

INSERT [dbo].[Result] ([ResultId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [GradeId]) VALUES (1, N'', N'', N'', N'CSE', 2, 2)
INSERT [dbo].[Result] ([ResultId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [GradeId]) VALUES (2, N'', N'', N'', N'CSE', 1, 3)
INSERT [dbo].[Result] ([ResultId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [GradeId]) VALUES (3, N'', N'', N'', N'CSE', 2, 1)
INSERT [dbo].[Result] ([ResultId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [GradeId]) VALUES (4, N'', N'', N'', N'CSE', 0, 0)
INSERT [dbo].[Result] ([ResultId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [GradeId]) VALUES (5, N'', N'', N'', N'CSE', 0, 0)
INSERT [dbo].[Result] ([ResultId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [GradeId]) VALUES (6, N'', N'Cheryl Herba', N'sefnj@verizon.net', N'ICE', 4, 2)
INSERT [dbo].[Result] ([ResultId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [GradeId]) VALUES (7, N'', N'Brian Kramer', N'qcaboard@queencity.edu', N'CSE', 1, 1)
INSERT [dbo].[Result] ([ResultId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [GradeId]) VALUES (8, N'', N'Brian Kramer', N'qcaboard@queencity.edu', N'CSE', 1, 4)
INSERT [dbo].[Result] ([ResultId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [GradeId]) VALUES (9, N'CSE-2016-002', N'Brian Kramer', N'qcaboard@queencity.edu', N'CSE', 2, 1)
INSERT [dbo].[Result] ([ResultId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [GradeId]) VALUES (10, N'CSE-2016-002', N'Brian Kramer', N'qcaboard@queencity.edu', N'CSE', 1, 1)
INSERT [dbo].[Result] ([ResultId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [GradeId]) VALUES (11, N'CSE-2016-002', N'Brian Kramer', N'qcaboard@queencity.edu', N'CSE', 2, 1)
INSERT [dbo].[Result] ([ResultId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [GradeId]) VALUES (12, N'CSE-2016-002', N'Brian Kramer', N'qcaboard@queencity.edu', N'CSE', 1, 1)
INSERT [dbo].[Result] ([ResultId], [RegistrationId], [StudentName], [StudentEmail], [DeptCode], [CourseId], [GradeId]) VALUES (13, N'BBA-2016-002', N'Rose Johnson', N'dlaf@ramseybank.com', N'BBA', 7, 0)
SET IDENTITY_INSERT [dbo].[Result] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([RoomId], [RoomNo]) VALUES (1, N'A-101')
INSERT [dbo].[Room] ([RoomId], [RoomNo]) VALUES (2, N'A-102')
INSERT [dbo].[Room] ([RoomId], [RoomNo]) VALUES (3, N'A-103')
INSERT [dbo].[Room] ([RoomId], [RoomNo]) VALUES (4, N'B-201')
INSERT [dbo].[Room] ([RoomId], [RoomNo]) VALUES (5, N'B-202')
INSERT [dbo].[Room] ([RoomId], [RoomNo]) VALUES (6, N'B-203')
SET IDENTITY_INSERT [dbo].[Room] OFF
SET IDENTITY_INSERT [dbo].[Semester] ON 

INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (1, N'1st ')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (2, N'2nd')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (3, N'3rd')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (4, N'4th')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (5, N'5th')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (6, N'6th')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (7, N'7th')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (8, N'8th')
SET IDENTITY_INSERT [dbo].[Semester] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [ContactNo], [Date], [Address], [DeptId], [RegistationNo]) VALUES (15, N'Brian Kramer', N'qcaboard@queencity.edu', N'9087534700', CAST(0x0000A5A600000000 AS DateTime), N'815 W 7th St', 1, N'CSE-2016-002')
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [ContactNo], [Date], [Address], [DeptId], [RegistationNo]) VALUES (16, N'Brian Kramer', N'questions@humsci.org', N'9087534700', CAST(0x0000A43400000000 AS DateTime), N'815 W 7th St', 0, N'-2015-001')
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [ContactNo], [Date], [Address], [DeptId], [RegistationNo]) VALUES (1009, N'Rose Johnson', N'dlaf@ramseybank.com', N'7016625547', CAST(0x0000A5AD00000000 AS DateTime), N'PO Box 160', 4, N'BBA-2016-002')
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [ContactNo], [Date], [Address], [DeptId], [RegistationNo]) VALUES (1010, N'Patti Elliott', N'p@gmail.com', N'6172913172', CAST(0x0000A5A100000000 AS DateTime), N'P.O. Box 223', 3, N'ICE-2016-001')
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [ContactNo], [Date], [Address], [DeptId], [RegistationNo]) VALUES (1011, N'Cheryl Herba', N'sefnj@verizon.net', N'6172913172', CAST(0x0000A43400000000 AS DateTime), N'P.O. Box 223', 3, N'ICE-2015-001')
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [ContactNo], [Date], [Address], [DeptId], [RegistationNo]) VALUES (1012, N'Brian Kramer', N'rlemoyne@influence1.org', N'9087534700', CAST(0x0000A5A700000000 AS DateTime), N'815 W 7th St', 3, N'ICE-2016-002')
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [ContactNo], [Date], [Address], [DeptId], [RegistationNo]) VALUES (1013, N'Paul Lynskey', N'plynskey@BVeducationfoundation.org', N'5082349090', CAST(0x0000A5A100000000 AS DateTime), N'110 Church Street', 3, N'ICE-2016-003')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [Address], [Email], [ContactNo], [DesignationId], [DeptId], [CreditToBeTaken]) VALUES (1, N'Md.Alam', N'Dhaka', N'alam@gmail.com', N'1236547', 1, 1, 20)
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [Address], [Email], [ContactNo], [DesignationId], [DeptId], [CreditToBeTaken]) VALUES (2, N'Anna Clancy', N'283 County Road', N'email@blueprinteducation.org', N'4012455000', 1, 1, 20)
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [Address], [Email], [ContactNo], [DesignationId], [DeptId], [CreditToBeTaken]) VALUES (3, N'Debra yergen', N'Po Box 1173', N'debra@yakimaschoolsfoundation.org', N'5094570898', 1, 1, 20)
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [Address], [Email], [ContactNo], [DesignationId], [DeptId], [CreditToBeTaken]) VALUES (4, N'Julio Zavaleta', N'4848 S. 2nd Street,', N't@gmail.com', N'6022437788', 2, 3, 15)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[5] 2[27] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "EnrollCourse"
            Begin Extent = 
               Top = 11
               Left = 464
               Bottom = 193
               Right = 634
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Student"
            Begin Extent = 
               Top = 0
               Left = 137
               Bottom = 204
               Right = 339
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Course"
            Begin Extent = 
               Top = 24
               Left = 723
               Bottom = 215
               Right = 912
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EnrollCoursesByRegNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EnrollCoursesByRegNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[34] 4[5] 2[31] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Course"
            Begin Extent = 
               Top = 19
               Left = 331
               Bottom = 222
               Right = 502
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Student"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 268
               Right = 268
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GetCourseCodeByRegNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GetCourseCodeByRegNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Student"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 211
               Right = 239
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Department"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 119
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GetStudentByRegNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GetStudentByRegNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[55] 4[7] 2[13] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AllocationRoom"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 204
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Day"
            Begin Extent = 
               Top = 110
               Left = 289
               Bottom = 205
               Right = 459
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Room"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 101
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewClassSchedule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewClassSchedule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[56] 4[5] 2[13] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Course"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 225
               Right = 227
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Semester"
            Begin Extent = 
               Top = 160
               Left = 550
               Bottom = 254
               Right = 720
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Teacher"
            Begin Extent = 
               Top = 18
               Left = 832
               Bottom = 147
               Right = 1012
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 3105
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewCourseStatic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewCourseStatic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[6] 2[17] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "EnrollCourse"
            Begin Extent = 
               Top = 0
               Left = 362
               Bottom = 183
               Right = 532
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Course"
            Begin Extent = 
               Top = 6
               Left = 570
               Bottom = 135
               Right = 759
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Result"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 209
               Right = 207
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Grade"
            Begin Extent = 
               Top = 104
               Left = 837
               Bottom = 199
               Right = 1007
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1005
         Width = 1500
         Width = 1500
         Width = 1980
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewResultByRegNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewResultByRegNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewResultByRegNo'
GO
USE [master]
GO
ALTER DATABASE [UCRMS_DB] SET  READ_WRITE 
GO
