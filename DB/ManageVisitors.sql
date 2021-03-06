USE [master]
GO
/****** Object:  Database [WorkPermitSystem]    Script Date: 20/07/2017 1:37:20 PM ******/
CREATE DATABASE [WorkPermitSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WorkPermitSystem', FILENAME = N'C:\Program Files (x86)\Parallels\Plesk\Databases\MSSQL\MSSQL11.MSSQLSERVER2012\MSSQL\DATA\WorkPermitSystem.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WorkPermitSystem_log', FILENAME = N'C:\Program Files (x86)\Parallels\Plesk\Databases\MSSQL\MSSQL11.MSSQLSERVER2012\MSSQL\DATA\WorkPermitSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WorkPermitSystem] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WorkPermitSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WorkPermitSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WorkPermitSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WorkPermitSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WorkPermitSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WorkPermitSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [WorkPermitSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [WorkPermitSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WorkPermitSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WorkPermitSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WorkPermitSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WorkPermitSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WorkPermitSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WorkPermitSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WorkPermitSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WorkPermitSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WorkPermitSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WorkPermitSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WorkPermitSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WorkPermitSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WorkPermitSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WorkPermitSystem] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [WorkPermitSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WorkPermitSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WorkPermitSystem] SET  MULTI_USER 
GO
ALTER DATABASE [WorkPermitSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WorkPermitSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WorkPermitSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WorkPermitSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [WorkPermitSystem]
GO
/****** Object:  User [WorkPermitSystem4u]    Script Date: 20/07/2017 1:37:24 PM ******/
CREATE USER [WorkPermitSystem4u] FOR LOGIN [WorkPermitSystem4u] WITH DEFAULT_SCHEMA=[WorkPermitSystem4u]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [WorkPermitSystem4u]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [WorkPermitSystem4u]
GO
ALTER ROLE [db_datareader] ADD MEMBER [WorkPermitSystem4u]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [WorkPermitSystem4u]
GO
/****** Object:  Schema [WorkPermitSystem4u]    Script Date: 20/07/2017 1:37:25 PM ******/
CREATE SCHEMA [WorkPermitSystem4u]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 20/07/2017 1:37:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 20/07/2017 1:37:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 20/07/2017 1:37:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 20/07/2017 1:37:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 20/07/2017 1:37:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 20/07/2017 1:37:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_ContractorMaster]    Script Date: 20/07/2017 1:37:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_ContractorMaster](
	[ContractorSrNo] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](max) NULL,
	[ContractorName] [varchar](max) NULL,
	[ContractorContactNo] [varchar](max) NULL,
	[ContractorCreateDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_ContractorMaster] PRIMARY KEY CLUSTERED 
(
	[ContractorSrNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_DepartmentEmployeeRegistration]    Script Date: 20/07/2017 1:37:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_DepartmentEmployeeRegistration](
	[EmployeeSrNo] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeTokenNo] [varchar](max) NOT NULL,
	[DeviceTokenId] [varchar](max) NULL,
	[EmployeeName] [varchar](max) NULL,
	[EmployeeAddress] [varchar](max) NULL,
	[EmployeeContactNo] [varchar](max) NULL,
	[EmployeeEmailID] [varchar](max) NULL,
	[EmployeeDepartmentID] [bigint] NULL,
	[EmployeeDesignationID] [bigint] NULL,
	[EmployeePassword] [varchar](max) NULL,
	[Date] [datetime] NULL CONSTRAINT [DF_tbl_DepartmentEmployeeRegistration_Date]  DEFAULT (getdate()),
 CONSTRAINT [PK_tbl_DepartmentEmployeeRegistration] PRIMARY KEY CLUSTERED 
