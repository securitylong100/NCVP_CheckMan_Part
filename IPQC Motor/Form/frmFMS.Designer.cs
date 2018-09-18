namespace IPQC_Part
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
            this.dgvMeasureData = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbQuiTrinh = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbKhuVuc = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPhuongThuc = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSLMau = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDanhGia = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gpbBanVe = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtpGiaCong = new System.Windows.Forms.DateTimePicker();
            this.dtpDoHang = new System.Windows.Forms.DateTimePicker();
            this.txtLot = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpKhungGio = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbNgoaiQuan = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnTaoForm = new System.Windows.Forms.Button();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbDongMay = new System.Windows.Forms.ComboBox();
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbCOM = new System.Windows.Forms.ComboBox();
            this.btnNoiLuu = new System.Windows.Forms.Button();
            this.txtNoiLuu = new System.Windows.Forms.TextBox();
            this.btnLuuXuat = new System.Windows.Forms.Button();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasureData)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMeasureData
            // 
            this.dgvMeasureData.AllowUserToAddRows = false;
            this.dgvMeasureData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMeasureData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMeasureData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeasureData.Location = new System.Drawing.Point(0, 236);
            this.dgvMeasureData.Name = "dgvMeasureData";
            this.dgvMeasureData.ReadOnly = true;
            this.dgvMeasureData.Size = new System.Drawing.Size(1265, 270);
            this.dgvMeasureData.TabIndex = 15;
            this.dgvMeasureData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMeasureData_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpKhungGio);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtNoiDung);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbQuiTrinh);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbKhuVuc);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cmbPhuongThuc);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmbSLMau);
            this.groupBox2.Location = new System.Drawing.Point(12, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 200);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Header";
            // 
            // cmbQuiTrinh
            // 
            this.cmbQuiTrinh.FormattingEnabled = true;
            this.cmbQuiTrinh.Location = new System.Drawing.Point(17, 33);
            this.cmbQuiTrinh.Name = "cmbQuiTrinh";
            this.cmbQuiTrinh.Size = new System.Drawing.Size(121, 21);
            this.cmbQuiTrinh.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 17);
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
            this.cmbKhuVuc.Location = new System.Drawing.Point(171, 72);
            this.cmbKhuVuc.Name = "cmbKhuVuc";
            this.cmbKhuVuc.Size = new System.Drawing.Size(121, 21);
            this.cmbKhuVuc.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(168, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Phương Thức";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(168, 56);
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
            this.cmbPhuongThuc.Location = new System.Drawing.Point(171, 33);
            this.cmbPhuongThuc.Name = "cmbPhuongThuc";
            this.cmbPhuongThuc.Size = new System.Drawing.Size(121, 21);
            this.cmbPhuongThuc.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 57);
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
            this.cmbSLMau.Location = new System.Drawing.Point(17, 72);
            this.cmbSLMau.Name = "cmbSLMau";
            this.cmbSLMau.Size = new System.Drawing.Size(121, 21);
            this.cmbSLMau.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nội Dung Thử Nghiệm";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(17, 158);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(275, 36);
            this.txtNoiDung.TabIndex = 19;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLot);
            this.groupBox3.Controls.Add(this.dtpDoHang);
            this.groupBox3.Controls.Add(this.dtpGiaCong);
            this.groupBox3.Controls.Add(this.txtUser);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtGhiChu);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cmbDanhGia);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(647, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(306, 200);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Footer";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(16, 158);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(276, 36);
            this.txtGhiChu.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ghi Chú";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 17);
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
            this.cmbDanhGia.Location = new System.Drawing.Point(171, 72);
            this.cmbDanhGia.Name = "cmbDanhGia";
            this.cmbDanhGia.Size = new System.Drawing.Size(121, 21);
            this.cmbDanhGia.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số lot";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(168, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Đánh Giá";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Ngày Đo Hàng";
            // 
            // txtUser
            // 
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(17, 114);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(121, 20);
            this.txtUser.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "User: ";
            // 
            // gpbBanVe
            // 
            this.gpbBanVe.Location = new System.Drawing.Point(960, 6);
            this.gpbBanVe.Name = "gpbBanVe";
            this.gpbBanVe.Size = new System.Drawing.Size(294, 200);
            this.gpbBanVe.TabIndex = 23;
            this.gpbBanVe.TabStop = false;
            this.gpbBanVe.Text = "Bản Vẽ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.btnTimKiem);
            this.groupBox4.Controls.Add(this.dtpToDate);
            this.groupBox4.Controls.Add(this.dtpFromDate);
            this.groupBox4.Controls.Add(this.btnLuuXuat);
            this.groupBox4.Controls.Add(this.txtNoiLuu);
            this.groupBox4.Controls.Add(this.btnNoiLuu);
            this.groupBox4.Controls.Add(this.btnKetNoi);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.cmbCOM);
            this.groupBox4.Controls.Add(this.btnBatDau);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.cmbDongMay);
            this.groupBox4.Controls.Add(this.btnTaoForm);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.cmbNgoaiQuan);
            this.groupBox4.Location = new System.Drawing.Point(324, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(317, 200);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Xử Lý";
            // 
            // dtpGiaCong
            // 
            this.dtpGiaCong.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGiaCong.Location = new System.Drawing.Point(16, 34);
            this.dtpGiaCong.Name = "dtpGiaCong";
            this.dtpGiaCong.Size = new System.Drawing.Size(121, 20);
            this.dtpGiaCong.TabIndex = 22;
            // 
            // dtpDoHang
            // 
            this.dtpDoHang.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDoHang.Location = new System.Drawing.Point(17, 73);
            this.dtpDoHang.Name = "dtpDoHang";
            this.dtpDoHang.Size = new System.Drawing.Size(121, 20);
            this.dtpDoHang.TabIndex = 23;
            // 
            // txtLot
            // 
            this.txtLot.Location = new System.Drawing.Point(171, 33);
            this.txtLot.Name = "txtLot";
            this.txtLot.Size = new System.Drawing.Size(121, 20);
            this.txtLot.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Khung Giờ:";
            // 
            // dtpKhungGio
            // 
            this.dtpKhungGio.CustomFormat = "HH:00";
            this.dtpKhungGio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpKhungGio.Location = new System.Drawing.Point(17, 113);
            this.dtpKhungGio.Name = "dtpKhungGio";
            this.dtpKhungGio.Size = new System.Drawing.Size(121, 20);
            this.dtpKhungGio.TabIndex = 24;
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
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(192, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "--->";
            // 
            // btnTaoForm
            // 
            this.btnTaoForm.Location = new System.Drawing.Point(229, 12);
            this.btnTaoForm.Name = "btnTaoForm";
            this.btnTaoForm.Size = new System.Drawing.Size(75, 23);
            this.btnTaoForm.TabIndex = 8;
            this.btnTaoForm.Text = "Tạo Form";
            this.btnTaoForm.UseVisualStyleBackColor = true;
            // 
            // btnBatDau
            // 
            this.btnBatDau.Location = new System.Drawing.Point(229, 43);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(75, 23);
            this.btnBatDau.TabIndex = 12;
            this.btnBatDau.Text = "Bắt Đầu";
            this.btnBatDau.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(192, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 13);
            this.label15.TabIndex = 11;
            this.label15.Text = "--->";
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
            "PG",
            "DG"});
            this.cmbDongMay.Location = new System.Drawing.Point(87, 45);
            this.cmbDongMay.Name = "cmbDongMay";
            this.cmbDongMay.Size = new System.Drawing.Size(99, 21);
            this.cmbDongMay.TabIndex = 10;
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.Location = new System.Drawing.Point(230, 74);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(75, 23);
            this.btnKetNoi.TabIndex = 16;
            this.btnKetNoi.Text = "Kết Nối";
            this.btnKetNoi.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(193, 79);
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
            // btnNoiLuu
            // 
            this.btnNoiLuu.Location = new System.Drawing.Point(2, 169);
            this.btnNoiLuu.Name = "btnNoiLuu";
            this.btnNoiLuu.Size = new System.Drawing.Size(52, 23);
            this.btnNoiLuu.TabIndex = 17;
            this.btnNoiLuu.Text = "Nơi Lưu";
            this.btnNoiLuu.UseVisualStyleBackColor = true;
            // 
            // txtNoiLuu
            // 
            this.txtNoiLuu.Location = new System.Drawing.Point(58, 171);
            this.txtNoiLuu.Name = "txtNoiLuu";
            this.txtNoiLuu.Size = new System.Drawing.Size(149, 20);
            this.txtNoiLuu.TabIndex = 18;
            // 
            // btnLuuXuat
            // 
            this.btnLuuXuat.Location = new System.Drawing.Point(230, 169);
            this.btnLuuXuat.Name = "btnLuuXuat";
            this.btnLuuXuat.Size = new System.Drawing.Size(74, 23);
            this.btnLuuXuat.TabIndex = 19;
            this.btnLuuXuat.Text = "Lưu và Xuất";
            this.btnLuuXuat.UseVisualStyleBackColor = true;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(8, 140);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(99, 20);
            this.dtpFromDate.TabIndex = 23;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(138, 140);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(77, 20);
            this.dtpToDate.TabIndex = 24;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(230, 137);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(74, 23);
            this.btnTimKiem.TabIndex = 25;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(113, 142);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(22, 13);
            this.label19.TabIndex = 26;
            this.label19.Text = "--->";
            // 
            // frmFMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 506);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvMeasureData);
            this.Controls.Add(this.gpbBanVe);
            this.Name = "frmFMS";
            this.Text = "frmFMS";
            this.Load += new System.EventHandler(this.frmFMS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasureData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvMeasureData;
        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDanhGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox gpbBanVe;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dtpKhungGio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLot;
        private System.Windows.Forms.DateTimePicker dtpDoHang;
        private System.Windows.Forms.DateTimePicker dtpGiaCong;
        private System.Windows.Forms.Button btnLuuXuat;
        private System.Windows.Forms.TextBox txtNoiLuu;
        private System.Windows.Forms.Button btnNoiLuu;
        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbCOM;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbDongMay;
        private System.Windows.Forms.Button btnTaoForm;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbNgoaiQuan;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
    }
}