USE [master]
GO
/****** Object:  Database [GShop]    Script Date: 08/03/2017 10:01:51 SA ******/
CREATE DATABASE [GShop]
 CONTAINMENT = NONE
 
ALTER DATABASE [GShop] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [GShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GShop] SET  MULTI_USER 
GO
ALTER DATABASE [GShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GShop] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GShop] SET DELAYED_DURABILITY = DISABLED 
GO
USE [GShop]
GO
/****** Object:  Table [dbo].[CaThe]    Script Date: 08/03/2017 10:01:51 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CaThe](
	[MaCaThe] [int] IDENTITY(1,1) NOT NULL,
	[MaLoai] [int] NOT NULL,
	[TenCaThe] [nvarchar](100) NULL,
	[MoTa] [nvarchar](500) NULL,
	[NgaySinh] [date] NULL,
	[GiaMua] [int] NULL,
	[GiaBan] [int] NULL,
	[KhuyenMai] [int] NULL,
	[TinhTrang] [nvarchar](100) NULL,
	[HinhAnh] [nvarchar](500) NULL,
 CONSTRAINT [PK_CaThe] PRIMARY KEY CLUSTERED 
(
	[MaCaThe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 08/03/2017 10:01:51 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaChiTietHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaHoaDon] [int] NOT NULL,
	[MaCaThe] [int] NOT NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaChiTietHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 08/03/2017 10:01:51 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaNguoiDung] [int] NOT NULL,
	[NgayMua] [date] NULL,
	[TongTien] [int] NULL,
	[NgayGiaoHang] [date] NULL,
	[DiaChi] [nvarchar] (500) NULL,
	[TinhTrang] [nvarchar] (100) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Loai]    Script Date: 08/03/2017 10:01:51 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loai](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](500) NULL,
	[MoTa] [nvarchar](500) NULL,
 CONSTRAINT [PK_Loai] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 08/03/2017 10:01:51 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[MaNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](500) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[Email] [nvarchar](500) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar] (10),
	[SoDienThoai] [nvarchar](50) NULL,
	[VaiTro] [nvarchar](100) NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CaThe]  WITH CHECK ADD  CONSTRAINT [FK_CaThe_Loai] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[Loai] ([MaLoai])
GO
ALTER TABLE [dbo].[CaThe] CHECK CONSTRAINT [FK_CaThe_Loai]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_CaThe] FOREIGN KEY([MaCaThe])
REFERENCES [dbo].[CaThe] ([MaCaThe])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_CaThe]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NguoiDung] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NguoiDung]
GO
USE [master]
GO
ALTER DATABASE [GShop] SET  READ_WRITE 
GO

USE [GShop]
GO
SET IDENTITY_INSERT [dbo].[Loai] ON 

INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MoTa]) VALUES (1, N'Winter White', N'Là sự lựa chọn tốt nhất cho những người mới tập nuôi Hamster, thân thiện, ít sợ con người')
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MoTa]) VALUES (2, N'Campbell', N'Nhanh nhẹn, khó gần, dễ bị cắn, là động vật đột biến gen, không khuyến khích cho người mới')
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MoTa]) VALUES (3, N'Syrian Hamster', N'Là loại hamster to nhất, dễ gần với con người, càng lớn càng dễ chơi')
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MoTa]) VALUES (4, N'Robo', N'Nhút nhát nhưng nhanh nhẹn, nhỏ nhất trong các loại hamster, làm cảnh là chính')
SET IDENTITY_INSERT [dbo].[Loai] OFF
SET IDENTITY_INSERT [dbo].[CaThe] ON 

INSERT [dbo].[CaThe] ([MaCaThe], [MaLoai], [TenCaThe], [MoTa], [NgaySinh], [GiaMua], [GiaBan], [KhuyenMai], [TinhTrang], [HinhAnh]) VALUES (1, 1, N'Winter White 1', N'Lông xám, mượt, có một lằn đen dài trên lưng', CAST(N'2017-01-01' AS Date), 4000, 14000, 0, N'Sẵn bán', NULL)
INSERT [dbo].[CaThe] ([MaCaThe], [MaLoai], [TenCaThe], [MoTa], [NgaySinh], [GiaMua], [GiaBan], [KhuyenMai], [TinhTrang], [HinhAnh]) VALUES (2, 1, N'Winter White 2', N'Lông xám, mượt, có một lằn đen dài trên lưng', CAST(N'2016-12-12' AS Date), 5000, 15000, 0, N'Đã bán', NULL)
INSERT [dbo].[CaThe] ([MaCaThe], [MaLoai], [TenCaThe], [MoTa], [NgaySinh], [GiaMua], [GiaBan], [KhuyenMai], [TinhTrang], [HinhAnh]) VALUES (3 , 1, N'Winter White 3', N'Lông xám, mượt, có một lằn đen dài trên lưng', CAST(N'2016-12-12' AS Date), 6000, 16000, 0, N'Sẵn bán', NULL)
INSERT [dbo].[CaThe] ([MaCaThe], [MaLoai], [TenCaThe], [MoTa], [NgaySinh], [GiaMua], [GiaBan], [KhuyenMai], [TinhTrang], [HinhAnh]) VALUES (4 , 1, N'Winter White 4', N'Lông xám, mượt, có một lằn đen dài trên lưng', CAST(N'2016-12-12' AS Date), 7000, 17000, 0, N'Sẵn bán', NULL)
INSERT [dbo].[CaThe] ([MaCaThe], [MaLoai], [TenCaThe], [MoTa], [NgaySinh], [GiaMua], [GiaBan], [KhuyenMai], [TinhTrang], [HinhAnh]) VALUES (5 , 1, N'Winter White 5', N'Lông xám, mượt, có một lằn đen dài trên lưng', CAST(N'2016-12-12' AS Date), 8000, 18000, 0, N'Sẵn bán', NULL)
INSERT [dbo].[CaThe] ([MaCaThe], [MaLoai], [TenCaThe], [MoTa], [NgaySinh], [GiaMua], [GiaBan], [KhuyenMai], [TinhTrang], [HinhAnh]) VALUES (6 , 1, N'Winter White 6', N'Lông xám, mượt, có một lằn đen dài trên lưng', CAST(N'2016-12-12' AS Date), 9000, 19000, 0, N'Sẵn bán', NULL)
INSERT [dbo].[CaThe] ([MaCaThe], [MaLoai], [TenCaThe], [MoTa], [NgaySinh], [GiaMua], [GiaBan], [KhuyenMai], [TinhTrang], [HinhAnh]) VALUES (7 , 1, N'Winter White 7', N'Lông xám, mượt, có một lằn đen dài trên lưng', CAST(N'2016-12-12' AS Date), 10000, 20000, 0, N'Sẵn bán', NULL)
INSERT [dbo].[CaThe] ([MaCaThe], [MaLoai], [TenCaThe], [MoTa], [NgaySinh], [GiaMua], [GiaBan], [KhuyenMai], [TinhTrang], [HinhAnh]) VALUES (8 , 1, N'Campbell 1', N'Đốm đen, mũi đỏ, mắt hiếp', CAST(N'2016-12-12' AS Date), 5000, 95000, 0, N'Sẵn bán', NULL)
INSERT [dbo].[CaThe] ([MaCaThe], [MaLoai], [TenCaThe], [MoTa], [NgaySinh], [GiaMua], [GiaBan], [KhuyenMai], [TinhTrang], [HinhAnh]) VALUES (9 , 1, N'CampBell 2', N'Đốm đen, mũi đỏ, mắt hiếp', CAST(N'2016-12-12' AS Date), 5000, 95000, 0, N'Sẵn bán', NULL)
INSERT [dbo].[CaThe] ([MaCaThe], [MaLoai], [TenCaThe], [MoTa], [NgaySinh], [GiaMua], [GiaBan], [KhuyenMai], [TinhTrang], [HinhAnh]) VALUES (10, 1, N'Syrian 1', N'Lông cam xù, mỏ heo ,tai vểnh', CAST(N'2016-12-12' AS Date), 1000, 17000, 0, N'Sẵn bán', NULL)
INSERT [dbo].[CaThe] ([MaCaThe], [MaLoai], [TenCaThe], [MoTa], [NgaySinh], [GiaMua], [GiaBan], [KhuyenMai], [TinhTrang], [HinhAnh]) VALUES (11, 1, N'Syrian 2', N'Lông cam xù, mỏ heo ,tai vểnh', CAST(N'2016-12-12' AS Date), 1000, 17000, 0, N'Sẵn bán', NULL)
INSERT [dbo].[CaThe] ([MaCaThe], [MaLoai], [TenCaThe], [MoTa], [NgaySinh], [GiaMua], [GiaBan], [KhuyenMai], [TinhTrang], [HinhAnh]) VALUES (12, 1, N'Robotic 1', N'Mặt ngầu, tinh vi, trông rất nguy hiểm', CAST(N'2016-12-12' AS Date), 46000, 69000, 0, N'Đã mất', NULL)
SET IDENTITY_INSERT [dbo].[CaThe] OFF
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([MaNguoiDung], [TenDangNhap], [MatKhau], [Email], [NgaySinh], [GioiTinh], [SoDienThoai], [VaiTro]) VALUES (1, N'user1', N'123456', N'admin@gmail.com', CAST(N'2000-01-15' AS Date), N'Nam', N'01698734925', N'Quản trị viên')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [TenDangNhap], [MatKhau], [Email], [NgaySinh], [GioiTinh], [SoDienThoai], [VaiTro]) VALUES (2, N'user2', N'123456', N'KhachHang1@gmail.com', CAST(N'2000-02-19' AS Date), N'Nu', N'0123456987', N'Khách hàng')
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNguoiDung], [NgayMua], [TongTien], [TinhTrang]) VALUES (1, 2, CAST(N'2017-03-07' AS Date), 15000, N'Hoàn thành')
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] ON 

INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaCaThe]) VALUES (3, 1, 2)
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] OFF



