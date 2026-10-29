/* =====================================================================
   BÀI 55 - INVENTORY MANAGEMENT  |  Script tạo CSDL InventoryDB
   Chạy toàn bộ script trong SQL Server Object Explorer / SSMS
   ===================================================================== */
IF DB_ID(N'InventoryDB') IS NULL
    CREATE DATABASE InventoryDB;
GO

USE InventoryDB;
GO

IF OBJECT_ID(N'dbo.ChiTietPhieuKho', N'U') IS NOT NULL DROP TABLE dbo.ChiTietPhieuKho;
IF OBJECT_ID(N'dbo.PhieuKho', N'U') IS NOT NULL DROP TABLE dbo.PhieuKho;
IF OBJECT_ID(N'dbo.VatTu', N'U') IS NOT NULL DROP TABLE dbo.VatTu;
IF OBJECT_ID(N'dbo.NhaCungCap', N'U') IS NOT NULL DROP TABLE dbo.NhaCungCap;
GO

/* ---------- 1. Nhà cung cấp ---------- */
CREATE TABLE dbo.NhaCungCap
(
    MaNCC      int IDENTITY(1,1) NOT NULL CONSTRAINT PK_NhaCungCap PRIMARY KEY,
    TenNCC     nvarchar(150) NOT NULL,
    DienThoai  varchar(15)   NULL,
    DiaChi     nvarchar(255) NULL
);
GO
/* UNIQUE cho DienThoai nhưng cho phép nhiều NCC chưa có số (NULL) */
CREATE UNIQUE INDEX UQ_NhaCungCap_DienThoai ON dbo.NhaCungCap(DienThoai) WHERE DienThoai IS NOT NULL;
GO

/* ---------- 2. Vật tư ---------- */
CREATE TABLE dbo.VatTu
(
    MaVatTu     varchar(20)   NOT NULL CONSTRAINT PK_VatTu PRIMARY KEY,
    TenVatTu    nvarchar(150) NOT NULL,
    DVT         nvarchar(20)  NULL,
    SoLuongTon  decimal(18,2) NOT NULL CONSTRAINT DF_VatTu_Ton DEFAULT (0)
                              CONSTRAINT CK_VatTu_Ton CHECK (SoLuongTon >= 0)
);
GO

/* ---------- 3. Phiếu kho ---------- */
CREATE TABLE dbo.PhieuKho
(
    MaPhieu    int IDENTITY(1,1) NOT NULL CONSTRAINT PK_PhieuKho PRIMARY KEY,
    LoaiPhieu  nvarchar(10)  NOT NULL CONSTRAINT CK_PhieuKho_Loai CHECK (LoaiPhieu IN (N'NHAP', N'XUAT')),
    NgayLap    datetime      NOT NULL CONSTRAINT DF_PhieuKho_Ngay DEFAULT (GETDATE()),
    MaNCC      int           NULL CONSTRAINT FK_PhieuKho_NCC REFERENCES dbo.NhaCungCap(MaNCC),
    TongTien   decimal(18,2) NOT NULL CONSTRAINT DF_PhieuKho_Tong DEFAULT (0)
);
GO

/* ---------- 4. Chi tiết phiếu kho ---------- */
CREATE TABLE dbo.ChiTietPhieuKho
(
    MaPhieu   int           NOT NULL CONSTRAINT FK_CT_Phieu REFERENCES dbo.PhieuKho(MaPhieu),
    MaVatTu   varchar(20)   NOT NULL CONSTRAINT FK_CT_VatTu REFERENCES dbo.VatTu(MaVatTu),
    SoLuong   decimal(18,2) NOT NULL CONSTRAINT CK_CT_SoLuong CHECK (SoLuong > 0),
    DonGia    decimal(18,2) NOT NULL CONSTRAINT DF_CT_DonGia DEFAULT (0) CONSTRAINT CK_CT_DonGia CHECK (DonGia >= 0),
    CONSTRAINT PK_ChiTietPhieuKho PRIMARY KEY (MaPhieu, MaVatTu)
);
GO

/* ---------- Dữ liệu mẫu ---------- */
INSERT INTO dbo.NhaCungCap (TenNCC, DienThoai, DiaChi) VALUES
 (N'Công ty Thép Hòa Phát',  '02435551234', N'Hà Nội'),
 (N'Công ty Nhựa Bình Minh', '02838881234', N'TP. Hồ Chí Minh'),
 (N'Cơ sở Gạo Tám Thơm',     '0987654321',  N'Nam Định');
GO

INSERT INTO dbo.VatTu (MaVatTu, TenVatTu, DVT, SoLuongTon) VALUES
 ('VT001', N'Thép tấm 3mm',     N'Kg',    0),
 ('VT002', N'Ống nhựa PVC 27',  N'Cái',   0),
 ('VT003', N'Gạo tám thơm',     N'Kg',    0),
 ('VT004', N'Bulong M8',        N'Hộp',   0),
 ('VT005', N'Sơn chống rỉ',     N'Thùng', 0);
GO

/* Phiếu nhập mẫu (để có tồn kho và giá nhập dùng tính giá trị tồn) */
INSERT INTO dbo.PhieuKho (LoaiPhieu, NgayLap, MaNCC, TongTien)
VALUES (N'NHAP', DATEADD(DAY, -2, GETDATE()), 1, 0);
INSERT INTO dbo.ChiTietPhieuKho (MaPhieu, MaVatTu, SoLuong, DonGia) VALUES
 (1, 'VT001', 500, 25000),
 (1, 'VT004', 8,   45000),
 (1, 'VT005', 3,   320000);
UPDATE dbo.PhieuKho SET TongTien = 500*25000 + 8*45000 + 3*320000 WHERE MaPhieu = 1;
UPDATE dbo.VatTu SET SoLuongTon = 500 WHERE MaVatTu = 'VT001';
UPDATE dbo.VatTu SET SoLuongTon = 8   WHERE MaVatTu = 'VT004';
UPDATE dbo.VatTu SET SoLuongTon = 3   WHERE MaVatTu = 'VT005';

INSERT INTO dbo.PhieuKho (LoaiPhieu, NgayLap, MaNCC, TongTien)
VALUES (N'NHAP', DATEADD(DAY, -1, GETDATE()), 3, 0);
INSERT INTO dbo.ChiTietPhieuKho (MaPhieu, MaVatTu, SoLuong, DonGia) VALUES
 (2, 'VT003', 200, 18000);
UPDATE dbo.PhieuKho SET TongTien = 200*18000 WHERE MaPhieu = 2;
UPDATE dbo.VatTu SET SoLuongTon = 200 WHERE MaVatTu = 'VT003';
GO

SELECT * FROM dbo.NhaCungCap;
SELECT * FROM dbo.VatTu;
SELECT * FROM dbo.PhieuKho;
SELECT * FROM dbo.ChiTietPhieuKho;
GO
