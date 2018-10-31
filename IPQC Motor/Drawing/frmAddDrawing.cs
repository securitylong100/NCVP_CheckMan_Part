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
    public partial class frmAddDrawing : Form
    {
        public string User;
        public string DrawingId;
        string ModelId;
        public frmAddDrawing(string user_, string drawingId_, string modelId_)
        {
            User = user_;
            DrawingId = drawingId_;
            ModelId = modelId_;
            InitializeComponent();
        }

        private void frmModel_Load(object sender, EventArgs e)
        {
            IPQC_Motor.TfSQL tf = new IPQC_Motor.TfSQL();
            if (DrawingId == "")
            {
                Text = "Add Drawing";
                string sqlCmbModel = @"select distinct model_cd from(select model_cd ,user_dept_cd from m_model a,m_user b where a.user_id = b.user_id )t,m_user a 
            where a.user_dept_cd = t.user_dept_cd and a.user_name = '" + User + "'";
                getCmb(sqlCmbModel, ref cmbModel);
            }
            else
            {
                Text = "Update Drawing";
                
                string sqlDwrCd = "select dwr_cd from m_drawing where dwr_id = " + int.Parse(DrawingId);
                string sqlDwrName = "select dwr_name from m_drawing where dwr_id = " + int.Parse(DrawingId);
                string sqlDoc = "select doc_name from m_drawing where dwr_id = " + int.Parse(DrawingId);
                string sqlModel = "select model_cd from m_model where model_id =" + int.Parse(ModelId);
                string sqlModelSub = "select model_sub_cd from m_model where model_id =" + int.Parse(ModelId);

                txtDwrCd.Text = tf.sqlExecuteScalarString(sqlDwrCd);
                txtDwrName.Text = tf.sqlExecuteScalarString(sqlDwrName);
                txtDoc.Text = tf.sqlExecuteScalarString(sqlDoc);
                cmbModel.SelectedText = tf.sqlExecuteScalarString(sqlModel);
                cmbModel.Text = tf.sqlExecuteScalarString(sqlModel);
                cmbSubModel.Text = tf.sqlExecuteScalarString(sqlModelSub);
                cmbSubModel.Enabled = false;
                cmbModel.Enabled = false;
            }
        }
        public void getCmb(string sql, ref ComboBox cmb)
        {
            IPQC_Motor.TfSQL tf = new IPQC_Motor.TfSQL();
            tf.getComboBoxData(sql, ref cmb);
        }
        public bool CheckDup()
        {
            IPQC_Motor.TfSQL tf = new IPQC_Motor.TfSQL();
            string sqldup = "select count(*) from m_drawing where dwr_cd = '" + txtDwrCd.Text + "'";
            if (tf.sqlExecuteScalarDouble(sqldup) >= 1)
            {
                return false;
            }
            return true;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                IPQC_Motor.TfSQL tf = new IPQC_Motor.TfSQL();
                if (!CheckDup()) { MessageBox.Show("Drawing Code exist in Database","Note",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
                else
                {
                    bool showMes = false;
                    if (DrawingId == "")
                    {
                        string sqlAdd = "Insert into m_drawing(model_id, dwr_cd, dwr_name, doc_name, user_id, registration_date_time) values(" + int.Parse(cmbSubModel.SelectedValue.ToString()) + ", '" + txtDwrCd.Text + "', '" + txtDwrName.Text + "', '" + txtDoc.Text + "', (select user_id from m_user where user_name ='" + User + "'), now())";
                        showMes = tf.sqlExecuteNonQuery(sqlAdd, false);
                    }
                    else
                    {
                        string sqlUpdate = "update m_drawing set dwr_cd = '" + txtDwrCd.Text + "', dwr_name = '" + txtDwrName.Text + "', doc_name = '" + txtDoc.Text + "', user_id = (select user_id from m_user where user_name = '" + User + "'), registration_date_time = now() where dwr_id = " + DrawingId;
                        showMes = tf.sqlExecuteNonQuery(sqlUpdate, false);
                    }
                    if (showMes)
                    {
                        MessageBox.Show("Successful!", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        public bool Check()
        {
            if (txtDwrCd.Text == "") { return false; }
            if (txtDwrName.Text == "") { return false; }
            if (txtDoc.Text == "") { return false; }
            return true;
        }
        private void cmbModel_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            IPQC_Motor.TfSQL tf = new IPQC_Motor.TfSQL();
            DataTable dtModel = new DataTable();
            string sqlCmbModeSub = "select model_sub_cd,model_id from m_model  where model_cd = '" + cmbModel.Text + "' order by model_sub_cd";
            tf.sqlDataAdapterFillDatatable(sqlCmbModeSub, ref dtModel);
            cmbSubModel.DataSource = dtModel;
            cmbSubModel.ValueMember = "model_id";
            cmbSubModel.DisplayMember = "model_sub_cd";
            cmbSubModel.Text = "";
        }
    }
}
