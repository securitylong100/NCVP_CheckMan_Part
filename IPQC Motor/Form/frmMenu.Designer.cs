namespace IPQC_Part
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.button1 = new System.Windows.Forms.Button();
            this.item1_btn = new System.Windows.Forms.Button();
            this.item2_btn = new System.Windows.Forms.Button();
            this.item3_btn = new System.Windows.Forms.Button();
            this.item4_btn = new System.Windows.Forms.Button();
            this.item5_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // item1_btn
            // 
            this.item1_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item1_btn.Location = new System.Drawing.Point(3, 3);
            this.item1_btn.Name = "item1_btn";
            this.item1_btn.Size = new System.Drawing.Size(35, 35);
            this.item1_btn.TabIndex = 0;
            this.item1_btn.Text = "1";
            this.item1_btn.UseVisualStyleBackColor = true;
            this.item1_btn.Click += new System.EventHandler(this.item1_btn_Click);
            // 
            // item2_btn
            // 
            this.item2_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item2_btn.Location = new System.Drawing.Point(44, 3);
            this.item2_btn.Name = "item2_btn";
            this.item2_btn.Size = new System.Drawing.Size(35, 35);
            this.item2_btn.TabIndex = 1;
            this.item2_btn.Text = "2";
            this.item2_btn.UseVisualStyleBackColor = true;
            this.item2_btn.Click += new System.EventHandler(this.item2_btn_Click);
            // 
            // item3_btn
            // 
            this.item3_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item3_btn.Location = new System.Drawing.Point(85, 3);
            this.item3_btn.Name = "item3_btn";
            this.item3_btn.Size = new System.Drawing.Size(35, 35);
            this.item3_btn.TabIndex = 2;
            this.item3_btn.Text = "3";
            this.item3_btn.UseVisualStyleBackColor = true;
            this.item3_btn.Click += new System.EventHandler(this.item3_btn_Click);
            // 
            // item4_btn
            // 
            this.item4_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item4_btn.Location = new System.Drawing.Point(126, 3);
            this.item4_btn.Name = "item4_btn";
            this.item4_btn.Size = new System.Drawing.Size(35, 35);
            this.item4_btn.TabIndex = 3;
            this.item4_btn.Text = "4";
            this.item4_btn.UseVisualStyleBackColor = true;
            this.item4_btn.Click += new System.EventHandler(this.item4_btn_Click);
            // 
            // item5_btn
            // 
            this.item5_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item5_btn.Location = new System.Drawing.Point(167, 3);
            this.item5_btn.Name = "item5_btn";
            this.item5_btn.Size = new System.Drawing.Size(35, 35);
            this.item5_btn.TabIndex = 4;
            this.item5_btn.Text = "5";
            this.item5_btn.UseVisualStyleBackColor = true;
            this.item5_btn.Click += new System.EventHandler(this.item5_btn_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(205, 39);
            this.Controls.Add(this.item5_btn);
            this.Controls.Add(this.item4_btn);
            this.Controls.Add(this.item3_btn);
            this.Controls.Add(this.item2_btn);
            this.Controls.Add(this.item1_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmMenu";
            this.Text = "Click";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button item1_btn;
        private System.Windows.Forms.Button item2_btn;
        private System.Windows.Forms.Button item3_btn;
        private System.Windows.Forms.Button item4_btn;
        private System.Windows.Forms.Button item5_btn;
    }
}