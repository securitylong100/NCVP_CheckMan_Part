﻿using System;
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
        DataTable dtInspectItems;
        public frmItem(string username_)
        {
            InitializeComponent();
            username = username_;
        }
        private void frmItem_Load(object sender, EventArgs e)
        {

            TfSQL con = new TfSQL();
            string sql = @"
select distinct model_cd from(
select model_cd ,user_dept_cd from m_model a,m_user b where a.user_id = b.user_id )t,m_user a 
where a.user_dept_cd = t.user_dept_cd and a.user_name = '" + username + "'";

            con.getComboBoxData(sql, ref cmbModel);
            cmbModel.Text = "";
            txtUser.Text = username;
            dtInspectItems = new DataTable();
            string sqlpermision = "select distinct user_permision from m_user where user_name = '" + username+ "'";
            if (con.sqlExecuteScalarString(sqlpermision) == "admin")
            {
                btnEditMaster.Visible = true;
            }

        }

        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            TfSQL con = new TfSQL();
            string sql = "select distinct model_sub_cd from m_model  where model_cd = '" + cmbModel.Text + "' order by model_sub_cd";
            con.getComboBoxData(sql, ref cmbSubModel);
        }
        private void cmbSubModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtInspectItems = new DataTable();
            defineItemTable(ref dtInspectItems);
            updateDataGripViews(ref dgvMeasureItem, true);
        }

        private void defineItemTable(ref DataTable dt)
        {
            dt.Columns.Add("model", Type.GetType("System.String"));
            dt.Columns.Add("dwr_cd", Type.GetType("System.String"));
            dt.Columns.Add("dwr_name", Type.GetType("System.String"));
            dt.Columns.Add("doc_name", Type.GetType("System.String"));
            dt.Columns.Add("registration_date_time", Type.GetType("System.DateTime"));
        }
        DataGridViewButtonColumn colNew;
        DataGridViewButtonColumn colCon;
        public void updateDataGripViews(ref DataGridView dgv, bool load)
        {
            dgvMeasureItem.DataSource = null;
            dtInspectItems.Clear();
       
            string sql = @"select   b.model_sub_cd as model, a.dwr_cd, a.dwr_name, a.doc_name, a.registration_date_time from m_drawing a
                            left join m_model b on a.model_id = b.model_id
                            where
                        b.model_cd = '" + cmbModel.Text + "' and b.model_sub_cd = '" + cmbSubModel.Text + "' order by dwr_cd";
           // System.Diagnostics.Debug.Print(sql);
            TfSQL tf = new TfSQL();
            tf.sqlDataAdapterFillDatatable(sql, ref dtInspectItems);
            dgv.DataSource = dtInspectItems;
            if(dgv.RowCount > 0)
            {                
                colNew = new DataGridViewButtonColumn {
                    Text = "New",
                    UseColumnTextForButtonValue = true,
                    Width = 25};
                colCon = new DataGridViewButtonColumn {
                    Text = "Continue",
                    UseColumnTextForButtonValue = true,
                    Width = 25
                };
                dgv.Columns.Add(colNew);
                dgv.Columns.Add(colCon);
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnEditMaster_Click(object sender, EventArgs e)
        {
        if (dgvMeasureItem.RowCount > 0)
            {
                frmItemMaster frmitemM = new frmItemMaster(dgvMeasureItem.CurrentRow.Cells["dwr_cd"].Value.ToString(), username);
                frmitemM.ShowDialog();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPQC_Part.frmChangePass frmchangepass = new IPQC_Part.frmChangePass(username);
            frmchangepass.ShowDialog();
        }

        private void registerUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (username == "admin")
            {
                IPQC_Part.frmRegisterUser regisUser = new IPQC_Part.frmRegisterUser(username);
                regisUser.ShowDialog();
            }
            else
            {
                MessageBox.Show("Your have not permision", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }          
        }

        private void dgvMeasureItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string DrawingCd = dgvMeasureItem.CurrentRow.Cells[1].Value.ToString();
            DialogResult dialog = MessageBox.Show("Chọn \"Yes\" để đo tiếp  " + System.Environment.NewLine +
                             "\"No\" để đo mới", "Note", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (DialogResult.Yes == dialog)//Đo tiếp
            {
                IPQC_Part.frmContinue frmC = new IPQC_Part.frmContinue(DrawingCd,username);
                frmC.ShowDialog();
            }
            else if (DialogResult.No == dialog)//đo mới
            {
                IPQC_Part.frmFMS frmFMS = new IPQC_Part.frmFMS(0,username, DrawingCd);
                frmFMS.ShowDialog();
            }

           
            //IPQC_Part.frmFMS FMSfrm = new IPQC_Part.frmFMS(username, DrawingCd);
            //FMSfrm.ShowDialog();
             
        }

        private void dgvMeasureItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int curRow = dgvMeasureItem.CurrentRow.Index;
            if (dgvMeasureItem.Columns[e.ColumnIndex] == colNew && curRow >= 0)
            {

            }
        }
    }
}