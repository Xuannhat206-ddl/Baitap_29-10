using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Bai55.BUS;
using Bai55.DTO;

namespace Bai55.GUI
{
    public partial class Form1 : Form
    {
        // GUI chỉ làm việc với BUS (không viết SQL ở đây)
        private readonly NhaCungCapBUS nccBUS = new NhaCungCapBUS();
        private readonly VatTuBUS vtBUS = new VatTuBUS();
        private readonly PhieuKhoBUS pkBUS = new PhieuKhoBUS();

        private DataTable dtChiTiet;        // danh sách vật tư của phiếu đang lập (chưa lưu)
        private bool dangTai = false;
        private bool daLoad = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Bảng chi tiết phiếu trong bộ nhớ
            dtChiTiet = new DataTable();
            dtChiTiet.Columns.Add("MaVatTu", typeof(string));
            dtChiTiet.Columns.Add("TenVatTu", typeof(string));
            dtChiTiet.Columns.Add("DVT", typeof(string));
            dtChiTiet.Columns.Add("SoLuong", typeof(decimal));
            dtChiTiet.Columns.Add("DonGia", typeof(decimal));
            dtChiTiet.Columns.Add("ThanhTien", typeof(decimal), "SoLuong * DonGia");
            dtChiTiet.PrimaryKey = new DataColumn[] { dtChiTiet.Columns["MaVatTu"] };
            dgvChiTiet.DataSource = dtChiTiet;
            DinhDangChiTiet(dgvChiTiet);

            cboLoaiPhieu.Items.Add("Phiếu NHẬP kho (NHAP)");
            cboLoaiPhieu.Items.Add("Phiếu XUẤT kho (XUAT)");
            cboLoaiPhieu.SelectedIndex = 0;

