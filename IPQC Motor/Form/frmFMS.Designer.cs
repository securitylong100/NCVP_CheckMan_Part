﻿namespace IPQC_Part
{
    partial class frmFMS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFMS));
            this.dgvMeasureData = new System.Windows.Forms.DataGridView();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbMaSo = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpKhungGio = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbQuiTrinh = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbKhuVuc = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPhuongThuc = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSLMau = new System.Windows.Forms.ComboBox();
            this.txtLot = new System.Windows.Forms.TextBox();
            this.dtpDoHang = new System.Windows.Forms.DateTimePicker();
            this.dtpGiaCong = new System.Windows.Forms.DateTimePicker();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDanhGia = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btnLuuXuat = new System.Windows.Forms.Button();
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbCOM = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbDongMay = new System.Windows.Forms.ComboBox();
            this.btnTaoForm = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbNgoaiQuan = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpHeader = new System.Windows.Forms.TabPage();
            this.label27 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPageId = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.tpFootder = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.TimeFMS = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.picMeasure = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDwr = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasureData)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpHeader.SuspendLayout();
            this.tpFootder.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMeasure)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMeasureData
            // 
            this.dgvMeasureData.AllowUserToAddRows = false;
            this.dgvMeasureData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMeasureData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeasureData.Location = new System.Drawing.Point(0, 212);
            this.dgvMeasureData.Name = "dgvMeasureData";
            this.dgvMeasureData.ReadOnly = true;
            this.dgvMeasureData.RowHeadersVisible = false;
            this.dgvMeasureData.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dgvMeasureData.Size = new System.Drawing.Size(1265, 500);
            this.dgvMeasureData.TabIndex = 15;
            this.dgvMeasureData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMeasureData_CellEndEdit);
            this.dgvMeasureData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvMeasureData_KeyDown);
            this.dgvMeasureData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvMeasureData_MouseClick);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(286, 64);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(17, 13);
            this.label25.TabIndex = 30;
            this.label25.Text = "(*)";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(286, 24);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(17, 13);
            this.label24.TabIndex = 29;
            this.label24.Text = "(*)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(137, 107);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 13);
            this.label23.TabIndex = 28;
            this.label23.Text = "(*)";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(137, 63);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(17, 13);
            this.label22.TabIndex = 27;
            this.label22.Text = "(*)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(137, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 13);
            this.label21.TabIndex = 24;
            this.label21.Text = "(*)";
            // 
            // cmbMaSo
            // 
            this.cmbMaSo.FormattingEnabled = true;
            this.cmbMaSo.Location = new System.Drawing.Point(166, 102);
            this.cmbMaSo.Name = "cmbMaSo";
            this.cmbMaSo.Size = new System.Drawing.Size(121, 21);
            this.cmbMaSo.TabIndex = 26;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(163, 86);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(94, 13);
            this.label20.TabIndex = 25;
            this.label20.Text = "Mã Máy/Mã Hàng";
            // 
            // dtpKhungGio
            // 
            this.dtpKhungGio.CustomFormat = "HH:00";
            this.dtpKhungGio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpKhungGio.Location = new System.Drawing.Point(16, 101);
            this.dtpKhungGio.Name = "dtpKhungGio";
            this.dtpKhungGio.Size = new System.Drawing.Size(121, 20);
            this.dtpKhungGio.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Khung Giờ:";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(319, 20);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(272, 84);
            this.txtNoiDung.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nội Dung Thử Nghiệm";
            // 
            // cmbQuiTrinh
            // 
            this.cmbQuiTrinh.FormattingEnabled = true;
            this.cmbQuiTrinh.Location = new System.Drawing.Point(16, 20);
            this.cmbQuiTrinh.Name = "cmbQuiTrinh";
            this.cmbQuiTrinh.Size = new System.Drawing.Size(121, 21);
            this.cmbQuiTrinh.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Qui Trình";
            // 
            // cmbKhuVuc
            // 
            this.cmbKhuVuc.FormattingEnabled = true;
            this.cmbKhuVuc.Items.AddRange(new object[] {
            "Hàng Loạt",
            "Thử Nghiệm"});
            this.cmbKhuVuc.Location = new System.Drawing.Point(166, 60);
            this.cmbKhuVuc.Name = "cmbKhuVuc";
            this.cmbKhuVuc.Size = new System.Drawing.Size(121, 21);
            this.cmbKhuVuc.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(163, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Phương Thức";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(163, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Khu Vực";
            // 
            // cmbPhuongThuc
            // 
            this.cmbPhuongThuc.FormattingEnabled = true;
            this.cmbPhuongThuc.Items.AddRange(new object[] {
            "Ngẫu Nhiên",
            "Toàn Bộ"});
            this.cmbPhuongThuc.Location = new System.Drawing.Point(166, 21);
            this.cmbPhuongThuc.Name = "cmbPhuongThuc";
            this.cmbPhuongThuc.Size = new System.Drawing.Size(121, 21);
            this.cmbPhuongThuc.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Số Lượng Mẫu";
            // 
            // cmbSLMau
            // 
            this.cmbSLMau.FormattingEnabled = true;
            this.cmbSLMau.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbSLMau.Location = new System.Drawing.Point(16, 59);
            this.cmbSLMau.Name = "cmbSLMau";
            this.cmbSLMau.Size = new System.Drawing.Size(121, 21);
            this.cmbSLMau.TabIndex = 6;
            // 
            // txtLot
            // 
            this.txtLot.Location = new System.Drawing.Point(186, 21);
            this.txtLot.Name = "txtLot";
            this.txtLot.Size = new System.Drawing.Size(121, 20);
            this.txtLot.TabIndex = 24;
            // 
            // dtpDoHang
            // 
            this.dtpDoHang.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDoHang.Location = new System.Drawing.Point(32, 61);
            this.dtpDoHang.Name = "dtpDoHang";
            this.dtpDoHang.Size = new System.Drawing.Size(121, 20);
            this.dtpDoHang.TabIndex = 23;
            // 
            // dtpGiaCong
            // 
            this.dtpGiaCong.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGiaCong.Location = new System.Drawing.Point(31, 22);
            this.dtpGiaCong.Name = "dtpGiaCong";
            this.dtpGiaCong.Size = new System.Drawing.Size(121, 20);
            this.dtpGiaCong.TabIndex = 22;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(318, 21);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(276, 138);
            this.txtGhiChu.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ghi Chú";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày Gia Công";
            // 
            // cmbDanhGia
            // 
            this.cmbDanhGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDanhGia.FormattingEnabled = true;
            this.cmbDanhGia.Items.AddRange(new object[] {
            "OK",
            "NG"});
            this.cmbDanhGia.Location = new System.Drawing.Point(186, 60);
            this.cmbDanhGia.Name = "cmbDanhGia";
            this.cmbDanhGia.Size = new System.Drawing.Size(121, 21);
            this.cmbDanhGia.TabIndex = 17;
            this.cmbDanhGia.SelectedIndexChanged += new System.EventHandler(this.cmbDanhGia_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số lot";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(183, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Đánh Giá";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Ngày Đo Hàng";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.btnLuuXuat);
            this.groupBox4.Controls.Add(this.btnKetNoi);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.cmbCOM);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.cmbDongMay);
            this.groupBox4.Controls.Add(this.btnTaoForm);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.cmbNgoaiQuan);
            this.groupBox4.Location = new System.Drawing.Point(637, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(317, 200);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Xử Lý";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(185, 17);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(17, 13);
            this.label26.TabIndex = 31;
            this.label26.Text = "(*)";
            // 
            // btnLuuXuat
            // 
            this.btnLuuXuat.Location = new System.Drawing.Point(232, 169);
            this.btnLuuXuat.Name = "btnLuuXuat";
            this.btnLuuXuat.Size = new System.Drawing.Size(74, 23);
            this.btnLuuXuat.TabIndex = 19;
            this.btnLuuXuat.Text = "Xuất Excel";
            this.btnLuuXuat.UseVisualStyleBackColor = true;
            this.btnLuuXuat.Click += new System.EventHandler(this.btnLuuXuat_Click);
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.Location = new System.Drawing.Point(230, 74);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(75, 23);
            this.btnKetNoi.TabIndex = 16;
            this.btnKetNoi.Text = "Kết Nối";
            this.btnKetNoi.UseVisualStyleBackColor = true;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(200, 79);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "--->";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(28, 79);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "Cổng Com:";
            // 
            // cmbCOM
            // 
            this.cmbCOM.FormattingEnabled = true;
            this.cmbCOM.Location = new System.Drawing.Point(88, 76);
            this.cmbCOM.Name = "cmbCOM";
            this.cmbCOM.Size = new System.Drawing.Size(99, 21);
            this.cmbCOM.TabIndex = 14;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(25, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Dòng Máy:";
            // 
            // cmbDongMay
            // 
            this.cmbDongMay.FormattingEnabled = true;
            this.cmbDongMay.Items.AddRange(new object[] {
            "FMS",
            "PinGau",
            "DaiGau",
            "Push",
            "Pull",
            "M",
            "N",
            "TDG",
            "SR"});
            this.cmbDongMay.Location = new System.Drawing.Point(87, 45);
            this.cmbDongMay.Name = "cmbDongMay";
            this.cmbDongMay.Size = new System.Drawing.Size(99, 21);
            this.cmbDongMay.TabIndex = 10;
            this.cmbDongMay.SelectedIndexChanged += new System.EventHandler(this.cmbDongMay_SelectedIndexChanged);
            // 
            // btnTaoForm
            // 
            this.btnTaoForm.Location = new System.Drawing.Point(229, 12);
            this.btnTaoForm.Name = "btnTaoForm";
            this.btnTaoForm.Size = new System.Drawing.Size(75, 23);
            this.btnTaoForm.TabIndex = 8;
            this.btnTaoForm.Text = "Tạo Form";
            this.btnTaoForm.UseVisualStyleBackColor = true;
            this.btnTaoForm.Click += new System.EventHandler(this.btnTaoForm_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(200, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "--->";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Ngoại Quan:";
            // 
            // cmbNgoaiQuan
            // 
            this.cmbNgoaiQuan.FormattingEnabled = true;
            this.cmbNgoaiQuan.Items.AddRange(new object[] {
            "OK",
            "NG"});
            this.cmbNgoaiQuan.Location = new System.Drawing.Point(87, 14);
            this.cmbNgoaiQuan.Name = "cmbNgoaiQuan";
            this.cmbNgoaiQuan.Size = new System.Drawing.Size(99, 21);
            this.cmbNgoaiQuan.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpHeader);
            this.tabControl1.Controls.Add(this.tpFootder);
            this.tabControl1.Location = new System.Drawing.Point(12, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(619, 200);
            this.tabControl1.TabIndex = 24;
            // 
            // tpHeader
            // 
            this.tpHeader.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tpHeader.Controls.Add(this.label27);
            this.tpHeader.Controls.Add(this.txtUser);
            this.tpHeader.Controls.Add(this.label5);
            this.tpHeader.Controls.Add(this.txtPageId);
            this.tpHeader.Controls.Add(this.label29);
            this.tpHeader.Controls.Add(this.label30);
            this.tpHeader.Controls.Add(this.label28);
            this.tpHeader.Controls.Add(this.label25);
            this.tpHeader.Controls.Add(this.txtNoiDung);
            this.tpHeader.Controls.Add(this.label24);
            this.tpHeader.Controls.Add(this.cmbSLMau);
            this.tpHeader.Controls.Add(this.label23);
            this.tpHeader.Controls.Add(this.label9);
            this.tpHeader.Controls.Add(this.label22);
            this.tpHeader.Controls.Add(this.cmbPhuongThuc);
            this.tpHeader.Controls.Add(this.label21);
            this.tpHeader.Controls.Add(this.label8);
            this.tpHeader.Controls.Add(this.cmbMaSo);
            this.tpHeader.Controls.Add(this.label7);
            this.tpHeader.Controls.Add(this.label20);
            this.tpHeader.Controls.Add(this.cmbKhuVuc);
            this.tpHeader.Controls.Add(this.dtpKhungGio);
            this.tpHeader.Controls.Add(this.label6);
            this.tpHeader.Controls.Add(this.label12);
            this.tpHeader.Controls.Add(this.cmbQuiTrinh);
            this.tpHeader.Controls.Add(this.label1);
            this.tpHeader.Location = new System.Drawing.Point(4, 22);
            this.tpHeader.Name = "tpHeader";
            this.tpHeader.Padding = new System.Windows.Forms.Padding(3);
            this.tpHeader.Size = new System.Drawing.Size(611, 174);
            this.tpHeader.TabIndex = 0;
            this.tpHeader.Text = "Header";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(137, 148);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(17, 13);
            this.label27.TabIndex = 38;
            this.label27.Text = "(*)";
            // 
            // txtUser
            // 
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(16, 145);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(121, 20);
            this.txtUser.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "User: ";
            // 
            // txtPageId
            // 
            this.txtPageId.Location = new System.Drawing.Point(166, 148);
            this.txtPageId.Name = "txtPageId";
            this.txtPageId.ReadOnly = true;
            this.txtPageId.Size = new System.Drawing.Size(121, 20);
            this.txtPageId.TabIndex = 35;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(286, 152);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(17, 13);
            this.label29.TabIndex = 34;
            this.label29.Text = "(*)";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(286, 108);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(17, 13);
            this.label30.TabIndex = 33;
            this.label30.Text = "(*)";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(163, 131);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(44, 13);
            this.label28.TabIndex = 31;
            this.label28.Text = "Page Id";
            // 
            // tpFootder
            // 
            this.tpFootder.BackColor = System.Drawing.Color.White;
            this.tpFootder.Controls.Add(this.txtGhiChu);
            this.tpFootder.Controls.Add(this.txtLot);
            this.tpFootder.Controls.Add(this.label11);
            this.tpFootder.Controls.Add(this.dtpDoHang);
            this.tpFootder.Controls.Add(this.label10);
            this.tpFootder.Controls.Add(this.dtpGiaCong);
            this.tpFootder.Controls.Add(this.label4);
            this.tpFootder.Controls.Add(this.cmbDanhGia);
            this.tpFootder.Controls.Add(this.label3);
            this.tpFootder.Controls.Add(this.label2);
            this.tpFootder.Location = new System.Drawing.Point(4, 22);
            this.tpFootder.Name = "tpFootder";
            this.tpFootder.Padding = new System.Windows.Forms.Padding(3);
            this.tpFootder.Size = new System.Drawing.Size(611, 174);
            this.tpFootder.TabIndex = 1;
            this.tpFootder.Text = "Footder";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(960, 6);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(305, 200);
            this.tabControl2.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.picMeasure);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(297, 174);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bản vẽ đo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // picMeasure
            // 
            this.picMeasure.Location = new System.Drawing.Point(0, 0);
            this.picMeasure.Name = "picMeasure";
            this.picMeasure.Size = new System.Drawing.Size(297, 174);
            this.picMeasure.TabIndex = 1;
            this.picMeasure.TabStop = false;
            this.picMeasure.DoubleClick += new System.EventHandler(this.picMeasure_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.picMain);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(297, 174);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bản vẽ kích thước";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // picMain
            // 
            this.picMain.Location = new System.Drawing.Point(0, 0);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(297, 178);
            this.picMain.TabIndex = 1;
            this.picMain.TabStop = false;
            this.picMain.DoubleClick += new System.EventHandler(this.picMain_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDwr);
            this.panel1.Location = new System.Drawing.Point(1128, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 19);
            this.panel1.TabIndex = 32;
            // 
            // lblDwr
            // 
            this.lblDwr.AutoSize = true;
            this.lblDwr.Location = new System.Drawing.Point(3, 4);
            this.lblDwr.Name = "lblDwr";
            this.lblDwr.Size = new System.Drawing.Size(46, 13);
            this.lblDwr.TabIndex = 0;
            this.lblDwr.Text = "Drawing";
            // 
            // frmFMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1263, 695);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dgvMeasureData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFMS";
            this.Text = "frmFMS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFMS_FormClosing);
            this.Load += new System.EventHandler(this.frmFMS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasureData)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpHeader.ResumeLayout(false);
            this.tpHeader.PerformLayout();
            this.tpFootder.ResumeLayout(false);
            this.tpFootder.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMeasure)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvMeasureData;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbQuiTrinh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbKhuVuc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbPhuongThuc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbSLMau;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDanhGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dtpKhungGio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLot;
        private System.Windows.Forms.DateTimePicker dtpDoHang;
        private System.Windows.Forms.DateTimePicker dtpGiaCong;
        private System.Windows.Forms.Button btnLuuXuat;
        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbCOM;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbDongMay;
        private System.Windows.Forms.Button btnTaoForm;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbNgoaiQuan;
        private System.Windows.Forms.ComboBox cmbMaSo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpHeader;
        private System.Windows.Forms.TabPage tpFootder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtPageId;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer TimeFMS;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox picMeasure;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDwr;
    }
}