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
        public void updateDataGripViews(ref DataGridView dgv, bool load)
        {
            dgv.DataSource = null;
            dgv.Columns.Clear();
            dtInspectItems.Clear();
            dgv.RowTemplate.MinimumHeight = 28;
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
                    Text = "Measure New",
                    UseColumnTextForButtonValue = true
                };
                colCon = new DataGridViewButtonColumn {
                    Text = "Continue",
                    UseColumnTextForButtonValue = true,
                };
                dgv.Columns.Add(colNew);
                dgv.Columns.Add(colCon);

                dgv.Columns["model"].HeaderText = "Model";
                dgv.Columns["dwr_cd"].HeaderText = "Drawing Code";
                dgv.Columns["dwr_name"].HeaderText = "Drawing Name";
                dgv.Columns["doc_name"].HeaderText = "Document";
                dgv.Columns["registration_date_time"].HeaderText = "Date";
                dgv.Columns[5].HeaderText = "New";
                dgv.Columns[6].HeaderText = "Continue";

                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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
                    TreeView(DrawingCd, dateNow.AddYears(-1).ToString(), dateNow.ToString(), 7);
                    boolTV = true;
                }
            }
        }
        private void TreeView(string dwr_cd, string dateFrom, string dateTo, int limit)
        {
            DataTable dtTreeNode = new DataTable();
            listTV.Nodes.Clear();
            IPQC_Motor.TfSQL tfSql = new IPQC_Motor.TfSQL();
            StringBuilder sqlTV = new StringBuilder();
            sqlTV.Append(@"select cast(a.registration_date_time as date) dates
                            from m_header a left join m_data b on a.page_id = b.page_id left join m_item c on b.item_id = c.item_id 
                            where c.dwr_id = (select dwr_id from m_drawing where dwr_cd = '" + dwr_cd + "') and a.registration_date_time >= '" + dateFrom.ToString() + 
                            "' and cast(a.registration_date_time as date) <= '" + dateTo.ToString() + "' group by dates order by dates desc limit " + limit);
            tfSql.sqlDataAdapterFillDatatable(sqlTV.ToString(), ref dtTreeNode);

            if (dtTreeNode.Rows.Count > 0)
            {
                TreeNode[] headerN = new TreeNode[dtTreeNode.Rows.Count];
                for (int i = 0; i < dtTreeNode.Rows.Count; i++)
                {
                    TreeNode tree = new TreeNode
                    {
                        Text = DateTime.Parse(dtTreeNode.Rows[i]["dates"].ToString()).ToString("yyyy-MM-dd"),
                        Tag = DateTime.Parse(dtTreeNode.Rows[i]["dates"].ToString()).ToString("yyyy-MM-dd")
                    };
                    headerN[i] = tree;
                    //listTV.Nodes.Add(child);
                    DataTable dtChildNode = new DataTable();
                    string sqlNodeChild = @"select * from (select a.page_id, header_machine, footer_result, cast(a.registration_date_time as date) dates,a.registration_date_time date 
                            from m_header a left join m_data b on a.page_id = b.page_id left join m_item c on b.item_id = c.item_id where c.dwr_id = (select dwr_id from m_drawing where dwr_cd = '" + dwr_cd + "') group by a.page_id,a.registration_date_time, header_machine, footer_result) tb where tb.dates = '" + headerN[i].Text + "'";
                    tfSql.sqlDataAdapterFillDatatable(sqlNodeChild, ref dtChildNode);

                    TreeNode[] headerchild = new TreeNode[dtChildNode.Rows.Count];
                    for (int j = 0; j < dtChildNode.Rows.Count; j++)
                    {
                        TreeNode childtree = new TreeNode
                        {
                            Text = "MM: " + dtChildNode.Rows[j]["header_machine"].ToString() + " -- Page Id: " + dtChildNode.Rows[j]["page_id"].ToString() + " " + dtChildNode.Rows[j]["footer_result"].ToString(),
                            Tag = dtChildNode.Rows[j]["page_id"].ToString(),
                            Checked = false,
                        };

                        headerchild[j] = childtree;

                        if (dtChildNode.Rows[j]["footer_result"].ToString() == "NG")
                        {
                            headerchild[j].BackColor = Color.Red;
                        }
                        else if (dtChildNode.Rows[j]["footer_result"].ToString() == "OK")
                        {
                            headerchild[j].Text = childtree.Text;
                        }
                        else headerchild[j].BackColor = Color.Yellow;

                        tree.Nodes.Add(childtree);
                    }
                    listTV.Nodes.Add(tree);
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
                        IPQC_Part.frmFMS from = new IPQC_Part.frmFMS(pageId, username, DrawingCd);
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
        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (boolTV) { TreeView(DrawingCd, dtpFromDate.Value.ToString(), dtpToDate.Value.ToString(), 30); }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (boolTV) { TreeView(DrawingCd, dtpFromDate.Value.ToString(), dtpToDate.Value.ToString(), 30); }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TreeView2(dtpFromDate.Value.ToString(), dtpToDate.Value.ToString(), 30);
        }
        private void TreeView2( string dateFrom, string dateTo, int limit)
        {
            DataTable dtTV = new DataTable();
            listTV.Nodes.Clear();
            IPQC_Motor.TfSQL tfSql = new IPQC_Motor.TfSQL();

            string sqlTreeDr = "select dwr_cd, dwr_name from m_drawing where model_id in (select model_id from m_model where model_sub_cd = '" + cmbSubModel.Text + "')";
            tfSql.sqlDataAdapterFillDatatable(sqlTreeDr, ref dtTV);
            if (dtTV.Rows.Count > 0)
            {
                TreeNode[] header = new TreeNode[dtTV.Rows.Count];
                for (int k = 0; k < dtTV.Rows.Count; k++)
                {
                    DataTable dtTreeNode = new DataTable();
                    string a = dtTV.Rows[k]["dwr_cd"].ToString();
                    header[k].Text = "Drawing CD: ";
                    header[k].Tag = dtTV.Rows[k]["dwr_cd"].ToString();

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
                            headerN[i].Text = DateTime.Parse(dtTreeNode.Rows[i]["dates"].ToString()).ToString("yyyy-MM-dd");
                            header[k].Nodes.Add(headerN[i].Text);

                            DataTable dtChildNode = new DataTable();
                            string sqlNodeChild = @"select * from (select a.page_id, header_machine, footer_result, cast(a.registration_date_time as date) dates,a.registration_date_time date 
                            from m_header a left join m_data b on a.page_id = b.page_id left join m_item c on b.item_id = c.item_id where c.dwr_id = (select dwr_id from m_drawing where dwr_cd = '" + header[k].Tag + "') group by a.page_id,a.registration_date_time, header_machine, footer_result) tb where tb.dates = '" + headerN[i].Text + "'";
                            tfSql.sqlDataAdapterFillDatatable(sqlNodeChild, ref dtChildNode);

                            TreeNode[] headerchild = new TreeNode[dtChildNode.Rows.Count];
                            for (int j = 0; j < dtChildNode.Rows.Count; j++)
                            {
                                headerchild[j].Text = "MM: " + dtChildNode.Rows[j]["header_machine"].ToString() + " -- Page Id: " + dtChildNode.Rows[j]["page_id"].ToString() + " " + dtChildNode.Rows[j]["footer_result"].ToString();
                                headerchild[j].Tag = dtChildNode.Rows[j]["page_id"].ToString();

                                if (dtChildNode.Rows[j]["footer_result"].ToString() == "NG")
                                {
                                    headerchild[j].BackColor = Color.Red;
                                }
                                else if (dtChildNode.Rows[j]["footer_result"].ToString() == "OK")
                                {

                                }
                                else headerchild[j].BackColor = Color.Yellow;

                                headerN[i].Nodes.Add(headerchild[j].Text);
                            }
                        }
                        listTV.Nodes.Add(header[k]);
                    }
                }
            }
        }
        private void TreeViewTimKiem()
        {
            if (cmbModel.Text.Length > 0 && cmbSubModel.Text.Length > 0)
            {
                DataTable dtTreeDrawing = new DataTable();
                listTV.Nodes.Clear();
                IPQC_Motor.TfSQL tfSql = new IPQC_Motor.TfSQL();
                string sqlDrawing = "select dwr_cd, dwr_name from m_drawing where model_id = (select model_id from m_model where model_sub_cd = '" + cmbSubModel.Text + "')";
                tfSql.sqlDataAdapterFillDatatable(sqlDrawing, ref dtTreeDrawing);
                if(dtTreeDrawing.Rows.Count > 0)
                {

                }
            }            
        }
    }
}