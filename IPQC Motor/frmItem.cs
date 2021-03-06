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
            string sql = @"select distinct model_cd from(select model_cd ,user_dept_cd from m_model a,m_user b where a.user_id = b.user_id )t,m_user a 
            where a.user_dept_cd = t.user_dept_cd and a.user_name = '" + username + "'";

            con.getComboBoxData(sql, ref cmbModel);
            cmbModel.Text = "";
            txtUser.Text = username;
            dtInspectItems = new DataTable();
            dtpFromDate.Value = DateTime.Now.AddDays(-7);
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
            //defineItemTable(ref dtInspectItems);
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
        DataGridViewButtonColumn colEdit;
        public void updateDataGripViews(ref DataGridView dgv, bool load)
        {
            dgv.Columns.Clear();
            dtInspectItems.Clear();
            dgv.RowTemplate.MinimumHeight = 28;
            string sql = @"select b.model_sub_cd as model, a.dwr_cd, a.dwr_name, a.doc_name, a.registration_date_time,a.dwr_id from m_drawing a
                            left join m_model b on a.model_id = b.model_id
                            where b.model_cd = '" + cmbModel.Text + "' and b.model_sub_cd = '" + cmbSubModel.Text + "' order by dwr_cd";
            TfSQL tf = new TfSQL();
            tf.sqlDataAdapterFillDatatable(sql, ref dtInspectItems);
            dgv.DataSource = dtInspectItems;
            if (dgv.RowCount > 0)
            {
                colNew = new DataGridViewButtonColumn
                {
                    Text = "Measure New",
                    UseColumnTextForButtonValue = true,
                };
                colCon = new DataGridViewButtonColumn
                {
                    Text = "Continue",
                    UseColumnTextForButtonValue = true,
                };
                colEdit = new DataGridViewButtonColumn
                {
                    Text = "Edit",
                    UseColumnTextForButtonValue = true,
                };
                dgv.Columns.Add(colNew);
                dgv.Columns.Add(colCon);

                string sqlpermision = "select distinct user_permision from m_user where user_name = '" + username + "'";
                if (tf.sqlExecuteScalarString(sqlpermision) == "admin")
                {
                    dgv.Columns.Add(colEdit);
                    dgv.Columns[8].HeaderText = "Edit";
                }

                dgv.Columns["model"].HeaderText = "Model";
                dgv.Columns["dwr_cd"].HeaderText = "Drawing Code";
                dgv.Columns["dwr_name"].HeaderText = "Drawing Name";
                dgv.Columns["doc_name"].HeaderText = "Document";
                dgv.Columns["registration_date_time"].HeaderText = "Date";
                dgv.Columns[6].HeaderText = "New";
                dgv.Columns[7].HeaderText = "Continue";

                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgv.Columns[4].Visible = false;
                dgv.Columns[5].Visible = false;
                dgv.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPQC_Part.frmChangePass frmchangepass = new IPQC_Part.frmChangePass(username);
            frmchangepass.ShowDialog();
        }

        private void registerUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TfSQL tf = new TfSQL();
            string pemission = tf.sqlExecuteScalarString("select distinct user_permision from m_user where user_name = '" + username + "'");
            if (pemission == "admin")
            {
                IPQC_Part.frmRegisterUser regisUser = new IPQC_Part.frmRegisterUser(username);
                regisUser.ShowDialog();
            }
            else
            {
                MessageBox.Show("Your have not permision", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        public string DrawingCd;
        private void dgvMeasureItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMeasureItem.RowCount > 0)
            {
                int curRow = dgvMeasureItem.CurrentRow.Index;
                DrawingCd = dgvMeasureItem.CurrentRow.Cells[1].Value.ToString();
                if (dgvMeasureItem.Columns[e.ColumnIndex] == colNew && curRow >= 0)//đo mới
                {
                    IPQC_Part.frmFMS frmFMS = new IPQC_Part.frmFMS(0, username, DrawingCd);
                    this.Hide();
                    frmFMS.ShowDialog();
                    this.Show();
                }
                else if (dgvMeasureItem.Columns[e.ColumnIndex] == colCon && curRow >= 0)//đo tiep
                {
                    DateTime dateNow = DateTime.Now;
                    //TreeView(DrawingCd, dateNow.AddYears(-1).ToString(), dateNow.ToString(), 7);
                    TreeView2(DrawingCd, dtpFromDate.Value.ToString(), dtpToDate.Value.ToString(), 7, true);
                    boolTV = true;
                }
                else if (dgvMeasureItem.Columns[e.ColumnIndex] == colEdit && curRow >= 0)//edit ban ve
                {
                    frmItemMaster frmitemM = new frmItemMaster(int.Parse(dgvMeasureItem.CurrentRow.Cells["dwr_id"].Value.ToString()), dgvMeasureItem.CurrentRow.Cells["dwr_cd"].Value.ToString(), dgvMeasureItem.CurrentRow.Cells["dwr_name"].Value.ToString(), dgvMeasureItem.CurrentRow.Cells["doc_name"].Value.ToString(), username);
                    this.Hide();
                    frmitemM.ShowDialog();
                    this.Show();
                    cmbSubModel_SelectedIndexChanged(sender, e);
                }
            }
        }
        private void listTV_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int pageId = 0;
                if (int.TryParse(listTV.SelectedNode.Tag.ToString(), out pageId))
                {
                    IPQC_Motor.TfSQL tf = new IPQC_Motor.TfSQL();
                    string tagNode = "select count(*) from m_header where page_id = " + pageId;
                    long checkPage = tf.sqlExecuteScalarLong(tagNode);

                    if (checkPage > 0)
                    {
                        string[] a = listTV.SelectedNode.FullPath.ToString().Split('\\');
                        string DWRCd = a[0];
                        IPQC_Part.frmFMS from = new IPQC_Part.frmFMS(pageId, username, DWRCd);
                        this.Hide();
                        from.ShowDialog();
                        this.Show();
                    }
                }
                else MessageBox.Show("Hãy chọn một mã máy !", "Note!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { return; }
        }

        public bool boolTV = false;

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TreeView2("", dtpFromDate.Value.ToString(), dtpToDate.Value.ToString(), 30, false);
        }
        private void TreeView2(string DwrCd, string dateFrom, string dateTo, int limit, bool showDrawing)
        {
            DataTable dtTV = new DataTable();
            listTV.Nodes.Clear();
            IPQC_Motor.TfSQL tfSql = new IPQC_Motor.TfSQL();

            string sqlTreeDr = "select dwr_cd, dwr_name from m_drawing where model_id in (select model_id from m_model where model_sub_cd = '" + cmbSubModel.Text + "') ";
            if (showDrawing)
            {
                sqlTreeDr += " and dwr_cd = '" + DwrCd + "' ";
            }
            sqlTreeDr += " order by dwr_cd";
            tfSql.sqlDataAdapterFillDatatable(sqlTreeDr, ref dtTV);
            if (dtTV.Rows.Count > 0)
            {
                TreeNode[] header = new TreeNode[dtTV.Rows.Count];
                for (int k = 0; k < dtTV.Rows.Count; k++)
                {
                    DataTable dtTreeNode = new DataTable();
                    TreeNode treeheader = new TreeNode
                    {
                        Text = dtTV.Rows[k]["dwr_cd"].ToString(),
                        Tag = dtTV.Rows[k]["dwr_cd"].ToString()
                    };
                    header[k] = treeheader;

                    if (showDrawing) { header[k].Expand(); }

                    StringBuilder sqlTV = new StringBuilder();
                    sqlTV.Append(@"select cast(a.registration_date_time as date) dates
                            from m_header a left join m_data b on a.page_id = b.page_id left join m_item c on b.item_id = c.item_id 
                            where c.dwr_id = (select dwr_id from m_drawing where dwr_cd = '" + header[k].Tag + "') and a.registration_date_time >= '" + dateFrom.ToString() +
                                    "' and cast(a.registration_date_time as date) <= '" + dateTo.ToString() + "' group by dates order by dates desc limit " + limit);
                    tfSql.sqlDataAdapterFillDatatable(sqlTV.ToString(), ref dtTreeNode);

                    if (dtTreeNode.Rows.Count > 0)
                    {
                        TreeNode[] headerN = new TreeNode[dtTreeNode.Rows.Count];
                        for (int i = 0; i < dtTreeNode.Rows.Count; i++)
                        {
                            TreeNode treeheaderN = new TreeNode
                            {
                                Text = DateTime.Parse(dtTreeNode.Rows[i]["dates"].ToString()).ToString("yyyy-MM-dd"),
                            };
                            headerN[i] = treeheaderN;
                            header[k].Nodes.Add(treeheaderN);

                            DataTable dtChildNode = new DataTable();
                            string sqlNodeChild = @"select * from (select a.page_id, header_machine, footer_result, cast(a.registration_date_time as date) dates,a.registration_date_time date 
                            from m_header a left join m_data b on a.page_id = b.page_id left join m_item c on b.item_id = c.item_id where c.dwr_id = (select dwr_id from m_drawing where dwr_cd = '" + header[k].Tag + "') group by a.page_id,a.registration_date_time, header_machine, footer_result) tb where tb.dates = '" + headerN[i].Text + "'";
                            tfSql.sqlDataAdapterFillDatatable(sqlNodeChild, ref dtChildNode);

                            TreeNode[] headerchild = new TreeNode[dtChildNode.Rows.Count];
                            for (int j = 0; j < dtChildNode.Rows.Count; j++)
                            {
                                TreeNode treeheaderchild = new TreeNode
                                {
                                    Text = "MM: " + dtChildNode.Rows[j]["header_machine"].ToString() + " -- Page Id: " + dtChildNode.Rows[j]["page_id"].ToString() + " " + dtChildNode.Rows[j]["footer_result"].ToString(),
                                    Tag = dtChildNode.Rows[j]["page_id"].ToString()
                                };

                                headerchild[j] = treeheaderchild;

                                if (dtChildNode.Rows[j]["footer_result"].ToString() == "NG")
                                {
                                    headerchild[j].BackColor = Color.Red;
                                }
                                else if (dtChildNode.Rows[j]["footer_result"].ToString() == "OK")
                                {

                                }
                                else headerchild[j].BackColor = Color.Yellow;

                                headerN[i].Nodes.Add(treeheaderchild);
                            }
                        }
                    }
                    listTV.Nodes.Add(header[k]);
                }
            }
        }
        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TfSQL tf = new TfSQL();
            string pemission = tf.sqlExecuteScalarString("select distinct user_permision from m_user where user_name = '" + username + "'");
            if (pemission == "admin")
            {
                IPQC_Part.frmModel modelfrm = new IPQC_Part.frmModel(username);
                modelfrm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Your have not permision", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void drawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TfSQL tf = new TfSQL();
            string pemission = tf.sqlExecuteScalarString("select distinct user_permision from m_user where user_name = '" + username + "'");
            if (pemission == "admin")
            {
                IPQC_Part.frmDrawing dwrFrm = new IPQC_Part.frmDrawing(username);
                dwrFrm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Your have not permision", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}