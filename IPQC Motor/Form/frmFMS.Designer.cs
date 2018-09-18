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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbProcedure = new System.Windows.Forms.ComboBox();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvMeasureData = new System.Windows.Forms.DataGridView();
            this.cmbMachineModel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStartFMS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasureData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Procedure";
            // 
            // cmbProcedure
            // 
            this.cmbProcedure.FormattingEnabled = true;
            this.cmbProcedure.Location = new System.Drawing.Point(24, 25);
            this.cmbProcedure.Name = "cmbProcedure";
            this.cmbProcedure.Size = new System.Drawing.Size(121, 21);
            this.cmbProcedure.TabIndex = 2;
            // 
            // cmbMethod
            // 
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.Items.AddRange(new object[] {
            "Ngẫu Nhiên",
            "Toàn Bộ"});
            this.cmbMethod.Location = new System.Drawing.Point(178, 25);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(121, 21);
            this.cmbMethod.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Method";
            // 
            // cmbArea
            // 
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Items.AddRange(new object[] {
            "Hàng Loạt",
            "Thử Nghiệm"});
            this.cmbArea.Location = new System.Drawing.Point(337, 25);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(121, 21);
            this.cmbArea.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Area:";
            // 
            // txtUser
            // 
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(809, 26);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(130, 20);
            this.txtUser.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(806, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "User: ";
            // 
            // dgvMeasureData
            // 
            this.dgvMeasureData.AllowUserToAddRows = false;
            this.dgvMeasureData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMeasureData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeasureData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvMeasureData.Location = new System.Drawing.Point(0, 76);
            this.dgvMeasureData.Name = "dgvMeasureData";
            this.dgvMeasureData.ReadOnly = true;
            this.dgvMeasureData.Size = new System.Drawing.Size(997, 351);
            this.dgvMeasureData.TabIndex = 15;
            this.dgvMeasureData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMeasureData_CellContentClick);
            // 
            // cmbMachineModel
            // 
            this.cmbMachineModel.FormattingEnabled = true;
            this.cmbMachineModel.Items.AddRange(new object[] {
            "FMS",
            "PG",
            "DG",
            "Pull&Push"});
            this.cmbMachineModel.Location = new System.Drawing.Point(494, 25);
            this.cmbMachineModel.Name = "cmbMachineModel";
            this.cmbMachineModel.Size = new System.Drawing.Size(121, 21);
            this.cmbMachineModel.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(491, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Machine Model:";
            // 
            // btnStartFMS
            // 
            this.btnStartFMS.Location = new System.Drawing.Point(676, 25);
            this.btnStartFMS.Name = "btnStartFMS";
            this.btnStartFMS.Size = new System.Drawing.Size(75, 21);
            this.btnStartFMS.TabIndex = 18;
            this.btnStartFMS.Text = "StartFMS";
            this.btnStartFMS.UseVisualStyleBackColor = true;
            this.btnStartFMS.Click += new System.EventHandler(this.btnStartFMS_Click);
            // 
            // frmFMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 427);
            this.Controls.Add(this.btnStartFMS);
            this.Controls.Add(this.cmbMachineModel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvMeasureData);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMethod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbProcedure);
            this.Controls.Add(this.label1);
            this.Name = "frmFMS";
            this.Text = "frmFMS";
            this.Load += new System.EventHandler(this.frmFMS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasureData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProcedure;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvMeasureData;
        private System.Windows.Forms.ComboBox cmbMachineModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStartFMS;
    }
}