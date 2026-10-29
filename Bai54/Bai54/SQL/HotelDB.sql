/* =====================================================================
   BÀI 54 - HOTEL MANAGEMENT SYSTEM  |  Script tạo CSDL HotelDB
   Chạy toàn bộ script trong SQL Server Object Explorer / SSMS
   (New Query trên server, KHÔNG cần tạo trước database)
   ===================================================================== */
IF DB_ID(N'HotelDB') IS NULL
    CREATE DATABASE HotelDB;
GO

USE HotelDB;
GO

/* ---------- Xóa bảng cũ (nếu có) theo thứ tự khóa ngoại ---------- */
IF OBJECT_ID(N'dbo.SuDungDichVu', N'U') IS NOT NULL DROP TABLE dbo.SuDungDichVu;
IF OBJECT_ID(N'dbo.PhieuDatPhong', N'U') IS NOT NULL DROP TABLE dbo.PhieuDatPhong;
IF OBJECT_ID(N'dbo.DichVu', N'U') IS NOT NULL DROP TABLE dbo.DichVu;
IF OBJECT_ID(N'dbo.KhachHang', N'U') IS NOT NULL DROP TABLE dbo.KhachHang;
IF OBJECT_ID(N'dbo.Phong', N'U') IS NOT NULL DROP TABLE dbo.Phong;
GO

/* ---------- 1. Phòng ---------- */
CREATE TABLE dbo.Phong
(
    SoPhong     varchar(10)   NOT NULL CONSTRAINT PK_Phong PRIMARY KEY,
    LoaiPhong   nvarchar(50)  NOT NULL,
    GiaTheoGio  decimal(18,2) NOT NULL CONSTRAINT CK_Phong_Gia CHECK (GiaTheoGio >= 0),
    TrangThai   nvarchar(30)  NOT NULL CONSTRAINT DF_Phong_TT DEFAULT (N'Trống')
);
GO

/* ---------- 2. Khách hàng ---------- */
CREATE TABLE dbo.KhachHang
(
    MaKH         int IDENTITY(1,1) NOT NULL CONSTRAINT PK_KhachHang PRIMARY KEY,
    HoTen        nvarchar(100)     NOT NULL,
    CCCD         varchar(20)       NOT NULL CONSTRAINT UQ_KhachHang_CCCD UNIQUE,
    SoDienThoai  varchar(15)       NULL
);
GO

/* ---------- 3. Dịch vụ ---------- */
CREATE TABLE dbo.DichVu
(
    MaDV    int IDENTITY(1,1) NOT NULL CONSTRAINT PK_DichVu PRIMARY KEY,
    TenDV   nvarchar(100)     NOT NULL,
    DonGia  decimal(18,2)     NOT NULL CONSTRAINT CK_DichVu_Gia CHECK (DonGia >= 0)
);
GO

/* ---------- 4a. Phiếu đặt phòng ---------- */
CREATE TABLE dbo.PhieuDatPhong
(
    MaPhieu            int IDENTITY(1,1) NOT NULL CONSTRAINT PK_PhieuDatPhong PRIMARY KEY,
    SoPhong            varchar(10)   NOT NULL CONSTRAINT FK_Phieu_Phong REFERENCES dbo.Phong(SoPhong),
    MaKH               int           NOT NULL CONSTRAINT FK_Phieu_KhachHang REFERENCES dbo.KhachHang(MaKH),
    NgayNhanPhong      datetime      NOT NULL CONSTRAINT DF_Phieu_Nhan DEFAULT (GETDATE()),
    NgayTraPhong       datetime      NULL,
    TongTienThanhToan  decimal(18,2) NULL CONSTRAINT DF_Phieu_Tong DEFAULT (0)
);
GO

/* ---------- 4b. Sử dụng dịch vụ ---------- */
CREATE TABLE dbo.SuDungDichVu
(
    MaSD      int IDENTITY(1,1) NOT NULL CONSTRAINT PK_SuDungDichVu PRIMARY KEY,
    MaPhieu   int      NOT NULL CONSTRAINT FK_SD_Phieu REFERENCES dbo.PhieuDatPhong(MaPhieu),
    MaDV      int      NOT NULL CONSTRAINT FK_SD_DichVu REFERENCES dbo.DichVu(MaDV),
    SoLuong   int      NOT NULL CONSTRAINT CK_SD_SoLuong CHECK (SoLuong > 0),
    ThoiGian  datetime NOT NULL CONSTRAINT DF_SD_ThoiGian DEFAULT (GETDATE())
);
GO

/* ---------- Dữ liệu mẫu ---------- */
INSERT INTO dbo.Phong (SoPhong, LoaiPhong, GiaTheoGio, TrangThai) VALUES
 ('P101', N'Đơn', 100000, N'Trống'),
 ('P102', N'Đơn', 100000, N'Trống'),
 ('P103', N'Đơn', 100000, N'Đang dọn dẹp'),
 ('P201', N'Đôi', 180000, N'Trống'),
 ('P202', N'Đôi', 180000, N'Đang ở'),
 ('P203', N'Đôi', 180000, N'Trống'),
 ('P301', N'VIP', 350000, N'Trống'),
 ('P302', N'VIP', 350000, N'Trống');
GO

INSERT INTO dbo.KhachHang (HoTen, CCCD, SoDienThoai) VALUES
 (N'Nguyễn Văn An',  '001099012345', '0901234567'),
 (N'Trần Thị Bình',  '001199054321', '0912345678');
GO

INSERT INTO dbo.DichVu (TenDV, DonGia) VALUES
 (N'Nước suối',          15000),
 (N'Nước ngọt',          20000),
 (N'Bia lon',            30000),
 (N'Giặt là (theo bộ)',  50000),
 (N'Mì ly',              25000),
 (N'Cơm phần',           70000);
GO

/* Demo: khách An đang ở P202 từ 3 giờ trước và đã gọi 2 dịch vụ */
INSERT INTO dbo.PhieuDatPhong (SoPhong, MaKH, NgayNhanPhong, NgayTraPhong, TongTienThanhToan)
VALUES ('P202', 1, DATEADD(HOUR, -3, GETDATE()), NULL, 0);
GO

INSERT INTO dbo.SuDungDichVu (MaPhieu, MaDV, SoLuong, ThoiGian)
VALUES (1, 1, 2, DATEADD(HOUR, -2, GETDATE())),
       (1, 4, 1, DATEADD(HOUR, -1, GETDATE()));
GO

/* Kiểm tra nhanh */
SELECT * FROM dbo.Phong;
SELECT * FROM dbo.KhachHang;
SELECT * FROM dbo.DichVu;
SELECT * FROM dbo.PhieuDatPhong;
SELECT * FROM dbo.SuDungDichVu;
GO
