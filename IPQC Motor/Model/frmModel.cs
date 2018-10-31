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
    public partial class frmModel : Form
    {
        public string User;
        public frmModel(string user_)
        {
            User = user_;
            InitializeComponent();
        }

        private void frmModel_Load(object sender, EventArgs e)
        {
            IPQC_Motor.TfSQL con = new IPQC_Motor.TfSQL();
            string sql = @"select distinct model_cd from(select model_cd ,user_dept_cd from m_model a,m_user b where a.user_id = b.user_id )t,m_user a 
            where a.user_dept_cd = t.user_dept_cd and a.user_name = '" + User + "'";
            
        }
        public DataTable dt;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            IPQC_Motor.TfSQL tf = new IPQC_Motor.TfSQL();
            dt = new DataTable();
            string sqlSearch = "select t.model_id, t.model_cd, t.model_sub_cd from m_user m,(select model_id,model_cd,model_sub_cd, user_dept_cd from m_model a,m_user b where a.user_id = b.user_id ) t where m.user_dept_cd = t.user_dept_cd and m.user_name ='" + User + "' ";

            if (!String.IsNullOrEmpty(txtModel.Text))
            {
                sqlSearch += " and t.model_cd = '" + txtModel.Text + "'";
            }
            if (!String.IsNullOrEmpty(txtModelSub.Text))
            {
                sqlSearch += " and t.model_sub_cd = '" + txtModelSub.Text + "'";
            }
            sqlSearch += " order by t.model_cd, t.model_id";
            tf.sqlDataAdapterFillDatatable(sqlSearch, ref dt);
            updateDGV(ref dgvModel, ref dt);
        }

        public void updateDGV(ref DataGridView dgv, ref DataTable dt)
        {
            dgv.DataSource = dt;

            dgv.Columns["model_id"].Visible = false;
            dgv.Columns["model_cd"].HeaderText = "Model";
            dgv.Columns["model_sub_cd"].HeaderText = "Model Sub";

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModel add = new frmAddModel(User,"");
            add.ShowDialog();
            btnSearch_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try {
                if (dgvModel.RowCount > 0)
                {
                    string modelId = dgvModel.Rows[dgvModel.CurrentRow.Index].Cells["model_id"].Value.ToString();
                    string modelsub = dgvModel.Rows[dgvModel.CurrentRow.Index].Cells["model_sub_cd"].Value.ToString();
                    frmAddModel add = new frmAddModel(User, modelId);
                    add.ShowDialog();
                    btnSearch_Click(sender, e);
                }
                else MessageBox.Show("Choose a Model Sub", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            { return; }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvModel.RowCount > 0)
                {
                    int modelId = int.Parse(dgvModel.Rows[dgvModel.CurrentRow.Index].Cells["model_id"].Value.ToString());
                    IPQC_Motor.TfSQL tf = new IPQC_Motor.TfSQL();

                    string sqlDel = "delete from m_model where model_id = " + modelId;
                    DialogResult dialog = MessageBox.Show("Do you want to delete " + dgvModel.Rows[dgvModel.CurrentRow.Index].Cells["model_sub_cd"].Value.ToString(), "Note !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialog == DialogResult.Yes)
                    {
                        tf.sqlExecuteNonQuery(sqlDel, false);
                        btnSearch_Click(sender, e);
                    }
                }
                else MessageBox.Show("Choose a Model", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { return; }
        }
    }
}
