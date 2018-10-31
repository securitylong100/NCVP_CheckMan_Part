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
    public partial class frmAddModel : Form
    {
        public string User;
        public string ModelId;
        public frmAddModel(string user_, string modelId_)
        {
            User = user_;
            ModelId = modelId_;
            InitializeComponent();
        }

        private void frmModel_Load(object sender, EventArgs e)
        {
            if(ModelId == "")
            {
                Text = "Add Model";
            }
            else
            {
                IPQC_Motor.TfSQL tf = new IPQC_Motor.TfSQL();
                string sqlModel = "select model_cd from m_model where model_id = " + int.Parse(ModelId);
                string sqlModelSub = "select model_sub_cd from m_model where model_id = " + int.Parse(ModelId);
                Text = "Update Model";
                txtModel.Enabled = false;
                txtModel.Text = tf.sqlExecuteScalarString(sqlModel);
                txtModelSub.Text = tf.sqlExecuteScalarString(sqlModelSub);
            }
        }
        public bool CheckDup()
        {
            IPQC_Motor.TfSQL tf = new IPQC_Motor.TfSQL();
            string sqldup = "select count(*) from m_model where model_cd = '" + txtModel.Text + "' and model_sub_cd ='" + txtModelSub.Text + "'";
            if (tf.sqlExecuteScalarDouble(sqldup) >=1)
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
                if (!CheckDup()) { MessageBox.Show("Model Sub exist in database!", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                {
                    bool show = false;
                    if (ModelId == "")
                    {
                        string sqlAdd = "Insert into m_model(model_id, model_cd, model_sub_cd, user_id, registration_date_time) values((select max(model_id)+1 from m_model),'" + txtModel.Text + "', '" + txtModelSub.Text + "', (select user_id from m_user where user_name ='" + User + "'), now())";
                        show = tf.sqlExecuteNonQuery(sqlAdd, false);
                    }
                    else
                    {
                        string sqlUpdate = "update m_model set model_sub_cd = '" + txtModelSub.Text + "', user_id = (select user_id from m_user where user_name = '" + User + "'), registration_date_time = now() where model_id = " + int.Parse(ModelId);
                        show = tf.sqlExecuteNonQuery(sqlUpdate, false);
                    }
                    if (show)
                    {
                        MessageBox.Show("Successful!", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else MessageBox.Show("Info is null", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public bool Check()
        {
            if (txtModel.Text == "") { return false; }
            if (txtModelSub.Text == "") { return false; }
            return true;
        }
    }
}
