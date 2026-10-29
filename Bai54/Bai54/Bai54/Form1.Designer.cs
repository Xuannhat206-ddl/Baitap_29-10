namespace Bai54
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPhong = new System.Windows.Forms.TabPage();
            this.tabCheckIn = new System.Windows.Forms.TabPage();
            this.tabDichVu = new System.Windows.Forms.TabPage();
            this.tabCheckOut = new System.Windows.Forms.TabPage();
            this.lblLocLoai = new System.Windows.Forms.Label();
            this.cboLocLoai = new System.Windows.Forms.ComboBox();
            this.lblLocTT = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDonXong = new System.Windows.Forms.Button();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.grpKhach = new System.Windows.Forms.GroupBox();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.btnTraCuu = new System.Windows.Forms.Button();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblTTKhach = new System.Windows.Forms.Label();
            this.grpPhong = new System.Windows.Forms.GroupBox();
            this.lblPhongTrong = new System.Windows.Forms.Label();
            this.cboPhongTrong = new System.Windows.Forms.ComboBox();
            this.lblGiaPhong = new System.Windows.Forms.Label();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.lblDangO = new System.Windows.Forms.Label();
            this.dgvDangO = new System.Windows.Forms.DataGridView();
            this.lblPhongDV = new System.Windows.Forms.Label();
            this.cboPhongDV = new System.Windows.Forms.ComboBox();
            this.lblDV = new System.Windows.Forms.Label();
            this.cboDichVu = new System.Windows.Forms.ComboBox();
            this.lblSL = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.dgvDichVu = new System.Windows.Forms.DataGridView();
            this.lblTongDV = new System.Windows.Forms.Label();
            this.lblPhongCO = new System.Windows.Forms.Label();
            this.cboPhongCO = new System.Windows.Forms.ComboBox();
            this.btnTinhTien = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.txtHoaDon = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPhong.SuspendLayout();
            this.tabCheckIn.SuspendLayout();
            this.tabDichVu.SuspendLayout();
            this.tabCheckOut.SuspendLayout();
            this.grpKhach.SuspendLayout();
            this.grpPhong.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Size = new System.Drawing.Size(1000, 640);
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Controls.Add(this.tabPhong);
            this.tabControl1.Controls.Add(this.tabCheckIn);
            this.tabControl1.Controls.Add(this.tabDichVu);
            this.tabControl1.Controls.Add(this.tabCheckOut);
            // 
            // tabPhong
            // 
            this.tabPhong.UseVisualStyleBackColor = true;
            this.tabPhong.Text = "Danh sách phòng && Lọc";
            this.tabPhong.Name = "tabPhong";
            this.tabPhong.TabIndex = 0;
            this.tabPhong.Controls.Add(this.lblLocLoai);
            this.tabPhong.Controls.Add(this.cboLocLoai);
            this.tabPhong.Controls.Add(this.lblLocTT);
            this.tabPhong.Controls.Add(this.cboLocTrangThai);
            this.tabPhong.Controls.Add(this.btnLamMoi);
            this.tabPhong.Controls.Add(this.btnDonXong);
            this.tabPhong.Controls.Add(this.dgvPhong);
            // 
            // tabCheckIn
            // 
            this.tabCheckIn.UseVisualStyleBackColor = true;
            this.tabCheckIn.Text = "Check-in";
            this.tabCheckIn.Name = "tabCheckIn";
            this.tabCheckIn.TabIndex = 1;
            this.tabCheckIn.Controls.Add(this.grpKhach);
            this.tabCheckIn.Controls.Add(this.grpPhong);
            this.tabCheckIn.Controls.Add(this.lblDangO);
            this.tabCheckIn.Controls.Add(this.dgvDangO);
            // 
            // tabDichVu
            // 
            this.tabDichVu.UseVisualStyleBackColor = true;
            this.tabDichVu.Text = "Gọi dịch vụ";
            this.tabDichVu.Name = "tabDichVu";
            this.tabDichVu.TabIndex = 2;
            this.tabDichVu.Controls.Add(this.lblPhongDV);
            this.tabDichVu.Controls.Add(this.cboPhongDV);
            this.tabDichVu.Controls.Add(this.lblDV);
            this.tabDichVu.Controls.Add(this.cboDichVu);
            this.tabDichVu.Controls.Add(this.lblSL);
            this.tabDichVu.Controls.Add(this.nudSoLuong);
            this.tabDichVu.Controls.Add(this.btnThemDV);
            this.tabDichVu.Controls.Add(this.dgvDichVu);
            this.tabDichVu.Controls.Add(this.lblTongDV);
            // 
            // tabCheckOut
            // 
            this.tabCheckOut.UseVisualStyleBackColor = true;
            this.tabCheckOut.Text = "Check-out && Hóa đơn";
            this.tabCheckOut.Name = "tabCheckOut";
            this.tabCheckOut.TabIndex = 3;
            this.tabCheckOut.Controls.Add(this.lblPhongCO);
            this.tabCheckOut.Controls.Add(this.cboPhongCO);
            this.tabCheckOut.Controls.Add(this.btnTinhTien);
            this.tabCheckOut.Controls.Add(this.btnThanhToan);
            this.tabCheckOut.Controls.Add(this.txtHoaDon);
            // 
            // lblLocLoai
            // 
            this.lblLocLoai.AutoSize = true;
            this.lblLocLoai.Location = new System.Drawing.Point(10, 17);
            this.lblLocLoai.Text = "Loại phòng:";
            this.lblLocLoai.Name = "lblLocLoai";
            this.lblLocLoai.TabIndex = 0;
            // 
            // cboLocLoai
            // 
            this.cboLocLoai.Location = new System.Drawing.Point(95, 13);
            this.cboLocLoai.Size = new System.Drawing.Size(130, 23);
            this.cboLocLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoai.FormattingEnabled = true;
            this.cboLocLoai.Name = "cboLocLoai";
            this.cboLocLoai.TabIndex = 1;
            this.cboLocLoai.SelectedIndexChanged += new System.EventHandler(this.cboLoc_SelectedIndexChanged);
            // 
            // lblLocTT
            // 
            this.lblLocTT.AutoSize = true;
            this.lblLocTT.Location = new System.Drawing.Point(245, 17);
            this.lblLocTT.Text = "Trạng thái:";
            this.lblLocTT.Name = "lblLocTT";
            this.lblLocTT.TabIndex = 2;
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.Location = new System.Drawing.Point(320, 13);
            this.cboLocTrangThai.Size = new System.Drawing.Size(130, 23);
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.FormattingEnabled = true;
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.TabIndex = 3;
            this.cboLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboLoc_SelectedIndexChanged);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(475, 11);
            this.btnLamMoi.Size = new System.Drawing.Size(100, 28);
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnDonXong
            // 
            this.btnDonXong.Location = new System.Drawing.Point(585, 11);
            this.btnDonXong.Size = new System.Drawing.Size(180, 28);
            this.btnDonXong.UseVisualStyleBackColor = true;
            this.btnDonXong.Text = "Dọn xong → Trống";
            this.btnDonXong.Name = "btnDonXong";
            this.btnDonXong.TabIndex = 5;
            this.btnDonXong.Click += new System.EventHandler(this.btnDonXong_Click);
            // 
            // dgvPhong
            // 
            this.dgvPhong.Location = new System.Drawing.Point(10, 50);
            this.dgvPhong.Size = new System.Drawing.Size(965, 540);
            this.dgvPhong.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.AllowUserToDeleteRows = false;
            this.dgvPhong.MultiSelect = false;
            this.dgvPhong.RowHeadersVisible = false;
            this.dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.TabIndex = 6;
            // 
            // grpKhach
            // 
            this.grpKhach.Location = new System.Drawing.Point(10, 10);
            this.grpKhach.Size = new System.Drawing.Size(480, 200);
            this.grpKhach.Text = "Thông tin khách hàng";
            this.grpKhach.Name = "grpKhach";
            this.grpKhach.TabIndex = 0;
            this.grpKhach.Controls.Add(this.lblCCCD);
            this.grpKhach.Controls.Add(this.txtCCCD);
            this.grpKhach.Controls.Add(this.btnTraCuu);
            this.grpKhach.Controls.Add(this.lblHoTen);
            this.grpKhach.Controls.Add(this.txtHoTen);
            this.grpKhach.Controls.Add(this.lblSDT);
            this.grpKhach.Controls.Add(this.txtSDT);
            this.grpKhach.Controls.Add(this.lblTTKhach);
            // 
            // lblCCCD
            // 
            this.lblCCCD.AutoSize = true;
            this.lblCCCD.Location = new System.Drawing.Point(15, 33);
            this.lblCCCD.Text = "CCCD:";
            this.lblCCCD.Name = "lblCCCD";
            this.lblCCCD.TabIndex = 0;
            // 
            // txtCCCD
            // 
            this.txtCCCD.Location = new System.Drawing.Point(120, 30);
            this.txtCCCD.Size = new System.Drawing.Size(220, 23);
            this.txtCCCD.MaxLength = 20;
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.TabIndex = 1;
            this.txtCCCD.TextChanged += new System.EventHandler(this.txtCCCD_TextChanged);
            // 
            // btnTraCuu
            // 
            this.btnTraCuu.Location = new System.Drawing.Point(350, 28);
            this.btnTraCuu.Size = new System.Drawing.Size(110, 28);
            this.btnTraCuu.UseVisualStyleBackColor = true;
            this.btnTraCuu.Text = "Tra cứu";
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.TabIndex = 2;
            this.btnTraCuu.Click += new System.EventHandler(this.btnTraCuu_Click);
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(15, 73);
            this.lblHoTen.Text = "Họ tên:";
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.TabIndex = 3;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(120, 70);
            this.txtHoTen.Size = new System.Drawing.Size(340, 23);
            this.txtHoTen.MaxLength = 100;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.TabIndex = 4;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(15, 113);
            this.lblSDT.Text = "Số điện thoại:";
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.TabIndex = 5;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(120, 110);
            this.txtSDT.Size = new System.Drawing.Size(340, 23);
            this.txtSDT.MaxLength = 15;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.TabIndex = 6;
            // 
            // lblTTKhach
            // 
            this.lblTTKhach.AutoSize = true;
            this.lblTTKhach.Location = new System.Drawing.Point(15, 155);
            this.lblTTKhach.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTTKhach.Text = "Nhập CCCD rồi bấm Tra cứu.";
            this.lblTTKhach.Name = "lblTTKhach";
            this.lblTTKhach.TabIndex = 7;
            // 
            // grpPhong
            // 
            this.grpPhong.Location = new System.Drawing.Point(500, 10);
            this.grpPhong.Size = new System.Drawing.Size(475, 200);
            this.grpPhong.Text = "Chọn phòng";
            this.grpPhong.Name = "grpPhong";
            this.grpPhong.TabIndex = 1;
            this.grpPhong.Controls.Add(this.lblPhongTrong);
            this.grpPhong.Controls.Add(this.cboPhongTrong);
            this.grpPhong.Controls.Add(this.lblGiaPhong);
            this.grpPhong.Controls.Add(this.btnCheckIn);
            // 
            // lblPhongTrong
            // 
            this.lblPhongTrong.AutoSize = true;
            this.lblPhongTrong.Location = new System.Drawing.Point(15, 33);
            this.lblPhongTrong.Text = "Phòng trống:";
            this.lblPhongTrong.Name = "lblPhongTrong";
            this.lblPhongTrong.TabIndex = 0;
            // 
            // cboPhongTrong
            // 
            this.cboPhongTrong.Location = new System.Drawing.Point(110, 30);
            this.cboPhongTrong.Size = new System.Drawing.Size(340, 23);
            this.cboPhongTrong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhongTrong.FormattingEnabled = true;
            this.cboPhongTrong.Name = "cboPhongTrong";
            this.cboPhongTrong.TabIndex = 1;
            this.cboPhongTrong.SelectedIndexChanged += new System.EventHandler(this.cboPhongTrong_SelectedIndexChanged);
            // 
            // lblGiaPhong
            // 
            this.lblGiaPhong.AutoSize = true;
            this.lblGiaPhong.Location = new System.Drawing.Point(15, 73);
            this.lblGiaPhong.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblGiaPhong.Text = "";
            this.lblGiaPhong.Name = "lblGiaPhong";
            this.lblGiaPhong.TabIndex = 2;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(110, 125);
            this.btnCheckIn.Size = new System.Drawing.Size(240, 45);
            this.btnCheckIn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Text = "CHECK-IN (Nhận phòng)";
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.TabIndex = 3;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // lblDangO
            // 
            this.lblDangO.AutoSize = true;
            this.lblDangO.Location = new System.Drawing.Point(10, 222);
            this.lblDangO.Text = "Các phòng đang có khách (phiếu chưa trả phòng):";
            this.lblDangO.Name = "lblDangO";
            this.lblDangO.TabIndex = 2;
            // 
            // dgvDangO
            // 
            this.dgvDangO.Location = new System.Drawing.Point(10, 245);
            this.dgvDangO.Size = new System.Drawing.Size(965, 345);
            this.dgvDangO.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvDangO.ReadOnly = true;
            this.dgvDangO.AllowUserToAddRows = false;
            this.dgvDangO.AllowUserToDeleteRows = false;
            this.dgvDangO.MultiSelect = false;
            this.dgvDangO.RowHeadersVisible = false;
            this.dgvDangO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDangO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDangO.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDangO.Name = "dgvDangO";
            this.dgvDangO.TabIndex = 3;
            // 
            // lblPhongDV
            // 
            this.lblPhongDV.AutoSize = true;
            this.lblPhongDV.Location = new System.Drawing.Point(10, 17);
            this.lblPhongDV.Text = "Phòng đang ở:";
            this.lblPhongDV.Name = "lblPhongDV";
            this.lblPhongDV.TabIndex = 0;
            // 
            // cboPhongDV
            // 
            this.cboPhongDV.Location = new System.Drawing.Point(105, 13);
            this.cboPhongDV.Size = new System.Drawing.Size(100, 23);
            this.cboPhongDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhongDV.FormattingEnabled = true;
            this.cboPhongDV.Name = "cboPhongDV";
            this.cboPhongDV.TabIndex = 1;
            this.cboPhongDV.SelectedIndexChanged += new System.EventHandler(this.cboPhongDV_SelectedIndexChanged);
            // 
            // lblDV
            // 
            this.lblDV.AutoSize = true;
            this.lblDV.Location = new System.Drawing.Point(225, 17);
            this.lblDV.Text = "Dịch vụ:";
            this.lblDV.Name = "lblDV";
            this.lblDV.TabIndex = 2;
            // 
            // cboDichVu
            // 
            this.cboDichVu.Location = new System.Drawing.Point(285, 13);
            this.cboDichVu.Size = new System.Drawing.Size(260, 23);
            this.cboDichVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDichVu.FormattingEnabled = true;
            this.cboDichVu.Name = "cboDichVu";
            this.cboDichVu.TabIndex = 3;
            // 
            // lblSL
            // 
            this.lblSL.AutoSize = true;
            this.lblSL.Location = new System.Drawing.Point(565, 17);
            this.lblSL.Text = "Số lượng:";
            this.lblSL.Name = "lblSL";
            this.lblSL.TabIndex = 4;
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(630, 14);
            this.nudSoLuong.Size = new System.Drawing.Size(60, 23);
            this.nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuong.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.TabIndex = 5;
            // 
            // btnThemDV
            // 
            this.btnThemDV.Location = new System.Drawing.Point(710, 11);
            this.btnThemDV.Size = new System.Drawing.Size(140, 28);
            this.btnThemDV.UseVisualStyleBackColor = true;
            this.btnThemDV.Text = "Thêm dịch vụ";
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.TabIndex = 6;
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            // 
            // dgvDichVu
            // 
            this.dgvDichVu.Location = new System.Drawing.Point(10, 50);
            this.dgvDichVu.Size = new System.Drawing.Size(965, 490);
            this.dgvDichVu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvDichVu.ReadOnly = true;
            this.dgvDichVu.AllowUserToAddRows = false;
            this.dgvDichVu.AllowUserToDeleteRows = false;
            this.dgvDichVu.MultiSelect = false;
            this.dgvDichVu.RowHeadersVisible = false;
            this.dgvDichVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDichVu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDichVu.Name = "dgvDichVu";
            this.dgvDichVu.TabIndex = 7;
            // 
            // lblTongDV
            // 
            this.lblTongDV.AutoSize = true;
            this.lblTongDV.Location = new System.Drawing.Point(10, 555);
            this.lblTongDV.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.lblTongDV.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTongDV.Text = "Tổng tiền dịch vụ: 0 VNĐ";
            this.lblTongDV.Name = "lblTongDV";
            this.lblTongDV.TabIndex = 8;
            // 
            // lblPhongCO
            // 
            this.lblPhongCO.AutoSize = true;
            this.lblPhongCO.Location = new System.Drawing.Point(10, 17);
            this.lblPhongCO.Text = "Phòng:";
            this.lblPhongCO.Name = "lblPhongCO";
            this.lblPhongCO.TabIndex = 0;
            // 
            // cboPhongCO
            // 
            this.cboPhongCO.Location = new System.Drawing.Point(65, 13);
            this.cboPhongCO.Size = new System.Drawing.Size(110, 23);
            this.cboPhongCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhongCO.FormattingEnabled = true;
            this.cboPhongCO.Name = "cboPhongCO";
            this.cboPhongCO.TabIndex = 1;
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.Location = new System.Drawing.Point(195, 11);
            this.btnTinhTien.Size = new System.Drawing.Size(120, 28);
            this.btnTinhTien.UseVisualStyleBackColor = true;
            this.btnTinhTien.Text = "Tính tiền";
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.TabIndex = 2;
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(325, 11);
            this.btnThanhToan.Size = new System.Drawing.Size(190, 28);
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Text = "Xác nhận thanh toán";
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.TabIndex = 3;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // txtHoaDon
            // 
            this.txtHoaDon.Location = new System.Drawing.Point(10, 50);
            this.txtHoaDon.Size = new System.Drawing.Size(965, 540);
            this.txtHoaDon.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtHoaDon.Multiline = true;
            this.txtHoaDon.ReadOnly = true;
            this.txtHoaDon.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHoaDon.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtHoaDon.Name = "txtHoaDon";
            this.txtHoaDon.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 54 - Hệ thống quản lý tiện ích dịch vụ & khách sạn";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpPhong.ResumeLayout(false);
            this.grpKhach.ResumeLayout(false);
            this.tabCheckOut.ResumeLayout(false);
            this.tabDichVu.ResumeLayout(false);
            this.tabCheckIn.ResumeLayout(false);
            this.tabPhong.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPhong;
        private System.Windows.Forms.TabPage tabCheckIn;
        private System.Windows.Forms.TabPage tabDichVu;
        private System.Windows.Forms.TabPage tabCheckOut;
        private System.Windows.Forms.Label lblLocLoai;
        private System.Windows.Forms.ComboBox cboLocLoai;
        private System.Windows.Forms.Label lblLocTT;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnDonXong;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.GroupBox grpKhach;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Button btnTraCuu;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblTTKhach;
        private System.Windows.Forms.GroupBox grpPhong;
        private System.Windows.Forms.Label lblPhongTrong;
        private System.Windows.Forms.ComboBox cboPhongTrong;
        private System.Windows.Forms.Label lblGiaPhong;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Label lblDangO;
        private System.Windows.Forms.DataGridView dgvDangO;
        private System.Windows.Forms.Label lblPhongDV;
        private System.Windows.Forms.ComboBox cboPhongDV;
        private System.Windows.Forms.Label lblDV;
        private System.Windows.Forms.ComboBox cboDichVu;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.DataGridView dgvDichVu;
        private System.Windows.Forms.Label lblTongDV;
        private System.Windows.Forms.Label lblPhongCO;
        private System.Windows.Forms.ComboBox cboPhongCO;
        private System.Windows.Forms.Button btnTinhTien;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.TextBox txtHoaDon;
    }
}
