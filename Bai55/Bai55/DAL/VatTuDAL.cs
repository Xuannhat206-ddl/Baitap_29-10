using System;
using System.Data;
using System.Data.SqlClient;
using Bai55.DTO;

namespace Bai55.DAL
{
    public class VatTuDAL
    {
        public DataTable LayTatCa()
        {
            return DBHelper.LayBang("SELECT MaVatTu, TenVatTu, DVT, SoLuongTon FROM VatTu ORDER BY MaVatTu");
        }

        // Tìm theo mã HOẶC tên (SqlParameter + LIKE)
        public DataTable TimKiem(string tuKhoa)
        {
            string sql = "SELECT MaVatTu, TenVatTu, DVT, SoLuongTon FROM VatTu " +
                         "WHERE MaVatTu LIKE @kw OR TenVatTu LIKE @kw ORDER BY MaVatTu";
            SqlParameter p = new SqlParameter("@kw", SqlDbType.NVarChar, 300);
            p.Value = DBHelper.DangLike(tuKhoa);
            return DBHelper.LayBang(sql, p);
        }

        // Dữ liệu cho ComboBox ở màn hình lập phiếu
        public DataTable LayChoCombo()
        {
            string sql = "SELECT MaVatTu, TenVatTu, DVT, SoLuongTon, " +
                         "MaVatTu + N' - ' + TenVatTu + N'  (Tồn: ' + CONVERT(nvarchar(30), SoLuongTon) + N' ' + ISNULL(DVT, N'') + N')' AS HienThi " +
                         "FROM VatTu ORDER BY MaVatTu";
            return DBHelper.LayBang(sql);
        }

        public int Them(VatTuDTO v)
        {
            try
            {
                using (SqlConnection conn = DBHelper.TaoKetNoi())
                {
                    string sql = "INSERT INTO VatTu (MaVatTu, TenVatTu, DVT, SoLuongTon) VALUES (@ma, @ten, @dvt, @ton)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@ma", SqlDbType.VarChar, 20).Value = v.MaVatTu;
                    cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 150).Value = v.TenVatTu;
                    cmd.Parameters.Add("@dvt", SqlDbType.NVarChar, 20).Value = DBHelper.NullNeuRong(v.DVT);
                    cmd.Parameters.Add(DBHelper.Dec("@ton", v.SoLuongTon));
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw DBHelper.DichLoi(ex);
            }
        }

        // Sửa thông tin (KHÔNG sửa SoLuongTon - tồn kho chỉ thay đổi qua phiếu nhập/xuất)
        public int Sua(VatTuDTO v)
        {
            try
            {
                using (SqlConnection conn = DBHelper.TaoKetNoi())
                {
                    string sql = "UPDATE VatTu SET TenVatTu = @ten, DVT = @dvt WHERE MaVatTu = @ma";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 150).Value = v.TenVatTu;
                    cmd.Parameters.Add("@dvt", SqlDbType.NVarChar, 20).Value = DBHelper.NullNeuRong(v.DVT);
                    cmd.Parameters.Add("@ma", SqlDbType.VarChar, 20).Value = v.MaVatTu;
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw DBHelper.DichLoi(ex);
            }
        }

        public int Xoa(string maVatTu)
        {
            try
            {
                using (SqlConnection conn = DBHelper.TaoKetNoi())
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM VatTu WHERE MaVatTu = @ma", conn);
                    cmd.Parameters.Add("@ma", SqlDbType.VarChar, 20).Value = maVatTu;
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw DBHelper.DichLoi(ex);
            }
        }

        // Vật tư có tồn kho dưới ngưỡng an toàn
        public DataTable CanhBaoTon(decimal nguong)
        {
            string sql = "SELECT MaVatTu, TenVatTu, DVT, SoLuongTon FROM VatTu " +
                         "WHERE SoLuongTon < @nguong ORDER BY SoLuongTon, MaVatTu";
            return DBHelper.LayBang(sql, DBHelper.Dec("@nguong", nguong));
        }

        // Tổng giá trị tồn kho = SUM(SoLuongTon x đơn giá nhập gần nhất) - dùng ExecuteScalar
        public decimal TongGiaTriTon()
        {
            string sql =
                @"SELECT ISNULL(SUM(v.SoLuongTon * ISNULL(g.DonGia, 0)), 0)
                  FROM VatTu v
                  OUTER APPLY (SELECT TOP 1 ct.DonGia
                               FROM ChiTietPhieuKho ct
                               INNER JOIN PhieuKho p ON ct.MaPhieu = p.MaPhieu
                               WHERE ct.MaVatTu = v.MaVatTu AND p.LoaiPhieu = @nhap
                               ORDER BY p.NgayLap DESC, p.MaPhieu DESC) g";
            using (SqlConnection conn = DBHelper.TaoKetNoi())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@nhap", SqlDbType.NVarChar, 10).Value = "NHAP";
                conn.Open();
                object kq = cmd.ExecuteScalar();
                if (kq == null || kq == DBNull.Value) return 0m;
                return Convert.ToDecimal(kq);
            }
        }
    }
}
