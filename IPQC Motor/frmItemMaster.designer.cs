namespace IPQC_Motor
{
    partial class frmItemMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemMaster));
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvTester = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDwr = new System.Windows.Forms.TextBox();
            this.picbox = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.picbox_main = new System.Windows.Forms.PictureBox();
            this.btn_imageMeasure = new System.Windows.Forms.Button();
            this.btn_imageMain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTester)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_main)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(181, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 33);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add / Edit";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvTester
            // 
            this.dgvTester.AllowUserToAddRows = false;
            this.dgvTester.BackgroundColor = System.Drawing.Color.NavajoWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTester.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTester.ColumnHeadersHeight = 30;
            this.dgvTester.Location = new System.Drawing.Point(0, 84);
            this.dgvTester.Name = "dgvTester";
            this.dgvTester.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTester.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTester.RowHeadersVisible = false;
            this.dgvTester.RowTemplate.Height = 21;
            this.dgvTester.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTester.Size = new System.Drawing.Size(625, 623);
            this.dgvTester.TabIndex = 12;
            this.dgvTester.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvTester_RowsAdded);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(433, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 33);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(307, 25);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 33);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Drawing No";
            // 
            // txtDwr
            // 
            this.txtDwr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDwr.Location = new System.Drawing.Point(40, 35);
            this.txtDwr.Name = "txtDwr";
            this.txtDwr.Size = new System.Drawing.Size(130, 20);
            this.txtDwr.TabIndex = 14;
            // 
            // picbox
            // 
            this.picbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbox.Location = new System.Drawing.Point(634, 37);
            this.picbox.Name = "picbox";
            this.picbox.Size = new System.Drawing.Size(379, 309);
            this.picbox.TabIndex = 15;
            this.picbox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.txtDwr);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 76);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edit";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_imageMeasure);
            this.groupBox3.Location = new System.Drawing.Point(631, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(385, 350);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Drawing Measure";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_imageMain);
            this.groupBox4.Controls.Add(this.picbox_main);
            this.groupBox4.Location = new System.Drawing.Point(631, 358);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(385, 349);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Drawing Main";
            // 
            // picbox_main
            // 
            this.picbox_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbox_main.Location = new System.Drawing.Point(3, 34);
            this.picbox_main.Name = "picbox_main";
            this.picbox_main.Size = new System.Drawing.Size(379, 309);
            this.picbox_main.TabIndex = 18;
            this.picbox_main.TabStop = false;
            // 
            // btn_imageMeasure
            // 
            this.btn_imageMeasure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_imageMeasure.Location = new System.Drawing.Point(279, 10);
            this.btn_imageMeasure.Name = "btn_imageMeasure";
            this.btn_imageMeasure.Size = new System.Drawing.Size(101, 22);
            this.btn_imageMeasure.TabIndex = 16;
            this.btn_imageMeasure.Text = "Choose Image";
            this.btn_imageMeasure.UseVisualStyleBackColor = true;
            this.btn_imageMeasure.Click += new System.EventHandler(this.btn_imageMeasure_Click);
            // 
            // btn_imageMain
            // 
            this.btn_imageMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_imageMain.Location = new System.Drawing.Point(279, 9);
            this.btn_imageMain.Name = "btn_imageMain";
            this.btn_imageMain.Size = new System.Drawing.Size(100, 22);
            this.btn_imageMain.TabIndex = 19;
            this.btn_imageMain.Text = "Choose Image";
            this.btn_imageMain.UseVisualStyleBackColor = true;
            this.btn_imageMain.Click += new System.EventHandler(this.btn_imageMain_Click);
            // 
            // frmItemMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1023, 708);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.picbox);
            this.Controls.Add(this.dgvTester);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmItemMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Measurement Item Edit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmItemMaster_FormClosing);
            this.Load += new System.EventHandler(this.Form7_2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTester)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbox_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvTester;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDwr;
        private System.Windows.Forms.PictureBox picbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox picbox_main;
        private System.Windows.Forms.Button btn_imageMeasure;
        private System.Windows.Forms.Button btn_imageMain;
    }
}

