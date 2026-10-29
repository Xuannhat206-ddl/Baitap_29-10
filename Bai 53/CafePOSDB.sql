IF DB_ID('CafePOSDB') IS NULL
    CREATE DATABASE CafePOSDB;
GO
USE CafePOSDB;
GO

IF OBJECT_ID('ChiTietHoaDon') IS NOT NULL DROP TABLE ChiTietHoaDon;
IF OBJECT_ID('HoaDon')        IS NOT NULL DROP TABLE HoaDon;
IF OBJECT_ID('MonAn')         IS NOT NULL DROP TABLE MonAn;
IF OBJECT_ID('DanhMuc')       IS NOT NULL DROP TABLE DanhMuc;
IF OBJECT_ID('BanAn')         IS NOT NULL DROP TABLE BanAn;
GO

CREATE TABLE BanAn (
    MaBan     INT IDENTITY(1,1) PRIMARY KEY,
    TenBan    NVARCHAR(50) NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Trống',
    CONSTRAINT CK_BanAn_TrangThai CHECK (TrangThai IN (N'Trống', N'Có khách'))
);

CREATE TABLE DanhMuc (
    MaDanhMuc  INT IDENTITY(1,1) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL
);

CREATE TABLE MonAn (
    MaMon     INT IDENTITY(1,1) PRIMARY KEY,
    TenMon    NVARCHAR(100) NOT NULL,
    MaDanhMuc INT NOT NULL,
    DonGia    DECIMAL(18,2) NOT NULL DEFAULT 0,
    CONSTRAINT FK_MonAn_DanhMuc FOREIGN KEY (MaDanhMuc) REFERENCES DanhMuc(MaDanhMuc),
    CONSTRAINT CK_MonAn_DonGia CHECK (DonGia >= 0)
);

CREATE TABLE HoaDon (
    MaHoaDon  INT IDENTITY(1,1) PRIMARY KEY,
    MaBan     INT NOT NULL,
    GioVao    DATETIME NOT NULL DEFAULT GETDATE(),
    GioRa     DATETIME NULL,
    TongTien  DECIMAL(18,2) NOT NULL DEFAULT 0,
    TrangThai BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_HoaDon_BanAn FOREIGN KEY (MaBan) REFERENCES BanAn(MaBan)
);

CREATE TABLE ChiTietHoaDon (
    MaHoaDon INT NOT NULL,
    MaMon    INT NOT NULL,
    SoLuong  INT NOT NULL CHECK (SoLuong > 0),
    DonGia   DECIMAL(18,2) NOT NULL,
    CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (MaHoaDon, MaMon),
    CONSTRAINT FK_CTHD_HoaDon FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
    CONSTRAINT FK_CTHD_MonAn  FOREIGN KEY (MaMon)    REFERENCES MonAn(MaMon)
);
GO

INSERT INTO BanAn(TenBan) VALUES
(N'Bàn 01'),(N'Bàn 02'),(N'Bàn 03'),(N'Bàn 04'),
(N'Bàn 05'),(N'Bàn 06'),(N'Bàn 07'),(N'Bàn 08');

INSERT INTO DanhMuc(TenDanhMuc) VALUES (N'Cà phê'),(N'Trà sữa'),(N'Đồ ăn nhẹ');

INSERT INTO MonAn(TenMon, MaDanhMuc, DonGia) VALUES
(N'Cà phê đen',       1, 20000),
(N'Cà phê sữa',       1, 25000),
(N'Bạc xỉu',          1, 29000),
(N'Trà sữa trân châu',2, 35000),
(N'Trà sữa matcha',   2, 38000),
(N'Trà đào cam sả',   2, 40000),
(N'Bánh mì que',      3, 15000),
(N'Khoai tây chiên',  3, 30000),
(N'Bánh flan',        3, 18000);
GO
