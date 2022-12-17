USE [master]
GO
/****** Object:  Database [BTL_DoAn]    Script Date: 16/12/2022 10:32:57 CH ******/
CREATE DATABASE [BTL_DoAn]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BTL_DoAn', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.HAUTLYM\MSSQL\DATA\BTL_DoAn.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BTL_DoAn_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.HAUTLYM\MSSQL\DATA\BTL_DoAn_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BTL_DoAn] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BTL_DoAn].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BTL_DoAn] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BTL_DoAn] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BTL_DoAn] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BTL_DoAn] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BTL_DoAn] SET ARITHABORT OFF 
GO
ALTER DATABASE [BTL_DoAn] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BTL_DoAn] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BTL_DoAn] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BTL_DoAn] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BTL_DoAn] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BTL_DoAn] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BTL_DoAn] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BTL_DoAn] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BTL_DoAn] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BTL_DoAn] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BTL_DoAn] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BTL_DoAn] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BTL_DoAn] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BTL_DoAn] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BTL_DoAn] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BTL_DoAn] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BTL_DoAn] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BTL_DoAn] SET RECOVERY FULL 
GO
ALTER DATABASE [BTL_DoAn] SET  MULTI_USER 
GO
ALTER DATABASE [BTL_DoAn] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BTL_DoAn] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BTL_DoAn] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BTL_DoAn] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BTL_DoAn] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BTL_DoAn] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BTL_DoAn', N'ON'
GO
ALTER DATABASE [BTL_DoAn] SET QUERY_STORE = OFF
GO
USE [BTL_DoAn]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[abouts]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[abouts](
	[ShopId] [int] IDENTITY(1,1) NOT NULL,
	[ShopName] [nvarchar](max) NOT NULL,
	[NumberPhone] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[AddressInMap] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_abouts] PRIMARY KEY CLUSTERED 
