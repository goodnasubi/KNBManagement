USE [master]
GO

-- ê⁄ë±ÇµÇƒÇ¢ÇÈÉZÉbÉVÉáÉìÇÃçÌèú

DECLARE @proc smallint
DECLARE sysproc_cur CURSOR FAST_FORWARD FOR
 SELECT spid FROM master..sysprocesses WITH(NOLOCK)
OPEN sysproc_cur
FETCH NEXT FROM sysproc_cur INTO @proc
WHILE (@@FETCH_STATUS <> -1)
BEGIN
   EXEC('KILL ' + @proc)
   FETCH NEXT FROM sysproc_cur INTO @proc
END
CLOSE sysproc_cur
DEALLOCATE sysproc_cur

-- KN_BManageÉfÅ[É^ÉxÅ[ÉXÇÃçÏê¨
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'KN_BManage')
DROP DATABASE [KN_BManage]

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE KN_BManage
  ON PRIMARY (NAME = N''KN_BManage'', FILENAME = N''' + @device_directory + N'KN_BManage.mdf'', SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB)
  LOG ON (NAME = N''KN_BManage_log'',  FILENAME = N''' + @device_directory + N'KN_BManage_log.ldf'', SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)')
GO

EXEC dbo.sp_dbcmptlevel @dbname=N'KN_BManage', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KN_BManage].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [KN_BManage] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KN_BManage] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KN_BManage] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KN_BManage] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KN_BManage] SET ARITHABORT OFF 
GO
ALTER DATABASE [KN_BManage] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KN_BManage] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [KN_BManage] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KN_BManage] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KN_BManage] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KN_BManage] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KN_BManage] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KN_BManage] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KN_BManage] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KN_BManage] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KN_BManage] SET  ENABLE_BROKER 
GO
ALTER DATABASE [KN_BManage] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KN_BManage] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KN_BManage] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KN_BManage] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KN_BManage] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KN_BManage] SET  READ_WRITE 
GO
ALTER DATABASE [KN_BManage] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KN_BManage] SET  MULTI_USER 
GO
ALTER DATABASE [KN_BManage] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KN_BManage] SET DB_CHAINING OFF 

