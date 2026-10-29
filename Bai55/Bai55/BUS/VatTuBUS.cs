using System;
using System.Data;
using Bai55.DAL;
using Bai55.DTO;

namespace Bai55.BUS
{
    public class VatTuBUS
    {
        private readonly VatTuDAL dal = new VatTuDAL();

        public DataTable LayTatCa()
        {
            return dal.LayTatCa();
        }

        public DataTable TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa)) return dal.LayTatCa();
            return dal.TimKiem(tuKhoa);
        }

        public DataTable LayChoCombo()
        {
            return dal.LayChoCombo();
        }

        private void KiemTra(VatTuDTO v, bool kiemTraTon)
        {
            if (v == null) throw new ArgumentException("Dữ liệu vật tư rỗng.");
            v.MaVatTu = (v.MaVatTu ?? "").Trim();
            v.TenVatTu = (v.TenVatTu ?? "").Trim();
            v.DVT = (v.DVT ?? "").Trim();

            if (v.MaVatTu == "") throw new ArgumentException("Vui lòng nhập mã vật tư.");
            if (v.MaVatTu.Length > 20) throw new ArgumentException("Mã vật tư tối đa 20 ký tự.");
            if (v.MaVatTu.Contains(" ")) throw new ArgumentException("Mã vật tư không được chứa khoảng trắng.");
            if (v.TenVatTu == "") throw new ArgumentException("Vui lòng nhập tên vật tư.");
            if (v.TenVatTu.Length > 150) throw new ArgumentException("Tên vật tư tối đa 150 ký tự.");
            if (v.DVT.Length > 20) throw new ArgumentException("Đơn vị tính tối đa 20 ký tự.");
            if (kiemTraTon && v.SoLuongTon < 0) throw new ArgumentException("Số lượng tồn không được âm.");
        }

        public void Them(VatTuDTO v)
        {
            KiemTra(v, true);
            dal.Them(v);
        }

        public void Sua(VatTuDTO v)
        {
            KiemTra(v, false);
            if (dal.Sua(v) == 0) throw new Exception("Không tìm thấy vật tư để sửa.");
        }

        public void Xoa(string maVatTu)
        {
            if (string.IsNullOrWhiteSpace(maVatTu)) throw new ArgumentException("Hãy chọn vật tư cần xóa.");
            if (dal.Xoa(maVatTu.Trim()) == 0) throw new Exception("Không tìm thấy vật tư để xóa.");
        }

        // ----- Cảnh báo & báo cáo -----
        public DataTable CanhBaoTon(decimal nguong)
        {
            if (nguong < 0) throw new ArgumentException("Ngưỡng an toàn không được âm.");
            return dal.CanhBaoTon(nguong);
        }

        public decimal TongGiaTriTon()
        {
            return dal.TongGiaTriTon();
        }
    }
}