(
	[ShopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppRoleClaims]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppRoles]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUser]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUser](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,
	[Dob] [datetime2](7) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Male] [nvarchar](max) NOT NULL,
	[NumberPhone] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AppUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserClaims]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserLogins]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserLogins](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserRoles]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AppUserRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserTokens]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserTokens](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[CartId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Voucher] [nvarchar](max) NOT NULL,
	[AppUserId] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[ContactName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[NumberPhone] [nvarchar](max) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[NewsId] [int] IDENTITY(1,1) NOT NULL,
	[Img] [nvarchar](max) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Author] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[DatePost] [datetime2](7) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[NewsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[ProductId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[ShipName] [nvarchar](max) NOT NULL,
	[ShipAddress] [nvarchar](max) NOT NULL,
	[ShipEmail] [nvarchar](max) NOT NULL,
	[ShipNumberPhone] [nvarchar](max) NOT NULL,
	[ShipDescription] [nvarchar](max) NOT NULL,
	[ShippingFee] [nvarchar](max) NOT NULL,
	[AppUserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Policies]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Policies](
	[PolicyId] [int] IDENTITY(1,1) NOT NULL,
	[PolicyName] [nvarchar](max) NOT NULL,
	[PolicyDescription] [nvarchar](max) NOT NULL,
	[Discount] [float] NOT NULL,
	[ProductId] [int] NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Voucher] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Policies] PRIMARY KEY CLUSTERED 
(
	[PolicyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImages]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ImagePath] [nvarchar](200) NOT NULL,
	[Caption] [nvarchar](200) NOT NULL,
	[IsDefault] [bit] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[SortOrder] [int] NOT NULL,
	[FileSize] [bigint] NOT NULL,
 CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 16/12/2022 10:32:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[ProductPrice] [float] NOT NULL,
	[ProductTitle] [nvarchar](max) NOT NULL,
	[ProductDescription] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[CountView] [int] NOT NULL,
	[Discount] [float] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[PolicyId] [int] NOT NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221214170517_initialDB', N'6.0.5')
GO
INSERT [dbo].[AppRoles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9ab9a5bb-b398-4f53-8f05-681efd68e16f', N'admin', N'admin', N'admin', N'{0092D1C0-90BC-4CFC-97EE-1329A32E801D}')
GO
INSERT [dbo].[AppUser] ([Id], [FirstName], [LastName], [Dob], [Address], [Male], [NumberPhone], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'f5cf191e-11fa-4d7a-1cb5-08daddf60285', N'Hậu', N'Nguyễn', CAST(N'2022-12-14T17:09:14.1630000' AS DateTime2), N'Hưng Yên', N'Nam', N'0987654321', N'hautlym', N'HAUTLYM', N'nguyenhautlym@gmail.com', N'NGUYENHAUTLYM@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEMfQtDam/faIn8yg2j3NgD6n65V4U5bG44IeYAuqlV+BvCZUIW/1FSd688zmqkF0cw==', N'KSKQOYFF6DRVPYRX4ZRFNTEGHULPE7OG', N'2080a1fe-26ce-4019-904b-b5b43a79da19', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AppUser] ([Id], [FirstName], [LastName], [Dob], [Address], [Male], [NumberPhone], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'28aa400b-0c48-46fa-1cb6-08daddf60285', N'Nguyễn', N'Văn Hậu ', CAST(N'2022-12-03T00:13:00.0000000' AS DateTime2), N'Tân Lập - Yên Mỹ - Hưng yên', N'Nam', N'1234567890', N'hautlym1', N'HAUTLYM1', N'fsfssf@gmail.com', N'FSFSSF@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKYxJbsT3ajGfENSidPbQcvF7ud8uSzZBMayaz7jeLubUUIg04tXLf+lLyS9A8CF7A==', N'XG3TEBMYDP64MYZYPJOOVME7KKVLM27B', N'0efb9370-1ace-4d69-a592-c3b98be63c38', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AppUserRoles] ([UserId], [RoleId]) VALUES (N'f5cf191e-11fa-4d7a-1cb5-08daddf60285', N'9ab9a5bb-b398-4f53-8f05-681efd68e16f')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (2, N'Coffee', N'các sản phẩm cà phê')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (3, N'Trà Sữa', N'Các loại đồ uống khác ')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (4, N'Đồ Ăn Vặt', N'Các loại đồ ăn vặt')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (5, N'Trà', N'Các loại trà')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([ContactId], [ContactName], [Email], [NumberPhone], [Message]) VALUES (1, N'Nguyễn Văn A', N'nguyenhautlym@gmail.com', N'Muốn đổi hàng', N'sfdghjkl;''')
INSERT [dbo].[Contacts] ([ContactId], [ContactName], [Email], [NumberPhone], [Message]) VALUES (2, N'Nguyễn Văn A', N'nguyenhautlym@gmail.com', N'Muốn đổi hàng', N'sfdghjkl;''')
INSERT [dbo].[Contacts] ([ContactId], [ContactName], [Email], [NumberPhone], [Message]) VALUES (3, N'Nguyễn Văn A', N'nguyenhautlym@gmail.com', N'Muốn đổi hàng', N'o98i7u6yhgt5rfedws')
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[Policies] ON 

INSERT [dbo].[Policies] ([PolicyId], [PolicyName], [PolicyDescription], [Discount], [ProductId], [StartDate], [EndDate], [Voucher]) VALUES (1, N'fđggg3434', N'sggdfgfgtring', 1, 1, CAST(N'2022-12-14T17:12:16.4940000' AS DateTime2), CAST(N'2022-12-14T17:12:16.4940000' AS DateTime2), N'fdfdf')
SET IDENTITY_INSERT [dbo].[Policies] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductImages] ON 

INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (2, 2, N'c9dfdb5c-3b9c-42b0-b6b1-c2d8adeb6bac.jpeg', N'Thumbnail image', 1, CAST(N'2022-12-15T23:22:15.8648462' AS DateTime2), 1, 108170)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (3, 3, N'5303b5db-d067-4bbe-9b0b-8acc352c8ae7.jpg', N'Thumbnail image', 1, CAST(N'2022-12-15T23:26:53.8065143' AS DateTime2), 1, 211398)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (4, 4, N'92a348d8-850d-4f2a-afd0-d7d028789fc9.jfif', N'Thumbnail image', 1, CAST(N'2022-12-15T23:35:37.1872099' AS DateTime2), 1, 5435)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (5, 5, N'0e89a34b-0813-4a42-b2e3-90955ccec77c.webp', N'Thumbnail image', 1, CAST(N'2022-12-15T23:37:37.8707345' AS DateTime2), 1, 81986)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (6, 6, N'2b15aff8-caed-4ef6-90a8-af0615b41c44.jfif', N'Thumbnail image', 1, CAST(N'2022-12-15T23:38:39.1520871' AS DateTime2), 1, 7669)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (7, 7, N'07366305-de65-48c3-bc25-30121900e22f.jpg', N'Thumbnail image', 1, CAST(N'2022-12-15T23:42:30.3456204' AS DateTime2), 1, 29843)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (8, 8, N'a09dfcf2-bd95-4580-be16-a4b2d5f15c21.jfif', N'Thumbnail image', 1, CAST(N'2022-12-15T23:43:45.0988357' AS DateTime2), 1, 7092)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (9, 9, N'dc814ae0-0a8e-435f-93d4-8091d99acc29.png', N'Thumbnail image', 1, CAST(N'2022-12-15T23:45:38.3317774' AS DateTime2), 1, 342340)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (10, 10, N'74f8a15d-2f90-420c-87b8-695eeb9b7bea.webp', N'Thumbnail image', 1, CAST(N'2022-12-15T23:47:11.2892437' AS DateTime2), 1, 36790)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (11, 11, N'20c4baec-018c-4bf3-96be-f5e74d912c67.jfif', N'Thumbnail image', 1, CAST(N'2022-12-15T23:48:43.9060793' AS DateTime2), 1, 6369)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (12, 12, N'2626f586-47c3-49a9-b820-1b636f6f0366.jpg', N'Thumbnail image', 1, CAST(N'2022-12-15T23:50:03.8280710' AS DateTime2), 1, 112003)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (13, 13, N'14718034-545e-45ac-a02e-710e9c44470a.jpg', N'Thumbnail image', 1, CAST(N'2022-12-15T23:51:20.7330186' AS DateTime2), 1, 49130)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (14, 14, N'0c655353-85dd-48b7-b580-d9a1cc553123.jpg', N'Thumbnail image', 1, CAST(N'2022-12-15T23:52:23.8425044' AS DateTime2), 1, 61419)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (15, 15, N'cb2540f8-6cd8-489b-add1-43a369b87970.webp', N'Thumbnail image', 1, CAST(N'2022-12-15T23:53:37.5171747' AS DateTime2), 1, 34692)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (16, 16, N'1e300733-6087-46f5-84bd-461fe42c1632.jfif', N'Thumbnail image', 1, CAST(N'2022-12-15T23:55:26.1309808' AS DateTime2), 1, 9746)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (17, 17, N'cc9839db-a368-4ab5-861e-5b095fc03d61.jpg', N'Thumbnail image', 1, CAST(N'2022-12-15T23:56:35.7303005' AS DateTime2), 1, 202317)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (18, 19, N'e656aee5-cf1b-4422-b5c0-ec35331dc4f9.jpg', N'Thumbnail image', 1, CAST(N'2022-12-15T23:58:13.5479446' AS DateTime2), 1, 173729)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [IsDefault], [DateCreated], [SortOrder], [FileSize]) VALUES (19, 20, N'47faba36-a996-4039-a188-b567fa4c3ff8.jfif', N'Thumbnail image', 1, CAST(N'2022-12-16T00:00:16.4926055' AS DateTime2), 1, 9253)
SET IDENTITY_INSERT [dbo].[ProductImages] OFF
GO
SET IDENTITY_INSERT [dbo].[products] ON 

INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (2, N'Cà phê cốt dừa', 30000, N'Cà phê cốt dừa', N'Đây là cà phê làm từ cốt dừa', N'Còn hàng', 0, 0, 2, 1)
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (3, N'Cà phê muối', 25000, N'Đây là cà phê muối', N'Đây là cà phê muối', N'Còn hàng', 0, 0, 2, 1)
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (4, N'Cà phê bạc xỉu', 25000, N'cà phê bạc xỉu', N'đây là cà phê bạc xỉu', N'Còn Hàng', 0, 10, 2, 1)
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (5, N'Cà phê nâu', 25000, N'Cà phê nâu', N'Cà phê nâu', N'Còn Hàng', 0, 15, 2, 1)
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (6, N'Cà phê đen', 25000, N'đây là cà phê đen', N'đây là cà phê đen', N'Còn Hàng', 0, 0, 2, 1)
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (7, N'Cà phê Espresso', 30000, N'Cà phê Espresso', N'Cà phê Espresso', N'Còn Hàng', 0, 0, 2, 1)
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (8, N'Trà Sữa Dừa', 30000, N'Trà Sữa Dừa', N'Trà Sữa Dừa', N'Còn Hàng', 0, 0, 3, 1)
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (9, N'Trà sữa nướng kem trứng', 30000, N'Trà sữa nướng kem trứng', N'Trà sữa nướng kem trứng', N'Còn Hàng', 0, 0, 3, 1)
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (10, N'Trà Sữa Mix Vị', 30000, N'Trà Sữa Mix Vị', N'Trà Sữa Mix Vị', N'Còn Hàng', 0, 0, 3, 1)
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (11, N'Trà Sữa Oreo', 30000, N'Trà Sữa Oreo', N'Trà Sữa Oreo', N'Còn Hàng', 0, 5, 3, 1)
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (12, N'Sữa tươi trân châu đường đen', 30000, N'Sữa tươi trân châu đường đen', N'Sữa tươi trân châu đường đen', N'Còn Hàng', 0, 0, 3, 1)
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (13, N'Sữa chua nha đam', 25000, N'Sữa chua nha đam', N'Sữa chua nha đam', N'Còn Hàng', 0, 10, 3, 1)
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (14, N'Khoai tây chiên', 20000, N'Khoai tây chiên', N'Khoai tây chiên', N'Còn Hàng', 0, 0, 4, 1)
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (15, N'Khoai Lang Kén', 20000, N'Khoai Lang Kén', N'Khoai Lang Kén', N'Còn Hàng', 0, 0, 4, 1)
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (16, N'Bánh Pizza', 150000, N'Bánh Pizza', N'Bánh Pizza', N'Còn Hàng', 0, 10, 4, 1)
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (17, N'Hạt Hướng Dương', 10000, N'Hạt Hướng Dương', N'Hạt Hướng Dương', N'Còn Hàng', 0, 0, 4, 1)
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (19, N'Gà Rán', 35000, N'Gà Rán', N'Gà Rán', N'Còn Hàng', 0, 0, 4, 1)
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductPrice], [ProductTitle], [ProductDescription], [Status], [CountView], [Discount], [CategoryId], [PolicyId]) VALUES (20, N'Kimbap', 20000, N'Kimbap', N'Kimbap', N'Còn hàng', 0, 0, 4, 1)
SET IDENTITY_INSERT [dbo].[products] OFF
GO
/****** Object:  Index [IX_Carts_AppUserId]    Script Date: 16/12/2022 10:32:58 CH ******/
CREATE NONCLUSTERED INDEX [IX_Carts_AppUserId] ON [dbo].[Carts]
(
	[AppUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Carts_ProductId]    Script Date: 16/12/2022 10:32:58 CH ******/
CREATE NONCLUSTERED INDEX [IX_Carts_ProductId] ON [dbo].[Carts]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_News_UserId]    Script Date: 16/12/2022 10:32:58 CH ******/
CREATE NONCLUSTERED INDEX [IX_News_UserId] ON [dbo].[News]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_ProductId]    Script Date: 16/12/2022 10:32:58 CH ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductId] ON [dbo].[OrderDetails]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_AppUserId]    Script Date: 16/12/2022 10:32:58 CH ******/
CREATE NONCLUSTERED INDEX [IX_Orders_AppUserId] ON [dbo].[Orders]
(
	[AppUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductImages_ProductId]    Script Date: 16/12/2022 10:32:58 CH ******/
CREATE NONCLUSTERED INDEX [IX_ProductImages_ProductId] ON [dbo].[ProductImages]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_products_CategoryId]    Script Date: 16/12/2022 10:32:58 CH ******/
CREATE NONCLUSTERED INDEX [IX_products_CategoryId] ON [dbo].[products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_products_PolicyId]    Script Date: 16/12/2022 10:32:58 CH ******/
CREATE NONCLUSTERED INDEX [IX_products_PolicyId] ON [dbo].[products]
(
	[PolicyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((1)) FOR [Quantity]
GO
ALTER TABLE [dbo].[products] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Discount]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_AppUser_AppUserId] FOREIGN KEY([AppUserId])
REFERENCES [dbo].[AppUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_AppUser_AppUserId]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_products_ProductId]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_AppUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_AppUser_UserId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_AppUser_AppUserId] FOREIGN KEY([AppUserId])
REFERENCES [dbo].[AppUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_AppUser_AppUserId]
GO
ALTER TABLE [dbo].[ProductImages]  WITH CHECK ADD  CONSTRAINT [FK_ProductImages_products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductImages] CHECK CONSTRAINT [FK_ProductImages_products_ProductId]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [FK_products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[products] CHECK CONSTRAINT [FK_products_Categories_CategoryId]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [FK_products_Policies_PolicyId] FOREIGN KEY([PolicyId])
REFERENCES [dbo].[Policies] ([PolicyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[products] CHECK CONSTRAINT [FK_products_Policies_PolicyId]
GO
USE [master]
GO
ALTER DATABASE [BTL_DoAn] SET  READ_WRITE 
GO
