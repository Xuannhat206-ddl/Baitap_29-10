using System;
using System.Data;
using System.Text.RegularExpressions;
using Bai55.DAL;
using Bai55.DTO;

namespace Bai55.BUS
{
    public class NhaCungCapBUS
    {
        private readonly NhaCungCapDAL dal = new NhaCungCapDAL();

        public DataTable LayTatCa()
        {
            return dal.LayTatCa();
        }

        public DataTable TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa)) return dal.LayTatCa();
            return dal.TimKiem(tuKhoa);
        }

        private void KiemTra(NhaCungCapDTO n)
        {
            if (n == null) throw new ArgumentException("Dữ liệu nhà cung cấp rỗng.");
            n.TenNCC = (n.TenNCC ?? "").Trim();
            n.DienThoai = (n.DienThoai ?? "").Trim();
            n.DiaChi = (n.DiaChi ?? "").Trim();

            if (n.TenNCC == "") throw new ArgumentException("Vui lòng nhập tên nhà cung cấp.");
            if (n.TenNCC.Length > 150) throw new ArgumentException("Tên nhà cung cấp tối đa 150 ký tự.");
            if (n.DienThoai != "" && !Regex.IsMatch(n.DienThoai, @"^[0-9]{8,15}$"))
                throw new ArgumentException("Số điện thoại phải gồm 8-15 chữ số.");
            if (n.DiaChi.Length > 255) throw new ArgumentException("Địa chỉ tối đa 255 ký tự.");
        }

        public void Them(NhaCungCapDTO n)
        {
            KiemTra(n);
            dal.Them(n);
        }

        public void Sua(NhaCungCapDTO n)
        {
            KiemTra(n);
            if (n.MaNCC <= 0) throw new ArgumentException("Hãy chọn nhà cung cấp cần sửa.");
            if (dal.Sua(n) == 0) throw new Exception("Không tìm thấy nhà cung cấp để sửa.");
        }

        public void Xoa(int maNCC)
        {
            if (maNCC <= 0) throw new ArgumentException("Hãy chọn nhà cung cấp cần xóa.");
            if (dal.Xoa(maNCC) == 0) throw new Exception("Không tìm thấy nhà cung cấp để xóa.");
        }
    }
}
