using System.Data;
using System.Data.SqlClient;
using Bai55.DTO;

namespace Bai55.DAL
{
    public class NhaCungCapDAL
    {
        public DataTable LayTatCa()
        {
            return DBHelper.LayBang("SELECT MaNCC, TenNCC, DienThoai, DiaChi FROM NhaCungCap ORDER BY TenNCC");
        }

        public DataTable TimKiem(string tuKhoa)
        {
            string sql = "SELECT MaNCC, TenNCC, DienThoai, DiaChi FROM NhaCungCap " +
                         "WHERE TenNCC LIKE @kw OR DienThoai LIKE @kw OR DiaChi LIKE @kw ORDER BY TenNCC";
            SqlParameter p = new SqlParameter("@kw", SqlDbType.NVarChar, 300);
            p.Value = DBHelper.DangLike(tuKhoa);
            return DBHelper.LayBang(sql, p);
        }

        public int Them(NhaCungCapDTO n)
        {
            try
            {
                using (SqlConnection conn = DBHelper.TaoKetNoi())
                {
                    string sql = "INSERT INTO NhaCungCap (TenNCC, DienThoai, DiaChi) VALUES (@ten, @dt, @dc)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 150).Value = n.TenNCC;
                    cmd.Parameters.Add("@dt", SqlDbType.VarChar, 15).Value = DBHelper.NullNeuRong(n.DienThoai);
                    cmd.Parameters.Add("@dc", SqlDbType.NVarChar, 255).Value = DBHelper.NullNeuRong(n.DiaChi);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw DBHelper.DichLoi(ex);
            }
        }

        public int Sua(NhaCungCapDTO n)
        {
            try
            {
                using (SqlConnection conn = DBHelper.TaoKetNoi())
                {
                    string sql = "UPDATE NhaCungCap SET TenNCC = @ten, DienThoai = @dt, DiaChi = @dc WHERE MaNCC = @ma";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 150).Value = n.TenNCC;
                    cmd.Parameters.Add("@dt", SqlDbType.VarChar, 15).Value = DBHelper.NullNeuRong(n.DienThoai);
                    cmd.Parameters.Add("@dc", SqlDbType.NVarChar, 255).Value = DBHelper.NullNeuRong(n.DiaChi);
                    cmd.Parameters.Add("@ma", SqlDbType.Int).Value = n.MaNCC;
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw DBHelper.DichLoi(ex);
            }
        }

        public int Xoa(int maNCC)
        {
            try
            {
                using (SqlConnection conn = DBHelper.TaoKetNoi())
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM NhaCungCap WHERE MaNCC = @ma", conn);
                    cmd.Parameters.Add("@ma", SqlDbType.Int).Value = maNCC;
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw DBHelper.DichLoi(ex);
            }
        }
    }
}
