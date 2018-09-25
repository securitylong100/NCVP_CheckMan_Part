namespace IPQC_Part
{
    partial class frmContinue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContinue));
            this.listTV = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // listTV
            // 
            this.listTV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTV.Location = new System.Drawing.Point(0, 0);
            this.listTV.Name = "listTV";
            this.listTV.Size = new System.Drawing.Size(317, 295);
            this.listTV.TabIndex = 0;
            this.listTV.DoubleClick += new System.EventHandler(this.listTV_DoubleClick);
            // 
            // frmContinue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(317, 295);
            this.Controls.Add(this.listTV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmContinue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item";
            this.Load += new System.EventHandler(this.frmContinue_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView listTV;
    }
}

