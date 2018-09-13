using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Security.Permissions;
using Npgsql;
using System.Net;

namespace IPQC_Motor
{
    public partial class frmItem : Form
    {
        public string username;
        public frmItem()
        {
            InitializeComponent();
        }
        private void frmItem_Load(object sender, EventArgs e)
        {
            TfSQL con = new TfSQL();
            string sql = "select distinct model_cd from m_model order by user_name";
            con.getComboBoxData(sql, ref cmbUserName);
        }

        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}