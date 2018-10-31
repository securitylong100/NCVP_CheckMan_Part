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
        Image image;
        private void frmImageView_Load(object sender, EventArgs e)
        {
            this.Text = DrawingCd + " - Image View";
            if (bytePic != "")
            {
                byte[] imgBytes = Convert.FromBase64String(bytePic);
                MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                ms.Write(imgBytes, 0, imgBytes.Length);
                image = Image.FromStream(ms, true);
                
                picBox.SizeMode = PictureBoxSizeMode.Zoom;
                this.Height = image.Height;
                this.Width = image.Width;
                picBox.Image = image;
                picBox.Height = image.Height;
                picBox.Width = image.Width;
                if (image.Height > 730)
                {
                    this.Height = 725;
                    picBox.Height = 630;
                }                
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            RotatePic("L");
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            RotatePic("R");
        }

        public void RotatePic(string rotate)
        {
            if (rotate == "L") { image.RotateFlip(RotateFlipType.Rotate270FlipNone); }
            else if (rotate == "R") { image.RotateFlip(RotateFlipType.Rotate90FlipNone); }
            this.Height = image.Height;
            this.Width = image.Width;
            picBox.Image = image;
            if (image.Height > 730)
            {
                this.Height = 725;
                picBox.Height = 630;
            }
        }

        private void frmImageView_Resize(object sender, EventArgs e)
        {
            int w = panel1.Width;
            btnLeft.Location = new Point((w / 2) - 80); 
            btnRight.Location = new Point((w / 2) + 5);
            if (this.Width <= 200) { this.Width = 200; }
            if (this.Height <= 200) { this.Height = 200; }
        }
    }
}
