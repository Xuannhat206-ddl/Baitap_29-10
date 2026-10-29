using System;
using System.Data;
using System.Data.SqlClient;

namespace Bai55.DAL
{
    public static class DBHelper
    {
        // ====== CHUỖI KẾT NỐI - ĐỔI CHO ĐÚNG MÁY CỦA BẠN ======
        //  SQL Server Express : Server=.\SQLEXPRESS;Database=InventoryDB;Integrated Security=True;
        //  SQL Server mặc định: Server=.;Database=InventoryDB;Integrated Security=True;
        //  LocalDB (VS)       : Server=(localdb)\MSSQLLocalDB;Database=InventoryDB;Integrated Security=True;
        //  Đăng nhập sa       : Server=.;Database=InventoryDB;User Id=sa;Password=mat_khau;
        public static readonly string ConnectionString =
            @"Server=.\SQLEXPRESS;Database=InventoryDB;Integrated Security=True;";

        public static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(ConnectionString);
        }

        // Truy vấn trả về DataTable (mô hình kết nối - đọc xong đóng ngay)
        public static DataTable LayBang(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = TaoKetNoi())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                if (ps != null && ps.Length > 0) adapter.SelectCommand.Parameters.AddRange(ps);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Tham số decimal(18,2) - tránh bị cắt phần thập phân
        public static SqlParameter Dec(string ten, decimal giaTri)
        {
            SqlParameter p = new SqlParameter(ten, SqlDbType.Decimal);
            p.Precision = 18;
            p.Scale = 2;
            p.Value = giaTri;
            return p;
        }

        public static object NullNeuRong(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return DBNull.Value;
            return s.Trim();
        }

        // Tạo mẫu LIKE an toàn: %từ khóa% (escape ký tự đặc biệt của LIKE)
        public static string DangLike(string tuKhoa)
        {
            string s = (tuKhoa ?? "").Trim();
            s = s.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]");
            return "%" + s + "%";
        }

        // Đổi lỗi SQL sang thông báo dễ hiểu
        public static Exception DichLoi(SqlException ex)
        {
            switch (ex.Number)
            {
                case 2601:
                case 2627:
                    return new Exception("Dữ liệu bị trùng (mã hoặc số điện thoại đã tồn tại).", ex);
                case 547:
                    return new Exception("Vi phạm ràng buộc dữ liệu (đang được sử dụng ở bảng khác hoặc giá trị không hợp lệ).", ex);
                default:
                    return new Exception(ex.Message, ex);
            }
        }
    }
}
