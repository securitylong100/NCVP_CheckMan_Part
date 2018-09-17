using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPQC_Part
{
    public partial class frmFMS : Form
    {
        public string username;
        public string drawingcd;
        public frmFMS(string username_, string drawingcd_)
        {
            InitializeComponent();
            username = username_;
            drawingcd = drawingcd_;
            txtUser.Text = username;

        }

        private void frmFMS_Load(object sender, EventArgs e)
        {

        }
    }
}