(
	[EmployeeSrNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_DepartmentMaster]    Script Date: 20/07/2017 1:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_DepartmentMaster](
	[DepartmentID] [bigint] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](max) NOT NULL,
	[DepartmentCreateDate] [datetime] NULL CONSTRAINT [DF_tbl_DepartmentMaster_DepartmentCreateDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_tbl_DepartmentMaster] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_DesignationMaster]    Script Date: 20/07/2017 1:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_DesignationMaster](
	[DesignationID] [bigint] IDENTITY(1,1) NOT NULL,
	[DepartmentID] [bigint] NOT NULL,
	[DesignationName] [varchar](max) NOT NULL,
	[DesignationCreateDate] [datetime] NULL CONSTRAINT [DF_tbl_DesignationMaster_DesignationCreateDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_tbl_DesignationMaster] PRIMARY KEY CLUSTERED 
(
	[DesignationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_RequestProcess]    Script Date: 20/07/2017 1:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_RequestProcess](
	[EmployeeId] [bigint] NULL,
	[RequestProcessSrNo] [bigint] IDENTITY(1,1) NOT NULL,
	[VendorSrNo] [bigint] NULL,
	[EmployeeDepartmentID] [bigint] NULL,
	[VisitStartTime] [datetime] NULL,
	[VisitEndTime] [datetime] NULL,
	[VendorAccessories] [varchar](max) NULL,
	[NoOfVendors] [bigint] NULL,
	[VendorVisitResons] [varchar](max) NULL,
	[RequestProcessDate] [datetime] NULL,
	[ActivityOwnerStatus] [varchar](max) NULL,
	[AreaOwnerStatus] [varchar](max) NULL,
	[SafetyStatus] [varchar](max) NULL,
	[ContractorStatus] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_RequestProcess] PRIMARY KEY CLUSTERED 
(
	[RequestProcessSrNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_VendorUserRegistration]    Script Date: 20/07/2017 1:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_VendorUserRegistration](
	[VendorSrNo] [bigint] IDENTITY(1,1) NOT NULL,
	[VendorUserID] [varchar](max) NOT NULL,
	[DeviceTokenId] [varchar](max) NULL,
	[VendorName] [varchar](max) NULL,
	[VendorAddress] [varchar](max) NULL,
	[VendorContactNo] [varchar](max) NULL,
	[VendorEmailID] [varchar](max) NULL,
	[VendorNatureOfWork] [varchar](max) NULL,
	[VendorContractorSrNo] [bigint] NULL,
	[VendorContractorCoNo] [varchar](max) NULL,
	[VendorPassword] [varchar](max) NULL,
	[VendorRegistrationDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_VendorUserRegistration] PRIMARY KEY CLUSTERED 
(
	[VendorSrNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'88683e49-2409-4225-8e04-275797bb792d', N'managevenders@mahindra.com', 0, N'ALB26sLhrC0abRc8mPrtZYpSUklGRL9FKhL93c3xi33QYjxmIfZT0fCnIkqaL9jacA==', N'f479bea9-d41f-4664-a310-1cedb0de1265', NULL, 0, 0, NULL, 1, 0, N'managevenders@mahindra.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9bc879ac-87c7-479b-9494-59732071ac48', N'dhirajbhalme15@gmail.com', 0, N'AE/aOX8vKIR5jJT/oMZ4UgHsklrp7mIUtA31hefioxqZTVzanoOHxCeJ8B2bFcU9Vw==', N'51ab9be9-de64-43dc-b098-fcebff15439f', NULL, 0, 0, NULL, 1, 0, N'dhirajbhalme15@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9f6de347-d6d7-4247-9da7-a9c9ec8dfbd7', N'Admin@gmail.com', 0, N'ABjvYCO87x22Sa5qmq9OdeCkhidao64ZB4Z4gHzayas5OKCar0hvwvQAs6VFR3pSEQ==', N'685754e3-287e-4592-9c9a-c5a1bde51126', NULL, 0, 0, NULL, 1, 0, N'Admin@gmail.com')
SET IDENTITY_INSERT [dbo].[tbl_ContractorMaster] ON 

INSERT [dbo].[tbl_ContractorMaster] ([ContractorSrNo], [CompanyName], [ContractorName], [ContractorContactNo], [ContractorCreateDate]) VALUES (1, N'CoalTech', N'Abhishek Sen', N'8806418123', CAST(N'2017-05-05 07:02:56.107' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_ContractorMaster] OFF
SET IDENTITY_INSERT [dbo].[tbl_DepartmentEmployeeRegistration] ON 

INSERT [dbo].[tbl_DepartmentEmployeeRegistration] ([EmployeeSrNo], [EmployeeTokenNo], [DeviceTokenId], [EmployeeName], [EmployeeAddress], [EmployeeContactNo], [EmployeeEmailID], [EmployeeDepartmentID], [EmployeeDesignationID], [EmployeePassword], [Date]) VALUES (7, N'20', NULL, N'Priyaranjan Wakankar', N'abcd', N'1236547890', N'priyaranjan@gmail.com', 4, 10, N'1234', CAST(N'2017-07-18 04:51:18.133' AS DateTime))
INSERT [dbo].[tbl_DepartmentEmployeeRegistration] ([EmployeeSrNo], [EmployeeTokenNo], [DeviceTokenId], [EmployeeName], [EmployeeAddress], [EmployeeContactNo], [EmployeeEmailID], [EmployeeDepartmentID], [EmployeeDesignationID], [EmployeePassword], [Date]) VALUES (8, N'21', NULL, N'Nilesh Patil', N'abcd', N'1236547890', N'nilesh@gmail.com', 3, 8, N'1234', CAST(N'2017-07-18 04:52:26.480' AS DateTime))
INSERT [dbo].[tbl_DepartmentEmployeeRegistration] ([EmployeeSrNo], [EmployeeTokenNo], [DeviceTokenId], [EmployeeName], [EmployeeAddress], [EmployeeContactNo], [EmployeeEmailID], [EmployeeDepartmentID], [EmployeeDesignationID], [EmployeePassword], [Date]) VALUES (9, N'22', NULL, N'Ritesh Jain', N'abcd', N'1236547890', N'ritesh@gmail.com', 3, 8, N'1234', CAST(N'2017-07-18 04:54:30.587' AS DateTime))
INSERT [dbo].[tbl_DepartmentEmployeeRegistration] ([EmployeeSrNo], [EmployeeTokenNo], [DeviceTokenId], [EmployeeName], [EmployeeAddress], [EmployeeContactNo], [EmployeeEmailID], [EmployeeDepartmentID], [EmployeeDesignationID], [EmployeePassword], [Date]) VALUES (10, N'23', NULL, N'Shubhomoy Bhardwaj ', N'abcd', N'1236547890', N'shubhomoy@gmail.com', 3, 8, N'1234', CAST(N'2017-07-18 04:55:47.720' AS DateTime))
INSERT [dbo].[tbl_DepartmentEmployeeRegistration] ([EmployeeSrNo], [EmployeeTokenNo], [DeviceTokenId], [EmployeeName], [EmployeeAddress], [EmployeeContactNo], [EmployeeEmailID], [EmployeeDepartmentID], [EmployeeDesignationID], [EmployeePassword], [Date]) VALUES (11, N'24', NULL, N'Anup Zanwar ', N'abcd', N'1236547890', N'anup@gmail.com', 3, 8, N'1234', CAST(N'2017-07-18 04:56:51.877' AS DateTime))
INSERT [dbo].[tbl_DepartmentEmployeeRegistration] ([EmployeeSrNo], [EmployeeTokenNo], [DeviceTokenId], [EmployeeName], [EmployeeAddress], [EmployeeContactNo], [EmployeeEmailID], [EmployeeDepartmentID], [EmployeeDesignationID], [EmployeePassword], [Date]) VALUES (12, N'25', NULL, N'Saurabh  Bisen', N'abcd', N'1236547890', N'saurabh@gmail.com', 3, 7, N'1234', CAST(N'2017-07-18 04:58:21.780' AS DateTime))
INSERT [dbo].[tbl_DepartmentEmployeeRegistration] ([EmployeeSrNo], [EmployeeTokenNo], [DeviceTokenId], [EmployeeName], [EmployeeAddress], [EmployeeContactNo], [EmployeeEmailID], [EmployeeDepartmentID], [EmployeeDesignationID], [EmployeePassword], [Date]) VALUES (13, N'26', NULL, N'Sanket   Doifhode', N'abcd', N'1236547890', N'sanket@gmail.com', 3, 7, N'1234', CAST(N'2017-07-18 04:59:25.957' AS DateTime))
INSERT [dbo].[tbl_DepartmentEmployeeRegistration] ([EmployeeSrNo], [EmployeeTokenNo], [DeviceTokenId], [EmployeeName], [EmployeeAddress], [EmployeeContactNo], [EmployeeEmailID], [EmployeeDepartmentID], [EmployeeDesignationID], [EmployeePassword], [Date]) VALUES (14, N'27', NULL, N'Mangesh  Joshi ', N'abcd', N'1236547890', N'mangesh@gmail.com', 3, 8, N'1234', CAST(N'2017-07-18 05:01:57.867' AS DateTime))
INSERT [dbo].[tbl_DepartmentEmployeeRegistration] ([EmployeeSrNo], [EmployeeTokenNo], [DeviceTokenId], [EmployeeName], [EmployeeAddress], [EmployeeContactNo], [EmployeeEmailID], [EmployeeDepartmentID], [EmployeeDesignationID], [EmployeePassword], [Date]) VALUES (15, N'28', NULL, N'Sandeep Sapkal', N'abcd', N'1236547890', N'sandeep@gmail.com', 3, 7, N'1234', CAST(N'2017-07-18 05:03:32.687' AS DateTime))
INSERT [dbo].[tbl_DepartmentEmployeeRegistration] ([EmployeeSrNo], [EmployeeTokenNo], [DeviceTokenId], [EmployeeName], [EmployeeAddress], [EmployeeContactNo], [EmployeeEmailID], [EmployeeDepartmentID], [EmployeeDesignationID], [EmployeePassword], [Date]) VALUES (16, N'29', NULL, N'Ashwin Meshram', N'abcd', N'1236547890', N'ashwin@gmail.com', 3, 7, N'1234', CAST(N'2017-07-18 05:05:00.197' AS DateTime))
INSERT [dbo].[tbl_DepartmentEmployeeRegistration] ([EmployeeSrNo], [EmployeeTokenNo], [DeviceTokenId], [EmployeeName], [EmployeeAddress], [EmployeeContactNo], [EmployeeEmailID], [EmployeeDepartmentID], [EmployeeDesignationID], [EmployeePassword], [Date]) VALUES (17, N'30', NULL, N'Harshad Papadkar ', N'abcd', N'1236547890', N'harshad@gmail.com', 7, 16, N'1234', CAST(N'2017-07-18 05:07:28.540' AS DateTime))
INSERT [dbo].[tbl_DepartmentEmployeeRegistration] ([EmployeeSrNo], [EmployeeTokenNo], [DeviceTokenId], [EmployeeName], [EmployeeAddress], [EmployeeContactNo], [EmployeeEmailID], [EmployeeDepartmentID], [EmployeeDesignationID], [EmployeePassword], [Date]) VALUES (18, N'31', NULL, N'Manish Gajallewar', N'abcd', N'1236547890', N'manish@gmail.com', 7, 16, N'1234', CAST(N'2017-07-18 05:10:54.623' AS DateTime))
INSERT [dbo].[tbl_DepartmentEmployeeRegistration] ([EmployeeSrNo], [EmployeeTokenNo], [DeviceTokenId], [EmployeeName], [EmployeeAddress], [EmployeeContactNo], [EmployeeEmailID], [EmployeeDepartmentID], [EmployeeDesignationID], [EmployeePassword], [Date]) VALUES (19, N'32', NULL, N'Virag Deshpande', N'abcd', N'1236547890', N'virag@gmail.com', 1, 2, N'1234', CAST(N'2017-07-18 05:12:59.097' AS DateTime))
INSERT [dbo].[tbl_DepartmentEmployeeRegistration] ([EmployeeSrNo], [EmployeeTokenNo], [DeviceTokenId], [EmployeeName], [EmployeeAddress], [EmployeeContactNo], [EmployeeEmailID], [EmployeeDepartmentID], [EmployeeDesignationID], [EmployeePassword], [Date]) VALUES (20, N'33', NULL, N'Bahadur Singh', N'abcd', N'1236547890', N'bahadur@gmail.com', 1, 1, N'1234', CAST(N'2017-07-18 05:15:30.493' AS DateTime))
INSERT [dbo].[tbl_DepartmentEmployeeRegistration] ([EmployeeSrNo], [EmployeeTokenNo], [DeviceTokenId], [EmployeeName], [EmployeeAddress], [EmployeeContactNo], [EmployeeEmailID], [EmployeeDepartmentID], [EmployeeDesignationID], [EmployeePassword], [Date]) VALUES (21, N'35', NULL, N'Amol Raut ', N'abcd', N'1236547890', N'amol@gmail.com', 1, 1, N'1234', CAST(N'2017-07-18 05:16:33.077' AS DateTime))
INSERT [dbo].[tbl_DepartmentEmployeeRegistration] ([EmployeeSrNo], [EmployeeTokenNo], [DeviceTokenId], [EmployeeName], [EmployeeAddress], [EmployeeContactNo], [EmployeeEmailID], [EmployeeDepartmentID], [EmployeeDesignationID], [EmployeePassword], [Date]) VALUES (22, N'2001', N'et6Mm6lzWxA:APA91bEeHYOtIHyALeuqXYeT4dA39ybzinK2uY3aApJogdBWT6Km2NOGr1E8TFlbqIpLYliytj2gL-9vK5BomXOsdrcsyrVX0woLYqSjEW5VKdkBsYJtmvBD-6Gq2wlUtfGjL2yKIGts', N'VIKRAM', N'NEW MANKAPUR', N'85544909492', N'vikramparteki90@gmail.com', 3, 7, N'8554909492', CAST(N'2017-07-19 23:26:28.277' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_DepartmentEmployeeRegistration] OFF
SET IDENTITY_INSERT [dbo].[tbl_DepartmentMaster] ON 

INSERT [dbo].[tbl_DepartmentMaster] ([DepartmentID], [DepartmentName], [DepartmentCreateDate]) VALUES (1, N'Tractor Department', CAST(N'2017-05-05 07:01:28.117' AS DateTime))
INSERT [dbo].[tbl_DepartmentMaster] ([DepartmentID], [DepartmentName], [DepartmentCreateDate]) VALUES (3, N'Central Maintenance ', CAST(N'2017-07-18 04:00:41.810' AS DateTime))
INSERT [dbo].[tbl_DepartmentMaster] ([DepartmentID], [DepartmentName], [DepartmentCreateDate]) VALUES (4, N'Transmission Assembly ', CAST(N'2017-07-18 04:15:35.987' AS DateTime))
INSERT [dbo].[tbl_DepartmentMaster] ([DepartmentID], [DepartmentName], [DepartmentCreateDate]) VALUES (5, N'Transmission Machining ', CAST(N'2017-07-18 04:16:12.877' AS DateTime))
INSERT [dbo].[tbl_DepartmentMaster] ([DepartmentID], [DepartmentName], [DepartmentCreateDate]) VALUES (6, N'Engine Department', CAST(N'2017-07-18 04:17:43.850' AS DateTime))
INSERT [dbo].[tbl_DepartmentMaster] ([DepartmentID], [DepartmentName], [DepartmentCreateDate]) VALUES (7, N'Hydraulic Department', CAST(N'2017-07-18 04:19:29.123' AS DateTime))
INSERT [dbo].[tbl_DepartmentMaster] ([DepartmentID], [DepartmentName], [DepartmentCreateDate]) VALUES (8, N'PTCED', CAST(N'2017-07-18 04:19:55.183' AS DateTime))
INSERT [dbo].[tbl_DepartmentMaster] ([DepartmentID], [DepartmentName], [DepartmentCreateDate]) VALUES (9, N'ALL', CAST(N'2017-07-19 23:46:59.853' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_DepartmentMaster] OFF
SET IDENTITY_INSERT [dbo].[tbl_DesignationMaster] ON 

INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (1, 1, N'Activity Owner', CAST(N'2017-05-05 07:01:29.083' AS DateTime))
INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (2, 1, N'Area Owner', CAST(N'2017-05-05 07:01:29.100' AS DateTime))
INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (6, 1, N'Safety', CAST(N'2017-06-22 01:35:28.490' AS DateTime))
INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (7, 3, N'Activity Owner', CAST(N'2017-07-18 04:00:42.093' AS DateTime))
INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (8, 3, N'Area Owner', CAST(N'2017-07-18 04:00:42.107' AS DateTime))
INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (9, 4, N'Activity Owner', CAST(N'2017-07-18 04:15:37.130' AS DateTime))
INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (10, 4, N'Area Owner', CAST(N'2017-07-18 04:15:37.130' AS DateTime))
INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (11, 5, N'Activity Owner', CAST(N'2017-07-18 04:16:12.877' AS DateTime))
INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (12, 5, N'Area Owner', CAST(N'2017-07-18 04:16:12.893' AS DateTime))
INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (13, 6, N'Activity Owner', CAST(N'2017-07-18 04:17:43.880' AS DateTime))
INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (14, 6, N'Area Owner', CAST(N'2017-07-18 04:17:43.897' AS DateTime))
INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (15, 7, N'Activity Owner', CAST(N'2017-07-18 04:19:29.137' AS DateTime))
INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (16, 7, N'Area Owner', CAST(N'2017-07-18 04:19:29.137' AS DateTime))
INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (17, 8, N'Activity Owner', CAST(N'2017-07-18 04:19:55.183' AS DateTime))
INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (18, 8, N'Area Owner', CAST(N'2017-07-18 04:19:55.183' AS DateTime))
INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (19, 9, N'Activity Owner', CAST(N'2017-07-19 23:46:59.917' AS DateTime))
INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (20, 9, N'Area Owner', CAST(N'2017-07-19 23:46:59.930' AS DateTime))
INSERT [dbo].[tbl_DesignationMaster] ([DesignationID], [DepartmentID], [DesignationName], [DesignationCreateDate]) VALUES (21, 9, N'Safety', CAST(N'2017-07-19 23:47:39.230' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_DesignationMaster] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 20/07/2017 1:37:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 20/07/2017 1:37:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 20/07/2017 1:37:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 20/07/2017 1:37:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 20/07/2017 1:37:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 20/07/2017 1:37:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_RequestProcess] ADD  CONSTRAINT [DF_tbl_RequestProcess_RequestProcessDate]  DEFAULT (getdate()) FOR [RequestProcessDate]
GO
ALTER TABLE [dbo].[tbl_VendorUserRegistration] ADD  CONSTRAINT [DF_tbl_VendorUserRegistration_VendorRegistrationDate]  DEFAULT (getdate()) FOR [VendorRegistrationDate]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[tbl_DepartmentEmployeeRegistration]  WITH CHECK ADD  CONSTRAINT [FK_tbl_DepartmentEmployeeRegistration_tbl_DepartmentMaster] FOREIGN KEY([EmployeeDepartmentID])
REFERENCES [dbo].[tbl_DepartmentMaster] ([DepartmentID])
GO
ALTER TABLE [dbo].[tbl_DepartmentEmployeeRegistration] CHECK CONSTRAINT [FK_tbl_DepartmentEmployeeRegistration_tbl_DepartmentMaster]
GO
ALTER TABLE [dbo].[tbl_DepartmentEmployeeRegistration]  WITH CHECK ADD  CONSTRAINT [FK_tbl_DepartmentEmployeeRegistration_tbl_DesignationMaster] FOREIGN KEY([EmployeeDesignationID])
REFERENCES [dbo].[tbl_DesignationMaster] ([DesignationID])
GO
ALTER TABLE [dbo].[tbl_DepartmentEmployeeRegistration] CHECK CONSTRAINT [FK_tbl_DepartmentEmployeeRegistration_tbl_DesignationMaster]
GO
ALTER TABLE [dbo].[tbl_RequestProcess]  WITH CHECK ADD  CONSTRAINT [FK_tbl_RequestProcess_tbl_DepartmentEmployeeRegistration] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[tbl_DepartmentEmployeeRegistration] ([EmployeeSrNo])
GO
ALTER TABLE [dbo].[tbl_RequestProcess] CHECK CONSTRAINT [FK_tbl_RequestProcess_tbl_DepartmentEmployeeRegistration]
GO
ALTER TABLE [dbo].[tbl_RequestProcess]  WITH CHECK ADD  CONSTRAINT [FK_tbl_RequestProcess_tbl_VendorUserRegistration] FOREIGN KEY([VendorSrNo])
REFERENCES [dbo].[tbl_VendorUserRegistration] ([VendorSrNo])
GO
ALTER TABLE [dbo].[tbl_RequestProcess] CHECK CONSTRAINT [FK_tbl_RequestProcess_tbl_VendorUserRegistration]
GO
USE [master]
GO
ALTER DATABASE [WorkPermitSystem] SET  READ_WRITE 
GO
