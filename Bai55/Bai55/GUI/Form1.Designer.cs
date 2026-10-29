namespace Bai55.GUI
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
            this.tabNCC = new System.Windows.Forms.TabPage();
            this.tabVatTu = new System.Windows.Forms.TabPage();
            this.tabPhieu = new System.Windows.Forms.TabPage();
            this.tabLichSu = new System.Windows.Forms.TabPage();
            this.tabBaoCao = new System.Windows.Forms.TabPage();
            this.lblTimNCC = new System.Windows.Forms.Label();
            this.txtTimNCC = new System.Windows.Forms.TextBox();
            this.btnTimNCC = new System.Windows.Forms.Button();
            this.btnTatCaNCC = new System.Windows.Forms.Button();
            this.dgvNCC = new System.Windows.Forms.DataGridView();
            this.grpNCC = new System.Windows.Forms.GroupBox();
            this.lblMaNCC = new System.Windows.Forms.Label();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.lblTenNCC = new System.Windows.Forms.Label();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.lblDTNCC = new System.Windows.Forms.Label();
            this.txtDTNCC = new System.Windows.Forms.TextBox();
            this.lblDCNCC = new System.Windows.Forms.Label();
            this.txtDCNCC = new System.Windows.Forms.TextBox();
            this.btnThemNCC = new System.Windows.Forms.Button();
            this.btnSuaNCC = new System.Windows.Forms.Button();
            this.btnXoaNCC = new System.Windows.Forms.Button();
            this.btnMoiNCC = new System.Windows.Forms.Button();
            this.lblTimVT = new System.Windows.Forms.Label();
            this.txtTimVT = new System.Windows.Forms.TextBox();
            this.btnTimVT = new System.Windows.Forms.Button();
            this.btnTatCaVT = new System.Windows.Forms.Button();
            this.dgvVatTu = new System.Windows.Forms.DataGridView();
            this.grpVT = new System.Windows.Forms.GroupBox();
            this.lblMaVT = new System.Windows.Forms.Label();
            this.txtMaVT = new System.Windows.Forms.TextBox();
            this.lblTenVT = new System.Windows.Forms.Label();
            this.txtTenVT = new System.Windows.Forms.TextBox();
            this.lblDVT = new System.Windows.Forms.Label();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.lblTon = new System.Windows.Forms.Label();
            this.nudTon = new System.Windows.Forms.NumericUpDown();
            this.lblGhiChuTon = new System.Windows.Forms.Label();
            this.btnThemVT = new System.Windows.Forms.Button();
            this.btnSuaVT = new System.Windows.Forms.Button();
            this.btnXoaVT = new System.Windows.Forms.Button();
            this.btnMoiVT = new System.Windows.Forms.Button();
            this.lblLoaiPhieu = new System.Windows.Forms.Label();
            this.cboLoaiPhieu = new System.Windows.Forms.ComboBox();
            this.lblNCC = new System.Windows.Forms.Label();
            this.cboNCC = new System.Windows.Forms.ComboBox();
            this.grpThem = new System.Windows.Forms.GroupBox();
            this.lblVT = new System.Windows.Forms.Label();
            this.cboVatTu = new System.Windows.Forms.ComboBox();
            this.lblSL = new System.Windows.Forms.Label();
            this.nudSL = new System.Windows.Forms.NumericUpDown();
            this.lblDG = new System.Windows.Forms.Label();
            this.nudDG = new System.Windows.Forms.NumericUpDown();
            this.btnThemCT = new System.Windows.Forms.Button();
            this.btnXoaCT = new System.Windows.Forms.Button();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.lblTongPhieu = new System.Windows.Forms.Label();
            this.btnLuuPhieu = new System.Windows.Forms.Button();
            this.btnHuyPhieu = new System.Windows.Forms.Button();
            this.btnTaiPhieu = new System.Windows.Forms.Button();
            this.lblGoiYLS = new System.Windows.Forms.Label();
            this.dgvPhieu = new System.Windows.Forms.DataGridView();
            this.lblCTPhieu = new System.Windows.Forms.Label();
            this.dgvCTPhieu = new System.Windows.Forms.DataGridView();
            this.lblNguong = new System.Windows.Forms.Label();
            this.nudNguong = new System.Windows.Forms.NumericUpDown();
            this.btnLoc = new System.Windows.Forms.Button();
            this.lblKQCB = new System.Windows.Forms.Label();
            this.dgvCanhBao = new System.Windows.Forms.DataGridView();
            this.btnTongGiaTri = new System.Windows.Forms.Button();
            this.lblTongGiaTri = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabNCC.SuspendLayout();
            this.tabVatTu.SuspendLayout();
            this.tabPhieu.SuspendLayout();
            this.tabLichSu.SuspendLayout();
            this.tabBaoCao.SuspendLayout();
            this.grpNCC.SuspendLayout();
            this.grpVT.SuspendLayout();
            this.grpThem.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Size = new System.Drawing.Size(1100, 680);
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Controls.Add(this.tabNCC);
            this.tabControl1.Controls.Add(this.tabVatTu);
            this.tabControl1.Controls.Add(this.tabPhieu);
            this.tabControl1.Controls.Add(this.tabLichSu);
            this.tabControl1.Controls.Add(this.tabBaoCao);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabNCC
            // 
            this.tabNCC.UseVisualStyleBackColor = true;
            this.tabNCC.Text = "Nhà cung cấp";
            this.tabNCC.Name = "tabNCC";
            this.tabNCC.TabIndex = 0;
            this.tabNCC.Controls.Add(this.lblTimNCC);
            this.tabNCC.Controls.Add(this.txtTimNCC);
            this.tabNCC.Controls.Add(this.btnTimNCC);
            this.tabNCC.Controls.Add(this.btnTatCaNCC);
            this.tabNCC.Controls.Add(this.dgvNCC);
            this.tabNCC.Controls.Add(this.grpNCC);
            // 
            // tabVatTu
            // 
            this.tabVatTu.UseVisualStyleBackColor = true;
            this.tabVatTu.Text = "Vật tư";
            this.tabVatTu.Name = "tabVatTu";
            this.tabVatTu.TabIndex = 1;
            this.tabVatTu.Controls.Add(this.lblTimVT);
            this.tabVatTu.Controls.Add(this.txtTimVT);
            this.tabVatTu.Controls.Add(this.btnTimVT);
            this.tabVatTu.Controls.Add(this.btnTatCaVT);
            this.tabVatTu.Controls.Add(this.dgvVatTu);
            this.tabVatTu.Controls.Add(this.grpVT);
            // 
            // tabPhieu
            // 
            this.tabPhieu.UseVisualStyleBackColor = true;
            this.tabPhieu.Text = "Lập phiếu nhập / xuất";
            this.tabPhieu.Name = "tabPhieu";
            this.tabPhieu.TabIndex = 2;
            this.tabPhieu.Controls.Add(this.lblLoaiPhieu);
            this.tabPhieu.Controls.Add(this.cboLoaiPhieu);
            this.tabPhieu.Controls.Add(this.lblNCC);
            this.tabPhieu.Controls.Add(this.cboNCC);
            this.tabPhieu.Controls.Add(this.grpThem);
            this.tabPhieu.Controls.Add(this.dgvChiTiet);
            this.tabPhieu.Controls.Add(this.lblTongPhieu);
            this.tabPhieu.Controls.Add(this.btnLuuPhieu);
            this.tabPhieu.Controls.Add(this.btnHuyPhieu);
            // 
            // tabLichSu
            // 
            this.tabLichSu.UseVisualStyleBackColor = true;
            this.tabLichSu.Text = "Lịch sử phiếu";
            this.tabLichSu.Name = "tabLichSu";
            this.tabLichSu.TabIndex = 3;
            this.tabLichSu.Controls.Add(this.btnTaiPhieu);
            this.tabLichSu.Controls.Add(this.lblGoiYLS);
            this.tabLichSu.Controls.Add(this.dgvPhieu);
            this.tabLichSu.Controls.Add(this.lblCTPhieu);
            this.tabLichSu.Controls.Add(this.dgvCTPhieu);
            // 
            // tabBaoCao
            // 
            this.tabBaoCao.UseVisualStyleBackColor = true;
            this.tabBaoCao.Text = "Cảnh báo tồn kho && Báo cáo";
            this.tabBaoCao.Name = "tabBaoCao";
            this.tabBaoCao.TabIndex = 4;
            this.tabBaoCao.Controls.Add(this.lblNguong);
            this.tabBaoCao.Controls.Add(this.nudNguong);
            this.tabBaoCao.Controls.Add(this.btnLoc);
            this.tabBaoCao.Controls.Add(this.lblKQCB);
            this.tabBaoCao.Controls.Add(this.dgvCanhBao);
            this.tabBaoCao.Controls.Add(this.btnTongGiaTri);
            this.tabBaoCao.Controls.Add(this.lblTongGiaTri);
            // 
            // lblTimNCC
            // 
            this.lblTimNCC.AutoSize = true;
            this.lblTimNCC.Location = new System.Drawing.Point(10, 17);
            this.lblTimNCC.Text = "Tìm (tên / SĐT / địa chỉ):";
            this.lblTimNCC.Name = "lblTimNCC";
            this.lblTimNCC.TabIndex = 0;
            // 
            // txtTimNCC
            // 
            this.txtTimNCC.Location = new System.Drawing.Point(170, 13);
            this.txtTimNCC.Size = new System.Drawing.Size(250, 23);
            this.txtTimNCC.Name = "txtTimNCC";
            this.txtTimNCC.TabIndex = 1;
            // 
            // btnTimNCC
            // 
            this.btnTimNCC.Location = new System.Drawing.Point(430, 11);
            this.btnTimNCC.Size = new System.Drawing.Size(90, 28);
            this.btnTimNCC.UseVisualStyleBackColor = true;
            this.btnTimNCC.Text = "Tìm";
            this.btnTimNCC.Name = "btnTimNCC";
            this.btnTimNCC.TabIndex = 2;
            this.btnTimNCC.Click += new System.EventHandler(this.btnTimNCC_Click);
            // 
            // btnTatCaNCC
            // 
            this.btnTatCaNCC.Location = new System.Drawing.Point(530, 11);
            this.btnTatCaNCC.Size = new System.Drawing.Size(110, 28);
            this.btnTatCaNCC.UseVisualStyleBackColor = true;
            this.btnTatCaNCC.Text = "Hiện tất cả";
            this.btnTatCaNCC.Name = "btnTatCaNCC";
            this.btnTatCaNCC.TabIndex = 3;
            this.btnTatCaNCC.Click += new System.EventHandler(this.btnTatCaNCC_Click);
            // 
            // dgvNCC
            // 
            this.dgvNCC.Location = new System.Drawing.Point(10, 50);
            this.dgvNCC.Size = new System.Drawing.Size(620, 575);
            this.dgvNCC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.dgvNCC.ReadOnly = true;
            this.dgvNCC.AllowUserToAddRows = false;
            this.dgvNCC.AllowUserToDeleteRows = false;
            this.dgvNCC.MultiSelect = false;
            this.dgvNCC.RowHeadersVisible = false;
            this.dgvNCC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNCC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNCC.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvNCC.Name = "dgvNCC";
            this.dgvNCC.TabIndex = 4;
            this.dgvNCC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNCC_CellClick);
            // 
            // grpNCC
            // 
            this.grpNCC.Location = new System.Drawing.Point(645, 50);
            this.grpNCC.Size = new System.Drawing.Size(430, 260);
            this.grpNCC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.grpNCC.Text = "Thông tin nhà cung cấp";
            this.grpNCC.Name = "grpNCC";
            this.grpNCC.TabIndex = 5;
            this.grpNCC.Controls.Add(this.lblMaNCC);
            this.grpNCC.Controls.Add(this.txtMaNCC);
            this.grpNCC.Controls.Add(this.lblTenNCC);
            this.grpNCC.Controls.Add(this.txtTenNCC);
            this.grpNCC.Controls.Add(this.lblDTNCC);
            this.grpNCC.Controls.Add(this.txtDTNCC);
            this.grpNCC.Controls.Add(this.lblDCNCC);
            this.grpNCC.Controls.Add(this.txtDCNCC);
            this.grpNCC.Controls.Add(this.btnThemNCC);
            this.grpNCC.Controls.Add(this.btnSuaNCC);
            this.grpNCC.Controls.Add(this.btnXoaNCC);
            this.grpNCC.Controls.Add(this.btnMoiNCC);
            // 
            // lblMaNCC
            // 
            this.lblMaNCC.AutoSize = true;
            this.lblMaNCC.Location = new System.Drawing.Point(15, 33);
            this.lblMaNCC.Text = "Mã NCC:";
            this.lblMaNCC.Name = "lblMaNCC";
            this.lblMaNCC.TabIndex = 0;
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Location = new System.Drawing.Point(110, 30);
            this.txtMaNCC.Size = new System.Drawing.Size(120, 23);
            this.txtMaNCC.ReadOnly = true;
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.TabIndex = 1;
            // 
            // lblTenNCC
            // 
            this.lblTenNCC.AutoSize = true;
            this.lblTenNCC.Location = new System.Drawing.Point(15, 73);
            this.lblTenNCC.Text = "Tên NCC:";
            this.lblTenNCC.Name = "lblTenNCC";
            this.lblTenNCC.TabIndex = 2;
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(110, 70);
            this.txtTenNCC.Size = new System.Drawing.Size(300, 23);
            this.txtTenNCC.MaxLength = 150;
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.TabIndex = 3;
            // 
            // lblDTNCC
            // 
            this.lblDTNCC.AutoSize = true;
            this.lblDTNCC.Location = new System.Drawing.Point(15, 113);
            this.lblDTNCC.Text = "Điện thoại:";
            this.lblDTNCC.Name = "lblDTNCC";
            this.lblDTNCC.TabIndex = 4;
            // 
            // txtDTNCC
            // 
            this.txtDTNCC.Location = new System.Drawing.Point(110, 110);
            this.txtDTNCC.Size = new System.Drawing.Size(300, 23);
            this.txtDTNCC.MaxLength = 15;
            this.txtDTNCC.Name = "txtDTNCC";
            this.txtDTNCC.TabIndex = 5;
            // 
            // lblDCNCC
            // 
            this.lblDCNCC.AutoSize = true;
            this.lblDCNCC.Location = new System.Drawing.Point(15, 153);
            this.lblDCNCC.Text = "Địa chỉ:";
            this.lblDCNCC.Name = "lblDCNCC";
            this.lblDCNCC.TabIndex = 6;
            // 
            // txtDCNCC
            // 
            this.txtDCNCC.Location = new System.Drawing.Point(110, 150);
            this.txtDCNCC.Size = new System.Drawing.Size(300, 23);
            this.txtDCNCC.MaxLength = 255;
            this.txtDCNCC.Name = "txtDCNCC";
            this.txtDCNCC.TabIndex = 7;
            // 
            // btnThemNCC
            // 
            this.btnThemNCC.Location = new System.Drawing.Point(15, 205);
            this.btnThemNCC.Size = new System.Drawing.Size(90, 32);
            this.btnThemNCC.UseVisualStyleBackColor = true;
            this.btnThemNCC.Text = "Thêm";
            this.btnThemNCC.Name = "btnThemNCC";
            this.btnThemNCC.TabIndex = 8;
            this.btnThemNCC.Click += new System.EventHandler(this.btnThemNCC_Click);
            // 
            // btnSuaNCC
            // 
            this.btnSuaNCC.Location = new System.Drawing.Point(115, 205);
            this.btnSuaNCC.Size = new System.Drawing.Size(90, 32);
            this.btnSuaNCC.UseVisualStyleBackColor = true;
            this.btnSuaNCC.Text = "Sửa";
            this.btnSuaNCC.Name = "btnSuaNCC";
            this.btnSuaNCC.TabIndex = 9;
            this.btnSuaNCC.Click += new System.EventHandler(this.btnSuaNCC_Click);
            // 
            // btnXoaNCC
            // 
            this.btnXoaNCC.Location = new System.Drawing.Point(215, 205);
            this.btnXoaNCC.Size = new System.Drawing.Size(90, 32);
            this.btnXoaNCC.UseVisualStyleBackColor = true;
            this.btnXoaNCC.Text = "Xóa";
            this.btnXoaNCC.Name = "btnXoaNCC";
            this.btnXoaNCC.TabIndex = 10;
            this.btnXoaNCC.Click += new System.EventHandler(this.btnXoaNCC_Click);
            // 
            // btnMoiNCC
            // 
            this.btnMoiNCC.Location = new System.Drawing.Point(315, 205);
            this.btnMoiNCC.Size = new System.Drawing.Size(100, 32);
            this.btnMoiNCC.UseVisualStyleBackColor = true;
            this.btnMoiNCC.Text = "Nhập mới";
            this.btnMoiNCC.Name = "btnMoiNCC";
            this.btnMoiNCC.TabIndex = 11;
            this.btnMoiNCC.Click += new System.EventHandler(this.btnMoiNCC_Click);
            // 
            // lblTimVT
            // 
            this.lblTimVT.AutoSize = true;
            this.lblTimVT.Location = new System.Drawing.Point(10, 17);
            this.lblTimVT.Text = "Tìm (mã hoặc tên vật tư):";
            this.lblTimVT.Name = "lblTimVT";
            this.lblTimVT.TabIndex = 0;
            // 
            // txtTimVT
            // 
            this.txtTimVT.Location = new System.Drawing.Point(170, 13);
            this.txtTimVT.Size = new System.Drawing.Size(250, 23);
            this.txtTimVT.Name = "txtTimVT";
            this.txtTimVT.TabIndex = 1;
            // 
            // btnTimVT
            // 
            this.btnTimVT.Location = new System.Drawing.Point(430, 11);
            this.btnTimVT.Size = new System.Drawing.Size(90, 28);
            this.btnTimVT.UseVisualStyleBackColor = true;
            this.btnTimVT.Text = "Tìm";
            this.btnTimVT.Name = "btnTimVT";
            this.btnTimVT.TabIndex = 2;
            this.btnTimVT.Click += new System.EventHandler(this.btnTimVT_Click);
            // 
            // btnTatCaVT
            // 
            this.btnTatCaVT.Location = new System.Drawing.Point(530, 11);
            this.btnTatCaVT.Size = new System.Drawing.Size(110, 28);
            this.btnTatCaVT.UseVisualStyleBackColor = true;
            this.btnTatCaVT.Text = "Hiện tất cả";
            this.btnTatCaVT.Name = "btnTatCaVT";
            this.btnTatCaVT.TabIndex = 3;
            this.btnTatCaVT.Click += new System.EventHandler(this.btnTatCaVT_Click);
            // 
            // dgvVatTu
            // 
            this.dgvVatTu.Location = new System.Drawing.Point(10, 50);
            this.dgvVatTu.Size = new System.Drawing.Size(620, 575);
            this.dgvVatTu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.dgvVatTu.ReadOnly = true;
            this.dgvVatTu.AllowUserToAddRows = false;
            this.dgvVatTu.AllowUserToDeleteRows = false;
            this.dgvVatTu.MultiSelect = false;
            this.dgvVatTu.RowHeadersVisible = false;
            this.dgvVatTu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVatTu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVatTu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvVatTu.Name = "dgvVatTu";
            this.dgvVatTu.TabIndex = 4;
            this.dgvVatTu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVatTu_CellClick);
            // 
            // grpVT
            // 
            this.grpVT.Location = new System.Drawing.Point(645, 50);
            this.grpVT.Size = new System.Drawing.Size(430, 300);
            this.grpVT.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.grpVT.Text = "Thông tin vật tư";
            this.grpVT.Name = "grpVT";
            this.grpVT.TabIndex = 5;
            this.grpVT.Controls.Add(this.lblMaVT);
            this.grpVT.Controls.Add(this.txtMaVT);
            this.grpVT.Controls.Add(this.lblTenVT);
            this.grpVT.Controls.Add(this.txtTenVT);
            this.grpVT.Controls.Add(this.lblDVT);
            this.grpVT.Controls.Add(this.txtDVT);
            this.grpVT.Controls.Add(this.lblTon);
            this.grpVT.Controls.Add(this.nudTon);
            this.grpVT.Controls.Add(this.lblGhiChuTon);
            this.grpVT.Controls.Add(this.btnThemVT);
            this.grpVT.Controls.Add(this.btnSuaVT);
            this.grpVT.Controls.Add(this.btnXoaVT);
            this.grpVT.Controls.Add(this.btnMoiVT);
            // 
            // lblMaVT
            // 
            this.lblMaVT.AutoSize = true;
            this.lblMaVT.Location = new System.Drawing.Point(15, 33);
            this.lblMaVT.Text = "Mã vật tư:";
            this.lblMaVT.Name = "lblMaVT";
            this.lblMaVT.TabIndex = 0;
            // 
            // txtMaVT
            // 
            this.txtMaVT.Location = new System.Drawing.Point(110, 30);
            this.txtMaVT.Size = new System.Drawing.Size(150, 23);
            this.txtMaVT.MaxLength = 20;
            this.txtMaVT.Name = "txtMaVT";
            this.txtMaVT.TabIndex = 1;
            // 
            // lblTenVT
            // 
            this.lblTenVT.AutoSize = true;
            this.lblTenVT.Location = new System.Drawing.Point(15, 73);
            this.lblTenVT.Text = "Tên vật tư:";
            this.lblTenVT.Name = "lblTenVT";
            this.lblTenVT.TabIndex = 2;
            // 
            // txtTenVT
            // 
            this.txtTenVT.Location = new System.Drawing.Point(110, 70);
            this.txtTenVT.Size = new System.Drawing.Size(300, 23);
            this.txtTenVT.MaxLength = 150;
            this.txtTenVT.Name = "txtTenVT";
            this.txtTenVT.TabIndex = 3;
            // 
            // lblDVT
            // 
            this.lblDVT.AutoSize = true;
            this.lblDVT.Location = new System.Drawing.Point(15, 113);
            this.lblDVT.Text = "Đơn vị tính:";
            this.lblDVT.Name = "lblDVT";
            this.lblDVT.TabIndex = 4;
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(110, 110);
            this.txtDVT.Size = new System.Drawing.Size(120, 23);
            this.txtDVT.MaxLength = 20;
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.TabIndex = 5;
            // 
            // lblTon
            // 
            this.lblTon.AutoSize = true;
            this.lblTon.Location = new System.Drawing.Point(15, 153);
            this.lblTon.Text = "Số lượng tồn:";
            this.lblTon.Name = "lblTon";
            this.lblTon.TabIndex = 6;
            // 
            // nudTon
            // 
            this.nudTon.Location = new System.Drawing.Point(110, 150);
            this.nudTon.Size = new System.Drawing.Size(120, 23);
            this.nudTon.DecimalPlaces = 2;
            this.nudTon.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.nudTon.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.nudTon.Value = new decimal(new int[] { 0, 0, 0, 0 });
            this.nudTon.ThousandsSeparator = true;
            this.nudTon.Name = "nudTon";
            this.nudTon.TabIndex = 7;
            // 
            // lblGhiChuTon
            // 
            this.lblGhiChuTon.Location = new System.Drawing.Point(15, 185);
            this.lblGhiChuTon.Size = new System.Drawing.Size(400, 36);
            this.lblGhiChuTon.ForeColor = System.Drawing.Color.DimGray;
            this.lblGhiChuTon.Text = "Tồn kho chỉ nhập khi thêm mới. Sau đó tồn kho thay đổi qua phiếu nhập / xuất (nút Sửa không đổi tồn).";
            this.lblGhiChuTon.Name = "lblGhiChuTon";
            this.lblGhiChuTon.TabIndex = 8;
            // 
            // btnThemVT
            // 
            this.btnThemVT.Location = new System.Drawing.Point(15, 245);
            this.btnThemVT.Size = new System.Drawing.Size(90, 32);
            this.btnThemVT.UseVisualStyleBackColor = true;
            this.btnThemVT.Text = "Thêm";
            this.btnThemVT.Name = "btnThemVT";
            this.btnThemVT.TabIndex = 9;
            this.btnThemVT.Click += new System.EventHandler(this.btnThemVT_Click);
            // 
            // btnSuaVT
            // 
            this.btnSuaVT.Location = new System.Drawing.Point(115, 245);
            this.btnSuaVT.Size = new System.Drawing.Size(90, 32);
            this.btnSuaVT.UseVisualStyleBackColor = true;
            this.btnSuaVT.Text = "Sửa";
            this.btnSuaVT.Name = "btnSuaVT";
            this.btnSuaVT.TabIndex = 10;
            this.btnSuaVT.Click += new System.EventHandler(this.btnSuaVT_Click);
            // 
            // btnXoaVT
            // 
            this.btnXoaVT.Location = new System.Drawing.Point(215, 245);
            this.btnXoaVT.Size = new System.Drawing.Size(90, 32);
            this.btnXoaVT.UseVisualStyleBackColor = true;
            this.btnXoaVT.Text = "Xóa";
            this.btnXoaVT.Name = "btnXoaVT";
            this.btnXoaVT.TabIndex = 11;
            this.btnXoaVT.Click += new System.EventHandler(this.btnXoaVT_Click);
            // 
            // btnMoiVT
            // 
            this.btnMoiVT.Location = new System.Drawing.Point(315, 245);
            this.btnMoiVT.Size = new System.Drawing.Size(100, 32);
            this.btnMoiVT.UseVisualStyleBackColor = true;
            this.btnMoiVT.Text = "Nhập mới";
            this.btnMoiVT.Name = "btnMoiVT";
            this.btnMoiVT.TabIndex = 12;
            this.btnMoiVT.Click += new System.EventHandler(this.btnMoiVT_Click);
            // 
            // lblLoaiPhieu
            // 
            this.lblLoaiPhieu.AutoSize = true;
            this.lblLoaiPhieu.Location = new System.Drawing.Point(10, 17);
            this.lblLoaiPhieu.Text = "Loại phiếu:";
            this.lblLoaiPhieu.Name = "lblLoaiPhieu";
            this.lblLoaiPhieu.TabIndex = 0;
            // 
            // cboLoaiPhieu
            // 
            this.cboLoaiPhieu.Location = new System.Drawing.Point(90, 13);
            this.cboLoaiPhieu.Size = new System.Drawing.Size(190, 23);
            this.cboLoaiPhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiPhieu.FormattingEnabled = true;
            this.cboLoaiPhieu.Name = "cboLoaiPhieu";
            this.cboLoaiPhieu.TabIndex = 1;
            this.cboLoaiPhieu.SelectedIndexChanged += new System.EventHandler(this.cboLoaiPhieu_SelectedIndexChanged);
            // 
            // lblNCC
            // 
            this.lblNCC.AutoSize = true;
            this.lblNCC.Location = new System.Drawing.Point(300, 17);
            this.lblNCC.Text = "Nhà cung cấp:";
            this.lblNCC.Name = "lblNCC";
            this.lblNCC.TabIndex = 2;
            // 
            // cboNCC
            // 
            this.cboNCC.Location = new System.Drawing.Point(390, 13);
            this.cboNCC.Size = new System.Drawing.Size(300, 23);
            this.cboNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNCC.FormattingEnabled = true;
            this.cboNCC.Name = "cboNCC";
            this.cboNCC.TabIndex = 3;
            // 
            // grpThem
            // 
            this.grpThem.Location = new System.Drawing.Point(10, 50);
            this.grpThem.Size = new System.Drawing.Size(1065, 75);
            this.grpThem.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.grpThem.Text = "Thêm vật tư vào phiếu";
            this.grpThem.Name = "grpThem";
            this.grpThem.TabIndex = 4;
            this.grpThem.Controls.Add(this.lblVT);
            this.grpThem.Controls.Add(this.cboVatTu);
            this.grpThem.Controls.Add(this.lblSL);
            this.grpThem.Controls.Add(this.nudSL);
            this.grpThem.Controls.Add(this.lblDG);
            this.grpThem.Controls.Add(this.nudDG);
            this.grpThem.Controls.Add(this.btnThemCT);
            this.grpThem.Controls.Add(this.btnXoaCT);
            // 
            // lblVT
            // 
            this.lblVT.AutoSize = true;
            this.lblVT.Location = new System.Drawing.Point(15, 32);
            this.lblVT.Text = "Vật tư:";
            this.lblVT.Name = "lblVT";
            this.lblVT.TabIndex = 0;
            // 
            // cboVatTu
            // 
            this.cboVatTu.Location = new System.Drawing.Point(70, 28);
            this.cboVatTu.Size = new System.Drawing.Size(330, 23);
            this.cboVatTu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVatTu.FormattingEnabled = true;
            this.cboVatTu.Name = "cboVatTu";
            this.cboVatTu.TabIndex = 1;
            // 
            // lblSL
            // 
            this.lblSL.AutoSize = true;
            this.lblSL.Location = new System.Drawing.Point(415, 32);
            this.lblSL.Text = "Số lượng:";
            this.lblSL.Name = "lblSL";
            this.lblSL.TabIndex = 2;
            // 
            // nudSL
            // 
            this.nudSL.Location = new System.Drawing.Point(480, 28);
            this.nudSL.Size = new System.Drawing.Size(90, 23);
            this.nudSL.DecimalPlaces = 2;
            this.nudSL.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudSL.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.nudSL.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSL.Name = "nudSL";
            this.nudSL.TabIndex = 3;
            // 
            // lblDG
            // 
            this.lblDG.AutoSize = true;
            this.lblDG.Location = new System.Drawing.Point(585, 32);
            this.lblDG.Text = "Đơn giá:";
            this.lblDG.Name = "lblDG";
            this.lblDG.TabIndex = 4;
            // 
            // nudDG
            // 
            this.nudDG.Location = new System.Drawing.Point(645, 28);
            this.nudDG.Size = new System.Drawing.Size(120, 23);
            this.nudDG.DecimalPlaces = 2;
            this.nudDG.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.nudDG.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.nudDG.Value = new decimal(new int[] { 0, 0, 0, 0 });
            this.nudDG.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.nudDG.ThousandsSeparator = true;
            this.nudDG.Name = "nudDG";
            this.nudDG.TabIndex = 5;
            // 
            // btnThemCT
            // 
            this.btnThemCT.Location = new System.Drawing.Point(785, 26);
            this.btnThemCT.Size = new System.Drawing.Size(130, 28);
            this.btnThemCT.UseVisualStyleBackColor = true;
            this.btnThemCT.Text = "Thêm vào phiếu";
            this.btnThemCT.Name = "btnThemCT";
            this.btnThemCT.TabIndex = 6;
            this.btnThemCT.Click += new System.EventHandler(this.btnThemCT_Click);
            // 
            // btnXoaCT
            // 
            this.btnXoaCT.Location = new System.Drawing.Point(925, 26);
            this.btnXoaCT.Size = new System.Drawing.Size(125, 28);
            this.btnXoaCT.UseVisualStyleBackColor = true;
            this.btnXoaCT.Text = "Xóa dòng chọn";
            this.btnXoaCT.Name = "btnXoaCT";
            this.btnXoaCT.TabIndex = 7;
            this.btnXoaCT.Click += new System.EventHandler(this.btnXoaCT_Click);
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Location = new System.Drawing.Point(10, 135);
            this.dgvChiTiet.Size = new System.Drawing.Size(1065, 430);
            this.dgvChiTiet.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.TabIndex = 5;
            // 
            // lblTongPhieu
            // 
            this.lblTongPhieu.AutoSize = true;
            this.lblTongPhieu.Location = new System.Drawing.Point(10, 585);
            this.lblTongPhieu.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.lblTongPhieu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTongPhieu.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTongPhieu.Text = "Tổng tiền phiếu: 0 VNĐ";
            this.lblTongPhieu.Name = "lblTongPhieu";
            this.lblTongPhieu.TabIndex = 6;
            // 
            // btnLuuPhieu
            // 
            this.btnLuuPhieu.Location = new System.Drawing.Point(715, 575);
            this.btnLuuPhieu.Size = new System.Drawing.Size(200, 40);
            this.btnLuuPhieu.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnLuuPhieu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLuuPhieu.UseVisualStyleBackColor = true;
            this.btnLuuPhieu.Text = "Lưu phiếu kho";
            this.btnLuuPhieu.Name = "btnLuuPhieu";
            this.btnLuuPhieu.TabIndex = 7;
            this.btnLuuPhieu.Click += new System.EventHandler(this.btnLuuPhieu_Click);
            // 
            // btnHuyPhieu
            // 
            this.btnHuyPhieu.Location = new System.Drawing.Point(925, 575);
            this.btnHuyPhieu.Size = new System.Drawing.Size(150, 40);
            this.btnHuyPhieu.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnHuyPhieu.UseVisualStyleBackColor = true;
            this.btnHuyPhieu.Text = "Làm lại phiếu";
            this.btnHuyPhieu.Name = "btnHuyPhieu";
            this.btnHuyPhieu.TabIndex = 8;
            this.btnHuyPhieu.Click += new System.EventHandler(this.btnHuyPhieu_Click);
            // 
            // btnTaiPhieu
            // 
            this.btnTaiPhieu.Location = new System.Drawing.Point(10, 11);
            this.btnTaiPhieu.Size = new System.Drawing.Size(120, 28);
            this.btnTaiPhieu.UseVisualStyleBackColor = true;
            this.btnTaiPhieu.Text = "Tải lại";
            this.btnTaiPhieu.Name = "btnTaiPhieu";
            this.btnTaiPhieu.TabIndex = 0;
            this.btnTaiPhieu.Click += new System.EventHandler(this.btnTaiPhieu_Click);
            // 
            // lblGoiYLS
            // 
            this.lblGoiYLS.AutoSize = true;
            this.lblGoiYLS.Location = new System.Drawing.Point(145, 17);
            this.lblGoiYLS.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblGoiYLS.Text = "Bấm vào một phiếu để xem chi tiết bên dưới.";
            this.lblGoiYLS.Name = "lblGoiYLS";
            this.lblGoiYLS.TabIndex = 1;
            // 
            // dgvPhieu
            // 
            this.dgvPhieu.Location = new System.Drawing.Point(10, 50);
            this.dgvPhieu.Size = new System.Drawing.Size(1065, 250);
            this.dgvPhieu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvPhieu.ReadOnly = true;
            this.dgvPhieu.AllowUserToAddRows = false;
            this.dgvPhieu.AllowUserToDeleteRows = false;
            this.dgvPhieu.MultiSelect = false;
            this.dgvPhieu.RowHeadersVisible = false;
            this.dgvPhieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPhieu.Name = "dgvPhieu";
            this.dgvPhieu.TabIndex = 2;
            this.dgvPhieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieu_CellClick);
            // 
            // lblCTPhieu
            // 
            this.lblCTPhieu.AutoSize = true;
            this.lblCTPhieu.Location = new System.Drawing.Point(10, 312);
            this.lblCTPhieu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCTPhieu.Text = "Chi tiết phiếu đang chọn:";
            this.lblCTPhieu.Name = "lblCTPhieu";
            this.lblCTPhieu.TabIndex = 3;
            // 
            // dgvCTPhieu
            // 
            this.dgvCTPhieu.Location = new System.Drawing.Point(10, 340);
            this.dgvCTPhieu.Size = new System.Drawing.Size(1065, 285);
            this.dgvCTPhieu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvCTPhieu.ReadOnly = true;
            this.dgvCTPhieu.AllowUserToAddRows = false;
            this.dgvCTPhieu.AllowUserToDeleteRows = false;
            this.dgvCTPhieu.MultiSelect = false;
            this.dgvCTPhieu.RowHeadersVisible = false;
            this.dgvCTPhieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCTPhieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCTPhieu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCTPhieu.Name = "dgvCTPhieu";
            this.dgvCTPhieu.TabIndex = 4;
            // 
            // lblNguong
            // 
            this.lblNguong.AutoSize = true;
            this.lblNguong.Location = new System.Drawing.Point(10, 17);
            this.lblNguong.Text = "Ngưỡng an toàn (tồn kho nhỏ hơn):";
            this.lblNguong.Name = "lblNguong";
            this.lblNguong.TabIndex = 0;
            // 
            // nudNguong
            // 
            this.nudNguong.Location = new System.Drawing.Point(225, 13);
            this.nudNguong.Size = new System.Drawing.Size(100, 23);
            this.nudNguong.DecimalPlaces = 2;
            this.nudNguong.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudNguong.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.nudNguong.Value = new decimal(new int[] { 10, 0, 0, 0 });
            this.nudNguong.Name = "nudNguong";
            this.nudNguong.TabIndex = 1;
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(340, 11);
            this.btnLoc.Size = new System.Drawing.Size(170, 28);
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Text = "Lọc vật tư sắp hết";
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.TabIndex = 2;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // lblKQCB
            // 
            this.lblKQCB.AutoSize = true;
            this.lblKQCB.Location = new System.Drawing.Point(530, 17);
            this.lblKQCB.ForeColor = System.Drawing.Color.Firebrick;
            this.lblKQCB.Text = "";
            this.lblKQCB.Name = "lblKQCB";
            this.lblKQCB.TabIndex = 3;
            // 
            // dgvCanhBao
            // 
            this.dgvCanhBao.Location = new System.Drawing.Point(10, 50);
            this.dgvCanhBao.Size = new System.Drawing.Size(1065, 520);
            this.dgvCanhBao.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvCanhBao.ReadOnly = true;
            this.dgvCanhBao.AllowUserToAddRows = false;
            this.dgvCanhBao.AllowUserToDeleteRows = false;
            this.dgvCanhBao.MultiSelect = false;
            this.dgvCanhBao.RowHeadersVisible = false;
            this.dgvCanhBao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCanhBao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCanhBao.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCanhBao.Name = "dgvCanhBao";
            this.dgvCanhBao.TabIndex = 4;
            // 
            // btnTongGiaTri
            // 
            this.btnTongGiaTri.Location = new System.Drawing.Point(10, 585);
            this.btnTongGiaTri.Size = new System.Drawing.Size(230, 36);
            this.btnTongGiaTri.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnTongGiaTri.UseVisualStyleBackColor = true;
            this.btnTongGiaTri.Text = "Tính tổng giá trị tồn kho";
            this.btnTongGiaTri.Name = "btnTongGiaTri";
            this.btnTongGiaTri.TabIndex = 5;
            this.btnTongGiaTri.Click += new System.EventHandler(this.btnTongGiaTri_Click);
            // 
            // lblTongGiaTri
            // 
            this.lblTongGiaTri.AutoSize = true;
            this.lblTongGiaTri.Location = new System.Drawing.Point(255, 594);
            this.lblTongGiaTri.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.lblTongGiaTri.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTongGiaTri.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTongGiaTri.Text = "Tổng giá trị tồn kho: (chưa tính)";
            this.lblTongGiaTri.Name = "lblTongGiaTri";
            this.lblTongGiaTri.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 640);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 55 - Hệ thống quản lý xuất nhập kho nguyên vật liệu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpThem.ResumeLayout(false);
            this.grpThem.PerformLayout();
            this.grpVT.ResumeLayout(false);
            this.grpVT.PerformLayout();
            this.grpNCC.ResumeLayout(false);
            this.grpNCC.PerformLayout();
            this.tabBaoCao.ResumeLayout(false);
            this.tabLichSu.ResumeLayout(false);
            this.tabPhieu.ResumeLayout(false);
            this.tabVatTu.ResumeLayout(false);
            this.tabNCC.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabNCC;
        private System.Windows.Forms.TabPage tabVatTu;
        private System.Windows.Forms.TabPage tabPhieu;
        private System.Windows.Forms.TabPage tabLichSu;
        private System.Windows.Forms.TabPage tabBaoCao;
        private System.Windows.Forms.Label lblTimNCC;
        private System.Windows.Forms.TextBox txtTimNCC;
        private System.Windows.Forms.Button btnTimNCC;
        private System.Windows.Forms.Button btnTatCaNCC;
        private System.Windows.Forms.DataGridView dgvNCC;
        private System.Windows.Forms.GroupBox grpNCC;
        private System.Windows.Forms.Label lblMaNCC;
        private System.Windows.Forms.TextBox txtMaNCC;
        private System.Windows.Forms.Label lblTenNCC;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.Label lblDTNCC;
        private System.Windows.Forms.TextBox txtDTNCC;
        private System.Windows.Forms.Label lblDCNCC;
        private System.Windows.Forms.TextBox txtDCNCC;
        private System.Windows.Forms.Button btnThemNCC;
        private System.Windows.Forms.Button btnSuaNCC;
        private System.Windows.Forms.Button btnXoaNCC;
        private System.Windows.Forms.Button btnMoiNCC;
        private System.Windows.Forms.Label lblTimVT;
        private System.Windows.Forms.TextBox txtTimVT;
        private System.Windows.Forms.Button btnTimVT;
        private System.Windows.Forms.Button btnTatCaVT;
        private System.Windows.Forms.DataGridView dgvVatTu;
        private System.Windows.Forms.GroupBox grpVT;
        private System.Windows.Forms.Label lblMaVT;
        private System.Windows.Forms.TextBox txtMaVT;
        private System.Windows.Forms.Label lblTenVT;
        private System.Windows.Forms.TextBox txtTenVT;
        private System.Windows.Forms.Label lblDVT;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label lblTon;
        private System.Windows.Forms.NumericUpDown nudTon;
        private System.Windows.Forms.Label lblGhiChuTon;
        private System.Windows.Forms.Button btnThemVT;
        private System.Windows.Forms.Button btnSuaVT;
        private System.Windows.Forms.Button btnXoaVT;
        private System.Windows.Forms.Button btnMoiVT;
        private System.Windows.Forms.Label lblLoaiPhieu;
        private System.Windows.Forms.ComboBox cboLoaiPhieu;
        private System.Windows.Forms.Label lblNCC;
        private System.Windows.Forms.ComboBox cboNCC;
        private System.Windows.Forms.GroupBox grpThem;
        private System.Windows.Forms.Label lblVT;
        private System.Windows.Forms.ComboBox cboVatTu;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.NumericUpDown nudSL;
        private System.Windows.Forms.Label lblDG;
        private System.Windows.Forms.NumericUpDown nudDG;
        private System.Windows.Forms.Button btnThemCT;
        private System.Windows.Forms.Button btnXoaCT;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Label lblTongPhieu;
        private System.Windows.Forms.Button btnLuuPhieu;
        private System.Windows.Forms.Button btnHuyPhieu;
        private System.Windows.Forms.Button btnTaiPhieu;
        private System.Windows.Forms.Label lblGoiYLS;
        private System.Windows.Forms.DataGridView dgvPhieu;
        private System.Windows.Forms.Label lblCTPhieu;
        private System.Windows.Forms.DataGridView dgvCTPhieu;
        private System.Windows.Forms.Label lblNguong;
        private System.Windows.Forms.NumericUpDown nudNguong;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Label lblKQCB;
        private System.Windows.Forms.DataGridView dgvCanhBao;
        private System.Windows.Forms.Button btnTongGiaTri;
        private System.Windows.Forms.Label lblTongGiaTri;
    }
}
