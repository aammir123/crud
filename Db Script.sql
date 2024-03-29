USE [master]
GO
/****** Object:  Database [TaskDB]    Script Date: 10/1/2019 8:00:51 PM ******/
CREATE DATABASE [TaskDB]

GO
ALTER DATABASE [TaskDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TaskDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TaskDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TaskDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TaskDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TaskDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TaskDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TaskDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TaskDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TaskDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TaskDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TaskDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TaskDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TaskDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TaskDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TaskDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TaskDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TaskDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TaskDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TaskDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TaskDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TaskDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TaskDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TaskDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TaskDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TaskDB] SET  MULTI_USER 
GO
ALTER DATABASE [TaskDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TaskDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TaskDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TaskDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TaskDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TaskDB]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 10/1/2019 8:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[RowId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](max) NULL,
	[Description] [varchar](50) NULL,
	[Active] [int] NOT NULL,
	[CreationDateTime] [datetime] NOT NULL,
	[LastUpdateDateTime] [datetime] NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[RowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/1/2019 8:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[RowId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[Address] [varchar](max) NULL,
	[Description] [varchar](50) NULL,
	[Active] [int] NOT NULL,
	[R_Department] [uniqueidentifier] NULL,
	[CreationDateTime] [datetime] NOT NULL,
	[LastUpdateDateTime] [datetime] NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[RowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Department] ADD  DEFAULT (newid()) FOR [RowId]
GO
ALTER TABLE [dbo].[Department] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Department] ADD  DEFAULT (getdate()) FOR [CreationDateTime]
GO
ALTER TABLE [dbo].[Department] ADD  DEFAULT (getdate()) FOR [LastUpdateDateTime]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (newid()) FOR [RowId]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (getdate()) FOR [CreationDateTime]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (getdate()) FOR [LastUpdateDateTime]
GO
ALTER TABLE [dbo].[User]  WITH NOCHECK ADD  CONSTRAINT [FK_USER_R_Department] FOREIGN KEY([R_Department])
REFERENCES [dbo].[Department] ([RowId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_USER_R_Department]
GO
USE [master]
GO
ALTER DATABASE [TaskDB] SET  READ_WRITE 
GO
