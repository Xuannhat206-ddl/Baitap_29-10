using System;
using System.Collections.Generic;

namespace Bai55.DTO
{
    public class PhieuKhoDTO
    {
        public int MaPhieu { get; set; }
        public string LoaiPhieu { get; set; }      // "NHAP" hoặc "XUAT"
        public DateTime NgayLap { get; set; }
        public int? MaNCC { get; set; }            // null nếu là phiếu xuất
        public decimal TongTien { get; set; }
        public List<ChiTietPhieuKhoDTO> ChiTiet { get; set; }

        public PhieuKhoDTO()
        {
            ChiTiet = new List<ChiTietPhieuKhoDTO>();
        }

        public decimal TinhTongTien()
        {
            decimal tong = 0;
            foreach (ChiTietPhieuKhoDTO ct in ChiTiet)
            {
                tong += ct.ThanhTien;
            }
            return tong;
        }
    }
}
