using System;
using System.Data;
using System.Data.SqlClient;
using Bai55.DTO;

namespace Bai55.DAL
{
    public class PhieuKhoDAL
    {
        // Lập phiếu nhập/xuất trong MỘT SqlTransaction (ACID). Trả về mã phiếu mới.
        public int LapPhieu(PhieuKhoDTO phieu)
        {
            using (SqlConnection conn = DBHelper.TaoKetNoi())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // BƯỚC 1: chèn PhieuKho
                    SqlCommand cmdPhieu = new SqlCommand(
                        "INSERT INTO PhieuKho (LoaiPhieu, NgayLap, MaNCC, TongTien) " +
                        "VALUES (@loai, @ngay, @ncc, @tong); SELECT CAST(SCOPE_IDENTITY() AS int);", conn, trans);
                    cmdPhieu.Parameters.Add("@loai", SqlDbType.NVarChar, 10).Value = phieu.LoaiPhieu;
                    cmdPhieu.Parameters.Add("@ngay", SqlDbType.DateTime).Value = phieu.NgayLap;
                    cmdPhieu.Parameters.Add("@ncc", SqlDbType.Int).Value =
                        phieu.MaNCC.HasValue ? (object)phieu.MaNCC.Value : DBNull.Value;
                    cmdPhieu.Parameters.Add(DBHelper.Dec("@tong", phieu.TongTien));
                    int maPhieu = Convert.ToInt32(cmdPhieu.ExecuteScalar());

                    foreach (ChiTietPhieuKhoDTO ct in phieu.ChiTiet)
                    {
                        // BƯỚC 2: chèn ChiTietPhieuKho
                        SqlCommand cmdCT = new SqlCommand(
                            "INSERT INTO ChiTietPhieuKho (MaPhieu, MaVatTu, SoLuong, DonGia) VALUES (@mp, @mv, @sl, @dg)",
                            conn, trans);
                        cmdCT.Parameters.Add("@mp", SqlDbType.Int).Value = maPhieu;
                        cmdCT.Parameters.Add("@mv", SqlDbType.VarChar, 20).Value = ct.MaVatTu;
                        cmdCT.Parameters.Add(DBHelper.Dec("@sl", ct.SoLuong));
                        cmdCT.Parameters.Add(DBHelper.Dec("@dg", ct.DonGia));
                        cmdCT.ExecuteNonQuery();

                        // BƯỚC 3: cập nhật tồn kho
                        if (phieu.LoaiPhieu == "NHAP")
                        {
                            SqlCommand cmdCong = new SqlCommand(
                                "UPDATE VatTu SET SoLuongTon = SoLuongTon + @sl WHERE MaVatTu = @mv", conn, trans);
                            cmdCong.Parameters.Add(DBHelper.Dec("@sl", ct.SoLuong));
                            cmdCong.Parameters.Add("@mv", SqlDbType.VarChar, 20).Value = ct.MaVatTu;
                            if (cmdCong.ExecuteNonQuery() == 0)
                            {
                                trans.Rollback();
                                throw new Exception("Vật tư " + ct.MaVatTu + " không tồn tại.");
                            }
                        }
                        else
                        {
                            // Khóa dòng vật tư và kiểm tra tồn kho trước khi trừ
                            SqlCommand cmdTon = new SqlCommand(
                                "SELECT SoLuongTon FROM VatTu WITH (UPDLOCK, ROWLOCK) WHERE MaVatTu = @mv", conn, trans);
                            cmdTon.Parameters.Add("@mv", SqlDbType.VarChar, 20).Value = ct.MaVatTu;
                            object ton = cmdTon.ExecuteScalar();
                            if (ton == null)
                            {
                                trans.Rollback();
                                throw new Exception("Vật tư " + ct.MaVatTu + " không tồn tại.");
                            }
                            if (Convert.ToDecimal(ton) < ct.SoLuong)
                            {
                                trans.Rollback();
                                throw new Exception("Không đủ hàng trong kho: vật tư " + ct.MaVatTu +
                                    " (tồn " + Convert.ToDecimal(ton).ToString("N2") +
                                    ", cần xuất " + ct.SoLuong.ToString("N2") + ").");
                            }

                            SqlCommand cmdTru = new SqlCommand(
                                "UPDATE VatTu SET SoLuongTon = SoLuongTon - @sl WHERE MaVatTu = @mv", conn, trans);
                            cmdTru.Parameters.Add(DBHelper.Dec("@sl", ct.SoLuong));
                            cmdTru.Parameters.Add("@mv", SqlDbType.VarChar, 20).Value = ct.MaVatTu;
                            cmdTru.ExecuteNonQuery();
                        }
                    }

                    // BƯỚC 4: tất cả thành công -> Commit
                    trans.Commit();
                    return maPhieu;
                }
                catch (SqlException ex)
                {
                    RollbackNeuCan(trans);
                    throw DBHelper.DichLoi(ex);
                }
                catch
                {
                    RollbackNeuCan(trans);
                    throw;
                }
            }
        }

        // Chỉ rollback nếu transaction chưa bị rollback/commit trước đó
        private static void RollbackNeuCan(SqlTransaction trans)
        {
            try
            {
                if (trans.Connection != null) trans.Rollback();
            }
            catch
            {
            }
        }

        public DataTable LayDanhSach()
        {
            string sql = "SELECT p.MaPhieu, p.LoaiPhieu, p.NgayLap, n.TenNCC, p.TongTien " +
                         "FROM PhieuKho p LEFT JOIN NhaCungCap n ON p.MaNCC = n.MaNCC " +
                         "ORDER BY p.NgayLap DESC, p.MaPhieu DESC";
            return DBHelper.LayBang(sql);
        }

        public DataTable LayChiTiet(int maPhieu)
        {
            string sql = "SELECT ct.MaVatTu, v.TenVatTu, v.DVT, ct.SoLuong, ct.DonGia, ct.SoLuong * ct.DonGia AS ThanhTien " +
                         "FROM ChiTietPhieuKho ct INNER JOIN VatTu v ON ct.MaVatTu = v.MaVatTu " +
                         "WHERE ct.MaPhieu = @mp ORDER BY ct.MaVatTu";
            SqlParameter p = new SqlParameter("@mp", SqlDbType.Int);
            p.Value = maPhieu;
            return DBHelper.LayBang(sql, p);
        }
    }
}
