using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Security.Permissions;
using System.Collections;
using Npgsql;

namespace IPQC_Motor
{
    public partial class frmItemMaster : Form
    {
        public string Model;
        public string DrawingCd;
        public string User;
        // コンストラクタ
        public frmItemMaster(string drawing_cd, string user)
        {
            InitializeComponent();
            DrawingCd = drawing_cd;
            User = user;
        }

        // ロード時の処理
        private void Form7_2_Load(object sender, EventArgs e)
        {
            LoadItem();
        }
        public DataTable dt;
        public void LoadItem()
        {
            drw_txt.Text = DrawingCd;
            string sql = "select item_id,a.dwr_id , item_measure,  item_symbol,item_tool,item_row,item_detail,item_spec_x,  item_lower, item_upper   from m_item a left join m_drawing b on a.dwr_id = b.dwr_id where b.dwr_cd = '" + DrawingCd + "'  ";
            TfSQL tfSql = new TfSQL();
            dt = new DataTable();
            tfSql.sqlDataAdapterFillDatatable(sql, ref dt);

            dgvTester.DataSource = dt;

            //Fix DGV

            //dgvTester.Columns["item_id"].HeaderText = "Id";
            //dgvTester.Columns["dwr_cd"].HeaderText = "Drawing";
            dgvTester.Columns["item_id"].Visible = false;
            dgvTester.Columns["dwr_id"].Visible = false;
            dgvTester.Columns["item_measure"].HeaderText = "Measure Item";
            dgvTester.Columns["item_symbol"].HeaderText = "Symbol";
            dgvTester.Columns["item_spec_x"].HeaderText = "Spec";
            dgvTester.Columns["item_lower"].HeaderText = "Lower";
            dgvTester.Columns["item_upper"].HeaderText = "Upper";
            dgvTester.Columns["item_tool"].HeaderText = "Tool";
            dgvTester.Columns["item_detail"].HeaderText = "Detail";
            dgvTester.Columns["item_row"].HeaderText = "Row";

            dgvTester.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvTester.ReadOnly = false;
            dgvTester.AllowUserToAddRows = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
        }

        // 既存レコードの削除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTester.Rows.Count > 0)
            {
                int rowIndex = dgvTester.CurrentRow.Index;
                DialogResult dialog = MessageBox.Show("Do you want to delete Measure item no " + dgvTester.Rows[rowIndex].Cells["item_measure"].Value.ToString(), "Note !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    TfSQL tfsql = new TfSQL();
                    bool del = true;
                    //string dwr_cd = dgvTester.Rows[rowIndex].Cells["dwr_cd"].Value.ToString();
                    int item_measure = int.Parse(dgvTester.Rows[rowIndex].Cells["item_measure"].Value.ToString());
                    string sqlDelete = @"delete from m_item where dwr_id = (select dwr_id from m_drawing where dwr_cd = '" + DrawingCd +
                        "') and item_measure = " + item_measure;
                    tfsql.sqlExecuteNonQuery(sqlDelete, del);
                    LoadItem();
                }
            }
        }

        // 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            TfSQL tfsql = new TfSQL();

            bool save = tfsql.sqlMultipleInsertItem(DrawingCd, ref dt, User);
            if (save)
            {
                dgvTester.AllowUserToAddRows = false;
                dgvTester.ReadOnly = true;
                btnSave.Enabled = false;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
        private void dgvTester_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (btnAdd.Enabled == false)
            {
                TfSQL tf = new TfSQL();
                string itemId = tf.sqlExecuteScalarString("select max(item_id) +1 from m_item");
                string drwId = tf.sqlExecuteScalarString("select dwr_id from m_drawing where dwr_cd = '" + DrawingCd + "'");
                if (dgvTester.Rows.Count >= 1)
                {
                    dgvTester.Rows[dgvTester.Rows.Count - 2].Cells["item_id"].Value = itemId;
                    dgvTester.Rows[dgvTester.Rows.Count - 2].Cells["dwr_id"].Value = drwId;
                }
                else if (dgvTester.Rows.Count == 0)
                {
                    dgvTester.Rows[0].Cells["item_id"].Value = itemId;
                    dgvTester.Rows[0].Cells["dwr_id"].Value = drwId;
                }
            }
        }

        private void frmItemMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                DialogResult dialog = MessageBox.Show("Data not saved !", "Note !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}