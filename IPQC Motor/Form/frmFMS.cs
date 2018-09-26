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
using System.IO;
namespace IPQC_Part
{
    public partial class frmFMS : Form
    {
        public string username;
        public string drawingcd;
        public int pageid = 2;
        public int csvMeasure;
        public double csvData;
        public int k = 0;
        DataTable dtInspectItems;
        public frmFMS(int PageId,string username_, string drawingcd_)
        {
            InitializeComponent();
            username = username_;
            drawingcd = drawingcd_;
            txtUser.Text = username;
            gpbBanVe.Text = "Bản Vẽ Số: " + drawingcd;
            pageid = PageId;
        }
        void callpic()
        {
            IPQC_Motor.TfSQL tfSql = new IPQC_Motor.TfSQL();
            string bytePic = tfSql.sqlExecuteScalarString("select dwr_image from m_drawing where dwr_cd = '" + drawingcd + "'");
            if (bytePic != "")
            {
                byte[] imgBytes = Convert.FromBase64String(bytePic);
                MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                ms.Write(imgBytes, 0, imgBytes.Length);
                Image image = Image.FromStream(ms, true);

                picbox.Image = image;
                picbox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void frmFMS_Load(object sender, EventArgs e)
        {
            IPQC_Motor.TfSQL con = new IPQC_Motor.TfSQL();
            if (pageid == 0)
            {
                string sqlProcedure = @"
            select distinct header_procedure from
            (select header_procedure, user_dept_cd from m_header a, m_user b where a.user_id = b.user_id)t, m_user a
            where a.user_dept_cd = t.user_dept_cd and a.user_name = '" + username + "' order by header_procedure";
                con.getComboBoxData(sqlProcedure, ref cmbQuiTrinh);

                string sqlMachine = @"
            select distinct header_machine from
            (select header_machine, user_dept_cd from m_header a, m_user b where a.user_id = b.user_id)t, m_user a
            where a.user_dept_cd = t.user_dept_cd and a.user_name = '" + username + "' order by header_machine";
                con.getComboBoxData(sqlMachine, ref cmbMaSo);

            }
            else
            {

                txtPageId.Text = pageid.ToString();
                string sqlHeaderMachine = "select distinct header_machine from m_header where page_id = '" + pageid + "'";
                cmbMaSo.Text = con.sqlExecuteScalarString(sqlHeaderMachine);
                cmbMaSo.Enabled = false;
                string sqlHeaderTime = "select distinct header_time from m_header where page_id = '" + pageid + "'";
                dtpKhungGio.Text = con.sqlExecuteScalarString(sqlHeaderTime);
                dtpKhungGio.Enabled = false;
                string sqlHeaderProcedure = "select distinct header_procedure from m_header where page_id = '" + pageid + "'";
                cmbQuiTrinh.Text = con.sqlExecuteScalarString(sqlHeaderProcedure);
                cmbQuiTrinh.Enabled = false;
                string sqlHeaderMethod = "select distinct header_method from m_header where page_id = '" + pageid + "'";
                cmbPhuongThuc.Text = con.sqlExecuteScalarString(sqlHeaderMethod);
                cmbPhuongThuc.Enabled = false;
                string sqlHeaderSample = "select distinct header_sample from m_header where page_id = '" + pageid + "'";
                cmbSLMau.Text = con.sqlExecuteScalarString(sqlHeaderSample);
                cmbSLMau.Enabled = false;
                string sqlHeaderArea = "select distinct header_area from m_header where page_id = '" + pageid + "'";
                cmbKhuVuc.Text = con.sqlExecuteScalarString(sqlHeaderArea);
                cmbKhuVuc.Enabled = false;
                string sqlHeaderContent = "select distinct header_content from m_header where page_id = '" + pageid + "'";
                txtNoiDung.Text = con.sqlExecuteScalarString(sqlHeaderContent);
                txtNoiDung.ReadOnly = true;
                string sqlDataCheck = "select distinct data_check from m_data where page_id = '" + pageid + "'";
                cmbNgoaiQuan.Text = con.sqlExecuteScalarString(sqlDataCheck);
                cmbNgoaiQuan.Enabled = false;


                buildDGV(ref dgvMeasureData);
            }

            //common
            callpic();

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
            if (cmbDanhGia.Text == "OK")
            {
                MessageBox.Show("Không thể đánh giá OK Khi chưa đo xong Hàng", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }

        void insertintodatabase()
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
                            (select " + pageId + @", a.item_id, a.item_lower, a.item_upper,'" + cmbNgoaiQuan.Text + @"',(select user_id from m_user where user_name= '" + username + @"'), now() from m_item a 
                            left join m_drawing b  on b.dwr_id = a.dwr_id
                            where 
                            b.dwr_cd = '" + drawingcd + "')";
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
                command2.Parameters.Add(new NpgsqlParameter("page_id", NpgsqlTypes.NpgsqlDbType.Integer));          //12

                //header design
                command2.Parameters[0].Value = cmbMaSo.Text;
                command2.Parameters[1].Value = dtpKhungGio.Text;
                command2.Parameters[2].Value = cmbQuiTrinh.Text;
                command2.Parameters[3].Value = cmbPhuongThuc.Text;
                command2.Parameters[4].Value = int.Parse(cmbSLMau.Text);
                command2.Parameters[5].Value = cmbKhuVuc.Text;
                command2.Parameters[6].Value = txtNoiDung.Text;
                //footder design
                command2.Parameters[7].Value = txtGhiChu.Text;
                command2.Parameters[8].Value = cmbDanhGia.Text;
                command2.Parameters[9].Value = DateTime.Parse(dtpGiaCong.Value.ToString("yyyy-MM-dd"));
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
        void buildDGV(ref DataGridView dgv)
        {
            //create datagipview
            dtInspectItems = new DataTable();
            dtInspectItems.Clear();
            StringBuilder sql = new StringBuilder();
            sql.Append(@"
                        select a.item_measure, a.item_detail, a.item_spec_x, a.item_lower, a.item_upper,
                       (a.item_upper  - a.item_spec_x) as tolerance_up , (a.item_lower  - a.item_spec_x) as tolerances_low,a.item_tool,  
                        b.data_1, b.data_2, b.data_3, b.data_4, b.data_5, b.data_x, b.data_est, b.registration_date_time   from m_item a left join
                        (select dwr_cd,dwr_id, user_dept_cd from m_drawing a, m_user b where a.user_id = b.user_id) c on a.dwr_id = c.dwr_id
                        left join m_data b on a.item_id = b.item_id where c.dwr_cd = '" + drawingcd + "' and c.user_dept_cd = (select distinct user_dept_cd from m_user where user_name = '" + username + @"')");
            if (pageid > 0)
            {
                sql.Append(" and page_id = '" + pageid + "'");
            }
            sql.Append("order by registration_date_time desc, item_measure asc ");
            IPQC_Motor.TfSQL con = new IPQC_Motor.TfSQL();
            con.sqlDataAdapterFillDatatable(sql.ToString(), ref dtInspectItems);
            dgv.DataSource = dtInspectItems;
        }
        private void defineItemTable(ref DataTable dt)
        {
            dt.Columns.Add("item_measure", Type.GetType("System.String"));//0
            dt.Columns.Add("item_detail", Type.GetType("System.String"));//1
            dt.Columns.Add("item_spec_x", Type.GetType("System.String"));//2
            dt.Columns.Add("item_lower", Type.GetType("System.Double"));//3
            dt.Columns.Add("item_upper", Type.GetType("System.Double"));//4
            dt.Columns.Add("tolerance_up", Type.GetType("System.Double"));//5
            dt.Columns.Add("tolerances_low", Type.GetType("System.Double"));//6
            dt.Columns.Add("item_tool", Type.GetType("System.String"));//7
            dt.Columns.Add("data_1", Type.GetType("System.Double"));//8
            dt.Columns.Add("data_2", Type.GetType("System.Double"));//9
            dt.Columns.Add("data_3", Type.GetType("System.Double"));//10
            dt.Columns.Add("data_4", Type.GetType("System.Double"));//11
            dt.Columns.Add("data_5", Type.GetType("System.Double"));//12
            dt.Columns.Add("data_x", Type.GetType("System.Double"));//13
            dt.Columns.Add("data_est", Type.GetType("System.String"));//14
            dt.Columns.Add("registration_date_time", Type.GetType("System.DateTime"));
        }
        private void btnTaoForm_Click(object sender, EventArgs e)
        {
            if (pageid == 0)
            {
                IPQC_Motor.TfSQL con = new IPQC_Motor.TfSQL();
                string sqlPageID = "select case when max(page_id) is null then 1 else max(page_id) +1 end as maxcode from  m_header";
                txtPageId.Text = con.sqlExecuteScalarString(sqlPageID);
                if (checkdata())
                {

                    //insert data  
                    insertintodatabase();
                    buildDGV(ref dgvMeasureData);
                }
                else
                {
                    MessageBox.Show("Chọn đầy đủ thông tin có dấu (*) ", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Ban đang ở thuộc tính Đo Tiếp. Thoát Form nay và login với New Form để tạo Form", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (checkdataMeasure())
            {
                TimeFMS.Enabled = true;
            }
            else
            {
                readcsvFMS();
            }
        }
        bool checkdataMeasure()
        {
            if (dgvMeasureData.RowCount == 0)
                return false;
            if (cmbDongMay.SelectedItem == null)
            {
                return false;
            }
            return true;
        }

        private void TimeFMS_Tick(object sender, EventArgs e)
        {
            TimeFMS.Interval = 10000;
            readcsvFMS();
        }
        public int col = 8;
        public void readcsvFMS()
        {
            var reader = new StreamReader(@"D:\EMAX.csv");
            StringBuilder searchList = new StringBuilder();
            //col = 8;//8 <==> data_1
            string[] mang;
            DataTable dtt = new DataTable();
            dtt.Columns.Add("ItemMeasure",typeof(string));
            dtt.Columns.Add("ItemData", typeof(string));
            while (!reader.EndOfStream)
            {
                mang = reader.ReadLine().Split(',');
                DataRow dr = dtt.NewRow();
                dr[0] = mang[0];
                dr[1] = mang[6];
                dtt.Rows.Add(dr);
            }

            for (int j = 1; j < dtt.Rows.Count; j++)//add value from emax.csv to dgvMeasure
            {
                for (int i = 0; i < dgvMeasureData.RowCount; i++)
                {
                    if(dtt.Rows[j]["ItemMeasure"].ToString() == dgvMeasureData.Rows[i].Cells["item_measure"].Value.ToString())
                    {
                        dgvMeasureData.Rows[i].Cells[col].Value = dtt.Rows[j]["ItemData"].ToString();
                    }
                }
            }
        }

        /*get no column dgvMeasure
            col data_1 ==> stt 8
            col data_2 ==> stt 9
            col data_3 ==> stt 10
            col data_4 ==> stt 11
            col data_5 ==> stt 12
            col data_x ==> stt 13
        */
        public int colTam;
        private void dgvMeasureData_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseCol = dgvMeasureData.HitTest(e.X, e.Y).ColumnIndex;
                if (currentMouseCol >= 8 && currentMouseCol <= 12)
                {
                    ContextMenu m = new ContextMenu();
                    MenuItem Mn = new MenuItem(string.Format("Add data no {0}", (currentMouseCol - 7).ToString()));
                    m.MenuItems.Add(Mn);
                    m.Show(dgvMeasureData, new Point(e.X, e.Y));
                    colTam = currentMouseCol;
                    Mn.Click += menuItem_Click;
                }                
            }
        }
        public void menuItem_Click(object sender,EventArgs e)
        {
            col = colTam;
        }
    }
}
