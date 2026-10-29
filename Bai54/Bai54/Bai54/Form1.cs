using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Bai54
{
    public partial class Form1 : Form
    {
        // ====== CHUỖI KẾT NỐI - ĐỔI CHO ĐÚNG MÁY CỦA BẠN ======
        //  SQL Server Express : Server=.\SQLEXPRESS;Database=HotelDB;Integrated Security=True;
        //  SQL Server mặc định: Server=.;Database=HotelDB;Integrated Security=True;
        //  LocalDB (VS)       : Server=(localdb)\MSSQLLocalDB;Database=HotelDB;Integrated Security=True;
        //  Đăng nhập sa       : Server=.;Database=HotelDB;User Id=sa;Password=mat_khau;
        private readonly string connectionString =
            @"Server=.\SQLEXPRESS;Database=HotelDB;Integrated Security=True;";

        private DataTable dtPhong;      // bảng phòng (ngắt kết nối) để lọc
        private DataView dvPhong;       // DataView dùng RowFilter
        private bool dangTai = false;   // chặn sự kiện khi đang nạp ComboBox
        private bool daLoad = false;    // chỉ cho phép sự kiện đổi tab chạy sau khi form đã load xong

        // Dữ liệu hóa đơn tạm khi check-out
        private class HoaDon
        {
            public int MaPhieu;
            public string SoPhong;
            public string LoaiPhong;
            public string HoTen;
            public string CCCD;
            public DateTime Nhan;
            public DateTime Tra;
            public decimal GiaGio;
            public int SoGio;
            public decimal TienPhong;
            public decimal TienDV;
            public decimal Tong;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboLocTrangThai.Items.AddRange(new object[] { "Tất cả", "Trống", "Đang ở", "Đang dọn dẹp" });
            cboLocTrangThai.SelectedIndex = 0;
            LoadTatCa();
            daLoad = true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!daLoad) return;
            LoadTatCa();
        }

        // =====================================================================
        //  TIỆN ÍCH CHUNG
        // =====================================================================

        private string Tien(decimal v)
        {
            return v.ToString("N0") + " VNĐ";
        }

        // Đọc 1 cột của dòng đang chọn trong ComboBox (đã gán DataSource là DataTable)
        private string GiaTriChon(ComboBox cbo, string cot)
        {
            DataRowView drv = cbo.SelectedItem as DataRowView;
            if (drv == null) return null;
            return Convert.ToString(drv[cot]);
        }

        // Lấy DataTable từ câu SQL (có thể kèm SqlParameter)
        private DataTable LayBang(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                if (ps != null && ps.Length > 0) adapter.SelectCommand.Parameters.AddRange(ps);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Nạp ComboBox nhưng giữ lại lựa chọn cũ nếu còn tồn tại
        private void NapCombo(ComboBox cbo, DataTable dt, string display, string value)
        {
            string truoc = GiaTriChon(cbo, value);
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.DataSource = dt;
            if (truoc != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToString(dt.Rows[i][value]) == truoc)
                    {
                        cbo.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void DatTieuDe(DataGridView dgv, string cot, string tieuDe)
        {
            if (dgv.Columns.Contains(cot)) dgv.Columns[cot].HeaderText = tieuDe;
        }

        private void DatDinhDang(DataGridView dgv, string cot, string format)
        {
            if (dgv.Columns.Contains(cot)) dgv.Columns[cot].DefaultCellStyle.Format = format;
        }

        private void LoadTatCa()
        {
            try
            {
                dangTai = true;
                LoadDanhSachPhong();
                LoadPhongTrong();
                LoadDangO();
                LoadDichVu();
                LoadPhongDangO();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu từ SQL Server: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dangTai = false;
            }
            CapNhatGiaPhong();
            LoadDichVuDaDung();
        }

        // =====================================================================
        //  TAB 1: DANH SÁCH PHÒNG + LỌC (ngắt kết nối - DataView)
        // =====================================================================

        private void LoadDanhSachPhong()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT SoPhong, LoaiPhong, GiaTheoGio, TrangThai FROM Phong ORDER BY SoPhong";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dtPhong = dt;
                dvPhong = new DataView(dtPhong);
                dgvPhong.DataSource = dvPhong;
            }

            DatTieuDe(dgvPhong, "SoPhong", "Số phòng");
            DatTieuDe(dgvPhong, "LoaiPhong", "Loại phòng");
            DatTieuDe(dgvPhong, "GiaTheoGio", "Giá theo giờ (VNĐ)");
            DatTieuDe(dgvPhong, "TrangThai", "Trạng thái");
            DatDinhDang(dgvPhong, "GiaTheoGio", "N0");

            // Nạp ComboBox lọc loại phòng từ dữ liệu đã tải (giữ lựa chọn cũ)
            string loaiCu = cboLocLoai.Text;
            cboLocLoai.Items.Clear();
            cboLocLoai.Items.Add("Tất cả");
            DataTable dsLoai = dtPhong.DefaultView.ToTable(true, "LoaiPhong");
            foreach (DataRow r in dsLoai.Rows)
            {
                cboLocLoai.Items.Add(r["LoaiPhong"].ToString());
            }
            int idx = cboLocLoai.Items.IndexOf(loaiCu);
            cboLocLoai.SelectedIndex = idx >= 0 ? idx : 0;

            ApDungLoc();
        }

        private void ApDungLoc()
        {
            if (dvPhong == null) return;
            List<string> dk = new List<string>();
            if (cboLocLoai.SelectedIndex > 0)
                dk.Add("LoaiPhong = '" + cboLocLoai.Text.Replace("'", "''") + "'");
            if (cboLocTrangThai.SelectedIndex > 0)
                dk.Add("TrangThai = '" + cboLocTrangThai.Text.Replace("'", "''") + "'");
            dvPhong.RowFilter = string.Join(" AND ", dk);
        }

        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTai) return;
            ApDungLoc();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboLocLoai.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndex = 0;
            LoadTatCa();
        }

        private void btnDonXong_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một phòng trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string soPhong = Convert.ToString(dgvPhong.CurrentRow.Cells["SoPhong"].Value);
            string tt = Convert.ToString(dgvPhong.CurrentRow.Cells["TrangThai"].Value);
            if (tt != "Đang dọn dẹp")
            {
                MessageBox.Show("Chỉ phòng đang ở trạng thái \"Đang dọn dẹp\" mới chuyển được sang \"Trống\".", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = "UPDATE Phong SET TrangThai = @moi WHERE SoPhong = @sp AND TrangThai = @cu";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@moi", SqlDbType.NVarChar, 30).Value = "Trống";
                    cmd.Parameters.Add("@sp", SqlDbType.VarChar, 10).Value = soPhong;
                    cmd.Parameters.Add("@cu", SqlDbType.NVarChar, 30).Value = "Đang dọn dẹp";
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadTatCa();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật phòng: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        //  TAB 2: CHECK-IN
        // =====================================================================

        private void LoadPhongTrong()
        {
            string sql = "SELECT SoPhong, SoPhong + N' - ' + LoaiPhong AS HienThi, LoaiPhong, GiaTheoGio " +
                         "FROM Phong WHERE TrangThai = @tt ORDER BY SoPhong";
            DataTable dt = LayBang(sql, new SqlParameter("@tt", "Trống"));
            NapCombo(cboPhongTrong, dt, "HienThi", "SoPhong");
        }

        private void CapNhatGiaPhong()
        {
            DataRowView drv = cboPhongTrong.SelectedItem as DataRowView;
            if (drv == null)
            {
                lblGiaPhong.Text = "Hiện không có phòng trống.";
                return;
            }
            lblGiaPhong.Text = "Loại: " + drv["LoaiPhong"] + "   |   Giá: " +
                               Convert.ToDecimal(drv["GiaTheoGio"]).ToString("N0") + " VNĐ/giờ";
        }

        private void cboPhongTrong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTai) return;
            CapNhatGiaPhong();
        }

        private void LoadDangO()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT p.MaPhieu, p.SoPhong, k.HoTen, k.CCCD, k.SoDienThoai, p.NgayNhanPhong " +
                             "FROM PhieuDatPhong p INNER JOIN KhachHang k ON p.MaKH = k.MaKH " +
                             "WHERE p.NgayTraPhong IS NULL ORDER BY p.NgayNhanPhong";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvDangO.DataSource = dt;
            }
            DatTieuDe(dgvDangO, "MaPhieu", "Mã phiếu");
            DatTieuDe(dgvDangO, "SoPhong", "Số phòng");
            DatTieuDe(dgvDangO, "HoTen", "Họ tên");
            DatTieuDe(dgvDangO, "CCCD", "CCCD");
            DatTieuDe(dgvDangO, "SoDienThoai", "Số điện thoại");
            DatTieuDe(dgvDangO, "NgayNhanPhong", "Ngày nhận phòng");
            DatDinhDang(dgvDangO, "NgayNhanPhong", "dd/MM/yyyy HH:mm");
        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            // Nếu đang hiển thị thông tin khách cũ mà sửa CCCD -> xóa để tra cứu lại
            if (txtHoTen.ReadOnly)
            {
                txtHoTen.ReadOnly = false;
                txtHoTen.Clear();
                txtSDT.Clear();
            }
            lblTTKhach.Text = "Nhập CCCD rồi bấm Tra cứu.";
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            string cccd = txtCCCD.Text.Trim();
            if (cccd == "")
            {
                MessageBox.Show("Vui lòng nhập số CCCD.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = "SELECT MaKH, HoTen, SoDienThoai FROM KhachHang WHERE CCCD = @cccd";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@cccd", SqlDbType.VarChar, 20).Value = cccd;
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            txtHoTen.Text = rd["HoTen"].ToString();
                            txtSDT.Text = rd["SoDienThoai"].ToString();
                            txtHoTen.ReadOnly = true;
                            lblTTKhach.Text = "Khách cũ (Mã KH: " + rd["MaKH"] + ") - đã có trong hệ thống.";
                        }
                        else
                        {
                            txtHoTen.ReadOnly = false;
                            txtHoTen.Clear();
                            txtSDT.Clear();
                            lblTTKhach.Text = "Khách mới - hãy nhập họ tên và số điện thoại.";
                            txtHoTen.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tra cứu khách hàng: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            string cccd = txtCCCD.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string soPhong = GiaTriChon(cboPhongTrong, "SoPhong");

            if (cccd == "")
            {
                MessageBox.Show("Vui lòng nhập số CCCD.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }
            if (soPhong == null)
            {
                MessageBox.Show("Không có phòng trống để nhận phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction tran = conn.BeginTransaction();
                    try
                    {
                        // 1. Tra cứu khách theo CCCD (SqlParameter), chưa có thì thêm mới
                        int maKH;
                        SqlCommand cmdTim = new SqlCommand("SELECT MaKH FROM KhachHang WHERE CCCD = @cccd", conn, tran);
                        cmdTim.Parameters.Add("@cccd", SqlDbType.VarChar, 20).Value = cccd;
                        object kq = cmdTim.ExecuteScalar();
                        if (kq != null)
                        {
                            maKH = Convert.ToInt32(kq);
                        }
                        else
                        {
                            if (hoTen == "") throw new Exception("Khách mới: vui lòng nhập họ tên.");
                            SqlCommand cmdThem = new SqlCommand(
                                "INSERT INTO KhachHang (HoTen, CCCD, SoDienThoai) VALUES (@ht, @cccd, @sdt); " +
                                "SELECT CAST(SCOPE_IDENTITY() AS int);", conn, tran);
                            cmdThem.Parameters.Add("@ht", SqlDbType.NVarChar, 100).Value = hoTen;
                            cmdThem.Parameters.Add("@cccd", SqlDbType.VarChar, 20).Value = cccd;
                            cmdThem.Parameters.Add("@sdt", SqlDbType.VarChar, 15).Value =
                                string.IsNullOrEmpty(sdt) ? (object)DBNull.Value : sdt;
                            maKH = Convert.ToInt32(cmdThem.ExecuteScalar());
                        }

                        // 2. Chuyển phòng sang "Đang ở" (chỉ khi phòng vẫn còn "Trống")
                        SqlCommand cmdPhong = new SqlCommand(
                            "UPDATE Phong SET TrangThai = @moi WHERE SoPhong = @sp AND TrangThai = @cu", conn, tran);
                        cmdPhong.Parameters.Add("@moi", SqlDbType.NVarChar, 30).Value = "Đang ở";
                        cmdPhong.Parameters.Add("@sp", SqlDbType.VarChar, 10).Value = soPhong;
                        cmdPhong.Parameters.Add("@cu", SqlDbType.NVarChar, 30).Value = "Trống";
                        if (cmdPhong.ExecuteNonQuery() == 0)
                            throw new Exception("Phòng " + soPhong + " không còn trống.");

                        // 3. Lập phiếu nhận phòng
                        SqlCommand cmdPhieu = new SqlCommand(
                            "INSERT INTO PhieuDatPhong (SoPhong, MaKH, NgayNhanPhong, TongTienThanhToan) " +
                            "VALUES (@sp, @kh, @nhan, 0)", conn, tran);
                        cmdPhieu.Parameters.Add("@sp", SqlDbType.VarChar, 10).Value = soPhong;
                        cmdPhieu.Parameters.Add("@kh", SqlDbType.Int).Value = maKH;
                        cmdPhieu.Parameters.Add("@nhan", SqlDbType.DateTime).Value = DateTime.Now;
                        cmdPhieu.ExecuteNonQuery();

                        tran.Commit();
                    }
                    catch
                    {
                        try { tran.Rollback(); } catch { }
                        throw;
                    }
                }

                MessageBox.Show("Check-in thành công phòng " + soPhong + ".", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.ReadOnly = false;
                txtCCCD.Clear();
                txtHoTen.Clear();
                txtSDT.Clear();
                lblTTKhach.Text = "Nhập CCCD rồi bấm Tra cứu.";
                LoadTatCa();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi check-in: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        //  TAB 3: GỌI DỊCH VỤ
        // =====================================================================

        private void LoadDichVu()
        {
            string sql = "SELECT MaDV, TenDV, DonGia, " +
                         "TenDV + N' - ' + CONVERT(nvarchar(20), CONVERT(int, DonGia)) + N' VNĐ' AS HienThi " +
                         "FROM DichVu ORDER BY TenDV";
            DataTable dt = LayBang(sql);
            NapCombo(cboDichVu, dt, "HienThi", "MaDV");
        }

        private void LoadPhongDangO()
        {
            string sql = "SELECT SoPhong FROM Phong WHERE TrangThai = @tt ORDER BY SoPhong";
            // 2 DataTable riêng để 2 ComboBox không bị đồng bộ vị trí chọn với nhau
            NapCombo(cboPhongDV, LayBang(sql, new SqlParameter("@tt", "Đang ở")), "SoPhong", "SoPhong");
            NapCombo(cboPhongCO, LayBang(sql, new SqlParameter("@tt", "Đang ở")), "SoPhong", "SoPhong");
        }

        private void LoadDichVuDaDung()
        {
            string soPhong = GiaTriChon(cboPhongDV, "SoPhong");
            if (soPhong == null)
            {
                dgvDichVu.DataSource = null;
                lblTongDV.Text = "Tổng tiền dịch vụ: 0 VNĐ";
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = "SELECT s.ThoiGian, d.TenDV, d.DonGia, s.SoLuong, d.DonGia * s.SoLuong AS ThanhTien " +
                                 "FROM SuDungDichVu s " +
                                 "INNER JOIN DichVu d ON s.MaDV = d.MaDV " +
                                 "INNER JOIN PhieuDatPhong p ON s.MaPhieu = p.MaPhieu " +
                                 "WHERE p.SoPhong = @sp AND p.NgayTraPhong IS NULL " +
                                 "ORDER BY s.ThoiGian";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.SelectCommand.Parameters.Add("@sp", SqlDbType.VarChar, 10).Value = soPhong;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvDichVu.DataSource = dt;

                    object tong = dt.Compute("SUM(ThanhTien)", "");
                    decimal tongTien = (tong == null || tong == DBNull.Value) ? 0 : Convert.ToDecimal(tong);
                    lblTongDV.Text = "Tổng tiền dịch vụ: " + Tien(tongTien);
                }
                DatTieuDe(dgvDichVu, "ThoiGian", "Thời gian gọi");
                DatTieuDe(dgvDichVu, "TenDV", "Tên dịch vụ");
                DatTieuDe(dgvDichVu, "DonGia", "Đơn giá");
                DatTieuDe(dgvDichVu, "SoLuong", "Số lượng");
                DatTieuDe(dgvDichVu, "ThanhTien", "Thành tiền");
                DatDinhDang(dgvDichVu, "ThoiGian", "dd/MM/yyyy HH:mm");
                DatDinhDang(dgvDichVu, "DonGia", "N0");
                DatDinhDang(dgvDichVu, "ThanhTien", "N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dịch vụ đã dùng: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPhongDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTai) return;
            LoadDichVuDaDung();
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            string soPhong = GiaTriChon(cboPhongDV, "SoPhong");
            string maDV = GiaTriChon(cboDichVu, "MaDV");
            if (soPhong == null)
            {
                MessageBox.Show("Chưa có phòng nào đang ở để gọi dịch vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (maDV == null)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int soLuong = (int)nudSoLuong.Value;

            try
            {
                int soDong;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Gắn dịch vụ vào phiếu đang hoạt động (chưa trả phòng) của phòng đó
                    string sql = "INSERT INTO SuDungDichVu (MaPhieu, MaDV, SoLuong, ThoiGian) " +
                                 "SELECT TOP 1 MaPhieu, @dv, @sl, @tg FROM PhieuDatPhong " +
                                 "WHERE SoPhong = @sp AND NgayTraPhong IS NULL ORDER BY NgayNhanPhong DESC";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@dv", SqlDbType.Int).Value = int.Parse(maDV);
                    cmd.Parameters.Add("@sl", SqlDbType.Int).Value = soLuong;
                    cmd.Parameters.Add("@tg", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@sp", SqlDbType.VarChar, 10).Value = soPhong;
                    conn.Open();
                    soDong = cmd.ExecuteNonQuery();
                }

                if (soDong == 0)
                {
                    MessageBox.Show("Phòng này chưa có phiếu nhận phòng đang hoạt động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                nudSoLuong.Value = 1;
                LoadDichVuDaDung();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm dịch vụ: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        //  TAB 4: CHECK-OUT & HÓA ĐƠN (SqlTransaction)
        // =====================================================================

        // Tính hóa đơn (chưa ghi CSDL). Trả về null nếu phòng không có phiếu đang hoạt động.
        private HoaDon TinhHoaDon(string soPhong)
        {
            HoaDon hd = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql =
                    @"SELECT TOP 1 p.MaPhieu, p.NgayNhanPhong, ph.LoaiPhong, ph.GiaTheoGio, k.HoTen, k.CCCD,
                             ISNULL((SELECT SUM(s.SoLuong * d.DonGia)
                                     FROM SuDungDichVu s INNER JOIN DichVu d ON s.MaDV = d.MaDV
                                     WHERE s.MaPhieu = p.MaPhieu), 0) AS TienDV
                      FROM PhieuDatPhong p
                      INNER JOIN Phong ph ON p.SoPhong = ph.SoPhong
                      INNER JOIN KhachHang k ON p.MaKH = k.MaKH
                      WHERE p.SoPhong = @sp AND p.NgayTraPhong IS NULL
                      ORDER BY p.NgayNhanPhong DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@sp", SqlDbType.VarChar, 10).Value = soPhong;
                conn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        hd = new HoaDon();
                        hd.MaPhieu = Convert.ToInt32(rd["MaPhieu"]);
                        hd.SoPhong = soPhong;
                        hd.LoaiPhong = rd["LoaiPhong"].ToString();
                        hd.HoTen = rd["HoTen"].ToString();
                        hd.CCCD = rd["CCCD"].ToString();
                        hd.Nhan = Convert.ToDateTime(rd["NgayNhanPhong"]);
                        hd.GiaGio = Convert.ToDecimal(rd["GiaTheoGio"]);
                        hd.TienDV = Convert.ToDecimal(rd["TienDV"]);
                    }
                }
            }

            if (hd != null)
            {
                hd.Tra = DateTime.Now;
                // Thời gian ở: làm tròn lên theo giờ, tối thiểu 1 giờ
                hd.SoGio = (int)Math.Ceiling((hd.Tra - hd.Nhan).TotalHours);
                if (hd.SoGio < 1) hd.SoGio = 1;
                hd.TienPhong = hd.SoGio * hd.GiaGio;
                hd.Tong = hd.TienPhong + hd.TienDV;
            }
            return hd;
        }

        private string TaoNoiDungHoaDon(HoaDon hd, bool daThanhToan)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=============== HÓA ĐƠN THANH TOÁN ===============");
            sb.AppendLine("Mã phiếu      : " + hd.MaPhieu);
            sb.AppendLine("Phòng         : " + hd.SoPhong + " (" + hd.LoaiPhong + ")");
            sb.AppendLine("Khách hàng    : " + hd.HoTen + " - CCCD: " + hd.CCCD);
            sb.AppendLine("Nhận phòng    : " + hd.Nhan.ToString("dd/MM/yyyy HH:mm"));
            sb.AppendLine("Trả phòng     : " + hd.Tra.ToString("dd/MM/yyyy HH:mm"));
            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine("Thời gian ở   : " + hd.SoGio + " giờ (làm tròn lên) x " + Tien(hd.GiaGio) + "/giờ");
            sb.AppendLine("Tiền phòng    : " + Tien(hd.TienPhong));
            sb.AppendLine();
            sb.AppendLine("Dịch vụ đã dùng:");

            string sql = "SELECT d.TenDV, s.SoLuong, d.DonGia, s.SoLuong * d.DonGia AS ThanhTien " +
                         "FROM SuDungDichVu s INNER JOIN DichVu d ON s.MaDV = d.MaDV " +
                         "WHERE s.MaPhieu = @mp ORDER BY s.ThoiGian";
            SqlParameter pMp = new SqlParameter("@mp", SqlDbType.Int);
            pMp.Value = hd.MaPhieu;
            DataTable dv = LayBang(sql, pMp);
            if (dv.Rows.Count == 0)
            {
                sb.AppendLine("  (Không sử dụng dịch vụ)");
            }
            foreach (DataRow r in dv.Rows)
            {
                sb.AppendLine("  - " + r["TenDV"] + " x" + r["SoLuong"] + " = " +
                              Tien(Convert.ToDecimal(r["ThanhTien"])));
            }
            sb.AppendLine("Tiền dịch vụ  : " + Tien(hd.TienDV));
            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine("TỔNG THANH TOÁN: " + Tien(hd.Tong));
            sb.AppendLine("==================================================");
            if (daThanhToan) sb.AppendLine("*** ĐÃ THANH TOÁN - PHÒNG CHUYỂN SANG \"ĐANG DỌN DẸP\" ***");
            return sb.ToString();
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            string soPhong = GiaTriChon(cboPhongCO, "SoPhong");
            if (soPhong == null)
            {
                MessageBox.Show("Không có phòng nào đang ở để trả phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                HoaDon hd = TinhHoaDon(soPhong);
                if (hd == null)
                {
                    MessageBox.Show("Phòng này không có phiếu đang hoạt động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                txtHoaDon.Text = TaoNoiDungHoaDon(hd, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tính tiền: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string soPhong = GiaTriChon(cboPhongCO, "SoPhong");
            if (soPhong == null)
            {
                MessageBox.Show("Không có phòng nào đang ở để trả phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                HoaDon hd = TinhHoaDon(soPhong);
                if (hd == null)
                {
                    MessageBox.Show("Phòng này không có phiếu đang hoạt động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                txtHoaDon.Text = TaoNoiDungHoaDon(hd, false);

                DialogResult dr = MessageBox.Show(
                    "Phòng " + hd.SoPhong + " - " + hd.HoTen + "\nTổng thanh toán: " + Tien(hd.Tong) +
                    "\n\nXác nhận thanh toán và trả phòng?",
                    "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) return;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction tran = conn.BeginTransaction();
                    try
                    {
                        // 1. Lưu tổng tiền + ngày trả phòng
                        SqlCommand cmdPhieu = new SqlCommand(
                            "UPDATE PhieuDatPhong SET NgayTraPhong = @tra, TongTienThanhToan = @tong " +
                            "WHERE MaPhieu = @mp AND NgayTraPhong IS NULL", conn, tran);
                        cmdPhieu.Parameters.Add("@tra", SqlDbType.DateTime).Value = hd.Tra;
                        SqlParameter pTong = cmdPhieu.Parameters.Add("@tong", SqlDbType.Decimal);
                        pTong.Precision = 18;
                        pTong.Scale = 2;
                        pTong.Value = hd.Tong;
                        cmdPhieu.Parameters.Add("@mp", SqlDbType.Int).Value = hd.MaPhieu;
                        if (cmdPhieu.ExecuteNonQuery() == 0)
                            throw new Exception("Phiếu này đã được thanh toán trước đó.");

                        // 2. Chuyển phòng sang "Đang dọn dẹp"
                        SqlCommand cmdPhong = new SqlCommand(
                            "UPDATE Phong SET TrangThai = @tt WHERE SoPhong = @sp", conn, tran);
                        cmdPhong.Parameters.Add("@tt", SqlDbType.NVarChar, 30).Value = "Đang dọn dẹp";
                        cmdPhong.Parameters.Add("@sp", SqlDbType.VarChar, 10).Value = hd.SoPhong;
                        cmdPhong.ExecuteNonQuery();

                        tran.Commit();
                    }
                    catch
                    {
                        try { tran.Rollback(); } catch { }
                        throw;
                    }
                }

                txtHoaDon.Text = TaoNoiDungHoaDon(hd, true);
                MessageBox.Show("Thanh toán thành công!\nTổng tiền: " + Tien(hd.Tong), "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTatCa();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thanh toán (đã hoàn tác giao dịch): {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
