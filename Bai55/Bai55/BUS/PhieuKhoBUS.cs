using System;
using System.Collections.Generic;
using System.Data;
using Bai55.DAL;
using Bai55.DTO;

namespace Bai55.BUS
{
    public class PhieuKhoBUS
    {
        private readonly PhieuKhoDAL dal = new PhieuKhoDAL();

        // Kiểm tra nghiệp vụ -> gộp các dòng trùng vật tư -> gọi DAL lập phiếu (SqlTransaction)
        public int LapPhieu(string loaiPhieu, int? maNCC, List<ChiTietPhieuKhoDTO> chiTiet)
        {
            if (loaiPhieu != "NHAP" && loaiPhieu != "XUAT")
                throw new ArgumentException("Loại phiếu không hợp lệ (chỉ NHAP hoặc XUAT).");
            if (loaiPhieu == "NHAP" && !maNCC.HasValue)
                throw new ArgumentException("Phiếu nhập phải chọn nhà cung cấp.");
            if (chiTiet == null || chiTiet.Count == 0)
                throw new ArgumentException("Phiếu kho chưa có vật tư nào.");

            // PK của ChiTietPhieuKho là (MaPhieu, MaVatTu) nên mỗi vật tư chỉ 1 dòng
            Dictionary<string, ChiTietPhieuKhoDTO> gop = new Dictionary<string, ChiTietPhieuKhoDTO>();
            foreach (ChiTietPhieuKhoDTO ct in chiTiet)
            {
                string ma = (ct.MaVatTu ?? "").Trim();
                if (ma == "") throw new ArgumentException("Có dòng chưa chọn vật tư.");
                if (ct.SoLuong <= 0) throw new ArgumentException("Số lượng của vật tư " + ma + " phải lớn hơn 0.");
                if (ct.DonGia < 0) throw new ArgumentException("Đơn giá của vật tư " + ma + " không được âm.");

                if (gop.ContainsKey(ma))
                {
                    gop[ma].SoLuong += ct.SoLuong;
                    gop[ma].DonGia = ct.DonGia;
                }
                else
                {
                    ChiTietPhieuKhoDTO moi = new ChiTietPhieuKhoDTO();
                    moi.MaVatTu = ma;
                    moi.SoLuong = ct.SoLuong;
                    moi.DonGia = ct.DonGia;
                    gop.Add(ma, moi);
                }
            }

            PhieuKhoDTO phieu = new PhieuKhoDTO();
            phieu.LoaiPhieu = loaiPhieu;
            phieu.NgayLap = DateTime.Now;
            phieu.MaNCC = (loaiPhieu == "NHAP") ? maNCC : null;
            phieu.ChiTiet.AddRange(gop.Values);
            phieu.TongTien = phieu.TinhTongTien();

            return dal.LapPhieu(phieu);
        }

        public DataTable LayDanhSach()
        {
            return dal.LayDanhSach();
        }

        public DataTable LayChiTiet(int maPhieu)
        {
            return dal.LayChiTiet(maPhieu);
        }
    }
}
