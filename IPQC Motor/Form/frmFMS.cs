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
            string sql = "select distinct header_procedure from m_header order by header_procedure";
            IPQC_Motor.TfSQL con = new IPQC_Motor.TfSQL();
            con.getComboBoxData(sql, ref cmbQuiTrinh);
        }

        private void btnStartFMS_Click(object sender, EventArgs e)
        {
            if (checkdata ())
            {



            }

        }
        bool  checkdata()
        {
            //if (cmbProcedure.Text == "")
            //    return false;
            //if (cmbMethod.SelectedItem == null)
            //    return false;
            //if (cmbArea.SelectedItem == null)
            //    return false;
            //if (cmbMachineModel.Text == "")
            //    return false;
            return true;

        }

        private void dgvMeasureData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
 