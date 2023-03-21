USE [master]
GO
/****** Object:  Database [DesctopHite]    Script Date: 21.03.2023 7:19:26 ******/
CREATE DATABASE [DesctopHite]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DesctopHite', FILENAME = N'D:\Programming\ProjectsDataBase\MyDataBase\DesctopHite\DesctopHite.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DesctopHite_log', FILENAME = N'D:\Programming\ProjectsDataBase\MyDataBase\DesctopHite\DesctopHite_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DesctopHite] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DesctopHite].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DesctopHite] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DesctopHite] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DesctopHite] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DesctopHite] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DesctopHite] SET ARITHABORT OFF 
GO
ALTER DATABASE [DesctopHite] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DesctopHite] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DesctopHite] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DesctopHite] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DesctopHite] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DesctopHite] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DesctopHite] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DesctopHite] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DesctopHite] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DesctopHite] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DesctopHite] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DesctopHite] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DesctopHite] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DesctopHite] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DesctopHite] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DesctopHite] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DesctopHite] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DesctopHite] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DesctopHite] SET  MULTI_USER 
GO
ALTER DATABASE [DesctopHite] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DesctopHite] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DesctopHite] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DesctopHite] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DesctopHite] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DesctopHite] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DesctopHite] SET QUERY_STORE = OFF
GO
USE [DesctopHite]
GO
/****** Object:  Table [dbo].[GenderTable]    Script Date: 21.03.2023 7:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenderTable](
	[PersonalNumber_Gender] [int] IDENTITY(1,1) NOT NULL,
	[Title_Gender] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_GenderTable] PRIMARY KEY CLUSTERED 
(
	[PersonalNumber_Gender] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INNTable]    Script Date: 21.03.2023 7:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INNTable](
	[PersonalNumber_INN] [char](12) NOT NULL,
	[TaxAuthority_INN] [nvarchar](500) NOT NULL,
	[NumberTaxAuthority_INN] [char](4) NOT NULL,
	[Date_INN] [date] NOT NULL,
 CONSTRAINT [PK_INNWorkerTable] PRIMARY KEY CLUSTERED 
(
	[PersonalNumber_INN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalBookTable]    Script Date: 21.03.2023 7:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalBookTable](
	[PersonalNumber_MedicalBook] [nchar](8) NOT NULL,
	[Issue_MedicalBook] [nvarchar](500) NOT NULL,
	[SNMDirector_MedicalBook] [nvarchar](500) NOT NULL,
	[DateIssue_MedicalBook] [date] NOT NULL,
	[HomeAdress_MedicalBook] [nvarchar](500) NOT NULL,
	[Role_MedicalBook] [nvarchar](500) NOT NULL,
	[Organization_MedicalBook] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_MedicalBookTable] PRIMARY KEY CLUSTERED 
(
	[PersonalNumber_MedicalBook] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PassportTable]    Script Date: 21.03.2023 7:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PassportTable](
	[Series_Passport] [char](4) NOT NULL,
	[Number_Passport] [nchar](6) NOT NULL,
	[Surname_Passport] [nvarchar](80) NOT NULL,
	[Name_Passport] [nvarchar](80) NOT NULL,
	[Middlename_Passport] [nvarchar](80) NULL,
	[pnGender_Passport] [int] NOT NULL,
	[Image_Passport] [image] NULL,
	[DateOfBrich_Passport] [date] NOT NULL,
	[LocationOfBrich_Passport] [nvarchar](400) NOT NULL,
	[Issued_Passport] [nvarchar](500) NOT NULL,
	[DateIssued_Passport] [date] NOT NULL,
	[DivisionCode_Passport] [nchar](7) NOT NULL,
 CONSTRAINT [PK_PassportTable] PRIMARY KEY CLUSTERED 
(
	[Series_Passport] ASC,
	[Number_Passport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlaceResidenceTable]    Script Date: 21.03.2023 7:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaceResidenceTable](
	[PersonalNumber_PlaceResidence] [nchar](10) NOT NULL,
	[RegistrationDate_PlaceResidence] [date] NOT NULL,
	[Region_PlaceResidence] [nvarchar](80) NOT NULL,
	[District_PlaceResidence] [nvarchar](80) NOT NULL,
	[Point_PlaceResidence] [nvarchar](80) NOT NULL,
	[Street_PlaceResidence] [nvarchar](80) NOT NULL,
	[House_PlaceResidence] [nvarchar](10) NOT NULL,
	[Flat_PlaceResidence] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_PlaceResidenceTable] PRIMARY KEY CLUSTERED 
(
	[PersonalNumber_PlaceResidence] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleTable]    Script Date: 21.03.2023 7:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleTable](
	[PersonalNumber_Role] [int] IDENTITY(1,1) NOT NULL,
	[Name_Role] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_RoleTable] PRIMARY KEY CLUSTERED 
(
	[PersonalNumber_Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalaryCardTable]    Script Date: 21.03.2023 7:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaryCardTable](
	[PersonalNumber_SalaryCard] [nchar](16) NOT NULL,
	[NameEnd_SalaryCard] [nvarchar](80) NOT NULL,
	[SurnameEng_SalaryCard] [nvarchar](80) NOT NULL,
	[YearEnd_SalaryCard] [nchar](4) NOT NULL,
	[Month_SalaryCard] [nchar](2) NOT NULL,
	[Code_SalaryCard] [nchar](3) NOT NULL,
 CONSTRAINT [PK_SalaryCardTable] PRIMARY KEY CLUSTERED 
(
	[PersonalNumber_SalaryCard] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SnilsTable]    Script Date: 21.03.2023 7:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SnilsTable](
	[PersonalNumber_Snils] [nchar](11) NOT NULL,
	[DateRegistration_Snils] [date] NOT NULL,
 CONSTRAINT [PK_SnilsTable] PRIMARY KEY CLUSTERED 
(
	[PersonalNumber_Snils] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusTable]    Script Date: 21.03.2023 7:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusTable](
	[PersonalNumber_Status] [int] IDENTITY(1,1) NOT NULL,
	[Title_Status] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_StatusTable] PRIMARY KEY CLUSTERED 
(
	[PersonalNumber_Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkerTabe]    Script Date: 21.03.2023 7:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkerTabe](
	[PersonalNumber_Worker] [int] IDENTITY(1,1) NOT NULL,
	[Phone_Worker] [nchar](11) NOT NULL,
	[Login_Worker] [nvarchar](80) NOT NULL,
	[Email_Worker] [nvarchar](80) NOT NULL,
	[Password_Worker] [nvarchar](80) NOT NULL,
	[pnRole_Worker] [int] NOT NULL,
	[SeriesPassport_Worker] [char](4) NOT NULL,
	[NumberPassport_Worker] [nchar](6) NOT NULL,
	[pnPlaceResidence_Worker] [nchar](10) NOT NULL,
	[pnMedicalBook_Worker] [nchar](8) NOT NULL,
	[pnSalaryCard_Worker] [nchar](16) NOT NULL,
	[DateWord_Worker] [date] NOT NULL,
	[pnStatus_Worker] [int] NOT NULL,
	[pnINN_Worker] [char](12) NOT NULL,
	[pnSnils_Worker] [nchar](11) NOT NULL,
 CONSTRAINT [PK_WorkerTabe] PRIMARY KEY CLUSTERED 
(
	[PersonalNumber_Worker] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[GenderTable] ON 

INSERT [dbo].[GenderTable] ([PersonalNumber_Gender], [Title_Gender]) VALUES (1, N'Мужской')
INSERT [dbo].[GenderTable] ([PersonalNumber_Gender], [Title_Gender]) VALUES (2, N'Женский')
SET IDENTITY_INSERT [dbo].[GenderTable] OFF
GO
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'111111111111', N'Error 404', N'1111', CAST(N'0001-01-01' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'157208969871', N'Отделением УФМС России по г. Черкесск', N'9585', CAST(N'2022-01-14' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'163099257134', N'Отделом внутренних дел России по г. Липецк', N'9333', CAST(N'2022-01-30' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'196195438360', N'Отделением УФМС России по г. Воронеж', N'8009', CAST(N'2022-01-29' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'204079758075', N'Отделением УФМС России по г. Новокузнецк', N'9459', CAST(N'2022-01-02' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'207287414307', N'ОУФМС России по г. Мытищи', N'2408', CAST(N'2022-01-11' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'217882389696', N'Отделом внутренних дел России по г. Санкт-Петербург', N'4705', CAST(N'2022-01-28' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'222219583283', N'ОВД России по г. Дзержинск', N'7909', CAST(N'2022-01-27' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'244326548567', N'Test002', N'5321', CAST(N'1111-11-11' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'278645691400', N'Управление внутренних дел по г. Домодедово', N'7305', CAST(N'2022-01-08' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'290183054220', N'Отделением УФМС России по г. Москва', N'3304', CAST(N'2022-01-19' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'366838812487', N'Отделом УФМС России по г. Великий Новгород', N'2959', CAST(N'2022-01-23' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'368964107340', N'Отделением УФМС России по г. Челябинск', N'8607', CAST(N'2022-01-10' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'387260043326', N'Отделом УФМС России по г. Ноябрьск', N'2190', CAST(N'2022-01-17' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'425933182602', N'Отделением УФМС России по г. Орск', N'3504', CAST(N'2022-01-06' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'463244237703', N'Управление внутренних дел по г. Березники', N'8077', CAST(N'2022-01-24' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'506005689017', N'Отделом УФМС России по г. Евпатория', N'4505', CAST(N'2022-01-25' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'531701296805', N'Отделом внутренних дел России по г. Новосибирск', N'7117', CAST(N'2022-01-04' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'555783861762', N'ОУФМС России по г. Грозный', N'3845', CAST(N'2022-01-01' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'563264523456', N'Test 001', N'2365', CAST(N'2023-03-18' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'570481242611', N'Отделом внутренних дел России по г. Южно-Сахалинск', N'9298', CAST(N'2022-01-16' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'578847287158', N'Отделом УФМС России по г. Владимир', N'4717', CAST(N'2022-01-09' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'597053306366', N'ОВД России по г. Балашиха', N'4292', CAST(N'2022-01-07' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'646300114099', N'Отделом внутренних дел России по г. Иваново', N'8898', CAST(N'2022-01-21' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'655435468768', N'Налоговый орган ПРОВЕРКА', N'0005', CAST(N'0005-05-05' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'681217836720', N'Отделом УФМС России по г. Энгельс', N'1474', CAST(N'2022-01-18' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'716916225593', N'Отделением УФМС России по г. Южно-Сахалинск', N'4350', CAST(N'2022-01-22' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'760147092163', N'Отделением УФМС России по г. Иваново', N'7161', CAST(N'2022-01-05' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'764205274057', N'Лично мой', N'3546', CAST(N'1111-11-11' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'770847504005', N'ОУФМС России по г. Новороссийск', N'8949', CAST(N'2022-01-13' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'816356137164', N'Отделением УФМС России в г. Чита', N'9426', CAST(N'2022-01-20' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'822260545777', N'Отделением УФМС России по г. Сергиев Посад', N'9350', CAST(N'2022-01-15' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'892250329757', N'Управление внутренних дел по г. Тольятти', N'9358', CAST(N'2022-01-03' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'915563726504', N'Отделением УФМС России по г. Москва', N'1342', CAST(N'2022-01-26' AS Date))
INSERT [dbo].[INNTable] ([PersonalNumber_INN], [TaxAuthority_INN], [NumberTaxAuthority_INN], [Date_INN]) VALUES (N'935611187683', N'Отделением УФМС России по г. Грозный', N'4265', CAST(N'2022-01-12' AS Date))
GO
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'11111111', N'Error 404', N'Error 404', CAST(N'0001-01-01' AS Date), N'Error 404', N'Error 404', N'Error 404')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'11111138', N'Мной и точка', N'Я и есть руководитель', CAST(N'1111-11-11' AS Date), N'Конечно же есть и точка', N'Хорошая, не жалуюсь', N'Индивидуальный предприниматель')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'17916876', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2018-10-24' AS Date), N'Оренбургская область, город Озёры, наб. Домодедовская, 75', N'Актёр', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'19488056', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2014-11-01' AS Date), N'Оренбургская область, город Озёры, наб. Домодедовская, 83', N'Фортификатор', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'23064507', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2008-05-13' AS Date), N'Тульская область, город Коломна, спуск Космонавтов, 91', N'Грейдерист', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'24459158', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2016-06-28' AS Date), N'Тульская область, город Коломна, спуск Космонавтов, 90', N'Машинист', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'24832506', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2018-02-12' AS Date), N'Оренбургская область, город Озёры, наб. Домодедовская, 77', N'Актуарий', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'26313937', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2014-11-21' AS Date), N'Тульская область, город Коломна, спуск Космонавтов, 87', N'Оператор коллцентра', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'28600299', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2011-03-03' AS Date), N'Тульская область, город Коломна, спуск Космонавтов, 85', N'Журналист', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'30703453', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2019-02-20' AS Date), N'Курганская область, город Чехов, шоссе Гоголя, 64', N'Врач функциональной диагностики', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'35468435', N'Личная медецинская книжка выдана ПРОВЕРКА', N'ФИО руководителя ПРОВЕРКА', CAST(N'0005-05-05' AS Date), N'Домашний адресс ПРОВЕРКА', N'Должность ПРОВЕРКА', N'Организация (индивидуальный предприниматель) ПРОВЕРКА')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'37253871', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2016-04-15' AS Date), N'Оренбургская область, город Озёры, наб. Домодедовская, 79', N'Декоратор', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'41091613', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2015-01-25' AS Date), N'Курганская область, город Чехов, шоссе Гоголя, 69', N'Зоолог', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'41239103', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2019-03-24' AS Date), N'Тульская область, город Коломна, спуск Космонавтов, 93', N'Подводник', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'45632564', N'Test 001', N'Test 001', CAST(N'2023-03-18' AS Date), N'Test 001', N'Test 001', N'Test 001')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'54476345', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2015-05-17' AS Date), N'Оренбургская область, город Озёры, наб. Домодедовская, 78', N'Военно-полевой хирург', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'54903451', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2013-08-13' AS Date), N'Оренбургская область, город Озёры, наб. Домодедовская, 76', N'Финансист', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'58560219', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2016-10-05' AS Date), N'Курганская область, город Чехов, шоссе Гоголя, 66', N'Табунщик', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'60300345', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2011-04-23' AS Date), N'Тульская область, город Коломна, спуск Космонавтов, 94', N'Продюсер', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'63664317', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2007-02-02' AS Date), N'Оренбургская область, город Озёры, наб. Домодедовская, 81', N'Командир', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'64535437', N'Test002', N'Test002', CAST(N'1111-11-11' AS Date), N'Test002Test002', N'Test002', N'Test002')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'70887789', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2006-01-23' AS Date), N'Курганская область, город Чехов, шоссе Гоголя, 68', N'Историк', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'71659198', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2019-12-25' AS Date), N'Оренбургская область, город Озёры, наб. Домодедовская, 80', N'Химик-аналитик', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'72733572', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2016-03-07' AS Date), N'Тульская область, город Коломна, спуск Космонавтов, 86', N'Донкерман', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'72893462', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2019-03-29' AS Date), N'Оренбургская область, город Озёры, наб. Домодедовская, 82', N'Бактериолог', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'73877372', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2016-06-23' AS Date), N'Курганская область, город Чехов, шоссе Гоголя, 62', N'Бондарь', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'79799656', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2010-05-28' AS Date), N'Оренбургская область, город Озёры, наб. Домодедовская, 84', N'Социолог', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'80832279', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2011-05-07' AS Date), N'Курганская область, город Чехов, шоссе Гоголя, 63', N'Парикмахер', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'81277009', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2016-04-24' AS Date), N'Тульская область, город Коломна, спуск Космонавтов, 92', N'Оператор машинного доения', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'87101602', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2005-11-03' AS Date), N'Курганская область, город Чехов, шоссе Гоголя, 70', N'Геолог', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'87593267', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2017-10-17' AS Date), N'Курганская область, город Чехов, шоссе Гоголя, 61', N'Миколог', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'90738269', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2020-08-07' AS Date), N'Тульская область, город Коломна, спуск Космонавтов, 88', N'Преподаватель', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'92776545', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2009-09-07' AS Date), N'Курганская область, город Чехов, шоссе Гоголя, 67', N'Уролог', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'93803320', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2009-09-23' AS Date), N'Тульская область, город Коломна, спуск Космонавтов, 89', N'Сборщик', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
INSERT [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook], [Issue_MedicalBook], [SNMDirector_MedicalBook], [DateIssue_MedicalBook], [HomeAdress_MedicalBook], [Role_MedicalBook], [Organization_MedicalBook]) VALUES (N'99805889', N'ФБУЗ "Центр гигиены и эпидемиологии в городе Москве"', N'Error 404', CAST(N'2007-10-15' AS Date), N'Курганская область, город Чехов, шоссе Гоголя, 65', N'Лётчик', N'Продукты (Быс.питание): Пищ.пром.(прочие) ООО "Hite"')
GO
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'0120', N'165985', N'Test 001', N'Test 001', N'Test 001', 1, NULL, CAST(N'2023-03-18' AS Date), N'Test 001', N'Test 001', CAST(N'2023-03-18' AS Date), N'256-569')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'1111', N'111111', N'Error 404', N'Error 404', N'Error 404', 1, NULL, CAST(N'0001-01-01' AS Date), N'Error 404', N'Error 404', CAST(N'0001-01-01' AS Date), N'111111 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'2252', N'627719', N'Гуляева', N'Ксения', N'Тимофеевна', 2, NULL, CAST(N'1978-10-06' AS Date), N'Россия, г. Псков, ЯнкиКупалы ул.', N'Отделом внутренних дел России по г. Санкт-Петербург', CAST(N'2010-01-28' AS Date), N'837778 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'2463', N'369762', N'Болдырев', N'Дмитрий', N'Данилович', 1, NULL, CAST(N'1973-04-21' AS Date), N'Россия, г. Батайск, Пионерская ул.', N'Отделением УФМС России по г. Воронеж', CAST(N'2010-01-29' AS Date), N'442982 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'2597', N'312423', N'Фокин', N'Тимофей', N'Егорович', 1, NULL, CAST(N'1973-08-26' AS Date), N'Россия, г. Сыктывкар, Юбилейная ул.', N'Отделением УФМС России в г. Чита', CAST(N'2010-01-20' AS Date), N'361572 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'2598', N'862161', N'Устинов', N'Кирилл', N'Михайлович', 1, NULL, CAST(N'1970-03-03' AS Date), N'Россия, г. Ковров, Заводская ул.', N'Отделением УФМС России по г. Орск', CAST(N'2010-01-06' AS Date), N'380441 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'3218', N'634336', N'Никитина', N'Варвара', N'Марковна', 2, NULL, CAST(N'1981-02-23' AS Date), N'Россия, г. Красноярск, Севернаяул.', N'Отделением УФМС России по г. Черкесск', CAST(N'2010-01-14' AS Date), N'120406 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'3514', N'165077', N'Орлова', N'Ульяна', N'Макаровна', 2, NULL, CAST(N'1970-07-08' AS Date), N'Россия, г. Рязань, Мира ул.', N'Отделением УФМС России по г. Москва', CAST(N'2010-01-26' AS Date), N'499990 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'3754', N'156172', N'Андреева', N'Виктория', N'Матвеевна', 2, NULL, CAST(N'1967-05-17' AS Date), N'Россия, г. Йошкар-Ола, Зеленый пер.', N'Отделением УФМС России по г. Челябинск', CAST(N'2010-01-10' AS Date), N'396534 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'4162', N'400236', N'Балашова', N'Нина', N'Артемьевна', 2, NULL, CAST(N'1967-12-08' AS Date), N'Россия, г. Невинномысск, Новоселов ул.', N'Отделением УФМС России по г. Южно-Сахалинск', CAST(N'2010-01-22' AS Date), N'749179 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'4408', N'609463', N'Сергеев', N'Арсений', N'Никитич', 1, NULL, CAST(N'1978-10-17' AS Date), N'Россия, г. Барнаул, Сосновая ул.', N'Отделом внутренних дел России по г. Новосибирск', CAST(N'2010-01-04' AS Date), N'561394 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'4710', N'619218', N'Петрова', N'Анастасия', N'Михайловна', 2, NULL, CAST(N'1977-09-14' AS Date), N'Россия, г. Рыбинск, Спортивная ул.', N'Отделом УФМС России по г. Владимир', CAST(N'2010-01-09' AS Date), N'405107 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'5139', N'613586', N'Судакова', N'Варвара', N'Мироновна', 2, NULL, CAST(N'1978-04-22' AS Date), N'Россия, г. Майкоп, Дорожная ул.', N'Отделом УФМС России по г. Великий Новгород', CAST(N'2010-01-23' AS Date), N'271144 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'5157', N'842187', N'Test002', N'Test002', N'', 1, NULL, CAST(N'1111-11-11' AS Date), N'Test002', N'Test002', CAST(N'1111-11-11' AS Date), N'111-111')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'5198', N'948399', N'Иванова', N'Анна', N'Максимовна', 2, NULL, CAST(N'1983-07-19' AS Date), N'Россия, г. Красноярск, Минская ул.', N'Отделом внутренних дел России по г. Липецк', CAST(N'2010-01-30' AS Date), N'394432 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'5341', N'534843', N'Фамилия ПРОВЕРКА', N'Имя ПРОВЕРКА', N'Отчество ПРОВЕКА', 1, NULL, CAST(N'0005-05-05' AS Date), N'Место рождения ПРОВЕРКА', N'Паспорт выдан ПРОВЕРКА', CAST(N'0005-05-05' AS Date), N'000-005')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'5534', N'869147', N'Моисеева', N'Василиса', N'Артуровна', 2, NULL, CAST(N'1975-02-21' AS Date), N'Россия, г. Абакан, Октябрьская ул.', N'Отделением УФМС России по г. Грозный', CAST(N'2010-01-12' AS Date), N'633110 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'5619', N'279885', N'Харитонов', N'Максим', N'Григорьевич', 2, NULL, CAST(N'1976-06-01' AS Date), N'Россия, г. Вологда, Песчаная ул.', N'ОУФМС России по г. Новороссийск', CAST(N'2010-01-13' AS Date), N'749339 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'5648', N'755340', N'Соловьев', N'Егор', N'Александрович', 1, NULL, CAST(N'1976-01-25' AS Date), N'Россия, г. Хасавюрт, Полесская ул.', N'Управление внутренних дел по г. Домодедово', CAST(N'2010-01-08' AS Date), N'414366 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'6167', N'388385', N'Николаев', N'Александр', N'Даниилович', 1, NULL, CAST(N'1975-04-22' AS Date), N'Россия, г. Дзержинск, Зеленая ул.', N'Управление внутренних дел по г. Тольятти', CAST(N'2010-01-03' AS Date), N'175772 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'6938', N'264574', N'Завьялова', N'Алёна', N'Адамовна', 2, NULL, CAST(N'1984-05-07' AS Date), N'Россия, г. Уссурийск, Светлая ул.', N'ОУФМС России по г. Грозный', CAST(N'2010-01-01' AS Date), N'140865 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'7093', N'315912', N'Богданова', N'Валерия', N'Андреевна', 2, NULL, CAST(N'1968-11-06' AS Date), N'Россия, г. Балаково, Мирная ул.', N'ОВД России по г. Дзержинск', CAST(N'2010-01-27' AS Date), N'796938 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'7294', N'781254', N'Золотарев', N'Никита', N'Максимович', 1, NULL, CAST(N'1969-05-04' AS Date), N'Россия, г. Находка, Центральная ул.', N'Отделением УФМС России по г. Иваново', CAST(N'2010-01-05' AS Date), N'776229 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'7405', N'876093', N'Моя Фамилия', N'Моё Имя', N'Моё Отчество', 1, NULL, CAST(N'1111-11-11' AS Date), N'Хорошее', N'Мной и точка', CAST(N'1111-11-11' AS Date), N'111-111')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'7523', N'112595', N'Кожевников', N'Степан', N'Владимирович', 1, NULL, CAST(N'1977-07-12' AS Date), N'Россия, г. Хабаровск, Советская ул.', N'Отделом УФМС России по г. Евпатория', CAST(N'2010-01-25' AS Date), N'360026 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'7552', N'525683', N'Григорьева', N'Светлана', N'Эминовна', 2, NULL, CAST(N'1983-08-20' AS Date), N'Россия, г. Армавир, Дачная ул.', N'Отделением УФМС России по г. Москва', CAST(N'2010-01-19' AS Date), N'305284 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'7692', N'125266', N'Павлова', N'Анастасия', N'Тимофеевна', 2, NULL, CAST(N'1973-06-25' AS Date), N'Россия, г. Ульяновск, Набережная ул.', N'Управление внутренних дел по г. Березники', CAST(N'2010-01-24' AS Date), N'285089 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'8250', N'843305', N'Одинцова', N'Варвара', N'Михайловна', 2, NULL, CAST(N'1978-09-25' AS Date), N'Россия, г. Братск, Дружная ул.', N'Отделом УФМС России по г. Энгельс', CAST(N'2010-01-18' AS Date), N'905250 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'8395', N'473006', N'Попов', N'Андрей', N'Евгеньевич', 1, NULL, CAST(N'1971-08-04' AS Date), N'Россия, г. Саранск, Комсомольская ул.', N'Отделом УФМС России по г. Ноябрьск', CAST(N'2010-01-17' AS Date), N'516236 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'8398', N'413078', N'Спиридонова', N'Фатима', N'Михайловна', 2, NULL, CAST(N'1979-03-05' AS Date), N'Россия, г. Энгельс, Советская ул.', N'Отделом внутренних дел России по г. Южно-Сахалинск', CAST(N'2010-01-16' AS Date), N'575319 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'8592', N'683110', N'Никитина', N'Александра', N'Даниэльевна', 2, NULL, CAST(N'1968-12-22' AS Date), N'Россия, г. Калуга, Совхозная ул.', N'Отделением УФМС России по г. Новокузнецк', CAST(N'2010-01-02' AS Date), N'673025 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'8668', N'407290', N'Афанасьев', N'Максим', N'Макарович', 1, NULL, CAST(N'1971-10-04' AS Date), N'Россия, г. Йошкар-Ола, Пролетарская ул.', N'Отделением УФМС России по г. Сергиев Посад', CAST(N'2010-01-15' AS Date), N'764017 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'8892', N'355459', N'Рудаков', N'Дмитрий', N'Тимофеевич', 1, NULL, CAST(N'1970-10-21' AS Date), N'Россия, г. Дербент, Интернациональная ул.', N'ОВД России по г. Балашиха', CAST(N'2010-01-07' AS Date), N'558948 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'9393', N'600430', N'Алексеев', N'Марк', N'Маркович', 1, NULL, CAST(N'1982-02-17' AS Date), N'Россия, г. Ковров, Ленина ул.', N'Отделом внутренних дел России по г. Иваново', CAST(N'2010-01-21' AS Date), N'622886 ')
INSERT [dbo].[PassportTable] ([Series_Passport], [Number_Passport], [Surname_Passport], [Name_Passport], [Middlename_Passport], [pnGender_Passport], [Image_Passport], [DateOfBrich_Passport], [LocationOfBrich_Passport], [Issued_Passport], [DateIssued_Passport], [DivisionCode_Passport]) VALUES (N'9824', N'880006', N'Савина', N'София', N'Германовна', 2, NULL, CAST(N'1974-04-13' AS Date), N'Россия, г. Орёл, Сельская ул.', N'ОУФМС России по г. Мытищи', CAST(N'2010-01-11' AS Date), N'478232 ')
GO
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'0120165985', CAST(N'2023-03-18' AS Date), N'Test 001', N'Test 001', N'Test 001', N'Test 001', N'23', N'25')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'1111111111', CAST(N'0001-01-01' AS Date), N'Error 404', N'Error 404', N'Error 404', N'Error 404', N'0', N'0')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'2252627719', CAST(N'2018-01-28' AS Date), N'Республика Дагестан', N'Нёрребро', N'Ханты-Мансийский автономный округ', N'Молодежная', N'212', N'462')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'2463369762', CAST(N'2018-01-29' AS Date), N'Республика Алтай', N'Андерсонвилль', N'Забайкальский край', N'Белорусская', N'111', N'28')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'2597312423', CAST(N'2018-01-20' AS Date), N'Республика Дагестан', N'Андерсонвилль', N'Иркутская область', N'Сельская', N'56', N'49')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'2598862161', CAST(N'2018-01-06' AS Date), N'Кабардино-Балкарская Республика', N'Ставропольский край', N'Иркутская область', N'Хуторская', N'444', N'42')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'3218634336', CAST(N'2018-01-14' AS Date), N'Кабардино-Балкарская Республика', N'Приморский край', N'Ханты-Мансийский автономный округ', N'Советская', N'4562', N'26')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'3514165077', CAST(N'2018-01-26' AS Date), N'Республика Башкортостан', N'Воронежская область', N'Красноярский край', N'Майская', N'45', N'444')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'3754156172', CAST(N'2018-01-10' AS Date), N'Республика Башкортостан', N'Нёрребро', N'Республика Крым', N'Полесская', N'1010', N'456')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'4162400236', CAST(N'2018-01-22' AS Date), N'Кабардино-Балкарская Республика', N'Красноярский край', N'Забайкальский край', N'Луговая', N'238', N'458')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'4408609463', CAST(N'2018-01-04' AS Date), N'Республика Дагестан', N'Красноярский край', N'Ненецкий автономный округ', N'Интернациональная', N'159', N'10')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'4710619218', CAST(N'2018-01-09' AS Date), N'Республика Адыгея', N'Иркутская область', N'Пермский край', N'Максима Горького', N'218', N'18')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'5139613586', CAST(N'2018-01-23' AS Date), N'Республика Калмыкия', N'Приморский край', N'Пермский край', N'Речная', N'218', N'123')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'5157842187', CAST(N'1111-11-11' AS Date), N'Test002', N'Test002', N'Test002', N'Test002', N'111111', N'1111')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'5198948399', CAST(N'2018-01-30' AS Date), N'Кабардино-Балкарская Республика', N'Чоннам Сам-га', N'Пермский край', N'Пионерская', N'222', N'256')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'5341534843', CAST(N'0005-05-05' AS Date), N'Регион ПРОВЕРКА', N'Район ПРОВЕРКА', N'Пункт ПРОВЕРКА', N'Улица ПРОВЕРКА', N'05', N'05')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'5534869147', CAST(N'2018-01-12' AS Date), N'Республика Дагестан', N'Чоннам Сам-га', N'Красноярский край', N'Луговая', N'359', N'426')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'5619279885', CAST(N'2018-01-13' AS Date), N'Республика Алтай', N'Красноярский край', N'Иркутская область', N'Западная', N'167', N'875')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'5648755340', CAST(N'2018-01-08' AS Date), N'Карачаево-Черкесская Республика', N'Воронежская область', N'Забайкальский край', N'Ленинская', N'256', N'24')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'6167388385', CAST(N'2018-01-03' AS Date), N'Республика Бурятия', N'Чоннам Сам-га', N'Республика Крым', N'Чкалова', N'246', N'12')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'6938264574', CAST(N'2018-01-01' AS Date), N'Республика Адыгея', N'Нёрребро', N'Забайкальский край', N'Зягас', N'101', N'105')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'7093315912', CAST(N'2018-01-27' AS Date), N'Республика Бурятия', N'Иркутская область', N'Иркутская область', N'Песчаная', N'254', N'495')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'7294781254', CAST(N'2018-01-05' AS Date), N'Республика Алтай', N'Приморский край', N'Красноярский край', N'Совхозная', N'452', N'58')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'7405876093', CAST(N'1111-11-11' AS Date), N'Хороший, не жалуюсь', N'Хороший', N'За 105 двор', N'Стреляю в упор', N'1111111111', N'1111111111')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'7523112595', CAST(N'2018-01-25' AS Date), N'Республика Адыгея', N'Волгоградская область', N'Ненецкий автономный округ', N'Сосновая', N'51285', N'248')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'7552525683', CAST(N'2018-01-19' AS Date), N'Республика Бурятия', N'Нёрребро', N'Красноярский край', N'Восточная', N'199', N'27')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'7692125266', CAST(N'2018-01-24' AS Date), N'Карачаево-Черкесская Республика', N'Ставропольский край', N'Республика Крым', N'Железнодорожная', N'333', N'526')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'8250843305', CAST(N'2018-01-18' AS Date), N'Республика Башкортостан', N'Иркутская область', N'Ненецкий автономный округ', N'Октябрьский', N'18', N'54')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'8395473006', CAST(N'2018-01-17' AS Date), N'Республика Адыгея', N'Воронежская область', N'Республика Крым', N'Сосновая', N'218', N'32')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'8398413078', CAST(N'2018-01-16' AS Date), N'Карачаево-Черкесская Республика', N'Волгоградская область', N'Пермский край', N'Мирная', N'2189', N'21')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'8592683110', CAST(N'2018-01-02' AS Date), N'Республика Башкортостан', N'Андерсонвилль', N'Пермский край', N'Сягг', N'333', N'5')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'8668407290', CAST(N'2018-01-15' AS Date), N'Республика Калмыкия', N'Ставропольский край', N'Забайкальский край', N'3 Марта', N'167', N'54')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'8892355459', CAST(N'2018-01-07' AS Date), N'Республика Калмыкия', N'Волгоградская область', N'Ханты-Мансийский автономный округ', N'Победы', N'489', N'15')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'9393600430', CAST(N'2018-01-21' AS Date), N'Республика Алтай', N'Чоннам Сам-га', N'Ханты-Мансийский автономный округ', N'Дорожная', N'2189', N'32')
INSERT [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence], [RegistrationDate_PlaceResidence], [Region_PlaceResidence], [District_PlaceResidence], [Point_PlaceResidence], [Street_PlaceResidence], [House_PlaceResidence], [Flat_PlaceResidence]) VALUES (N'9824880006', CAST(N'2018-01-11' AS Date), N'Республика Бурятия', N'Андерсонвилль', N'Ненецкий автономный округ', N'17 Сентября', N'110', N'851')
GO
SET IDENTITY_INSERT [dbo].[RoleTable] ON 

INSERT [dbo].[RoleTable] ([PersonalNumber_Role], [Name_Role]) VALUES (1, N'Программист')
INSERT [dbo].[RoleTable] ([PersonalNumber_Role], [Name_Role]) VALUES (2, N'Администратор')
INSERT [dbo].[RoleTable] ([PersonalNumber_Role], [Name_Role]) VALUES (3, N'Кассир')
INSERT [dbo].[RoleTable] ([PersonalNumber_Role], [Name_Role]) VALUES (4, N'Уборщик')
INSERT [dbo].[RoleTable] ([PersonalNumber_Role], [Name_Role]) VALUES (5, N'Директор')
SET IDENTITY_INSERT [dbo].[RoleTable] OFF
GO
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'1111111111111111', N'Error', N'404', N'23  ', N'07', N'141')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'1281784313798657', N'Svetlana', N'Grigorieva', N'26  ', N'07', N'129')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'1303631286832305', N'Vasilisa', N'Moiseeva', N'24  ', N'12', N'122')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'1435081713411878', N'Mark', N'Alekseev', N'23  ', N'09', N'131')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'1968114475822269', N'Varvara', N'Nikitina', N'26  ', N'02', N'124')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'2084871140302065', N'Ksenia', N'Gulyaeva', N'25  ', N'04', N'138')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'2104250123501254', N'Test 001', N'Test 001', N'2020', N'02', N'235')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'2963479254886119', N'Dmitry', N'Boldyrev', N'26  ', N'05', N'139')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'3067234261370138', N'Dmitry', N'Rudakov', N'24  ', N'07', N'117')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'3207264231541678', N'Alexander', N'Nikolaev', N'25  ', N'03', N'113')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'3739256940347611', N'Valeria', N'Bogdanova', N'24  ', N'03', N'137')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'3920392784305855', N'Victoria', N'Andreeva', N'27  ', N'10', N'120')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'4543554543574365', N'Test002', N'Test002', N'9562', N'65', N'513')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'4817887392263759', N'Andrey', N'Popov', N'24  ', N'05', N'127')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'5218221892245363', N'Maxim', N'Afanasyev', N'27  ', N'03', N'125')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'5468435468057468', N'Имя(Eng) ПРОВЕРКА', N'Фамилия (Eng) ПРОВЕРКА', N'0005', N'05', N'005')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'5794177846971733', N'Maxim', N'Kharitonov', N'25  ', N'01', N'123')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'5836152942827430', N'Varvara', N'Sudakova', N'25  ', N'11', N'133')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'6320540078651641', N'Sofia', N'Savina', N'23  ', N'11', N'121')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'6364711829814408', N'Kirill', N'Ustinov', N'23  ', N'06', N'116')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'6501643089688511', N'Egor', N'Solovyov', N'25  ', N'08', N'118')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'6715623917816301', N'Anna', N'Ivanova', N'27  ', N'06', N'140')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'6804514982365072', N'Stepan', N'Kozhevnikov', N'27  ', N'01', N'135')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'6881701502060592', N'Alena', N'Zavyalova', N'23  ', N'01', N'111')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'7238633030429361', N'Arseniy', N'Sergeev', N'26  ', N'04', N'114')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'7535776610353811', N'Alexandra', N'Nikitina', N'24  ', N'02', N'112')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'7546409270956283', N'Моё имя', N'Моя Фамилия', N'6435', N'46', N'516')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'7903275159609096', N'Timofey', N'Fokin', N'27  ', N'08', N'130')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'8026768387094746', N'Fatima', N'Spiridonova', N'23  ', N'04', N'126')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'8292298792078895', N'Anastasia', N'Pavlovna', N'26  ', N'12', N'134')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'8821931809819390', N'Ulyana', N'Orlova', N'23  ', N'02', N'136')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'8953775254592633', N'Anastasia', N'Petrova', N'26  ', N'09', N'119')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'9542409401650810', N'Varvara', N'Odintsovo', N'25  ', N'06', N'128')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'9869161857849344', N'Nikita', N'Zolotarev', N'27  ', N'05', N'115')
INSERT [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard], [NameEnd_SalaryCard], [SurnameEng_SalaryCard], [YearEnd_SalaryCard], [Month_SalaryCard], [Code_SalaryCard]) VALUES (N'9938400911116040', N'Nina', N'Balashova', N'24  ', N'10', N'132')
GO
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'11111111111', CAST(N'0001-01-01' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'12610802903', CAST(N'2015-01-13' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'13956757314', CAST(N'2015-01-09' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'17832818227', CAST(N'2015-01-16' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'20235620235', CAST(N'2023-03-18' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'22459024422', CAST(N'2015-01-12' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'23400037590', CAST(N'2015-01-29' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'25332392914', CAST(N'2015-01-04' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'25418501330', CAST(N'2015-01-15' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'31224920208', CAST(N'2015-01-08' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'35778749126', CAST(N'2015-01-11' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'36495370889', CAST(N'2015-01-30' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'37507998745', CAST(N'2015-01-25' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'45149563916', CAST(N'2015-01-02' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'45398237439', CAST(N'0005-05-05' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'45707806597', CAST(N'2015-01-17' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'47088145120', CAST(N'2015-01-26' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'56047231217', CAST(N'2015-01-01' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'56142583715', CAST(N'2015-01-07' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'56637685141', CAST(N'2015-01-10' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'61623558791', CAST(N'2015-01-14' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'65135435435', CAST(N'1111-11-11' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'65638610194', CAST(N'2015-01-03' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'66759660635', CAST(N'2015-01-21' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'70709831717', CAST(N'2015-01-23' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'72450247682', CAST(N'1111-11-11' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'72883458514', CAST(N'2015-01-28' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'73971049347', CAST(N'2015-01-06' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'76418743020', CAST(N'2015-01-22' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'84871848428', CAST(N'2015-01-24' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'89666240012', CAST(N'2015-01-05' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'92010456561', CAST(N'2015-01-27' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'92900663348', CAST(N'2015-01-18' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'98021438331', CAST(N'2015-01-19' AS Date))
INSERT [dbo].[SnilsTable] ([PersonalNumber_Snils], [DateRegistration_Snils]) VALUES (N'99656731632', CAST(N'2015-01-20' AS Date))
GO
SET IDENTITY_INSERT [dbo].[StatusTable] ON 

INSERT [dbo].[StatusTable] ([PersonalNumber_Status], [Title_Status]) VALUES (1, N'Offline')
INSERT [dbo].[StatusTable] ([PersonalNumber_Status], [Title_Status]) VALUES (2, N'Online')
SET IDENTITY_INSERT [dbo].[StatusTable] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkerTabe] ON 

INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (0, N'80000000000', N'Log1', N'Error 404', N'Pas1', 1, N'1111', N'111111', N'1111111111', N'11111111', N'1111111111111111', CAST(N'0001-01-01' AS Date), 1, N'111111111111', N'11111111111')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000001, N'89673995586', N'Wynnonandrea', N'froodian@verizon.net', N'moaF7H2A', 3, N'6938', N'264574', N'6938264574', N'17916876', N'6881701502060592', CAST(N'2022-01-02' AS Date), 1, N'555783861762', N'56047231217')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000002, N'89674503648', N'Warryaniabi', N'sjava@aol.com', N'eaU2m27r', 3, N'8592', N'683110', N'8592683110', N'28600299', N'7535776610353811', CAST(N'2022-01-03' AS Date), 1, N'204079758075', N'45149563916')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000003, N'89670946122', N'Pacobynahi', N'kwilliams@att.net', N'o15pRxo1', 2, N'6167', N'388385', N'6167388385', N'87593267', N'3207264231541678', CAST(N'2022-01-04' AS Date), 1, N'892250329757', N'65638610194')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000004, N'89671761253', N'Onetterylis', N'gmcgath@icloud.com', N'WY3x9aIw', 2, N'4408', N'609463', N'4408609463', N'54903451', N'7238633030429361', CAST(N'2022-01-05' AS Date), 2, N'531701296805', N'25332392914')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000005, N'89675210187', N'Neliana', N'dgatwood@yahoo.ca', N'4p294536', 3, N'7294', N'781254', N'7294781254', N'72733572', N'9869161857849344', CAST(N'2022-01-06' AS Date), 1, N'760147092163', N'89666240012')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000006, N'89673799278', N'Ykerangierr', N'telbij@icloud.com', N'2ofXg186', 3, N'2598', N'862161', N'2598862161', N'73877372', N'6364711829814408', CAST(N'2022-01-07' AS Date), 1, N'425933182602', N'73971049347')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000007, N'89677389513', N'Xueaaaaa', N'lydia@verizon.net', N'8251Y5i7', 3, N'8892', N'355459', N'8892355459', N'24832506', N'3067234261370138', CAST(N'2022-01-08' AS Date), 1, N'597053306366', N'56142583715')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000008, N'89678081517', N'Evelianna', N'ournews@yahoo.com', N'O64mS8m2', 3, N'5648', N'755340', N'5648755340', N'26313937', N'6501643089688511', CAST(N'2022-01-09' AS Date), 1, N'278645691400', N'31224920208')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000009, N'89674806772', N'Ecembern', N'gtaylor@optonline.net', N'BbmwYz7S', 3, N'4710', N'619218', N'4710619218', N'80832279', N'8953775254592633', CAST(N'2022-01-10' AS Date), 1, N'578847287158', N'13956757314')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000010, N'89675297080', N'Ylardanikko', N'oneiros@hotmail.com', N'bK39324k', 5, N'3754', N'156172', N'3754156172', N'54476345', N'3920392784305855', CAST(N'2022-01-11' AS Date), 1, N'368964107340', N'56637685141')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000011, N'89672868005', N'Omerounta', N'dwsauder@optonline.net', N'Qh8Jye2P', 4, N'9824', N'880006', N'9824880006', N'90738269', N'6320540078651641', CAST(N'2022-01-12' AS Date), 1, N'207287414307', N'35778749126')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000012, N'89670395576', N'Engelii', N'dobey@comcast.net', N'F63QZL76', 4, N'5534', N'869147', N'5534869147', N'30703453', N'1303631286832305', CAST(N'2022-01-13' AS Date), 1, N'935611187683', N'22459024422')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000013, N'89676673493', N'Jeannal', N'hstiles@sbcglobal.net', N'4RC3v9Yh', 4, N'5619', N'279885', N'5619279885', N'37253871', N'5794177846971733', CAST(N'2022-01-14' AS Date), 1, N'770847504005', N'12610802903')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000014, N'89672382180', N'Zirabell', N'cvrcek@me.com', N'36V8YCHD', 4, N'3218', N'634336', N'3218634336', N'93803320', N'1968114475822269', CAST(N'2022-01-15' AS Date), 1, N'157208969871', N'61623558791')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000015, N'89677727775', N'Xannericardn', N'kobayasi@mac.com', N'41m4jgxi', 4, N'8668', N'407290', N'8668407290', N'99805889', N'5218221892245363', CAST(N'2022-01-16' AS Date), 1, N'822260545777', N'25418501330')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000016, N'89671547208', N'Rlanthai', N'staikos@sbcglobal.net', N'7W7bXo16', 4, N'8398', N'413078', N'8398413078', N'71659198', N'8026768387094746', CAST(N'2022-01-17' AS Date), 1, N'570481242611', N'17832818227')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000017, N'89677511552', N'Xissalinahin', N'epeeist@sbcglobal.net', N'e56v54r1', 3, N'8395', N'473006', N'8395473006', N'24459158', N'4817887392263759', CAST(N'2022-01-18' AS Date), 1, N'387260043326', N'45707806597')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000018, N'89678000804', N'Mbertinellor', N'mcast@comcast.net', N'H2g46vO6', 3, N'8250', N'843305', N'8250843305', N'58560219', N'9542409401650810', CAST(N'2022-01-19' AS Date), 1, N'681217836720', N'92900663348')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000019, N'89677635393', N'Fadenver', N'jbarta@gmail.com', N'2wk8oAM6', 3, N'7552', N'525683', N'7552525683', N'63664317', N'1281784313798657', CAST(N'2022-01-20' AS Date), 1, N'290183054220', N'98021438331')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000020, N'89675727806', N'Margallori', N'mdielmann@optonline.net', N'13zo9343', 3, N'2597', N'312423', N'2597312423', N'23064507', N'7903275159609096', CAST(N'2022-01-21' AS Date), 2, N'816356137164', N'99656731632')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000021, N'89676871399', N'Tinellier', N'knorr@sbcglobal.net', N'56dHk1d9', 3, N'9393', N'600430', N'9393600430', N'92776545', N'1435081713411878', CAST(N'2022-01-22' AS Date), 1, N'646300114099', N'66759660635')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000022, N'89670929065', N'Geriettanag', N'wortmanj@verizon.net', N'708m3DwW', 3, N'4162', N'400236', N'4162400236', N'72893462', N'9938400911116040', CAST(N'2022-01-23' AS Date), 1, N'716916225593', N'76418743020')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000023, N'89672935871', N'Derielestas', N'catalog@msn.com', N'B726yYjK', 3, N'5139', N'613586', N'5139613586', N'81277009', N'5836152942827430', CAST(N'2022-01-24' AS Date), 1, N'366838812487', N'70709831717')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000024, N'89675313488', N'Lethereller', N'meinkej@yahoo.ca', N'W3t92Td2', 3, N'7692', N'125266', N'7692125266', N'70887789', N'8292298792078895', CAST(N'2022-01-25' AS Date), 1, N'463244237703', N'84871848428')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000025, N'89676610512', N'Lintellaniam', N'flaviog@verizon.net', N'i9c9j12s', 3, N'7523', N'112595', N'7523112595', N'19488056', N'6804514982365072', CAST(N'2022-01-26' AS Date), 1, N'506005689017', N'37507998745')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000026, N'89670440008', N'Leenalindan', N'citadel@yahoo.com', N'njZUcE5U', 2, N'3514', N'165077', N'3514165077', N'41239103', N'8821931809819390', CAST(N'2022-01-27' AS Date), 1, N'915563726504', N'47088145120')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000027, N'89679287991', N'Jennenedyth', N'kidehen@icloud.com', N'a4rEv26C', 2, N'7093', N'315912', N'7093315912', N'41091613', N'3739256940347611', CAST(N'2022-01-28' AS Date), 1, N'222219583283', N'92010456561')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000028, N'89673377168', N'Nevittzaa', N'catalog@yahoo.com', N'484YXa4H', 2, N'2252', N'627719', N'2252627719', N'79799656', N'2084871140302065', CAST(N'2022-01-29' AS Date), 2, N'217882389696', N'72883458514')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000029, N'89672088113', N'Janiamha', N'noticias@outlook.com', N'QFdzMh8v', 2, N'2463', N'369762', N'2463369762', N'60300345', N'2963479254886119', CAST(N'2022-01-30' AS Date), 1, N'196195438360', N'23400037590')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000030, N'89675826809', N'KDAFHiq', N'dodong@live.com', N'mS95862n', 1, N'5198', N'948399', N'5198948399', N'87101602', N'6715623917816301', CAST(N'2022-01-31' AS Date), 1, N'163099257134', N'36495370889')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000031, N'86452134565', N'Test 001', N'Test 001', N'Test 001', 1, N'0120', N'165985', N'0120165985', N'45632564', N'2104250123501254', CAST(N'2023-03-18' AS Date), 2, N'563264523456', N'20235620235')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000032, N'76347598345', N'fkjgbiurtghkulehg', N'JHGiushgkjebgkujhsdkiuhglkjhkuk', N'1234567890', 3, N'7405', N'876093', N'7405876093', N'11111138', N'7546409270956283', CAST(N'2023-03-19' AS Date), 2, N'764205274057', N'72450247682')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000033, N'48435468435', N'Test002', N'Test002', N'Test002', 2, N'5157', N'842187', N'5157842187', N'64535437', N'4543554543574365', CAST(N'2023-03-19' AS Date), 2, N'244326548567', N'65135435435')
INSERT [dbo].[WorkerTabe] ([PersonalNumber_Worker], [Phone_Worker], [Login_Worker], [Email_Worker], [Password_Worker], [pnRole_Worker], [SeriesPassport_Worker], [NumberPassport_Worker], [pnPlaceResidence_Worker], [pnMedicalBook_Worker], [pnSalaryCard_Worker], [DateWord_Worker], [pnStatus_Worker], [pnINN_Worker], [pnSnils_Worker]) VALUES (1000034, N'05050505050', N'Login ПРОВЕРКА', N'Электронная почта ПРОВЕРКА', N'Password ПРОВЕРКА', 1, N'5341', N'534843', N'5341534843', N'35468435', N'5468435468057468', CAST(N'2023-03-19' AS Date), 2, N'655435468768', N'45398237439')
SET IDENTITY_INSERT [dbo].[WorkerTabe] OFF
GO
ALTER TABLE [dbo].[PassportTable]  WITH CHECK ADD  CONSTRAINT [FK_PassportTable_GenderTable] FOREIGN KEY([pnGender_Passport])
REFERENCES [dbo].[GenderTable] ([PersonalNumber_Gender])
GO
ALTER TABLE [dbo].[PassportTable] CHECK CONSTRAINT [FK_PassportTable_GenderTable]
GO
ALTER TABLE [dbo].[WorkerTabe]  WITH CHECK ADD  CONSTRAINT [FK_WorkerTabe_INNWorkerTable] FOREIGN KEY([pnINN_Worker])
REFERENCES [dbo].[INNTable] ([PersonalNumber_INN])
GO
ALTER TABLE [dbo].[WorkerTabe] CHECK CONSTRAINT [FK_WorkerTabe_INNWorkerTable]
GO
ALTER TABLE [dbo].[WorkerTabe]  WITH CHECK ADD  CONSTRAINT [FK_WorkerTabe_MedicalBookTable] FOREIGN KEY([pnMedicalBook_Worker])
REFERENCES [dbo].[MedicalBookTable] ([PersonalNumber_MedicalBook])
GO
ALTER TABLE [dbo].[WorkerTabe] CHECK CONSTRAINT [FK_WorkerTabe_MedicalBookTable]
GO
ALTER TABLE [dbo].[WorkerTabe]  WITH CHECK ADD  CONSTRAINT [FK_WorkerTabe_PassportTable] FOREIGN KEY([SeriesPassport_Worker], [NumberPassport_Worker])
REFERENCES [dbo].[PassportTable] ([Series_Passport], [Number_Passport])
GO
ALTER TABLE [dbo].[WorkerTabe] CHECK CONSTRAINT [FK_WorkerTabe_PassportTable]
GO
ALTER TABLE [dbo].[WorkerTabe]  WITH CHECK ADD  CONSTRAINT [FK_WorkerTabe_PlaceResidenceTable] FOREIGN KEY([pnPlaceResidence_Worker])
REFERENCES [dbo].[PlaceResidenceTable] ([PersonalNumber_PlaceResidence])
GO
ALTER TABLE [dbo].[WorkerTabe] CHECK CONSTRAINT [FK_WorkerTabe_PlaceResidenceTable]
GO
ALTER TABLE [dbo].[WorkerTabe]  WITH CHECK ADD  CONSTRAINT [FK_WorkerTabe_RoleTable] FOREIGN KEY([pnRole_Worker])
REFERENCES [dbo].[RoleTable] ([PersonalNumber_Role])
GO
ALTER TABLE [dbo].[WorkerTabe] CHECK CONSTRAINT [FK_WorkerTabe_RoleTable]
GO
ALTER TABLE [dbo].[WorkerTabe]  WITH CHECK ADD  CONSTRAINT [FK_WorkerTabe_SalaryCardTable] FOREIGN KEY([pnSalaryCard_Worker])
REFERENCES [dbo].[SalaryCardTable] ([PersonalNumber_SalaryCard])
GO
ALTER TABLE [dbo].[WorkerTabe] CHECK CONSTRAINT [FK_WorkerTabe_SalaryCardTable]
GO
ALTER TABLE [dbo].[WorkerTabe]  WITH CHECK ADD  CONSTRAINT [FK_WorkerTabe_SnilsTable] FOREIGN KEY([pnSnils_Worker])
REFERENCES [dbo].[SnilsTable] ([PersonalNumber_Snils])
GO
ALTER TABLE [dbo].[WorkerTabe] CHECK CONSTRAINT [FK_WorkerTabe_SnilsTable]
GO
ALTER TABLE [dbo].[WorkerTabe]  WITH CHECK ADD  CONSTRAINT [FK_WorkerTabe_StatusTable] FOREIGN KEY([pnStatus_Worker])
REFERENCES [dbo].[StatusTable] ([PersonalNumber_Status])
GO
ALTER TABLE [dbo].[WorkerTabe] CHECK CONSTRAINT [FK_WorkerTabe_StatusTable]
GO
USE [master]
GO
ALTER DATABASE [DesctopHite] SET  READ_WRITE 
GO