            LoadTatCa();
            daLoad = true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!daLoad) return;
            LoadTatCa();   // làm mới dữ liệu (tồn kho có thể đã thay đổi)
        }

        // =====================================================================
        //  TIỆN ÍCH
        // =====================================================================

        private string Tien(decimal v)
        {
            return v.ToString("N0") + " VNĐ";
        }

        private void ThongBao(string noiDung)
        {
            MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BaoLoi(string tieuDe, Exception ex)
        {
            MessageBox.Show($"{tieuDe}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string GiaTriChon(ComboBox cbo, string cot)
        {
            DataRowView drv = cbo.SelectedItem as DataRowView;
            if (drv == null) return null;
            return Convert.ToString(drv[cot]);
        }

        // Nạp ComboBox và giữ lại lựa chọn cũ nếu còn tồn tại
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

        private void DinhDangVatTu(DataGridView dgv)
        {
            DatTieuDe(dgv, "MaVatTu", "Mã vật tư");
            DatTieuDe(dgv, "TenVatTu", "Tên vật tư");
            DatTieuDe(dgv, "DVT", "ĐVT");
            DatTieuDe(dgv, "SoLuongTon", "Số lượng tồn");
            DatDinhDang(dgv, "SoLuongTon", "N2");
        }

        private void DinhDangChiTiet(DataGridView dgv)
        {
            DatTieuDe(dgv, "MaVatTu", "Mã vật tư");
            DatTieuDe(dgv, "TenVatTu", "Tên vật tư");
            DatTieuDe(dgv, "DVT", "ĐVT");
            DatTieuDe(dgv, "SoLuong", "Số lượng");
            DatTieuDe(dgv, "DonGia", "Đơn giá");
            DatTieuDe(dgv, "ThanhTien", "Thành tiền");
            DatDinhDang(dgv, "SoLuong", "N2");
            DatDinhDang(dgv, "DonGia", "N0");
            DatDinhDang(dgv, "ThanhTien", "N0");
        }

        private void LoadTatCa()
        {
            try
            {
                dangTai = true;
                LoadDanhSachNCC();
                LoadDanhSachVatTu();
                LoadComboPhieu();
                LoadLichSuPhieu();
                LoadCanhBao();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu từ SQL Server: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dangTai = false;
            }
        }

        // =====================================================================
        //  TAB 1: NHÀ CUNG CẤP (Thêm - Sửa - Xóa - Tìm)
        // =====================================================================

        private void HienThiNCC(DataTable dt)
        {
            dgvNCC.DataSource = dt;
            DatTieuDe(dgvNCC, "MaNCC", "Mã NCC");
            DatTieuDe(dgvNCC, "TenNCC", "Tên nhà cung cấp");
            DatTieuDe(dgvNCC, "DienThoai", "Điện thoại");
            DatTieuDe(dgvNCC, "DiaChi", "Địa chỉ");
        }

        private void LoadDanhSachNCC()
        {
            DataTable dt = nccBUS.LayTatCa();
            HienThiNCC(dt);
        }

        private void XoaTrangNCC()
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDTNCC.Clear();
            txtDCNCC.Clear();
            txtTenNCC.Focus();
        }

        private void btnTimNCC_Click(object sender, EventArgs e)
        {
            try
            {
                HienThiNCC(nccBUS.TimKiem(txtTimNCC.Text));
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi tìm kiếm", ex);
            }
        }

        private void btnTatCaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                txtTimNCC.Clear();
                LoadDanhSachNCC();
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi tải dữ liệu", ex);
            }
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgvNCC.Rows[e.RowIndex];
            txtMaNCC.Text = Convert.ToString(r.Cells["MaNCC"].Value);
            txtTenNCC.Text = Convert.ToString(r.Cells["TenNCC"].Value);
            txtDTNCC.Text = Convert.ToString(r.Cells["DienThoai"].Value);
            txtDCNCC.Text = Convert.ToString(r.Cells["DiaChi"].Value);
        }

        private void btnMoiNCC_Click(object sender, EventArgs e)
        {
            XoaTrangNCC();
        }

        private NhaCungCapDTO LayNCCTuForm()
        {
            NhaCungCapDTO n = new NhaCungCapDTO();
            int ma;
            if (int.TryParse(txtMaNCC.Text, out ma)) n.MaNCC = ma;
            n.TenNCC = txtTenNCC.Text;
            n.DienThoai = txtDTNCC.Text;
            n.DiaChi = txtDCNCC.Text;
            return n;
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text != "")
            {
                ThongBao("Đang chọn một nhà cung cấp có sẵn. Hãy bấm \"Nhập mới\" rồi nhập thông tin để thêm.");
                return;
            }
            try
            {
                nccBUS.Them(LayNCCTuForm());
                ThongBao("Đã thêm nhà cung cấp.");
                XoaTrangNCC();
                LoadTatCa();
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi thêm nhà cung cấp", ex);
            }
        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                nccBUS.Sua(LayNCCTuForm());
                ThongBao("Đã cập nhật nhà cung cấp.");
                LoadTatCa();
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi sửa nhà cung cấp", ex);
            }
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            int ma;
            if (!int.TryParse(txtMaNCC.Text, out ma))
            {
                ThongBao("Hãy chọn nhà cung cấp cần xóa trong danh sách.");
                return;
            }
            DialogResult dr = MessageBox.Show("Xóa nhà cung cấp \"" + txtTenNCC.Text + "\"?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            try
            {
                nccBUS.Xoa(ma);
                ThongBao("Đã xóa nhà cung cấp.");
                XoaTrangNCC();
                LoadTatCa();
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi xóa nhà cung cấp", ex);
            }
        }

        // =====================================================================
        //  TAB 2: VẬT TƯ (Thêm - Sửa - Xóa - Tìm theo mã/tên)
        // =====================================================================

        private void HienThiVatTu(DataTable dt)
        {
            dgvVatTu.DataSource = dt;
            DinhDangVatTu(dgvVatTu);
        }

        private void LoadDanhSachVatTu()
        {
            DataTable dt = vtBUS.LayTatCa();
            HienThiVatTu(dt);
        }

        private void XoaTrangVT()
        {
            txtMaVT.Clear();
            txtMaVT.ReadOnly = false;
            txtTenVT.Clear();
            txtDVT.Clear();
            nudTon.Value = 0;
            nudTon.Enabled = true;
            txtMaVT.Focus();
        }

        private void btnTimVT_Click(object sender, EventArgs e)
        {
            try
            {
                HienThiVatTu(vtBUS.TimKiem(txtTimVT.Text));
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi tìm kiếm", ex);
            }
        }

        private void btnTatCaVT_Click(object sender, EventArgs e)
        {
            try
            {
                txtTimVT.Clear();
                LoadDanhSachVatTu();
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi tải dữ liệu", ex);
            }
        }

        private void dgvVatTu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgvVatTu.Rows[e.RowIndex];
            txtMaVT.Text = Convert.ToString(r.Cells["MaVatTu"].Value);
            txtMaVT.ReadOnly = true;           // không cho đổi mã khi đang sửa
            txtTenVT.Text = Convert.ToString(r.Cells["TenVatTu"].Value);
            txtDVT.Text = Convert.ToString(r.Cells["DVT"].Value);
            decimal ton;
            if (decimal.TryParse(Convert.ToString(r.Cells["SoLuongTon"].Value), out ton))
            {
                if (ton > nudTon.Maximum) ton = nudTon.Maximum;
                nudTon.Value = ton;
            }
            nudTon.Enabled = false;            // tồn kho chỉ đổi qua phiếu nhập/xuất
        }

        private void btnMoiVT_Click(object sender, EventArgs e)
        {
            XoaTrangVT();
        }

        private void btnThemVT_Click(object sender, EventArgs e)
        {
            if (txtMaVT.ReadOnly)
            {
                ThongBao("Đang chọn một vật tư có sẵn. Hãy bấm \"Nhập mới\" rồi nhập thông tin để thêm.");
                return;
            }
            try
            {
                VatTuDTO v = new VatTuDTO();
                v.MaVatTu = txtMaVT.Text;
                v.TenVatTu = txtTenVT.Text;
                v.DVT = txtDVT.Text;
                v.SoLuongTon = nudTon.Value;
                vtBUS.Them(v);
                ThongBao("Đã thêm vật tư.");
                XoaTrangVT();
                LoadTatCa();
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi thêm vật tư", ex);
            }
        }

        private void btnSuaVT_Click(object sender, EventArgs e)
        {
            if (!txtMaVT.ReadOnly)
            {
                ThongBao("Hãy chọn vật tư cần sửa trong danh sách.");
                return;
            }
            try
            {
                VatTuDTO v = new VatTuDTO();
                v.MaVatTu = txtMaVT.Text;
                v.TenVatTu = txtTenVT.Text;
                v.DVT = txtDVT.Text;
                vtBUS.Sua(v);
                ThongBao("Đã cập nhật vật tư.");
                LoadTatCa();
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi sửa vật tư", ex);
            }
        }

        private void btnXoaVT_Click(object sender, EventArgs e)
        {
            if (!txtMaVT.ReadOnly)
            {
                ThongBao("Hãy chọn vật tư cần xóa trong danh sách.");
                return;
            }
            DialogResult dr = MessageBox.Show("Xóa vật tư \"" + txtMaVT.Text + " - " + txtTenVT.Text + "\"?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            try
            {
                vtBUS.Xoa(txtMaVT.Text);
                ThongBao("Đã xóa vật tư.");
                XoaTrangVT();
                LoadTatCa();
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi xóa vật tư", ex);
            }
        }

        // =====================================================================
        //  TAB 3: LẬP PHIẾU NHẬP / XUẤT (SqlTransaction nằm ở DAL)
        // =====================================================================

        private void LoadComboPhieu()
        {
            NapCombo(cboNCC, nccBUS.LayTatCa(), "TenNCC", "MaNCC");
            NapCombo(cboVatTu, vtBUS.LayChoCombo(), "HienThi", "MaVatTu");
        }

        private void cboLoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Phiếu xuất không cần nhà cung cấp
            cboNCC.Enabled = (cboLoaiPhieu.SelectedIndex == 0);
        }

        private void CapNhatTongPhieu()
        {
            object tong = dtChiTiet.Compute("SUM(ThanhTien)", "");
            decimal t = (tong == null || tong == DBNull.Value) ? 0 : Convert.ToDecimal(tong);
            lblTongPhieu.Text = "Tổng tiền phiếu: " + Tien(t);
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            DataRowView drv = cboVatTu.SelectedItem as DataRowView;
            if (drv == null)
            {
                ThongBao("Vui lòng chọn vật tư.");
                return;
            }
            decimal sl = nudSL.Value;
            decimal dg = nudDG.Value;
            if (sl <= 0)
            {
                ThongBao("Số lượng phải lớn hơn 0.");
                return;
            }

            string ma = Convert.ToString(drv["MaVatTu"]);
            DataRow dong = dtChiTiet.Rows.Find(ma);
            if (dong != null)
            {
                // vật tư đã có trong phiếu -> cộng dồn số lượng, cập nhật đơn giá
                dong["SoLuong"] = Convert.ToDecimal(dong["SoLuong"]) + sl;
                dong["DonGia"] = dg;
            }
            else
            {
                dtChiTiet.Rows.Add(ma, Convert.ToString(drv["TenVatTu"]), Convert.ToString(drv["DVT"]), sl, dg);
            }
            nudSL.Value = 1;
            CapNhatTongPhieu();
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow == null)
            {
                ThongBao("Hãy chọn dòng cần xóa.");
                return;
            }
            DataRowView drv = dgvChiTiet.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;
            dtChiTiet.Rows.Remove(drv.Row);
            CapNhatTongPhieu();
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            dtChiTiet.Rows.Clear();
            nudSL.Value = 1;
            nudDG.Value = 0;
            CapNhatTongPhieu();
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (dtChiTiet.Rows.Count == 0)
            {
                ThongBao("Phiếu chưa có vật tư nào. Hãy thêm vật tư trước khi lưu.");
                return;
            }

            bool laNhap = (cboLoaiPhieu.SelectedIndex == 0);
            string loai = laNhap ? "NHAP" : "XUAT";

            int? maNCC = null;
            if (laNhap)
            {
                string chonNCC = GiaTriChon(cboNCC, "MaNCC");
                if (chonNCC == null)
                {
                    ThongBao("Phiếu nhập phải chọn nhà cung cấp.");
                    return;
                }
                maNCC = int.Parse(chonNCC);
            }

            List<ChiTietPhieuKhoDTO> ds = new List<ChiTietPhieuKhoDTO>();
            foreach (DataRow r in dtChiTiet.Rows)
            {
                ChiTietPhieuKhoDTO ct = new ChiTietPhieuKhoDTO();
                ct.MaVatTu = Convert.ToString(r["MaVatTu"]);
                ct.SoLuong = Convert.ToDecimal(r["SoLuong"]);
                ct.DonGia = Convert.ToDecimal(r["DonGia"]);
                ds.Add(ct);
            }

            try
            {
                int maPhieu = pkBUS.LapPhieu(loai, maNCC, ds);
                MessageBox.Show("Lưu phiếu " + loai + " thành công. Mã phiếu: " + maPhieu, "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtChiTiet.Rows.Clear();
                CapNhatTongPhieu();
                LoadTatCa();   // tồn kho đã thay đổi -> nạp lại
            }
            catch (Exception ex)
            {
                // Ví dụ: "Không đủ hàng trong kho" (đã rollback toàn bộ giao dịch)
                MessageBox.Show(ex.Message, "Không lưu được phiếu (đã hoàn tác)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // =====================================================================
        //  TAB 4: LỊCH SỬ PHIẾU
        // =====================================================================

        private void LoadLichSuPhieu()
        {
            DataTable dt = pkBUS.LayDanhSach();
            dgvPhieu.DataSource = dt;
            DatTieuDe(dgvPhieu, "MaPhieu", "Mã phiếu");
            DatTieuDe(dgvPhieu, "LoaiPhieu", "Loại phiếu");
            DatTieuDe(dgvPhieu, "NgayLap", "Ngày lập");
            DatTieuDe(dgvPhieu, "TenNCC", "Nhà cung cấp");
            DatTieuDe(dgvPhieu, "TongTien", "Tổng tiền");
            DatDinhDang(dgvPhieu, "NgayLap", "dd/MM/yyyy HH:mm");
            DatDinhDang(dgvPhieu, "TongTien", "N0");
            dgvCTPhieu.DataSource = null;
        }

        private void btnTaiPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                LoadLichSuPhieu();
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi tải lịch sử phiếu", ex);
            }
        }

        private void dgvPhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                int maPhieu = Convert.ToInt32(dgvPhieu.Rows[e.RowIndex].Cells["MaPhieu"].Value);
                dgvCTPhieu.DataSource = pkBUS.LayChiTiet(maPhieu);
                DinhDangChiTiet(dgvCTPhieu);
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi tải chi tiết phiếu", ex);
            }
        }

        // =====================================================================
        //  TAB 5: CẢNH BÁO TỒN KHO & BÁO CÁO
        // =====================================================================

        private void LoadCanhBao()
        {
            DataTable dt = vtBUS.CanhBaoTon(nudNguong.Value);
            dgvCanhBao.DataSource = dt;
            DinhDangVatTu(dgvCanhBao);
            lblKQCB.Text = dt.Rows.Count == 0
                ? "Không có vật tư nào dưới ngưỡng."
                : "Có " + dt.Rows.Count + " vật tư dưới ngưỡng an toàn!";
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCanhBao();
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi lọc cảnh báo", ex);
            }
        }

        private void btnTongGiaTri_Click(object sender, EventArgs e)
        {
            try
            {
                decimal tong = vtBUS.TongGiaTriTon();   // ExecuteScalar ở DAL
                lblTongGiaTri.Text = "Tổng giá trị tồn kho: " + Tien(tong) + "  (tính theo đơn giá nhập gần nhất)";
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi tính tổng giá trị tồn", ex);
            }
        }
    }
}
