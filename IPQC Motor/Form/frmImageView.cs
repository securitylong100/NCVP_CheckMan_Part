using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
namespace IPQC_Part
{
    public partial class frmImageView : Form
    {
        public string bytePic;
        public string DrawingCd;
        public frmImageView(string drawingcd_,string bytePic_)
        {
            bytePic = bytePic_;
            DrawingCd = drawingcd_;
            InitializeComponent();
        }

        private void frmImageView_Load(object sender, EventArgs e)
        {
            this.Text = DrawingCd + " - Image View";
            if (bytePic != "")
            {
                byte[] imgBytes = Convert.FromBase64String(bytePic);
                MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                ms.Write(imgBytes, 0, imgBytes.Length);
                Image image = Image.FromStream(ms, true);

                picBox.Height = image.Height;
                picBox.Width = image.Width;
                this.Height = image.Height + 100;
                this.Width = image.Width + 50;

                picBox.Image = image;
                picBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}
