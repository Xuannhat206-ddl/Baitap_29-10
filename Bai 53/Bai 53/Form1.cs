using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Bai_53
{
    public partial class Form1 : Form
    {
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CafePOSDB;Integrated Security=True";

        private int maBanChon = -1;
        private string tenBanChon = "";
        private int maHoaDonHienTai = -1;
        private int maDanhMucChon = -1;
        private int maMonChon = -1;

        private DataTable dtBan;
        private DataTable dtDanhMuc;
        private DataTable dtMonAn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDanhMucVaMon();
            LoadDanhSachBan();
            LoadHoaDon();
            LoadDanhMucGrid();
            LoadMonAnGrid();
        }

        private void HienLoi(string tieuDe, Exception ex)
        {
            MessageBox.Show(tieuDe + ": " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CanhBao(string noiDung)
        {
            MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void LoadDanhMucVaMon()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    dtDanhMuc = new DataTable();
                    SqlDataAdapter adDM = new SqlDataAdapter(
                        "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc ORDER BY TenDanhMuc", conn);
                    adDM.Fill(dtDanhMuc);

                    dtMonAn = new DataTable();
                    SqlDataAdapter adMon = new SqlDataAdapter(
                        "SELECT MaMon, TenMon, MaDanhMuc, DonGia FROM MonAn", conn);
                    adMon.Fill(dtMonAn);
                }

                cboDanhMuc.DisplayMember = "TenDanhMuc";
                cboDanhMuc.ValueMember = "MaDanhMuc";
                cboDanhMuc.DataSource = new DataView(dtDanhMuc);

                cboDanhMucMon.DisplayMember = "TenDanhMuc";
                cboDanhMucMon.ValueMember = "MaDanhMuc";
                cboDanhMucMon.DataSource = new DataView(dtDanhMuc);

                LocMonTheoDanhMuc();
            }
            catch (Exception ex)
            {
                HienLoi("Lỗi tải thực đơn", ex);
            }
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocMonTheoDanhMuc();
        }

        private void LocMonTheoDanhMuc()
        {
            if (dtMonAn == null || !(cboDanhMuc.SelectedValue is int)) return;
            int maDM = (int)cboDanhMuc.SelectedValue;

            DataView view = new DataView(dtMonAn);
            view.RowFilter = "MaDanhMuc = " + maDM;
            view.Sort = "TenMon";

            cboMon.DisplayMember = "TenMon";
            cboMon.ValueMember = "MaMon";
            cboMon.DataSource = view;
        }

        private void LoadDanhSachBan()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = "SELECT MaBan, TenBan, TrangThai FROM BanAn ORDER BY MaBan";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    dtBan = new DataTable();
                    adapter.Fill(dtBan);
                }

                pnlBan.SuspendLayout();
                pnlBan.Controls.Clear();

                foreach (DataRow r in dtBan.Rows)
                {
                    int maBan = (int)r["MaBan"];
                    string tenBan = r["TenBan"].ToString();
                    string trangThai = r["TrangThai"].ToString();

                    Button btn = new Button();
                    btn.Width = 120;
                    btn.Height = 80;
                    btn.Margin = new Padding(8);
                    btn.Text = tenBan + Environment.NewLine + trangThai;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    btn.ForeColor = Color.White;
                    btn.BackColor = (trangThai == "Trống") ? Color.SeaGreen : Color.Firebrick;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.Gold;
                    btn.FlatAppearance.BorderSize = (maBan == maBanChon) ? 4 : 0;
                    btn.Tag = maBan;
                    btn.Click += BtnBan_Click;
                    pnlBan.Controls.Add(btn);
                }
                pnlBan.ResumeLayout();

                DataView dv = new DataView(dtBan);
                dv.RowFilter = "TrangThai = 'Trống' AND MaBan <> " + maBanChon;
                cboBanMoi.DisplayMember = "TenBan";
                cboBanMoi.ValueMember = "MaBan";
                cboBanMoi.DataSource = dv.ToTable();
            }
            catch (Exception ex)
            {
                HienLoi("Lỗi tải sơ đồ bàn", ex);
            }
        }

        private void BtnBan_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            maBanChon = (int)btn.Tag;
            DataRow[] rows = dtBan.Select("MaBan = " + maBanChon);
            tenBanChon = rows.Length > 0 ? rows[0]["TenBan"].ToString() : "";

            LoadDanhSachBan();
            LoadHoaDon();
        }

        private void LoadHoaDon()
        {
            maHoaDonHienTai = -1;
            decimal tong = 0;
            lblBanChon.Text = maBanChon > 0 ? tenBanChon : "Chưa chọn bàn";

            try
            {
                DataTable dt = new DataTable();
                if (maBanChon > 0)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(
                            "SELECT TOP 1 MaHoaDon FROM HoaDon WHERE MaBan = @b AND TrangThai = 0 ORDER BY MaHoaDon DESC", conn);
                        cmd.Parameters.AddWithValue("@b", maBanChon);
                        object o = cmd.ExecuteScalar();

                        if (o != null)
                        {
                            maHoaDonHienTai = Convert.ToInt32(o);
                            string sql = @"SELECT ct.MaMon, m.TenMon, ct.SoLuong, ct.DonGia,
                                                  ct.SoLuong * ct.DonGia AS ThanhTien
                                           FROM ChiTietHoaDon ct JOIN MonAn m ON m.MaMon = ct.MaMon
                                           WHERE ct.MaHoaDon = @h
                                           ORDER BY m.TenMon";
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                            adapter.SelectCommand.Parameters.AddWithValue("@h", maHoaDonHienTai);
                            adapter.Fill(dt);
                        }
                    }
                }

                dgvHoaDon.DataSource = dt;
                if (dgvHoaDon.Columns.Contains("MaMon"))
                {
                    dgvHoaDon.Columns["MaMon"].Visible = false;
                    dgvHoaDon.Columns["TenMon"].HeaderText = "Tên món";
                    dgvHoaDon.Columns["SoLuong"].HeaderText = "SL";
                    dgvHoaDon.Columns["DonGia"].HeaderText = "Đơn giá";
                    dgvHoaDon.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                    dgvHoaDon.Columns["ThanhTien"].HeaderText = "Thành tiền";
                    dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

                    object s = dt.Compute("SUM(ThanhTien)", "");
                    tong = (s == DBNull.Value) ? 0 : Convert.ToDecimal(s);
                }
            }
            catch (Exception ex)
            {
                HienLoi("Lỗi tải hóa đơn", ex);
            }

            lblTongTien.Text = "Tổng tiền: " + tong.ToString("N0") + " đ";
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (maBanChon <= 0) { CanhBao("Vui lòng chọn bàn trước."); return; }
            if (!(cboMon.SelectedValue is int)) { CanhBao("Chưa chọn món."); return; }

            int maMon = (int)cboMon.SelectedValue;
            int soLuong = (int)nudSoLuong.Value;
            if (soLuong <= 0) { CanhBao("Số lượng phải lớn hơn 0."); return; }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand(
                                "SELECT TOP 1 MaHoaDon FROM HoaDon WHERE MaBan = @b AND TrangThai = 0", conn, tran);
                            cmd.Parameters.AddWithValue("@b", maBanChon);
                            object o = cmd.ExecuteScalar();

                            int maHD;
                            if (o == null)
                            {
                                cmd = new SqlCommand(
                                    "INSERT INTO HoaDon(MaBan, GioVao, TongTien, TrangThai) VALUES(@b, GETDATE(), 0, 0); " +
                                    "SELECT CAST(SCOPE_IDENTITY() AS int)", conn, tran);
                                cmd.Parameters.AddWithValue("@b", maBanChon);
                                maHD = Convert.ToInt32(cmd.ExecuteScalar());
                            }
                            else maHD = Convert.ToInt32(o);

                            cmd = new SqlCommand("SELECT DonGia FROM MonAn WHERE MaMon = @m", conn, tran);
                            cmd.Parameters.AddWithValue("@m", maMon);
                            object gia = cmd.ExecuteScalar();
                            if (gia == null) throw new InvalidOperationException("Món không tồn tại.");

                            cmd = new SqlCommand(
                                "UPDATE ChiTietHoaDon SET SoLuong = SoLuong + @sl WHERE MaHoaDon = @h AND MaMon = @m", conn, tran);
                            cmd.Parameters.AddWithValue("@sl", soLuong);
                            cmd.Parameters.AddWithValue("@h", maHD);
                            cmd.Parameters.AddWithValue("@m", maMon);
                            if (cmd.ExecuteNonQuery() == 0)
                            {
                                cmd = new SqlCommand(
                                    "INSERT INTO ChiTietHoaDon(MaHoaDon, MaMon, SoLuong, DonGia) VALUES(@h, @m, @sl, @g)", conn, tran);
                                cmd.Parameters.AddWithValue("@h", maHD);
                                cmd.Parameters.AddWithValue("@m", maMon);
                                cmd.Parameters.AddWithValue("@sl", soLuong);
                                cmd.Parameters.AddWithValue("@g", Convert.ToDecimal(gia));
                                cmd.ExecuteNonQuery();
                            }

                            cmd = new SqlCommand("UPDATE BanAn SET TrangThai = N'Có khách' WHERE MaBan = @b", conn, tran);
                            cmd.Parameters.AddWithValue("@b", maBanChon);
                            cmd.ExecuteNonQuery();

                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }

                LoadDanhSachBan();
                LoadHoaDon();
            }
            catch (Exception ex)
            {
                HienLoi("Lỗi thêm món", ex);
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (maHoaDonHienTai <= 0 || dgvHoaDon.CurrentRow == null || !dgvHoaDon.Columns.Contains("MaMon"))
            {
                CanhBao("Hãy chọn một món trong hóa đơn.");
                return;
            }
            int maMon = Convert.ToInt32(dgvHoaDon.CurrentRow.Cells["MaMon"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand(
                                "DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @h AND MaMon = @m", conn, tran);
                            cmd.Parameters.AddWithValue("@h", maHoaDonHienTai);
                            cmd.Parameters.AddWithValue("@m", maMon);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("SELECT COUNT(*) FROM ChiTietHoaDon WHERE MaHoaDon = @h", conn, tran);
                            cmd.Parameters.AddWithValue("@h", maHoaDonHienTai);
                            if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                            {
                                cmd = new SqlCommand("DELETE FROM HoaDon WHERE MaHoaDon = @h", conn, tran);
                                cmd.Parameters.AddWithValue("@h", maHoaDonHienTai);
                                cmd.ExecuteNonQuery();

                                cmd = new SqlCommand("UPDATE BanAn SET TrangThai = N'Trống' WHERE MaBan = @b", conn, tran);
                                cmd.Parameters.AddWithValue("@b", maBanChon);
                                cmd.ExecuteNonQuery();
                            }
                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }

                LoadDanhSachBan();
                LoadHoaDon();
            }
            catch (Exception ex)
            {
                HienLoi("Lỗi xóa món", ex);
            }
        }

        private void btnDoiBan_Click(object sender, EventArgs e)
        {
            if (maHoaDonHienTai <= 0) { CanhBao("Bàn này chưa có hóa đơn để đổi."); return; }
            if (!(cboBanMoi.SelectedValue is int)) { CanhBao("Không có bàn trống để chuyển."); return; }

            int maBanMoi = (int)cboBanMoi.SelectedValue;
            string tenBanMoi = cboBanMoi.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("SELECT TrangThai FROM BanAn WHERE MaBan = @b", conn, tran);
                            cmd.Parameters.AddWithValue("@b", maBanMoi);
                            if (Convert.ToString(cmd.ExecuteScalar()) != "Trống")
                                throw new InvalidOperationException("Bàn muốn chuyển đến không còn trống.");

                            cmd = new SqlCommand("UPDATE HoaDon SET MaBan = @moi WHERE MaHoaDon = @h", conn, tran);
                            cmd.Parameters.AddWithValue("@moi", maBanMoi);
                            cmd.Parameters.AddWithValue("@h", maHoaDonHienTai);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("UPDATE BanAn SET TrangThai = N'Trống' WHERE MaBan = @b", conn, tran);
                            cmd.Parameters.AddWithValue("@b", maBanChon);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("UPDATE BanAn SET TrangThai = N'Có khách' WHERE MaBan = @b", conn, tran);
                            cmd.Parameters.AddWithValue("@b", maBanMoi);
                            cmd.ExecuteNonQuery();

                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }

                maBanChon = maBanMoi;
                tenBanChon = tenBanMoi;
                LoadDanhSachBan();
                LoadHoaDon();
            }
            catch (Exception ex)
            {
                HienLoi("Lỗi đổi bàn", ex);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (maHoaDonHienTai <= 0) { CanhBao("Bàn này chưa có hóa đơn để thanh toán."); return; }

            if (MessageBox.Show("Thanh toán " + tenBanChon + "?\n" + lblTongTien.Text, "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                decimal tong;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand(
                                "SELECT SUM(SoLuong * DonGia) FROM ChiTietHoaDon WHERE MaHoaDon = @h", conn, tran);
                            cmd.Parameters.AddWithValue("@h", maHoaDonHienTai);
                            object o = cmd.ExecuteScalar();
                            if (o == null || o == DBNull.Value)
                                throw new InvalidOperationException("Hóa đơn chưa có món nào để thanh toán.");
                            tong = Convert.ToDecimal(o);

                            cmd = new SqlCommand(
                                "UPDATE HoaDon SET GioRa = GETDATE(), TongTien = @t, TrangThai = 1 WHERE MaHoaDon = @h", conn, tran);
                            cmd.Parameters.AddWithValue("@t", tong);
                            cmd.Parameters.AddWithValue("@h", maHoaDonHienTai);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("UPDATE BanAn SET TrangThai = N'Trống' WHERE MaBan = @b", conn, tran);
                            cmd.Parameters.AddWithValue("@b", maBanChon);
                            cmd.ExecuteNonQuery();

                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Thanh toán thành công: " + tong.ToString("N0") + " đ", "Hoàn tất",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachBan();
                LoadHoaDon();
            }
            catch (Exception ex)
            {
                HienLoi("Lỗi thanh toán", ex);
            }
        }

        private void LoadDanhMucGrid()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc ORDER BY TenDanhMuc";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvDanhMuc.DataSource = dt;
                }
                dgvDanhMuc.Columns["MaDanhMuc"].Visible = false;
                dgvDanhMuc.Columns["TenDanhMuc"].HeaderText = "Danh mục";
                maDanhMucChon = -1;
            }
            catch (Exception ex)
            {
                HienLoi("Lỗi tải danh mục", ex);
            }
        }

        private void LoadMonAnGrid()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = @"SELECT m.MaMon, m.TenMon, m.MaDanhMuc, d.TenDanhMuc, m.DonGia
                                   FROM MonAn m JOIN DanhMuc d ON d.MaDanhMuc = m.MaDanhMuc
                                   ORDER BY d.TenDanhMuc, m.TenMon";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvMonAn.DataSource = dt;
                }
                dgvMonAn.Columns["MaMon"].Visible = false;
                dgvMonAn.Columns["MaDanhMuc"].Visible = false;
                dgvMonAn.Columns["TenMon"].HeaderText = "Tên món";
                dgvMonAn.Columns["TenDanhMuc"].HeaderText = "Danh mục";
                dgvMonAn.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvMonAn.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                maMonChon = -1;
            }
            catch (Exception ex)
            {
                HienLoi("Lỗi tải thực đơn", ex);
            }
        }

        private void LamMoiSauKhiSuaMenu()
        {
            LoadDanhMucGrid();
            LoadMonAnGrid();
            LoadDanhMucVaMon();
            if (maBanChon > 0) LoadHoaDon();
        }

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvDanhMuc.Rows[e.RowIndex];
            maDanhMucChon = Convert.ToInt32(row.Cells["MaDanhMuc"].Value);
            txtTenDM.Text = row.Cells["TenDanhMuc"].Value.ToString();
        }

        private void dgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvMonAn.Rows[e.RowIndex];
            maMonChon = Convert.ToInt32(row.Cells["MaMon"].Value);
            txtTenMon.Text = row.Cells["TenMon"].Value.ToString();
            txtDonGia.Text = Convert.ToDecimal(row.Cells["DonGia"].Value).ToString("0.##");
            cboDanhMucMon.SelectedValue = Convert.ToInt32(row.Cells["MaDanhMuc"].Value);
        }

        private void XuLyLoiXoa(SqlException ex)
        {
            if (ex.Number == 547)
                CanhBao("Không thể xóa vì dữ liệu đang được sử dụng (món đã có trong hóa đơn hoặc danh mục còn món).");
            else
                HienLoi("Lỗi xóa dữ liệu", ex);
        }

        private bool KiemTraDanhMuc()
        {
            if (string.IsNullOrWhiteSpace(txtTenDM.Text))
            {
                CanhBao("Tên danh mục không được để trống.");
                txtTenDM.Focus();
                return false;
            }
            return true;
        }

        private void btnThemDM_Click(object sender, EventArgs e)
        {
            if (!KiemTraDanhMuc()) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO DanhMuc(TenDanhMuc) VALUES(@t)", conn);
                    cmd.Parameters.AddWithValue("@t", txtTenDM.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
                txtTenDM.Clear();
                LamMoiSauKhiSuaMenu();
            }
            catch (Exception ex) { HienLoi("Lỗi thêm danh mục", ex); }
        }

        private void btnSuaDM_Click(object sender, EventArgs e)
        {
            if (maDanhMucChon <= 0) { CanhBao("Hãy chọn một danh mục trong bảng."); return; }
            if (!KiemTraDanhMuc()) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE DanhMuc SET TenDanhMuc = @t WHERE MaDanhMuc = @id", conn);
                    cmd.Parameters.AddWithValue("@t", txtTenDM.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", maDanhMucChon);
                    cmd.ExecuteNonQuery();
                }
                LamMoiSauKhiSuaMenu();
            }
            catch (Exception ex) { HienLoi("Lỗi sửa danh mục", ex); }
        }

        private void btnXoaDM_Click(object sender, EventArgs e)
        {
            if (maDanhMucChon <= 0) { CanhBao("Hãy chọn một danh mục trong bảng."); return; }
            if (MessageBox.Show("Xóa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM DanhMuc WHERE MaDanhMuc = @id", conn);
                    cmd.Parameters.AddWithValue("@id", maDanhMucChon);
                    cmd.ExecuteNonQuery();
                }
                txtTenDM.Clear();
                LamMoiSauKhiSuaMenu();
            }
            catch (SqlException ex) { XuLyLoiXoa(ex); }
            catch (Exception ex) { HienLoi("Lỗi xóa danh mục", ex); }
        }

        private bool KiemTraMonAn(out decimal gia)
        {
            gia = 0;
            if (string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                CanhBao("Tên món không được để trống.");
                txtTenMon.Focus();
                return false;
            }
            if (!(cboDanhMucMon.SelectedValue is int))
            {
                CanhBao("Hãy chọn danh mục cho món.");
                return false;
            }
            if (!decimal.TryParse(txtDonGia.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out gia))
            {
                CanhBao("Đơn giá phải là một số hợp lệ.");
                txtDonGia.Focus();
                return false;
            }
            if (gia < 0)
            {
                CanhBao("Đơn giá không được âm.");
                txtDonGia.Focus();
                return false;
            }
            return true;
        }

        private void btnThemMonAn_Click(object sender, EventArgs e)
        {
            decimal gia;
            if (!KiemTraMonAn(out gia)) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO MonAn(TenMon, MaDanhMuc, DonGia) VALUES(@t, @dm, @g)", conn);
                    cmd.Parameters.AddWithValue("@t", txtTenMon.Text.Trim());
                    cmd.Parameters.AddWithValue("@dm", (int)cboDanhMucMon.SelectedValue);
                    cmd.Parameters.AddWithValue("@g", gia);
                    cmd.ExecuteNonQuery();
                }
                txtTenMon.Clear();
                txtDonGia.Clear();
                LamMoiSauKhiSuaMenu();
            }
            catch (Exception ex) { HienLoi("Lỗi thêm món", ex); }
        }

        private void btnSuaMonAn_Click(object sender, EventArgs e)
        {
            if (maMonChon <= 0) { CanhBao("Hãy chọn một món trong bảng."); return; }
            decimal gia;
            if (!KiemTraMonAn(out gia)) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE MonAn SET TenMon = @t, MaDanhMuc = @dm, DonGia = @g WHERE MaMon = @id", conn);
                    cmd.Parameters.AddWithValue("@t", txtTenMon.Text.Trim());
                    cmd.Parameters.AddWithValue("@dm", (int)cboDanhMucMon.SelectedValue);
                    cmd.Parameters.AddWithValue("@g", gia);
                    cmd.Parameters.AddWithValue("@id", maMonChon);
                    cmd.ExecuteNonQuery();
                }
                LamMoiSauKhiSuaMenu();
            }
            catch (Exception ex) { HienLoi("Lỗi sửa món", ex); }
        }

        private void btnXoaMonAn_Click(object sender, EventArgs e)
        {
            if (maMonChon <= 0) { CanhBao("Hãy chọn một món trong bảng."); return; }
            if (MessageBox.Show("Xóa món này?", "Xác nhận", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM MonAn WHERE MaMon = @id", conn);
                    cmd.Parameters.AddWithValue("@id", maMonChon);
                    cmd.ExecuteNonQuery();
                }
                txtTenMon.Clear();
                txtDonGia.Clear();
                LamMoiSauKhiSuaMenu();
            }
            catch (SqlException ex) { XuLyLoiXoa(ex); }
            catch (Exception ex) { HienLoi("Lỗi xóa món", ex); }
        }
    }
}