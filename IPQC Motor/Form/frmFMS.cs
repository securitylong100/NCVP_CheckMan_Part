using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

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
            gpbBanVe.Text = "Bản Vẽ Số: " + drawingcd;
        }

        private void frmFMS_Load(object sender, EventArgs e)
        {
            string sql = "select distinct header_procedure from m_header order by header_procedure";
            IPQC_Motor.TfSQL con = new IPQC_Motor.TfSQL();
            con.getComboBoxData(sql, ref cmbQuiTrinh);
        }


        bool checkdata()
        {
            if (cmbQuiTrinh.Text == "")
                return false;
            if (cmbSLMau.SelectedItem == null)
                return false;
            if (dtpKhungGio.Text == "")
                return false;
            if (cmbPhuongThuc.SelectedItem == null)
                return false;
            if (cmbKhuVuc.SelectedItem == null)
                return false;
            if (cmbNgoaiQuan.SelectedItem == null)
                return false;
            if (txtUser.Text == "")
                return false;
            return true;

        }

        void insertheader()
        {
            NpgsqlConnection connection = new NpgsqlConnection(IPQC_Motor.TfSQL.conStringIpqcDbP4);
            connection.Open();
           try
            {
                //create page id
                string sqlPageID = "select case when max(page_id) is null then 1 else max(page_id) +1 end as maxcode from  m_header";
                NpgsqlCommand commandPageId = new NpgsqlCommand(sqlPageID, connection);
                int pageId = int.Parse(commandPageId.ExecuteScalar().ToString());

                //insert into m_data
                string sql1 = @"insert into m_data
                            (page_id, item_id, item_lower, item_upper, data_check, user_id, registration_date_time )
                            (select " + pageId+@", a.item_id, a.item_lower, a.item_upper,'"+ cmbNgoaiQuan.Text+ @"',(select user_id from m_user where user_name= '"+ username+@"'), now() from m_item a 
                            left join m_drawing b  on b.dwr_id = a.dwr_id
                            where 
                            b.dwr_cd = '"+ drawingcd+ "')";
                NpgsqlCommand command1 = new NpgsqlCommand(sql1, connection);
                command1.ExecuteScalar();

                //insert into m_header table.
                string sql2 = @"insert into m_header(page_id, header_machine , header_time,  header_procedure, header_method, header_sample,header_area,
                                header_content, footer_note, footer_result, footer_datemake, footer_lot, user_id, registration_date_time) 
                                VALUES (:page_id,
                                 :header_machine, :header_time, :header_procedure, :header_method, :header_sample, :header_area,
                                 :header_content, :footer_note, :footer_result, :footer_datemake, :footer_lot, (select user_id from m_user where user_name= :user_name), now())";
                NpgsqlCommand command2 = new NpgsqlCommand(sql2, connection);

                command2.Parameters.Add(new NpgsqlParameter("header_machine", NpgsqlTypes.NpgsqlDbType.Varchar));    //0
                command2.Parameters.Add(new NpgsqlParameter("header_time", NpgsqlTypes.NpgsqlDbType.Varchar));       // 1
                command2.Parameters.Add(new NpgsqlParameter("header_procedure", NpgsqlTypes.NpgsqlDbType.Varchar));  //2
                command2.Parameters.Add(new NpgsqlParameter("header_method", NpgsqlTypes.NpgsqlDbType.Varchar));     //3
                command2.Parameters.Add(new NpgsqlParameter("header_sample", NpgsqlTypes.NpgsqlDbType.Integer));     //4
                command2.Parameters.Add(new NpgsqlParameter("header_area", NpgsqlTypes.NpgsqlDbType.Varchar));      //5
                command2.Parameters.Add(new NpgsqlParameter("header_content", NpgsqlTypes.NpgsqlDbType.Varchar));   //6
                command2.Parameters.Add(new NpgsqlParameter("footer_note", NpgsqlTypes.NpgsqlDbType.Varchar));      //7
                command2.Parameters.Add(new NpgsqlParameter("footer_result", NpgsqlTypes.NpgsqlDbType.Varchar));    //8
                command2.Parameters.Add(new NpgsqlParameter("footer_datemake", NpgsqlTypes.NpgsqlDbType.Date));     //9
                command2.Parameters.Add(new NpgsqlParameter("footer_lot", NpgsqlTypes.NpgsqlDbType.Varchar));       //10
                command2.Parameters.Add(new NpgsqlParameter("user_name", NpgsqlTypes.NpgsqlDbType.Varchar));        //11
                command2.Parameters.Add(new NpgsqlParameter("page_id", NpgsqlTypes.NpgsqlDbType.Integer));

                //header design
                command2.Parameters[0].Value = cmbMaSoMay.Text;
                command2.Parameters[1].Value = dtpKhungGio.Text;
                command2.Parameters[2].Value = cmbQuiTrinh.Text;
                command2.Parameters[3].Value = cmbPhuongThuc.Text;
                command2.Parameters[4].Value = int.Parse(cmbSLMau.Text);
                command2.Parameters[5].Value = cmbKhuVuc.Text;
                command2.Parameters[6].Value = txtNoiDung.Text;
                //footder design
                command2.Parameters[7].Value = txtGhiChu.Text;
                command2.Parameters[8].Value = cmbDanhGia.Text;
                command2.Parameters[9].Value =DateTime.Parse( dtpGiaCong.Value.ToString("yyyy-MM-dd"));
                command2.Parameters[10].Value = txtLot.Text;
                command2.Parameters[11].Value = username;
                command2.Parameters[12].Value = pageId;


                command2.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Successful!", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Database not connected + " + ex.ToString(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }
        private void btnTaoForm_Click(object sender, EventArgs e)
        {
           
            if (checkdata())
            {
                //inser to header table
                insertheader();

               

            }
            else
            {
                MessageBox.Show("Chọn đầy đủ thông tin có dấu (*) ", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }
    }
}
