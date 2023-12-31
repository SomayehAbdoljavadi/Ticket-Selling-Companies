USE [master]
GO
/****** Object:  Database [DB_Agency]    Script Date: 03/10/2014 22:18:45 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'DB_Agency')
BEGIN
CREATE DATABASE [DB_Agency] ON  PRIMARY 
( NAME = N'DB_Agency', FILENAME = N'D:\DB_Agency.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DB_Agency_log', FILENAME = N'D:\DB_Agency_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END
GO
ALTER DATABASE [DB_Agency] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Agency].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Agency] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [DB_Agency] SET ANSI_NULLS OFF
GO
ALTER DATABASE [DB_Agency] SET ANSI_PADDING OFF
GO
ALTER DATABASE [DB_Agency] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [DB_Agency] SET ARITHABORT OFF
GO
ALTER DATABASE [DB_Agency] SET AUTO_CLOSE ON
GO
ALTER DATABASE [DB_Agency] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [DB_Agency] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [DB_Agency] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [DB_Agency] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [DB_Agency] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [DB_Agency] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [DB_Agency] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [DB_Agency] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [DB_Agency] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [DB_Agency] SET  DISABLE_BROKER
GO
ALTER DATABASE [DB_Agency] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [DB_Agency] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [DB_Agency] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [DB_Agency] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [DB_Agency] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [DB_Agency] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [DB_Agency] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [DB_Agency] SET  READ_WRITE
GO
ALTER DATABASE [DB_Agency] SET RECOVERY SIMPLE
GO
ALTER DATABASE [DB_Agency] SET  MULTI_USER
GO
ALTER DATABASE [DB_Agency] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [DB_Agency] SET DB_CHAINING OFF
GO
USE [DB_Agency]
GO
/****** Object:  User [ali]    Script Date: 03/10/2014 22:18:45 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'ali')
CREATE USER [ali] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[TBTicket]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBTicket]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBTicket](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Member] [int] NOT NULL,
	[Tour] [int] NOT NULL,
 CONSTRAINT [PK_TBTicket] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[TBTicket] ON
INSERT [dbo].[TBTicket] ([ID], [Member], [Tour]) VALUES (1, 1, 4)
SET IDENTITY_INSERT [dbo].[TBTicket] OFF
/****** Object:  Table [dbo].[TBMembers]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBMembers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBMembers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](450) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[GoogleEmail] [nvarchar](max) NULL,
	[YahooEmail] [nvarchar](max) NULL,
	[MSNEmail] [nvarchar](max) NULL,
	[OtherEmail] [nvarchar](max) NULL,
	[DisplayName] [nvarchar](50) NULL,
 CONSTRAINT [PK_TBMembers_1] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[TBMembers] ON
INSERT [dbo].[TBMembers] ([ID], [Username], [Password], [GoogleEmail], [YahooEmail], [MSNEmail], [OtherEmail], [DisplayName]) VALUES (1, N'admin', N'e10adc3949ba59abbe56e057f20f883e', N'alinaseri25@gmail.com', N'alinaseri_mil@yahoo.com', N'alinaseri25@hotmail.com', N'ندارم', N'علی ناصری میل کاریز')
SET IDENTITY_INSERT [dbo].[TBMembers] OFF
/****** Object:  Table [dbo].[TBHotelStars]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBHotelStars]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBHotelStars](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TBHotelStars] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[TBHotelStars] ON
INSERT [dbo].[TBHotelStars] ([ID], [Caption]) VALUES (1, N'یک ستاره')
INSERT [dbo].[TBHotelStars] ([ID], [Caption]) VALUES (2, N'دو ستاره')
INSERT [dbo].[TBHotelStars] ([ID], [Caption]) VALUES (3, N'سه ستاره')
INSERT [dbo].[TBHotelStars] ([ID], [Caption]) VALUES (4, N'چهار ستاره')
INSERT [dbo].[TBHotelStars] ([ID], [Caption]) VALUES (5, N'پنچ ستاره')
INSERT [dbo].[TBHotelStars] ([ID], [Caption]) VALUES (6, N'شش ستاره')
SET IDENTITY_INSERT [dbo].[TBHotelStars] OFF
/****** Object:  Table [dbo].[TBDevice]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBDevice]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBDevice](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TBDevice] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TBDevice] ON
INSERT [dbo].[TBDevice] ([id], [Name]) VALUES (1, N'هواپيما')
INSERT [dbo].[TBDevice] ([id], [Name]) VALUES (2, N'قطار')
INSERT [dbo].[TBDevice] ([id], [Name]) VALUES (3, N'اتوبوس')
INSERT [dbo].[TBDevice] ([id], [Name]) VALUES (4, N'خودرو')
SET IDENTITY_INSERT [dbo].[TBDevice] OFF
/****** Object:  Table [dbo].[TBCountry]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBCountry]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBCountry](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Capital] [int] NULL,
 CONSTRAINT [PK_TBCountry] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[TBCountry] ON
INSERT [dbo].[TBCountry] ([ID], [Name], [Capital]) VALUES (1, N'ایران', 4)
INSERT [dbo].[TBCountry] ([ID], [Name], [Capital]) VALUES (2, N'USA', 3)
SET IDENTITY_INSERT [dbo].[TBCountry] OFF
/****** Object:  Table [dbo].[FilterOperators]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FilterOperators]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FilterOperators](
	[code] [int] NOT NULL,
	[text] [nvarchar](max) NOT NULL
) ON [PRIMARY]
END
GO
INSERT [dbo].[FilterOperators] ([code], [text]) VALUES (0, N'= var')
INSERT [dbo].[FilterOperators] ([code], [text]) VALUES (1, N'!= var')
INSERT [dbo].[FilterOperators] ([code], [text]) VALUES (2, N'> var')
INSERT [dbo].[FilterOperators] ([code], [text]) VALUES (3, N'>= var')
INSERT [dbo].[FilterOperators] ([code], [text]) VALUES (4, N'< var')
INSERT [dbo].[FilterOperators] ([code], [text]) VALUES (5, N'<= var')
INSERT [dbo].[FilterOperators] ([code], [text]) VALUES (6, N'LIKE ''%var%''')
INSERT [dbo].[FilterOperators] ([code], [text]) VALUES (7, N'Nothing')
INSERT [dbo].[FilterOperators] ([code], [text]) VALUES (8, N'LIKE ''%var''')
INSERT [dbo].[FilterOperators] ([code], [text]) VALUES (9, N'LIKE ''var%''')
INSERT [dbo].[FilterOperators] ([code], [text]) VALUES (10, N'= ''var''')
INSERT [dbo].[FilterOperators] ([code], [text]) VALUES (11, N'!= ''var''')
INSERT [dbo].[FilterOperators] ([code], [text]) VALUES (12, N'> ''var''')
INSERT [dbo].[FilterOperators] ([code], [text]) VALUES (13, N'>= ''var''')
INSERT [dbo].[FilterOperators] ([code], [text]) VALUES (14, N'< ''var''')
INSERT [dbo].[FilterOperators] ([code], [text]) VALUES (15, N'<= ''var''')
/****** Object:  UserDefinedFunction [dbo].[fnSplit]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnSplit]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'Create  FUNCTION [dbo].[fnSplit](
    @sInputList VARCHAR(8000) -- List of delimited items
  , @sDelimiter VARCHAR(8000) = ''-'' -- delimiter that separates items
) RETURNS @List TABLE (ID int ,item VARCHAR(8000))

BEGIN
DECLARE @sItem VARCHAR(8000),@Id int
SET @Id = 0
WHILE CHARINDEX(@sDelimiter,@sInputList,0) <> 0
BEGIN
SELECT
  @sItem=RTRIM(LTRIM(SUBSTRING(@sInputList,1,CHARINDEX(@sDelimiter,@sInputList,0)-1))),
  @sInputList=RTRIM(LTRIM(SUBSTRING(@sInputList,CHARINDEX(@sDelimiter,@sInputList,0)+LEN(@sDelimiter),LEN(@sInputList))))

 IF LEN(@sItem) > 0
  SET @Id = @Id + 1	
  INSERT INTO @List SELECT @Id,@sItem
 END

IF LEN(@sInputList) > 0
 SET @Id = @Id + 1
 INSERT INTO @List SELECT @Id,@sInputList -- Put the last item in
RETURN
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBHotelStars_Insert]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBHotelStars_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBHotelStars_Insert]
		@ID int = null,
		@Caption nvarchar(max) = null
AS
BEGIN
	INSERT INTO TBHotelStars
		([Caption])
	VALUES
		(@Caption)

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBHotelStars_Delete]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBHotelStars_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBHotelStars_Delete]
		@ID int
AS
BEGIN
	DELETE FROM TBHotelStars
WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBCountry_Update]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBCountry_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBCountry_Update]
		@ID int = null,
		@Name nvarchar(max) = null,
		@Capital int = null
AS
BEGIN
	UPDATE TBCountry
	SET [Name] = @Name,[Capital] = @Capital
	WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBCountry_SelectById]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBCountry_SelectById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBCountry_SelectById]
		@ID int
AS
BEGIN
	SELECT * FROM TBCountry
WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBCountry_Insert]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBCountry_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBCountry_Insert]
		@ID int = null,
		@Name nvarchar(max) = null,
		@Capital int = null
AS
BEGIN
	INSERT INTO TBCountry
		([Name],[Capital])
	VALUES
		(@Name,@Capital)

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBCountry_Delete]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBCountry_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBCountry_Delete]
		@ID int
AS
BEGIN
	DELETE FROM TBCountry
WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[FnCreateSelectSql]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FnCreateSelectSql]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'Create FUNCTION [dbo].[FnCreateSelectSql] 
(
@Fields nvarchar(MAX) = null,
   @TableName nvarchar(max),
	@Data nvarchar(MAX),
	@Parameters nvarchar(MAX),
	@Filters nvarchar(MAX)
)
RETURNS nvarchar(MAX)
AS
BEGIN
declare @Sql nvarchar(MAX),@ParamName nvarchar(MAX),@Operand nvarchar(MAX),@DataValue nvarchar(MAX),@i int,@FieldSql nvarchar(MAX);
SET @Sql = '' WHERE  1 = 1''; 
SET @i = 0;
if(isnull(@Fields,''null'') = ''null'')
BEGIN
SET @FieldSql = ''SELECT * '';
END
ELSE
BEGIN
SET @FieldSql = ''SELECT '';
DECLARE FieldsSelect CURSOR FOR SELECT parameter.item,Fields.item FROM dbo.fnSplit(@Fields, ''-'') AS parameter INNER JOIN dbo.fnSplit(@Parameters, ''-'') AS Fields ON parameter.id = Fields.id
OPEN FieldsSelect
FETCH NEXT FROM FieldsSelect INTO @ParamName,@DataValue
WHILE @@FETCH_STATUS = 0
BEGIN
IF (@ParamName != ''0'')
BEGIN
if(@i > 0 )
BEGIN
SET @FieldSql = @FieldSql + '','' + @DataValue;
END
ELSE
BEGIN
SET @FieldSql = @FieldSql + @DataValue;
END
SET @i = @i + 1;
END
FETCH NEXT FROM FieldsSelect INTO @ParamName,@DataValue
END;
CLOSE FieldsSelect;
DEALLOCATE FieldsSelect;
END
DECLARE Filters CURSOR FOR SELECT p.item,filter.[text],data.item FROM dbo.fnSplit(@Filters, ''-'') AS d INNER JOIN FilterOperators AS filter ON d.item = filter.code LEFT JOIN dbo.fnSplit(@Parameters, ''-'') AS p ON p.ID = d.ID LEFT JOIN dbo.fnSplit(@Data, ''-'') AS data ON p.ID = data.ID
OPEN Filters;
FETCH NEXT FROM Filters INTO @ParamName,@Operand,@DataValue
WHILE @@FETCH_STATUS = 0
BEGIN
IF (@Operand != ''Nothing'' and @DataValue != ''NuLl'')
BEGIN
SET @Operand = REPLACE(@Operand,''var'', @DataValue)
SET @Sql = @Sql + '' AND '' + @ParamName + '' '' + @Operand 
END
FETCH NEXT FROM Filters INTO @ParamName,@Operand,@DataValue
END;
CLOSE Filters;
DEALLOCATE Filters;
RETURN   @FieldSql + '' FROM ['' + @TableName + '']'' +  @Sql;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_FilterOperators_Insert]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_FilterOperators_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_FilterOperators_Insert]
		@code int = null,
		@text nvarchar(max) = null
AS
BEGIN
	INSERT INTO FilterOperators
		([text])
	VALUES
		(@text)

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_FilterOperators_Delete]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_FilterOperators_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_FilterOperators_Delete]
		@code int
AS
BEGIN
	DELETE FROM FilterOperators
WHERE [code] = @code
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_FilterOperators_Update]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_FilterOperators_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_FilterOperators_Update]
		@code int = null,
		@text nvarchar(max) = null
AS
BEGIN
	UPDATE FilterOperators
	SET [text] = @text
	WHERE [code] = @code
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_FilterOperators_SelectById]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_FilterOperators_SelectById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_FilterOperators_SelectById]
		@code int
AS
BEGIN
	SELECT * FROM FilterOperators
WHERE [code] = @code
END
' 
END
GO
/****** Object:  Table [dbo].[TBCity]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBCity]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBCity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TBCity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[TBCity] ON
INSERT [dbo].[TBCity] ([ID], [CountryID], [Name]) VALUES (1, 1, N'مشهد مقدس')
INSERT [dbo].[TBCity] ([ID], [CountryID], [Name]) VALUES (3, 2, N'New York')
INSERT [dbo].[TBCity] ([ID], [CountryID], [Name]) VALUES (4, 1, N'تهران')
INSERT [dbo].[TBCity] ([ID], [CountryID], [Name]) VALUES (5, 1, N'اصفهان')
SET IDENTITY_INSERT [dbo].[TBCity] OFF
/****** Object:  Table [dbo].[TBAirPlane]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBAirPlane]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBAirPlane](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[MadeIn] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[DevId] [int] NOT NULL,
 CONSTRAINT [PK_TBAirPlane] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[TBAirPlane] ON
INSERT [dbo].[TBAirPlane] ([ID], [Name], [MadeIn], [Description], [DevId]) VALUES (2, N'Air Bus A380', 2, N'The A380 has been winning over business and leisure passengers alike since its service introduction in 2007, providing levels of comfort and reliability that have led travelers to specifically request flights on Airbus’ 21st century flagship – which is in operation with carriers around the globe. ', 1)
INSERT [dbo].[TBAirPlane] ([ID], [Name], [MadeIn], [Description], [DevId]) VALUES (3, N'Air Bus A320', 2, N'The A320 single-aisle jetliner family (composed of the A318, A319, A320 and A321) is the undisputed best-selling aircraft product line of all time. It is used in a full range of services from very short-haul airline routes to intercontinental segments, on operations from challenging in-city airports to high-altitude airfields and an Antarctic ice runway, and on VVIP and government missions with the most discerning passengers. ', 1)
INSERT [dbo].[TBAirPlane] ([ID], [Name], [MadeIn], [Description], [DevId]) VALUES (6, N'Boeing 737', 2, N'The 737 airborne early warning and control (AEW&C) system encompasses both the Boeing 737-700 aircraft platform and a variety of aircraft control and advanced radar systems. Consisting of components created by Boeing and Northrop Grumman, the 737 AEW&C represents the standard for future airborne early warning systems.', 1)
INSERT [dbo].[TBAirPlane] ([ID], [Name], [MadeIn], [Description], [DevId]) VALUES (7, N'Boeing 747-8', 2, N'The Boeing 747-8 Intercontinental and 747-8 Freighter are the new, high-capacity 747s that offer airlines the lowest operating costs and best economics of any large passenger or freighter aeroplane-while providing enhanced environmental performance.', 1)
INSERT [dbo].[TBAirPlane] ([ID], [Name], [MadeIn], [Description], [DevId]) VALUES (8, N'قطار رجا', 1, N'قطار درجه یک ایرانی', 2)
INSERT [dbo].[TBAirPlane] ([ID], [Name], [MadeIn], [Description], [DevId]) VALUES (9, N'ولوو', 2, N'اتوبوس مسافر بری', 3)
INSERT [dbo].[TBAirPlane] ([ID], [Name], [MadeIn], [Description], [DevId]) VALUES (10, N'اسکانیا', 2, N'اتوبوس مسافر بری', 3)
INSERT [dbo].[TBAirPlane] ([ID], [Name], [MadeIn], [Description], [DevId]) VALUES (11, N'سمند', 1, N'خودروی سواری', 4)
SET IDENTITY_INSERT [dbo].[TBAirPlane] OFF
/****** Object:  StoredProcedure [dbo].[sp_TBTicket_Update]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBTicket_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBTicket_Update]
		@ID int = null,
		@Member int = null,
		@Tour int = null
AS
BEGIN
	UPDATE TBTicket
	SET [Member] = @Member,[Tour] = @Tour
	WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBTicket_SelectById]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBTicket_SelectById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBTicket_SelectById]
		@ID int
AS
BEGIN
	SELECT * FROM TBTicket
WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBMembers_Insert]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBMembers_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBMembers_Insert]
		@ID int = null,
		@Username nvarchar(max) = null,
		@Password nvarchar(max) = null,
		@GoogleEmail nvarchar(max) = null,
		@YahooEmail nvarchar(max) = null,
		@MSNEmail nvarchar(max) = null,
		@OtherEmail nvarchar(max) = null,
		@DisplayName nvarchar(max) = null
AS
BEGIN
	INSERT INTO TBMembers
		([Username],[Password],[GoogleEmail],[YahooEmail],[MSNEmail],[OtherEmail],[DisplayName])
	VALUES
		(@Username,@Password,@GoogleEmail,@YahooEmail,@MSNEmail,@OtherEmail,@DisplayName)

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBMembers_Delete]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBMembers_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBMembers_Delete]
		@ID int
AS
BEGIN
	DELETE FROM TBMembers
WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBHotelStars_Update]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBHotelStars_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBHotelStars_Update]
		@ID int = null,
		@Caption nvarchar(max) = null
AS
BEGIN
	UPDATE TBHotelStars
	SET [Caption] = @Caption
	WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBHotelStars_SelectById]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBHotelStars_SelectById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBHotelStars_SelectById]
		@ID int
AS
BEGIN
	SELECT * FROM TBHotelStars
WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBTicket_Insert]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBTicket_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBTicket_Insert]
		@ID int = null,
		@Member int = null,
		@Tour int = null
AS
BEGIN
	INSERT INTO TBTicket
		([Member],[Tour])
	VALUES
		(@Member,@Tour)

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBTicket_Delete]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBTicket_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBTicket_Delete]
		@ID int
AS
BEGIN
	DELETE FROM TBTicket
WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBMembers_Update]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBMembers_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBMembers_Update]
		@ID int = null,
		@Username nvarchar(max) = null,
		@Password nvarchar(max) = null,
		@GoogleEmail nvarchar(max) = null,
		@YahooEmail nvarchar(max) = null,
		@MSNEmail nvarchar(max) = null,
		@OtherEmail nvarchar(max) = null,
		@DisplayName nvarchar(max) = null
AS
BEGIN
	UPDATE TBMembers
	SET [Username] = @Username,[Password] = @Password,[GoogleEmail] = @GoogleEmail,[YahooEmail] = @YahooEmail,[MSNEmail] = @MSNEmail,[OtherEmail] = @OtherEmail,[DisplayName] = @DisplayName
	WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBMembers_SelectById]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBMembers_SelectById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBMembers_SelectById]
		@ID int
AS
BEGIN
	SELECT * FROM TBMembers
WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBMembers_Select]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBMembers_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBMembers_Select]
		@ID int = NULL,
		@Username nvarchar(max) = NULL,
		@Password nvarchar(max) = NULL,
		@GoogleEmail nvarchar(max) = NULL,
		@YahooEmail nvarchar(max) = NULL,
		@MSNEmail nvarchar(max) = NULL,
		@OtherEmail nvarchar(max) = NULL,
		@DisplayName nvarchar(max) = NULL,
		@filter nvarchar(max),
		@Fields nvarchar(max) = null
AS
BEGIN
	declare @Sql nvarchar(MAX),@Data nvarchar(MAX)
	if(ISNULL(@ID,''0'') != ''0'')
	BEGIN
		SET @Data = CAST( @ID AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = ''NuLl'' + ''-''
	END
	if(ISNULL(@Username,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Username AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@Password,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Password AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@GoogleEmail,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @GoogleEmail AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@YahooEmail,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @YahooEmail AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@MSNEmail,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @MSNEmail AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@OtherEmail,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @OtherEmail AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@DisplayName,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @DisplayName AS NVARCHAR(MAX) )
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl''
	END
	SET @Sql = [dbo].[FnCreateSelectSql](@Fields,''TBMembers'',@Data,''ID-Username-Password-GoogleEmail-YahooEmail-MSNEmail-OtherEmail-DisplayName'',@filter)
	exec (@sql)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBHotelStars_Select]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBHotelStars_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBHotelStars_Select]
		@ID int = NULL,
		@Caption nvarchar(max) = NULL,
		@filter nvarchar(max),
		@Fields nvarchar(max) = null
AS
BEGIN
	declare @Sql nvarchar(MAX),@Data nvarchar(MAX)
	if(ISNULL(@ID,''0'') != ''0'')
	BEGIN
		SET @Data = CAST( @ID AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = ''NuLl'' + ''-''
	END
	if(ISNULL(@Caption,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Caption AS NVARCHAR(MAX) )
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl''
	END
	SET @Sql = [dbo].[FnCreateSelectSql](@Fields,''TBHotelStars'',@Data,''ID-Caption'',@filter)
	exec (@sql)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBTicket_Select]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBTicket_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBTicket_Select]
		@ID int = NULL,
		@Member int = NULL,
		@Tour int = NULL,
		@filter nvarchar(max),
		@Fields nvarchar(max) = null
AS
BEGIN
	declare @Sql nvarchar(MAX),@Data nvarchar(MAX)
	if(ISNULL(@ID,''0'') != ''0'')
	BEGIN
		SET @Data = CAST( @ID AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = ''NuLl'' + ''-''
	END
	if(ISNULL(@Member,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Member AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@Tour,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Tour AS NVARCHAR(MAX) )
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl''
	END
	SET @Sql = [dbo].[FnCreateSelectSql](@Fields,''TBTicket'',@Data,''ID-Member-Tour'',@filter)
	exec (@sql)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBTour_Select]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBTour_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBTour_Select]
		@ID int = NULL,
		@Name nvarchar(max) = NULL,
		@Hotel int = NULL,
		@AirPlane int = NULL,
		@Price nvarchar(max) = NULL,
		@LengthDays int = NULL,
		@lengthNights int = NULL,
		@City int = NULL,
		@Date varchar(max) = NULL,
		@filter nvarchar(max),
		@Fields nvarchar(max) = null
AS
BEGIN
	declare @Sql nvarchar(MAX),@Data nvarchar(MAX)
	if(ISNULL(@ID,''0'') != ''0'')
	BEGIN
		SET @Data = CAST( @ID AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = ''NuLl'' + ''-''
	END
	if(ISNULL(@Name,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Name AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@Hotel,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Hotel AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@AirPlane,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @AirPlane AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@Price,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Price AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@LengthDays,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @LengthDays AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@lengthNights,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @lengthNights AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@City,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @City AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@Date,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Date AS NVARCHAR(MAX) )
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl''
	END
	SET @Sql = [dbo].[FnCreateSelectSql](@Fields,''TBTour'',@Data,''ID-Name-Hotel-AirPlane-Price-LengthDays-lengthNights-City-Date'',@filter)
	exec (@sql)
END
' 
END
GO
/****** Object:  Table [dbo].[TBHotel]    Script Date: 03/10/2014 22:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBHotel]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBHotel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Stars] [int] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[City] [int] NULL,
	[Tell] [varchar](14) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_TBHotel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TBHotel] ON
INSERT [dbo].[TBHotel] ([ID], [Name], [Stars], [Address], [City], [Tell], [Description]) VALUES (2, N'هتل بزرگ تهران', 4, N'ندارد', 4, N'0', N'wefsaf sdsad asd ')
SET IDENTITY_INSERT [dbo].[TBHotel] OFF
/****** Object:  StoredProcedure [dbo].[sp_FilterOperators_Select]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_FilterOperators_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_FilterOperators_Select]
		@code int = NULL,
		@text nvarchar(max) = NULL,
		@filter nvarchar(max),
		@Fields nvarchar(max) = null
AS
BEGIN
	declare @Sql nvarchar(MAX),@Data nvarchar(MAX)
	if(ISNULL(@code,''0'') != ''0'')
	BEGIN
		SET @Data = CAST( @code AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = ''NuLl'' + ''-''
	END
	if(ISNULL(@text,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @text AS NVARCHAR(MAX) )
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl''
	END
	SET @Sql = [dbo].[FnCreateSelectSql](@Fields,''FilterOperators'',@Data,''code-text'',@filter)
	exec (@sql)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBCity_Update]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBCity_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBCity_Update]
		@ID int = null,
		@CountryID int = null,
		@Name nvarchar(max) = null
AS
BEGIN
	UPDATE TBCity
	SET [CountryID] = @CountryID,[Name] = @Name
	WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBCity_SelectById]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBCity_SelectById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBCity_SelectById]
		@ID int
AS
BEGIN
	SELECT * FROM TBCity
WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBCity_Select]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBCity_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBCity_Select]
		@ID int = NULL,
		@CountryID int = NULL,
		@Name nvarchar(max) = NULL,
		@filter nvarchar(max),
		@Fields nvarchar(max) = null
AS
BEGIN
	declare @Sql nvarchar(MAX),@Data nvarchar(MAX)
	if(ISNULL(@ID,''0'') != ''0'')
	BEGIN
		SET @Data = CAST( @ID AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = ''NuLl'' + ''-''
	END
	if(ISNULL(@CountryID,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @CountryID AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@Name,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Name AS NVARCHAR(MAX) )
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl''
	END
	SET @Sql = [dbo].[FnCreateSelectSql](@Fields,''TBCity'',@Data,''ID-CountryID-Name'',@filter)
	exec (@sql)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBCity_Insert]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBCity_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBCity_Insert]
		@ID int = null,
		@CountryID int = null,
		@Name nvarchar(max) = null
AS
BEGIN
	INSERT INTO TBCity
		([CountryID],[Name])
	VALUES
		(@CountryID,@Name)

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBCity_Delete]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBCity_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBCity_Delete]
		@ID int
AS
BEGIN
	DELETE FROM TBCity
WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBAirPlane_Update]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBAirPlane_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBAirPlane_Update]
		@ID int = null,
		@Name nvarchar(max) = null,
		@MadeIn int = null,
		@Description nvarchar(max) = null
AS
BEGIN
	UPDATE TBAirPlane
	SET [Name] = @Name,[MadeIn] = @MadeIn,[Description] = @Description
	WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBAirPlane_SelectById]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBAirPlane_SelectById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBAirPlane_SelectById]
		@ID int
AS
BEGIN
	SELECT * FROM TBAirPlane
WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBAirPlane_Select]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBAirPlane_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBAirPlane_Select]
		@ID int = NULL,
		@Name nvarchar(max) = NULL,
		@MadeIn int = NULL,
		@Description nvarchar(max) = NULL,
		@filter nvarchar(max),
		@Fields nvarchar(max) = null
AS
BEGIN
	declare @Sql nvarchar(MAX),@Data nvarchar(MAX)
	if(ISNULL(@ID,''0'') != ''0'')
	BEGIN
		SET @Data = CAST( @ID AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = ''NuLl'' + ''-''
	END
	if(ISNULL(@Name,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Name AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@MadeIn,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @MadeIn AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@Description,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Description AS NVARCHAR(MAX) )
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl''
	END
	SET @Sql = [dbo].[FnCreateSelectSql](@Fields,''TBAirPlane'',@Data,''ID-Name-MadeIn-Description'',@filter)
	exec (@sql)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBAirPlane_Insert]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBAirPlane_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBAirPlane_Insert]
		@ID int = null,
		@Name nvarchar(max) = null,
		@MadeIn int = null,
		@Description nvarchar(max) = null
AS
BEGIN
	INSERT INTO TBAirPlane
		([Name],[MadeIn],[Description])
	VALUES
		(@Name,@MadeIn,@Description)

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBAirPlane_Delete]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBAirPlane_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBAirPlane_Delete]
		@ID int
AS
BEGIN
	DELETE FROM TBAirPlane
WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBCountry_Select]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBCountry_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBCountry_Select]
		@ID int = NULL,
		@Name nvarchar(max) = NULL,
		@Capital int = NULL,
		@filter nvarchar(max),
		@Fields nvarchar(max) = null
AS
BEGIN
	declare @Sql nvarchar(MAX),@Data nvarchar(MAX)
	if(ISNULL(@ID,''0'') != ''0'')
	BEGIN
		SET @Data = CAST( @ID AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = ''NuLl'' + ''-''
	END
	if(ISNULL(@Name,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Name AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@Capital,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Capital AS NVARCHAR(MAX) )
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl''
	END
	SET @Sql = [dbo].[FnCreateSelectSql](@Fields,''TBCountry'',@Data,''ID-Name-Capital'',@filter)
	exec (@sql)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBHotel_Select]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBHotel_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBHotel_Select]
		@ID int = NULL,
		@Name nvarchar(max) = NULL,
		@Stars int = NULL,
		@Address nvarchar(max) = NULL,
		@City int = NULL,
		@Tell varchar = NULL,
		@Description nvarchar(max) = NULL,
		@filter nvarchar(max),
		@Fields nvarchar(max) = null
AS
BEGIN
	declare @Sql nvarchar(MAX),@Data nvarchar(MAX)
	if(ISNULL(@ID,''0'') != ''0'')
	BEGIN
		SET @Data = CAST( @ID AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = ''NuLl'' + ''-''
	END
	if(ISNULL(@Name,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Name AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@Stars,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Stars AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@Address,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Address AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@City,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @City AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@Tell,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Tell AS NVARCHAR(MAX) ) + ''-''
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl'' + ''-''
	END
	if(ISNULL(@Description,''0'') != ''0'')
	BEGIN
		SET @Data = @Data + CAST( @Description AS NVARCHAR(MAX) )
	END
	ELSE
	BEGIN
		SET @Data = @Data + ''NuLl''
	END
	SET @Sql = [dbo].[FnCreateSelectSql](@Fields,''TBHotel'',@Data,''ID-Name-Stars-Address-City-Tell-Description'',@filter)
	exec (@sql)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBHotel_Update]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBHotel_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBHotel_Update]
		@ID int = null,
		@Name nvarchar(max) = null,
		@Stars int = null,
		@Address nvarchar(max) = null,
		@City int = null,
		@Tell varchar = null,
		@Description nvarchar(max) = null
AS
BEGIN
	UPDATE TBHotel
	SET [Name] = @Name,[Stars] = @Stars,[Address] = @Address,[City] = @City,[Tell] = @Tell,[Description] = @Description
	WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBHotel_SelectById]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBHotel_SelectById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBHotel_SelectById]
		@ID int
AS
BEGIN
	SELECT * FROM TBHotel
WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBHotel_Insert]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBHotel_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBHotel_Insert]
		@ID int = null,
		@Name nvarchar(max) = null,
		@Stars int = null,
		@Address nvarchar(max) = null,
		@City int = null,
		@Tell varchar = null,
		@Description nvarchar(max) = null
AS
BEGIN
	INSERT INTO TBHotel
		([Name],[Stars],[Address],[City],[Tell],[Description])
	VALUES
		(@Name,@Stars,@Address,@City,@Tell,@Description)

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBHotel_Delete]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBHotel_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBHotel_Delete]
		@ID int
AS
BEGIN
	DELETE FROM TBHotel
WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  Table [dbo].[TBTour]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBTour]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBTour](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Hotel] [int] NOT NULL,
	[AirPlane] [int] NOT NULL,
	[Price] [nvarchar](20) NOT NULL,
	[LengthDays] [int] NOT NULL,
	[lengthNights] [int] NOT NULL,
	[City] [int] NOT NULL,
	[Date] [varchar](10) NOT NULL,
 CONSTRAINT [PK_TBTour] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TBTour] ON
INSERT [dbo].[TBTour] ([ID], [Name], [Hotel], [AirPlane], [Price], [LengthDays], [lengthNights], [City], [Date]) VALUES (4, N'test', 2, 6, N'300000', 3, 4, 4, N'1391-01-01')
SET IDENTITY_INSERT [dbo].[TBTour] OFF
/****** Object:  StoredProcedure [dbo].[sp_TBTour_Insert]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBTour_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBTour_Insert]
		@ID int = null,
		@Name nvarchar(max) = null,
		@Hotel int = null,
		@AirPlane int = null,
		@Price nvarchar(max) = null,
		@LengthDays int = null,
		@lengthNights int = null,
		@City int = null,
		@Date varchar(max) = null
AS
BEGIN
	INSERT INTO TBTour
		([Name],[Hotel],[AirPlane],[Price],[LengthDays],[lengthNights],[City],[Date])
	VALUES
		(@Name,@Hotel,@AirPlane,@Price,@LengthDays,@lengthNights,@City,@Date)

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBTour_Delete]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBTour_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBTour_Delete]
		@ID int
AS
BEGIN
	DELETE FROM TBTour
WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBTour_Update]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBTour_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBTour_Update]
		@ID int = null,
		@Name nvarchar(max) = null,
		@Hotel int = null,
		@AirPlane int = null,
		@Price nvarchar(max) = null,
		@LengthDays int = null,
		@lengthNights int = null,
		@City int = null,
		@Date varchar(max) = null
AS
BEGIN
	UPDATE TBTour
	SET [Name] = @Name,[Hotel] = @Hotel,[AirPlane] = @AirPlane,[Price] = @Price,[LengthDays] = @LengthDays,[lengthNights] = @lengthNights,[City] = @City,[Date] = @Date
	WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TBTour_SelectById]    Script Date: 03/10/2014 22:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_TBTour_SelectById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_TBTour_SelectById]
		@ID int
AS
BEGIN
	SELECT * FROM TBTour
WHERE [ID] = @ID
END
' 
END
GO
/****** Object:  Default [DF_TBTicket_Member]    Script Date: 03/10/2014 22:18:45 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_TBTicket_Member]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBTicket]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TBTicket_Member]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBTicket] ADD  CONSTRAINT [DF_TBTicket_Member]  DEFAULT ((0)) FOR [Member]
END


End
GO
/****** Object:  Default [DF_TBTicket_Tour]    Script Date: 03/10/2014 22:18:45 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_TBTicket_Tour]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBTicket]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TBTicket_Tour]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBTicket] ADD  CONSTRAINT [DF_TBTicket_Tour]  DEFAULT ((0)) FOR [Tour]
END


End
GO
/****** Object:  Default [DF_TBAirPlane_MadeIn]    Script Date: 03/10/2014 22:18:45 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_TBAirPlane_MadeIn]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBAirPlane]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TBAirPlane_MadeIn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBAirPlane] ADD  CONSTRAINT [DF_TBAirPlane_MadeIn]  DEFAULT ((0)) FOR [MadeIn]
END


End
GO
/****** Object:  Default [DF_TBAirPlane_DevId]    Script Date: 03/10/2014 22:18:45 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_TBAirPlane_DevId]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBAirPlane]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TBAirPlane_DevId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBAirPlane] ADD  CONSTRAINT [DF_TBAirPlane_DevId]  DEFAULT ((0)) FOR [DevId]
END


End
GO
/****** Object:  Default [DF_TBHotel_Stars]    Script Date: 03/10/2014 22:18:45 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_TBHotel_Stars]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBHotel]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TBHotel_Stars]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBHotel] ADD  CONSTRAINT [DF_TBHotel_Stars]  DEFAULT ((0)) FOR [Stars]
END


End
GO
/****** Object:  Default [DF_TBHotel_City]    Script Date: 03/10/2014 22:18:45 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_TBHotel_City]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBHotel]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TBHotel_City]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBHotel] ADD  CONSTRAINT [DF_TBHotel_City]  DEFAULT ((0)) FOR [City]
END


End
GO
/****** Object:  Default [DF_TBTour_Hotel]    Script Date: 03/10/2014 22:18:46 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_TBTour_Hotel]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBTour]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TBTour_Hotel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBTour] ADD  CONSTRAINT [DF_TBTour_Hotel]  DEFAULT ((0)) FOR [Hotel]
END


End
GO
/****** Object:  Default [DF_TBTour_AirPlane]    Script Date: 03/10/2014 22:18:46 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_TBTour_AirPlane]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBTour]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TBTour_AirPlane]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBTour] ADD  CONSTRAINT [DF_TBTour_AirPlane]  DEFAULT ((0)) FOR [AirPlane]
END


End
GO
/****** Object:  Default [DF_TBTour_City]    Script Date: 03/10/2014 22:18:46 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_TBTour_City]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBTour]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TBTour_City]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBTour] ADD  CONSTRAINT [DF_TBTour_City]  DEFAULT ((0)) FOR [City]
END


End
GO
/****** Object:  ForeignKey [FK_TBCity_TBCountry]    Script Date: 03/10/2014 22:18:45 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TBCity_TBCountry]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBCity]'))
ALTER TABLE [dbo].[TBCity]  WITH NOCHECK ADD  CONSTRAINT [FK_TBCity_TBCountry] FOREIGN KEY([CountryID])
REFERENCES [dbo].[TBCountry] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TBCity_TBCountry]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBCity]'))
ALTER TABLE [dbo].[TBCity] CHECK CONSTRAINT [FK_TBCity_TBCountry]
GO
/****** Object:  ForeignKey [FK_TBAirPlane_TBCountry]    Script Date: 03/10/2014 22:18:45 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TBAirPlane_TBCountry]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBAirPlane]'))
ALTER TABLE [dbo].[TBAirPlane]  WITH NOCHECK ADD  CONSTRAINT [FK_TBAirPlane_TBCountry] FOREIGN KEY([MadeIn])
REFERENCES [dbo].[TBCountry] ([ID])
ON UPDATE CASCADE
ON DELETE SET DEFAULT
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TBAirPlane_TBCountry]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBAirPlane]'))
ALTER TABLE [dbo].[TBAirPlane] CHECK CONSTRAINT [FK_TBAirPlane_TBCountry]
GO
/****** Object:  ForeignKey [FK_TBHotel_TBCity]    Script Date: 03/10/2014 22:18:45 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TBHotel_TBCity]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBHotel]'))
ALTER TABLE [dbo].[TBHotel]  WITH NOCHECK ADD  CONSTRAINT [FK_TBHotel_TBCity] FOREIGN KEY([City])
REFERENCES [dbo].[TBCity] ([ID])
ON UPDATE CASCADE
ON DELETE SET DEFAULT
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TBHotel_TBCity]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBHotel]'))
ALTER TABLE [dbo].[TBHotel] CHECK CONSTRAINT [FK_TBHotel_TBCity]
GO
/****** Object:  ForeignKey [FK_TBHotel_TBHotelStars]    Script Date: 03/10/2014 22:18:45 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TBHotel_TBHotelStars]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBHotel]'))
ALTER TABLE [dbo].[TBHotel]  WITH CHECK ADD  CONSTRAINT [FK_TBHotel_TBHotelStars] FOREIGN KEY([Stars])
REFERENCES [dbo].[TBHotelStars] ([ID])
ON DELETE SET DEFAULT
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TBHotel_TBHotelStars]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBHotel]'))
ALTER TABLE [dbo].[TBHotel] CHECK CONSTRAINT [FK_TBHotel_TBHotelStars]
GO
/****** Object:  ForeignKey [FK_TBTour_TBAirPlane]    Script Date: 03/10/2014 22:18:46 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TBTour_TBAirPlane]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBTour]'))
ALTER TABLE [dbo].[TBTour]  WITH CHECK ADD  CONSTRAINT [FK_TBTour_TBAirPlane] FOREIGN KEY([AirPlane])
REFERENCES [dbo].[TBAirPlane] ([ID])
ON DELETE SET DEFAULT
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TBTour_TBAirPlane]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBTour]'))
ALTER TABLE [dbo].[TBTour] CHECK CONSTRAINT [FK_TBTour_TBAirPlane]
GO
/****** Object:  ForeignKey [FK_TBTour_TBCity]    Script Date: 03/10/2014 22:18:46 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TBTour_TBCity]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBTour]'))
ALTER TABLE [dbo].[TBTour]  WITH CHECK ADD  CONSTRAINT [FK_TBTour_TBCity] FOREIGN KEY([City])
REFERENCES [dbo].[TBCity] ([ID])
ON DELETE SET DEFAULT
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TBTour_TBCity]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBTour]'))
ALTER TABLE [dbo].[TBTour] CHECK CONSTRAINT [FK_TBTour_TBCity]
GO
/****** Object:  ForeignKey [FK_TBTour_TBHotel]    Script Date: 03/10/2014 22:18:46 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TBTour_TBHotel]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBTour]'))
ALTER TABLE [dbo].[TBTour]  WITH CHECK ADD  CONSTRAINT [FK_TBTour_TBHotel] FOREIGN KEY([Hotel])
REFERENCES [dbo].[TBHotel] ([ID])
ON DELETE SET DEFAULT
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TBTour_TBHotel]') AND parent_object_id = OBJECT_ID(N'[dbo].[TBTour]'))
ALTER TABLE [dbo].[TBTour] CHECK CONSTRAINT [FK_TBTour_TBHotel]
GO
