using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IPQC_Part
{
    public partial class frmDrawing : Form
    {
        public string User;
        public frmDrawing(string user_)
        {
            User = user_;
            InitializeComponent();
        }

        private void frmModel_Load(object sender, EventArgs e)
        {
            string sqlCmbModel = @"select distinct model_cd from(select model_cd ,user_dept_cd from m_model a,m_user b where a.user_id = b.user_id )t,m_user a 
            where a.user_dept_cd = t.user_dept_cd and a.user_name = '" + User + "'";
            getCmb(sqlCmbModel, ref cmbModel);
        }
        public void getCmb(string sql, ref ComboBox cmb)
        {
            IPQC_Motor.TfSQL tf = new IPQC_Motor.TfSQL();
            tf.getComboBoxData(sql, ref cmb);
        }
        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlCmbModeSub = "select distinct model_sub_cd from m_model  where model_cd = '" + cmbModel.Text + "' order by model_sub_cd";
            getCmb(sqlCmbModeSub, ref cmbSubModel);
        }
        public DataTable dt;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            IPQC_Motor.TfSQL tf = new IPQC_Motor.TfSQL();
            dt = new DataTable();
            string sqlSearch = @"select b.model_id, b.model_sub_cd, a.dwr_cd, a.dwr_name, a.doc_name, a.registration_date_time,a.dwr_id from m_drawing a left join m_model b on a.model_id = b.model_id where 1=1 ";

            if (!String.IsNullOrEmpty(cmbModel.Text))
            {
                sqlSearch += " and b.model_cd = '" + cmbModel.Text + "'";
            }
            if (!String.IsNullOrEmpty(cmbSubModel.Text))
            {
                sqlSearch += " and b.model_sub_cd = '" + cmbSubModel.Text + "'";
            }
            if (!String.IsNullOrEmpty(txtDwr.Text))
            {
                sqlSearch += " and a.dwr_cd = '" + txtDwr.Text + "'";
            }
            sqlSearch += " order by b.model_id";
            tf.sqlDataAdapterFillDatatable(sqlSearch, ref dt);
            updateDGV(ref dgvDwr, ref dt);
        }

        public void updateDGV(ref DataGridView dgv, ref DataTable dt)
        {
            dgv.DataSource = dt;
            dgv.Columns["model_id"].Visible = false;
            dgv.Columns["model_sub_cd"].HeaderText = "Model Sub";
            dgv.Columns["dwr_cd"].HeaderText = "Drawing Code";
            dgv.Columns["dwr_name"].HeaderText = "Drawing Name";
            dgv.Columns["doc_name"].HeaderText = "Document Name";

            dgv.Columns["registration_date_time"].Visible = false;
            //dgv.Columns["dwr_id"].Visible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns["model_sub_cd"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv.Columns["dwr_cd"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv.Columns["dwr_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddDrawing add = new frmAddDrawing(User, "", "");
            add.ShowDialog();
            btnSearch_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDwr.RowCount > 0)
                {
                    string drawingId = dgvDwr.Rows[dgvDwr.CurrentRow.Index].Cells["dwr_id"].Value.ToString();
                    string modelId = dgvDwr.Rows[dgvDwr.CurrentRow.Index].Cells["model_id"].Value.ToString();
                    frmAddDrawing add = new frmAddDrawing(User, drawingId, modelId);
                    add.ShowDialog();
                    btnSearch_Click(sender, e);
                }
                else MessageBox.Show("Choose a Drawing", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Choose a Drawing", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDwr.RowCount > 0)
                {
                    int dwrlId = int.Parse(dgvDwr.Rows[dgvDwr.CurrentRow.Index].Cells["dwr_id"].Value.ToString());
                    IPQC_Motor.TfSQL tf = new IPQC_Motor.TfSQL();

                    string sqlDel = "delete from m_drawing where dwr_id = " + dwrlId;
                    DialogResult dialog = MessageBox.Show("Do you want to delete " + dgvDwr.Rows[dgvDwr.CurrentRow.Index].Cells["dwr_cd"].Value.ToString(), "Note !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialog == DialogResult.Yes)
                    {
                        tf.sqlExecuteNonQuery(sqlDel, false);
                        btnSearch_Click(sender, e);
                    }
                }
                else MessageBox.Show("Choose a Drawing", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            { MessageBox.Show("Choose a Drawing", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
    }
}