-- ÉeÅ[ÉuÉãÇÃçÏê¨

USE [KN_BManage]
GO
/****** Object:  Table [dbo].[SlipDetail]    Script Date: 10/12/2011 18:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SlipDetail](
	[CompanyID] [uniqueidentifier] NOT NULL,
	[SlipID] [uniqueidentifier] NOT NULL,
	[SlipDetailID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[JournalItemID] [uniqueidentifier] NOT NULL,
	[JournalMoney] [decimal](18, 0) NOT NULL,
	[DetailOrder] [int] NOT NULL,
	[TS] [timestamp] NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC,
	[SlipID] ASC,
	[SlipDetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ì`ï[è⁄ç◊' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SlipDetail'
GO
INSERT [dbo].[SlipDetail] ([CompanyID], [SlipID], [SlipDetailID], [JournalItemID], [JournalMoney], [DetailOrder]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'6f326b88-81ff-4641-9f57-136de7fca996', N'8ae5806f-380b-4e41-b0bb-9b47f07cf811', N'fe1d7ec5-53eb-48d0-b7b7-218d2ace5032', CAST(12345 AS Decimal(18, 0)), 0)
INSERT [dbo].[SlipDetail] ([CompanyID], [SlipID], [SlipDetailID], [JournalItemID], [JournalMoney], [DetailOrder]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'd4b37f5b-f1aa-4ec9-8fba-83c7120bf6cf', N'239fdeae-fa14-41b4-82fe-2dcd6ae2c4c0', N'ea2aa384-d3ed-4b73-8eb7-4a79c6d37fa4', CAST(30000 AS Decimal(18, 0)), 0)
INSERT [dbo].[SlipDetail] ([CompanyID], [SlipID], [SlipDetailID], [JournalItemID], [JournalMoney], [DetailOrder]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'84ba6cfb-4e58-432e-beca-8f76c047ffc4', N'2aeb5268-6830-47dd-8b0e-317122f09309', N'ea2aa384-d3ed-4b73-8eb7-4a79c6d37fa4', CAST(560000 AS Decimal(18, 0)), 0)
INSERT [dbo].[SlipDetail] ([CompanyID], [SlipID], [SlipDetailID], [JournalItemID], [JournalMoney], [DetailOrder]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'd7601579-3836-49c4-a0f3-9e50ca450db3', N'fbc9f564-6285-4206-bf79-38e64bddc395', N'ea2aa384-d3ed-4b73-8eb7-4a79c6d37fa4', CAST(500 AS Decimal(18, 0)), 0)
INSERT [dbo].[SlipDetail] ([CompanyID], [SlipID], [SlipDetailID], [JournalItemID], [JournalMoney], [DetailOrder]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'd7601579-3836-49c4-a0f3-9e50ca450db3', N'd2393492-7b6b-4b50-a32e-8a113d83cd09', N'ea2aa384-d3ed-4b73-8eb7-4a79c6d37fa4', CAST(30000 AS Decimal(18, 0)), 1)
INSERT [dbo].[SlipDetail] ([CompanyID], [SlipID], [SlipDetailID], [JournalItemID], [JournalMoney], [DetailOrder]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'd7601579-3836-49c4-a0f3-9e50ca450db3', N'fb53838d-440a-4697-9f46-aa8045c99550', N'ea2aa384-d3ed-4b73-8eb7-4a79c6d37fa4', CAST(12300 AS Decimal(18, 0)), 3)
INSERT [dbo].[SlipDetail] ([CompanyID], [SlipID], [SlipDetailID], [JournalItemID], [JournalMoney], [DetailOrder]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'd7601579-3836-49c4-a0f3-9e50ca450db3', N'67d2cbec-fd4e-4e46-afa2-ad32ae819ed8', N'ea2aa384-d3ed-4b73-8eb7-4a79c6d37fa4', CAST(20000 AS Decimal(18, 0)), 2)
INSERT [dbo].[SlipDetail] ([CompanyID], [SlipID], [SlipDetailID], [JournalItemID], [JournalMoney], [DetailOrder]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'e628f638-4c36-4412-8d2e-df72ca9c8716', N'bf138477-47b1-4467-bd63-97838ffea4af', N'fe1d7ec5-53eb-48d0-b7b7-218d2ace5032', CAST(12800 AS Decimal(18, 0)), 0)
INSERT [dbo].[SlipDetail] ([CompanyID], [SlipID], [SlipDetailID], [JournalItemID], [JournalMoney], [DetailOrder]) VALUES (N'6031a55b-ff7b-4e68-9327-5ffcb83b8c76', N'6098103a-94cd-41d3-8fd5-6c0ec9389002', N'32e9b90d-13b5-4853-aca8-e44a59729e3c', N'e7aaea4e-1303-40e6-90f3-36e79ce40acc', CAST(45600 AS Decimal(18, 0)), 0)
INSERT [dbo].[SlipDetail] ([CompanyID], [SlipID], [SlipDetailID], [JournalItemID], [JournalMoney], [DetailOrder]) VALUES (N'6031a55b-ff7b-4e68-9327-5ffcb83b8c76', N'39e02bb7-3cec-4f7f-9c44-ff20203b55f7', N'02bb17f5-9791-465f-95b0-c8d0a9f796c4', N'ec919498-70e1-4737-939f-5c11c5eed596', CAST(30000 AS Decimal(18, 0)), 0)
/****** Object:  Table [dbo].[Slip]    Script Date: 10/12/2011 18:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slip](
	[CompanyID] [uniqueidentifier] NOT NULL,
	[SlipID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[TradingDate] [datetime] NOT NULL,
	[Remarks] [nvarchar](max) NOT NULL,
	[SlipTypeID] [int] NOT NULL,
	[JournalItemID] [uniqueidentifier] NOT NULL,
	[TS] [timestamp] NOT NULL,
 CONSTRAINT [PK_Slip] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC,
	[SlipID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ì`ï[éÌï  0:ì¸ã‡ÅA1:éxï•' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Slip', @level2type=N'COLUMN',@level2name=N'SlipTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ì`ï[' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Slip'
GO
INSERT [dbo].[Slip] ([CompanyID], [SlipID], [TradingDate], [Remarks], [SlipTypeID], [JournalItemID]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'6f326b88-81ff-4641-9f57-136de7fca996', CAST(0x00009F5100000000 AS DateTime), N'É\ÉtÉgçwì¸', 1, N'40d4b0a1-42ee-4ed7-a332-7ec9880f0fe3')
INSERT [dbo].[Slip] ([CompanyID], [SlipID], [TradingDate], [Remarks], [SlipTypeID], [JournalItemID]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'd4b37f5b-f1aa-4ec9-8fba-83c7120bf6cf', CAST(0x00009F7B00000000 AS DateTime), N'îÑè„ÇQ', 0, N'fe1d7ec5-53eb-48d0-b7b7-218d2ace5032')
INSERT [dbo].[Slip] ([CompanyID], [SlipID], [TradingDate], [Remarks], [SlipTypeID], [JournalItemID]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'84ba6cfb-4e58-432e-beca-8f76c047ffc4', CAST(0x00009F7900000000 AS DateTime), N'ÉVÉXÉeÉÄî[ïi', 0, N'ea2aa384-d3ed-4b73-8eb7-4a79c6d37fa4')
INSERT [dbo].[Slip] ([CompanyID], [SlipID], [TradingDate], [Remarks], [SlipTypeID], [JournalItemID]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'd7601579-3836-49c4-a0f3-9e50ca450db3', CAST(0x00009F7C00000000 AS DateTime), N'îÑè„ÇP', 0, N'fe1d7ec5-53eb-48d0-b7b7-218d2ace5032')
INSERT [dbo].[Slip] ([CompanyID], [SlipID], [TradingDate], [Remarks], [SlipTypeID], [JournalItemID]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'e628f638-4c36-4412-8d2e-df72ca9c8716', CAST(0x00009F7A0021C414 AS DateTime), N'ÉTÅ[ÉoÅ[ÉäÅ[ÉXë„', 1, N'd59b6229-42a8-4b4c-aee4-4df21938d29a')
INSERT [dbo].[Slip] ([CompanyID], [SlipID], [TradingDate], [Remarks], [SlipTypeID], [JournalItemID]) VALUES (N'6031a55b-ff7b-4e68-9327-5ffcb83b8c76', N'6098103a-94cd-41d3-8fd5-6c0ec9389002', CAST(0x00009F5200000000 AS DateTime), N'è§ïiîÃîÑë„ã‡ÇÃâÒé˚', 0, N'ec919498-70e1-4737-939f-5c11c5eed596')
INSERT [dbo].[Slip] ([CompanyID], [SlipID], [TradingDate], [Remarks], [SlipTypeID], [JournalItemID]) VALUES (N'6031a55b-ff7b-4e68-9327-5ffcb83b8c76', N'39e02bb7-3cec-4f7f-9c44-ff20203b55f7', CAST(0x00009F5200000000 AS DateTime), N'è§ïiédì¸', 1, N'3178da28-2a8e-412e-86eb-5460765b29ed')
/****** Object:  Table [dbo].[JournalItemComp]    Script Date: 10/12/2011 18:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JournalItemComp](
	[CompanyID] [uniqueidentifier] NOT NULL,
	[JournalItemID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[JournalName] [nvarchar](50) NOT NULL,
	[JournalGroup] [nvarchar](50) NOT NULL,
	[Keyword] [nvarchar](50) NOT NULL,
	[TS] [timestamp] NOT NULL,
 CONSTRAINT [PK_JounalItem] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC,
	[JournalItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JournalItemBiz]    Script Date: 10/12/2011 18:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JournalItemBiz](
	[BusinessTypeID] [uniqueidentifier] NOT NULL,
	[JournalItemID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[JournalName] [nvarchar](50) NOT NULL,
	[JournalGroup] [nvarchar](50) NOT NULL,
	[Keyword] [nvarchar](50) NOT NULL,
	[TS] [timestamp] NOT NULL,
 CONSTRAINT [PK_JournalItemBiz] PRIMARY KEY CLUSTERED 
(
	[BusinessTypeID] ASC,
	[JournalItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[JournalItemBiz] ([BusinessTypeID], [JournalItemID], [JournalName], [JournalGroup], [Keyword]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'74dad81b-798d-4f7b-af9b-15ec62e8925e', N'ó∑îÔåí îÔ', N'åoîÔ', N'îÃîÑîÔãyÇ—àÍî ä«óùîÔ')
INSERT [dbo].[JournalItemBiz] ([BusinessTypeID], [JournalItemID], [JournalName], [JournalGroup], [Keyword]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'dfc1ae9c-2ed5-4087-af24-1a3f0f839d5b', N'îÉä|ã‡', N'åoîÔ', N'ó¨ìÆïâç¬')
INSERT [dbo].[JournalItemBiz] ([BusinessTypeID], [JournalItemID], [JournalName], [JournalGroup], [Keyword]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'fe1d7ec5-53eb-48d0-b7b7-218d2ace5032', N'åªã‡', N'åoîÔ', N'ó¨ìÆéëéY')
INSERT [dbo].[JournalItemBiz] ([BusinessTypeID], [JournalItemID], [JournalName], [JournalGroup], [Keyword]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'ea2aa384-d3ed-4b73-8eb7-4a79c6d37fa4', N'îÑä|ã‡', N'é˚ì¸', N'ó¨ìÆéëéY')
INSERT [dbo].[JournalItemBiz] ([BusinessTypeID], [JournalItemID], [JournalName], [JournalGroup], [Keyword]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'd59b6229-42a8-4b4c-aee4-4df21938d29a', N'ÉäÅ|ÉXóø', N'åoîÔ', N'(îÃîÑîÔãyÇ—àÍî ä«óùîÔ')
INSERT [dbo].[JournalItemBiz] ([BusinessTypeID], [JournalItemID], [JournalName], [JournalGroup], [Keyword]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'40d4b0a1-42ee-4ed7-a332-7ec9880f0fe3', N'É\ÉtÉgÉEÉGÉA', N'åoîÔ', N'ñ≥å`å≈íËéëéY')
INSERT [dbo].[JournalItemBiz] ([BusinessTypeID], [JournalItemID], [JournalName], [JournalGroup], [Keyword]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'34f799fc-6950-4ae3-9415-d4bcb971d047', N'îÑè„çÇ', N'é˚ì¸', N'é˚ì¸')
INSERT [dbo].[JournalItemBiz] ([BusinessTypeID], [JournalItemID], [JournalName], [JournalGroup], [Keyword]) VALUES (N'e2526a5b-c805-43cc-9507-7efe6f422d4f', N'ca0e26eb-9a3a-405e-8660-06f23320068f', N'îÑè„çÇ', N'é˚ì¸', N'é˚ì¸')
INSERT [dbo].[JournalItemBiz] ([BusinessTypeID], [JournalItemID], [JournalName], [JournalGroup], [Keyword]) VALUES (N'e2526a5b-c805-43cc-9507-7efe6f422d4f', N'e7aaea4e-1303-40e6-90f3-36e79ce40acc', N'îÑä|ã‡', N'é˚ì¸', N'ó¨ìÆéëéY')
INSERT [dbo].[JournalItemBiz] ([BusinessTypeID], [JournalItemID], [JournalName], [JournalGroup], [Keyword]) VALUES (N'e2526a5b-c805-43cc-9507-7efe6f422d4f', N'3178da28-2a8e-412e-86eb-5460765b29ed', N'çﬁóøédì¸çÇ', N'åoîÔ', N'édì¸')
INSERT [dbo].[JournalItemBiz] ([BusinessTypeID], [JournalItemID], [JournalName], [JournalGroup], [Keyword]) VALUES (N'e2526a5b-c805-43cc-9507-7efe6f422d4f', N'ec919498-70e1-4737-939f-5c11c5eed596', N'åªã‡', N'åoîÔ', N'ó¨ìÆéëéY')
INSERT [dbo].[JournalItemBiz] ([BusinessTypeID], [JournalItemID], [JournalName], [JournalGroup], [Keyword]) VALUES (N'e2526a5b-c805-43cc-9507-7efe6f422d4f', N'efdcd214-4cfd-451f-8881-8b7dd174676b', N'îÉä|ã‡', N'åoîÔ', N'ó¨ìÆïâç¬')
INSERT [dbo].[JournalItemBiz] ([BusinessTypeID], [JournalItemID], [JournalName], [JournalGroup], [Keyword]) VALUES (N'e2526a5b-c805-43cc-9507-7efe6f422d4f', N'81808a50-9414-4580-94e6-d585245652fa', N'ó∑îÔåí îÔ', N'åoîÔ', N'îÃîÑîÔãyÇ—àÍî ä«óùîÔ')
/****** Object:  Table [dbo].[Companies]    Script Date: 10/12/2011 18:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[CompanyID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
	[CompanyKey] [nvarchar](50) NOT NULL,
	[BusinessTypeID] [uniqueidentifier] NOT NULL,
	[TS] [timestamp] NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Companies] ([CompanyID], [CompanyName], [CompanyKey], [BusinessTypeID]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'ÇjÇmÅïÇaè§éñ', N'kenbCompany', N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e')
INSERT [dbo].[Companies] ([CompanyID], [CompanyName], [CompanyKey], [BusinessTypeID]) VALUES (N'6031a55b-ff7b-4e68-9327-5ffcb83b8c76', N'írìcè§éñ', N'ikedaCompany', N'e2526a5b-c805-43cc-9507-7efe6f422d4f')
/****** Object:  Table [dbo].[BusinessTypes]    Script Date: 10/12/2011 18:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessTypes](
	[BusinessTypeID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [nvarchar](50) NULL,
	[TS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BusinessTypes] PRIMARY KEY CLUSTERED 
(
	[BusinessTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BusinessTypes] ([BusinessTypeID], [Name]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'É\ÉtÉgÉEÉGÉA')
INSERT [dbo].[BusinessTypes] ([BusinessTypeID], [Name]) VALUES (N'e2526a5b-c805-43cc-9507-7efe6f422d4f', N'àÍî ')
/****** Object:  Table [dbo].[SlipTypes]    Script Date: 10/12/2011 18:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SlipTypes](
	[SlipTypeID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TS] [timestamp] NOT NULL,
 CONSTRAINT [PK_SlipTypes] PRIMARY KEY CLUSTERED 
(
	[SlipTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SlipTypes] ([SlipTypeID], [Name]) VALUES (0, N'ì¸ã‡ì`ï[')
INSERT [dbo].[SlipTypes] ([SlipTypeID], [Name]) VALUES (1, N'éxï•ì`ï[')
/****** Object:  View [dbo].[SlipListView]    Script Date: 10/12/2011 18:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SlipListView]
AS
SELECT                  TOP (100) PERCENT dbo.Companies.CompanyName AS âÔé–ñº, dbo.Slip.TradingDate AS èàóùì˙, dbo.Slip.Remarks AS ìEóv, 
                                  dbo.SlipTypes.Name AS ì`ï[éÌóﬁ, j1.JournalName AS éÿï˚, j2.JournalName AS ë›ï˚, dbo.SlipDetail.DetailOrder AS èáèò, 
                                  dbo.SlipDetail.JournalMoney AS ã‡äz
FROM                     dbo.Companies INNER JOIN
                                  dbo.Slip ON dbo.Companies.CompanyID = dbo.Slip.CompanyID INNER JOIN
                                  dbo.JournalItemBiz AS j1 ON dbo.Companies.BusinessTypeID = j1.BusinessTypeID AND dbo.Slip.JournalItemID = j1.JournalItemID INNER JOIN
                                  dbo.SlipTypes ON dbo.Slip.SlipTypeID = dbo.SlipTypes.SlipTypeID INNER JOIN
                                  dbo.SlipDetail ON dbo.Slip.CompanyID = dbo.SlipDetail.CompanyID AND dbo.Slip.SlipID = dbo.SlipDetail.SlipID INNER JOIN
                                  dbo.JournalItemBiz AS j2 ON dbo.Companies.BusinessTypeID = j2.BusinessTypeID AND dbo.SlipDetail.JournalItemID = j2.JournalItemID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[16] 3) )"
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
         Begin Table = "Companies"
            Begin Extent = 
               Top = 19
               Left = 8
               Bottom = 138
               Right = 173
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Slip"
            Begin Extent = 
               Top = 173
               Left = 146
               Bottom = 292
               Right = 303
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "j1"
            Begin Extent = 
               Top = 235
               Left = 449
               Bottom = 354
               Right = 614
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SlipTypes"
            Begin Extent = 
               Top = 233
               Left = 666
               Bottom = 337
               Right = 823
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SlipDetail"
            Begin Extent = 
               Top = 10
               Left = 482
               Bottom = 129
               Right = 639
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "j2"
            Begin Extent = 
               Top = 235
               Left = 951
               Bottom = 354
               Right = 1116
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
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 2430
       ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SlipListView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  Width = 2370
         Width = 2205
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SlipListView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SlipListView'
GO
/****** Object:  Table [dbo].[Journal]    Script Date: 10/12/2011 18:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journal](
	[CompanyID] [uniqueidentifier] NOT NULL,
	[JournalID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[EmployeeID] [uniqueidentifier] NOT NULL,
	[TradingDate] [datetime] NOT NULL,
	[Remarks] [nvarchar](max) NOT NULL,
	[TS] [timestamp] NOT NULL,
 CONSTRAINT [PK_Journal] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC,
	[JournalID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetJournalItems]    Script Date: 10/12/2011 18:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetJournalItems] (
	@CompanyID uniqueidentifier)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>
	DECLARE @BusinessTypeID uniqueidentifier
	SELECT @BusinessTypeID = NULL
	SELECT @BusinessTypeID = BusinessTypeID FROM Companies WHERE CompanyID = @CompanyID
	IF (@BusinessTypeID IS NULL)
		RETURN
	
	SELECT C.JournalItemID AS [JournalItemID], C.JournalName AS [JournalName], C.JournalGroup AS [JournalGroup], C.Keyword AS [Keyword]
		FROM JournalItemComp AS C
		WHERE CompanyID = @CompanyID
	UNION
	SELECT B.JournalItemID AS [JournalItemID], B.JournalName AS [JournalName], B.JournalGroup AS [JournalGroup], B.Keyword AS [Keyword]
		FROM JournalItemBiz AS B
		WHERE BusinessTypeID = @BusinessTypeID
	
END
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/12/2011 18:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[CompanyID] [uniqueidentifier] NOT NULL,
	[EmployeeID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[EmployeeName] [nvarchar](50) NOT NULL,
	[LoginID] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[TS] [timestamp] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC,
	[EmployeeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Employees] ([CompanyID], [EmployeeID], [EmployeeName], [LoginID], [Password]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'8080e8c1-ffc4-4ee5-8985-08b723af918f', N'KN3', N'kn3', N'kn3')
INSERT [dbo].[Employees] ([CompanyID], [EmployeeID], [EmployeeName], [LoginID], [Password]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'87a7090f-9eb5-4095-8d73-293aa5562141', N'KN4', N'kn4', N'kn4')
INSERT [dbo].[Employees] ([CompanyID], [EmployeeID], [EmployeeName], [LoginID], [Password]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'1cde7bff-3d39-489a-b8dc-2c5bc60409fb', N'KN5', N'kn5', N'kn5')
INSERT [dbo].[Employees] ([CompanyID], [EmployeeID], [EmployeeName], [LoginID], [Password]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'5568279b-ef24-419e-a3c8-983ff767c36f', N'KN2', N'kn2', N'kn2')
INSERT [dbo].[Employees] ([CompanyID], [EmployeeID], [EmployeeName], [LoginID], [Password]) VALUES (N'dd6a8cd1-7614-4f71-8bd8-0c6c949d7e2e', N'44a07354-be4b-4b53-a2d2-e5fac0545a80', N'KN1', N'kn1', N'kn1')
INSERT [dbo].[Employees] ([CompanyID], [EmployeeID], [EmployeeName], [LoginID], [Password]) VALUES (N'6031a55b-ff7b-4e68-9327-5ffcb83b8c76', N'e15c9a2e-1741-4619-bb91-680b4702a362', N'írìcÇP', N'ike1', N'ike1')
INSERT [dbo].[Employees] ([CompanyID], [EmployeeID], [EmployeeName], [LoginID], [Password]) VALUES (N'6031a55b-ff7b-4e68-9327-5ffcb83b8c76', N'f60dd70b-484c-4d7f-84d0-8742bb2e12b2', N'írìcÇS', N'ike4', N'ike4')
INSERT [dbo].[Employees] ([CompanyID], [EmployeeID], [EmployeeName], [LoginID], [Password]) VALUES (N'6031a55b-ff7b-4e68-9327-5ffcb83b8c76', N'4c3195a6-4a86-46f8-aa40-c5a1663203db', N'írìcÇR', N'ike3', N'ike3')
INSERT [dbo].[Employees] ([CompanyID], [EmployeeID], [EmployeeName], [LoginID], [Password]) VALUES (N'6031a55b-ff7b-4e68-9327-5ffcb83b8c76', N'e11a0e94-8dc4-41e6-856a-decb66387327', N'írìcÇQ', N'ike2', N'ike2')
/****** Object:  Table [dbo].[JournalDetail]    Script Date: 10/12/2011 18:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JournalDetail](
	[CompanyID] [uniqueidentifier] NOT NULL,
	[JournalID] [uniqueidentifier] NOT NULL,
	[JounalDetailID] [int] NOT NULL,
	[DebitItemID] [uniqueidentifier] NOT NULL,
	[DebitMoney] [decimal](18, 0) NOT NULL,
	[CreditItemID] [uniqueidentifier] NOT NULL,
	[CreditMoney] [decimal](18, 0) NOT NULL,
	[TS] [timestamp] NOT NULL,
 CONSTRAINT [PK_JournalDetail] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC,
	[JournalID] ASC,
	[JounalDetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Table_1_CompanyID]    Script Date: 10/12/2011 18:37:39 ******/
ALTER TABLE [dbo].[SlipDetail] ADD  CONSTRAINT [DF_Table_1_CompanyID]  DEFAULT (newid()) FOR [CompanyID]
GO
/****** Object:  Default [DF_Table_1_SlipID]    Script Date: 10/12/2011 18:37:39 ******/
ALTER TABLE [dbo].[SlipDetail] ADD  CONSTRAINT [DF_Table_1_SlipID]  DEFAULT (newid()) FOR [SlipID]
GO
/****** Object:  Default [DF_Table_1_SlipDetailID]    Script Date: 10/12/2011 18:37:39 ******/
ALTER TABLE [dbo].[SlipDetail] ADD  CONSTRAINT [DF_Table_1_SlipDetailID]  DEFAULT (newid()) FOR [SlipDetailID]
GO
/****** Object:  Default [DF_SlipDetail_order]    Script Date: 10/12/2011 18:37:39 ******/
ALTER TABLE [dbo].[SlipDetail] ADD  CONSTRAINT [DF_SlipDetail_order]  DEFAULT ((0)) FOR [DetailOrder]
GO
/****** Object:  Default [DF_Slip_CompanyID]    Script Date: 10/12/2011 18:37:39 ******/
ALTER TABLE [dbo].[Slip] ADD  CONSTRAINT [DF_Slip_CompanyID]  DEFAULT (newid()) FOR [CompanyID]
GO
/****** Object:  Default [DF_Slip_SlipID]    Script Date: 10/12/2011 18:37:39 ******/
ALTER TABLE [dbo].[Slip] ADD  CONSTRAINT [DF_Slip_SlipID]  DEFAULT (newid()) FOR [SlipID]
GO
/****** Object:  Default [DF_JournalItem_JounalItemID]    Script Date: 10/12/2011 18:37:39 ******/
ALTER TABLE [dbo].[JournalItemComp] ADD  CONSTRAINT [DF_JournalItem_JounalItemID]  DEFAULT (newid()) FOR [JournalItemID]
GO
/****** Object:  Default [DF_JournalItemBiz_BusinessTypeID]    Script Date: 10/12/2011 18:37:39 ******/
ALTER TABLE [dbo].[JournalItemBiz] ADD  CONSTRAINT [DF_JournalItemBiz_BusinessTypeID]  DEFAULT (newid()) FOR [BusinessTypeID]
GO
/****** Object:  Default [DF_JournalItemBiz_JounalItemID]    Script Date: 10/12/2011 18:37:39 ******/
ALTER TABLE [dbo].[JournalItemBiz] ADD  CONSTRAINT [DF_JournalItemBiz_JounalItemID]  DEFAULT (newid()) FOR [JournalItemID]
GO
/****** Object:  Default [DF_Companies_CompanyID]    Script Date: 10/12/2011 18:37:39 ******/
ALTER TABLE [dbo].[Companies] ADD  CONSTRAINT [DF_Companies_CompanyID]  DEFAULT (newid()) FOR [CompanyID]
GO
/****** Object:  Default [DF_Companies_businessType]    Script Date: 10/12/2011 18:37:39 ******/
ALTER TABLE [dbo].[Companies] ADD  CONSTRAINT [DF_Companies_businessType]  DEFAULT (newid()) FOR [BusinessTypeID]
GO
/****** Object:  Default [DF_businessTypes_businessType]    Script Date: 10/12/2011 18:37:39 ******/
ALTER TABLE [dbo].[BusinessTypes] ADD  CONSTRAINT [DF_businessTypes_businessType]  DEFAULT (newid()) FOR [BusinessTypeID]
GO
/****** Object:  Default [DF_Journal_JournalID]    Script Date: 10/12/2011 18:37:39 ******/
ALTER TABLE [dbo].[Journal] ADD  CONSTRAINT [DF_Journal_JournalID]  DEFAULT (newid()) FOR [JournalID]
GO
/****** Object:  Default [DF_Employees_EmployeeID]    Script Date: 10/12/2011 18:37:40 ******/
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_EmployeeID]  DEFAULT (newid()) FOR [EmployeeID]
GO
/****** Object:  ForeignKey [FK_CompanyJournal]    Script Date: 10/12/2011 18:37:39 ******/
ALTER TABLE [dbo].[Journal]  WITH CHECK ADD  CONSTRAINT [FK_CompanyJournal] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Companies] ([CompanyID])
GO
ALTER TABLE [dbo].[Journal] CHECK CONSTRAINT [FK_CompanyJournal]
GO
/****** Object:  ForeignKey [FK_CompanyEmployee]    Script Date: 10/12/2011 18:37:40 ******/
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_CompanyEmployee] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Companies] ([CompanyID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_CompanyEmployee]
GO
/****** Object:  ForeignKey [FK_CompanyJournalDetail]    Script Date: 10/12/2011 18:37:40 ******/
ALTER TABLE [dbo].[JournalDetail]  WITH CHECK ADD  CONSTRAINT [FK_CompanyJournalDetail] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Companies] ([CompanyID])
GO
ALTER TABLE [dbo].[JournalDetail] CHECK CONSTRAINT [FK_CompanyJournalDetail]
GO
/****** Object:  ForeignKey [FK_JournalJournalDetail]    Script Date: 10/12/2011 18:37:40 ******/
ALTER TABLE [dbo].[JournalDetail]  WITH CHECK ADD  CONSTRAINT [FK_JournalJournalDetail] FOREIGN KEY([CompanyID], [JournalID])
REFERENCES [dbo].[Journal] ([CompanyID], [JournalID])
GO
ALTER TABLE [dbo].[JournalDetail] CHECK CONSTRAINT [FK_JournalJournalDetail]
GO
