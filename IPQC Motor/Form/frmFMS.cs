using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Npgsql;
using System.IO;
using System.IO.Ports;
using System.Threading;
namespace IPQC_Part
{
    public partial class frmFMS : Form
    {
        public string username;
        public string drawingcd;
        public int pageid;
  
        public DataTable dtInspectItems;
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
                string sqlDateDoHang = "select footer_datemake from m_header where page_id = '" + pageid + "'";
                dtpGiaCong.Value = DateTime.Parse(con.sqlExecuteScalarString(sqlDateDoHang));
                string sqlLot = "select footer_lot from m_header where page_id = '" + pageid + "'";
                txtLot.Text = con.sqlExecuteScalarString(sqlLot);
                string sqlDanhGia = "select footer_result from m_header where page_id = '" + pageid + "'";
                cmbDanhGia.Text = con.sqlExecuteScalarString(sqlDanhGia);

                buildDGV(ref dgvMeasureData);
                btnTaoForm.Enabled = false;
                AlarmColor();
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
            dtInspectItems = defineItemTable(ref dtInspectItems);
            StringBuilder sql = new StringBuilder();
            sql.Append(@"
                        select a.item_measure, a.item_spec_x, a.item_lower, a.item_upper,
                       (a.item_upper  - a.item_spec_x) as tolerance_up , (a.item_lower  - a.item_spec_x) as tolerances_low,a.item_tool, a.item_detail,  
                        b.data_1, b.data_2, b.data_3, b.data_4, b.data_5, b.data_x, b.data_est, b.registration_date_time,a.item_id   from m_item a left join
                        (select dwr_cd,dwr_id, user_dept_cd from m_drawing a, m_user b where a.user_id = b.user_id) c on a.dwr_id = c.dwr_id
                        left join m_data b on a.item_id = b.item_id where c.dwr_cd = '" + drawingcd + "' and c.user_dept_cd = (select distinct user_dept_cd from m_user where user_name = '" + username + @"')");
            if (pageid > 0)
            {
                sql.Append(" and page_id = '" + pageid + "'");
            }
            sql.Append("order by registration_date_time desc, item_measure,item_id asc ");
            IPQC_Motor.TfSQL con = new IPQC_Motor.TfSQL();
            con.sqlDataAdapterFillDatatable(sql.ToString(), ref dtInspectItems);
            dgv.DataSource = dtInspectItems;                
            if(dgv.Columns.Count > 0)
            {
                foreach (DataGridViewColumn cl in dgv.Columns) { cl.SortMode = DataGridViewColumnSortMode.NotSortable; };
                dgv.Columns["item_measure"].HeaderText = "Item";//0
                dgv.Columns["item_spec_x"].HeaderText = "Spec";//1
                dgv.Columns["item_lower"].HeaderText = "Lower";//2
                dgv.Columns["item_upper"].HeaderText = "Upper";//3
                dgv.Columns["tolerance_up"].HeaderText = "Tor Up";//4
                dgv.Columns["tolerance_up"].DefaultCellStyle.Format = "#,###0.###";
                dgv.Columns["tolerances_low"].HeaderText = "Tor Down";//5
                dgv.Columns["tolerances_low"].DefaultCellStyle.Format = "#,###0.###";
                dgv.Columns["item_tool"].HeaderText = "Tool";//6
                dgv.Columns["item_detail"].HeaderText = "Detail";//7
                dgv.Columns["data_1"].HeaderText = "SP1";//8
                dgv.Columns["data_2"].HeaderText = "SP2";//9
                dgv.Columns["data_3"].HeaderText = "SP3";//10
                dgv.Columns["data_4"].HeaderText = "SP4";//11
                dgv.Columns["data_5"].HeaderText = "SP5";//12
                dgv.Columns["data_x"].HeaderText = "SPX";//13
                dgv.Columns["data_est"].HeaderText = "EST";//14
                dgv.Columns["data_est"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["registration_date_time"].HeaderText = "Date Time";//15
                dgv.Columns["item_id"].Visible = false;
                
                dgv.Columns["registration_date_time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            AlarmColor();
        }
        private DataTable defineItemTable(ref DataTable dt)
        {
            dt.Columns.Add("item_measure", Type.GetType("System.String"));//0
            dt.Columns.Add("item_spec_x", Type.GetType("System.String"));//1
            dt.Columns.Add("item_lower", Type.GetType("System.Double"));//2
            dt.Columns.Add("item_upper", Type.GetType("System.Double"));//3
            dt.Columns.Add("tolerance_up", Type.GetType("System.Double"));//4
            dt.Columns.Add("tolerances_low", Type.GetType("System.Double"));//5
            dt.Columns.Add("item_tool", Type.GetType("System.String"));//6
            dt.Columns.Add("item_detail", Type.GetType("System.String"));//7
            dt.Columns.Add("data_1", Type.GetType("System.String"));//8
            dt.Columns.Add("data_2", Type.GetType("System.String"));//9
            dt.Columns.Add("data_3", Type.GetType("System.String"));//10
            dt.Columns.Add("data_4", Type.GetType("System.String"));//11
            dt.Columns.Add("data_5", Type.GetType("System.String"));//12
            dt.Columns.Add("data_x", Type.GetType("System.Double"));//13
            dt.Columns.Add("data_est", Type.GetType("System.String"));//14
            dt.Columns.Add("registration_date_time", Type.GetType("System.DateTime"));

            return dt;
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
                    pageid = int.Parse(txtPageId.Text);
                    buildDGV(ref dgvMeasureData);
                    btnTaoForm.Enabled = false;
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
        public string SaveEmax = @"D:\EMAX.csv";
        public void readcsvFMS(int column)
        {
            if (File.Exists(SaveEmax))
            {
                var reader = new StreamReader(SaveEmax);
                string[] mang;
                DataTable dtt = new DataTable();
                dtt.Columns.Add("ItemMeasure", typeof(string));
                dtt.Columns.Add("ItemData", typeof(string));
                while (!reader.EndOfStream)
                {
                    mang = reader.ReadLine().Split(',');
                    DataRow dr = dtt.NewRow();
                    dr[0] = mang[0];
                    dr[1] = mang[6];
                    dtt.Rows.Add(dr);
                }
                reader.Close();
                int rowdtt = 1;
                for (int i = 0; i < dgvMeasureData.RowCount; i++)
                {
                    if (dtt.Rows.Count > 0 && rowdtt < dtt.Rows.Count)
                    {
                        if (dtt.Rows[rowdtt]["ItemMeasure"].ToString() == dgvMeasureData.Rows[i].Cells["item_measure"].Value.ToString() && dgvMeasureData.Rows[i].Cells["item_tool"].Value.ToString() == "FMS")
                        {
                            if (dgvMeasureData.Rows[i].Cells["item_detail"].Value.ToString() == "MIN" || dgvMeasureData.Rows[i].Cells["item_detail"].Value.ToString() == "MAX")
                            {
                                double datai = double.Parse(dtt.Rows[rowdtt]["ItemData"].ToString());
                                dgvMeasureData.Rows[i].Cells[column].Value = datai;
                                if (rowdtt < dtt.Rows.Count - 1)//kiem tra dtt đến dong cuối chưa 
                                {
                                    double dataii = double.Parse(dtt.Rows[rowdtt + 1]["ItemData"].ToString());//lay gia tri dong ke tiep
                                    double max = datai > dataii ? datai : dataii;//get max
                                    double min = datai > dataii ? dataii : datai;//get min
                                    dgvMeasureData.Rows[i].Cells[column].Value = (dgvMeasureData.Rows[i].Cells["item_detail"].Value.ToString() == "MAX") ? max : min;
                                    dgvMeasureData.Rows[i + 1].Cells[column].Value = (dgvMeasureData.Rows[i + 1].Cells["item_detail"].Value.ToString() == "MAX") ? max : min;
                                    i++;
                                    rowdtt++;
                                }
                            }
                            else dgvMeasureData.Rows[i].Cells[column].Value = dtt.Rows[rowdtt]["ItemData"].ToString();
                            rowdtt++;
                        }
                    }
                }
                File.Delete(SaveEmax);
                CalculatorDataX();
            }
            else {
                MessageBox.Show("Chưa khởi tạo file EMAX !", "NOTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void deleteEmax()
        {
            File.Delete(SaveEmax);
        }
        public int colTam;
        private void dgvMeasureData_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseCol = dgvMeasureData.HitTest(e.X, e.Y).ColumnIndex;
                if (currentMouseCol >= 8 && currentMouseCol <= 12 && cmbDongMay.Text == "FMS")
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
            readcsvFMS(colTam);
            updateData(ref dtInspectItems, pageid, "FMS");
        }
        public void updateData(ref DataTable dtMeasure, int page_Id,string dongmay)
        {
            if (dtMeasure.Rows.Count > 0)
            {
                IPQC_Motor.TfSQL tfSql = new IPQC_Motor.TfSQL();
                int t = 0;
                foreach (DataRow dr in dtMeasure.Rows)
                {
                    string updateDGVMeasure = "";
                    updateDGVMeasure += "update m_data set ";
                    if (dr[8].ToString() != "" && dr["item_tool"].ToString() == dongmay)
                    {
                        updateDGVMeasure += " data_1 = " + double.Parse(dr[8].ToString());
                        t++;
                    }
                    if (dr[9].ToString() != "" && dr["item_tool"].ToString() == dongmay)
                    {
                        if (t > 0)
                        { updateDGVMeasure += ", "; }
                        updateDGVMeasure += " data_2 = " + dr[9].ToString();
                        t++;
                    }
                    if (dr[10].ToString() != "" && dr["item_tool"].ToString() == dongmay)
                    {
                        if (t > 0)
                        { updateDGVMeasure += ", "; }
                        updateDGVMeasure += " data_3 = " + double.Parse(dr[10].ToString());
                        t++;
                    }
                    if (dr[11].ToString() != "" && dr["item_tool"].ToString() == dongmay)
                    {
                        if (t > 0)
                        { updateDGVMeasure += ", "; }
                        updateDGVMeasure += " data_4 = " + double.Parse(dr[11].ToString());
                        t++;
                    }
                    if (dr[12].ToString() != "" && dr["item_tool"].ToString() == dongmay)
                    {
                        if (t > 0)
                        { updateDGVMeasure += ", "; }
                        updateDGVMeasure += " data_5 = " + double.Parse(dr[12].ToString());
                        t++;
                    }
                    if (dr[13].ToString() != "" && dr["item_tool"].ToString() == dongmay)
                    {
                        if (t > 0)
                        { updateDGVMeasure += ", "; }
                        updateDGVMeasure += " data_x = " + double.Parse(dr[13].ToString());
                        t++;
                    }
                    if (dr[14].ToString() != "" && dr["item_tool"].ToString() == dongmay)
                    {
                        if (t > 0)
                        { updateDGVMeasure += ", "; }
                        updateDGVMeasure += " data_est = '" + dr[14].ToString() + "'";
                        t++;
                    }
                    if (t > 0)
                    {
                        updateDGVMeasure += " where page_id =" + page_Id + " and item_id = " + int.Parse(dr[16].ToString());
                        bool up = tfSql.sqlExecuteNonQuery(updateDGVMeasure, true);
                        if(up) { t = 0; }
                    }   
                }
                AlarmColor();
            }

        }
        public int cl = 0;
        frmMenu frmenu;
        private void cmbDongMay_SelectedIndexChanged(object sender, EventArgs e)
        {//DG FMS PinGau DaiGau Push Pull
            if (cmbSLMau.Text != "")
            {
                if (cl == 0) { frmenu = new frmMenu(this,int.Parse(cmbSLMau.Text)); }

                if (cmbDongMay.Text == "DaiGau" || cmbDongMay.Text == "PinGau")
                {
                    if (cl == 1) { frmenu.Close(); cl = 0; }
                    if (cmbDongMay.Text == "DaiGau") { DisableReadOnlyDGV("DG"); PutCurrentCell("DG"); }
                    else if (cmbDongMay.Text == "PinGau") { DisableReadOnlyDGV("PG"); PutCurrentCell("PG"); }
                }
                else if (cmbDongMay.Text == "Pull" || cmbDongMay.Text == "Push")
                {
                    dgvMeasureData.ReadOnly = false;
                    if (cl == 1) { frmenu.Close(); cl = 0; }
                    DisableReadOnlyDGV(cmbDongMay.Text);
                }
                else if (cmbDongMay.Text == "FMS")
                {
                    dgvMeasureData.ReadOnly = true;
                    if (cl == 0) { frmenu.Show(); cl += 1; }
                }
            }
        }
        public void DisableReadOnlyDGV(string dongmay)//On/Off ReadOnly DGVMeasure
        {
            dgvMeasureData.ReadOnly = false;
            for (int i = 0; i < dgvMeasureData.RowCount; i++)
            {
                if (dgvMeasureData.Rows[i].Cells["item_tool"].Value.ToString() == dongmay)
                { this.dgvMeasureData.Rows[i].ReadOnly = false; }
                else
                { this.dgvMeasureData.Rows[i].ReadOnly = true; }
            }
            if(cmbSLMau.Text != "")
            {
                int slMau = 5 - int.Parse(cmbSLMau.Text);
                for (int i = 1; i <= slMau; i++)
                {
                    dgvMeasureData.Columns[13 - i].ReadOnly = true;
                }
            }
        }
        public void PutCurrentCell(string dongmay)//Đặt vi tri con trỏ khi chọn dong máy
        {
            dgvMeasureData.ClearSelection();
            for (int i = 0; i < dgvMeasureData.RowCount; i++)
            {
                if (dgvMeasureData.Rows[i].Cells["item_tool"].Value.ToString() == dongmay)
                {
                    this.dgvMeasureData.Rows[i].Cells[8].Selected = true;
                    this.dgvMeasureData.CurrentCell = dgvMeasureData.Rows[i].Cells[8];
                    break;
                }
            }
        }
        private void frmFMS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cl == 1) { frmenu.Close(); }
        }
        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            string[] PortList = SerialPort.GetPortNames();
            cmbCOM.Items.Clear();
            cmbCOM.Text = PortList[0];
            if (serialPort1.IsOpen) return;
            serialPort1.PortName = cmbCOM.Text;
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Encoding = Encoding.ASCII;
            try
            {
                serialPort1.Open();
                btnKetNoi.Text = "Đã Kết Nối";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string cmdPullData;
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen == false) return;
            try
            {
                Thread.Sleep(100);
                cmdPullData = serialPort1.ReadExisting().Substring(6, 5);
                MessageBox.Show(cmdPullData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void data ()
            {
            string content1 = "";
            if (cmbDongMay.Text == "Push")
            {
                content1 = "BF" + "\r"; //âm
            }
            else if (cmbDongMay.Text == "Pull")
            {
                content1 = "BE" + "\r"; //âm
            }
            serialPort1.Write(content1);
            string content = "AE" + "\r";
            serialPort1.Write(content);
        }
        private void dgvMeasureData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!IsDouble(dgvMeasureData.CurrentCell.Value.ToString()))
            {
                MessageBox.Show("Dữ liệu phải dạng số !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dgvMeasureData.CurrentCell.Value = null;
                SendKeys.Send("{up}");
                AlarmColor();
            }
            else
            {
                if (cmbDongMay.Text == "DaiGau") { NextRow("DG"); }
                else if (cmbDongMay.Text == "PinGau") { NextRow("PG"); }
                else if (cmbDongMay.Text == "Pull") { NextRow("Pull"); }
                else if (cmbDongMay.Text == "Push") { NextRow("Push"); }
            }
        }
        public bool IsDouble(string Str)//kiểm tra du liêu nhap vào cell dgv
        {
            double e;
            bool i = double.TryParse(Str, out e);
            return i;
        }
        public void NextRow(string dongmay)//CHuyen tơi  cell kê tiep khi nhâp
        {
            int CurrentRow = dgvMeasureData.CurrentCell.RowIndex;
            if (CurrentRow > 0 && dgvMeasureData.Rows[CurrentRow].Cells["item_tool"].Value.ToString() == dongmay)
            {
                for (int i = CurrentRow + 1; i < dgvMeasureData.RowCount; i++)
                {
                    if (dgvMeasureData.Rows[i].Cells["item_tool"].Value.ToString() != dongmay)
                    {
                        SendKeys.Send("{down}");
                    }
                    else { break; }
                }
                CalculatorDataX();
                updateData(ref dtInspectItems, pageid, dongmay);
            }
        }
        public void AlarmColor()//cảnh báo màu
        {
            if (dgvMeasureData.RowCount > 0)
            {
                for (int i = 0; i < dgvMeasureData.RowCount; i++)
                {
                    double lower = 0;
                    double upper = 0;
                    double.TryParse(dgvMeasureData.Rows[i].Cells["item_lower"].Value.ToString(), out lower);
                    double.TryParse(dgvMeasureData.Rows[i].Cells["item_upper"].Value.ToString(), out upper);
                    for (int j = 8; j <= (int.Parse(cmbSLMau.Text) + 8); j++)
                    {
                        if (dgvMeasureData.Rows[i].Cells[j].Value.ToString() != "")
                        {
                            double data1 = 0;
                            bool b = double.TryParse(dgvMeasureData.Rows[i].Cells[j].Value.ToString(), out data1);
                            if (data1 < lower || data1 > upper)
                            {
                                dgvMeasureData.Rows[i].Cells[j].Style.BackColor = Color.Red;
                            }
                            else dgvMeasureData.Rows[i].Cells[j].Style.BackColor = SystemColors.Window;
                        }
                        else dgvMeasureData.Rows[i].Cells[j].Style.BackColor = SystemColors.Window;
                    }
                }
            }
            CalculatorEst();
        }
        private void dgvMeasureData_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbDongMay.Text == "DaiGau") { NextRow("DG"); }
                    else if (cmbDongMay.Text == "PinGau") { NextRow("PG"); }
                    else if (cmbDongMay.Text == "Pull") { NextRow("Pull"); }
                    else if (cmbDongMay.Text == "Push") { NextRow("Push"); }
                }
            }
            catch { }
        }
        public void CalculatorDataX()//tinh trung binh theo so luuong mau
        {
            if (dgvMeasureData.RowCount > 0)
            {
                foreach (DataRow dr in dtInspectItems.Rows)
                {
                    double datatb = 0;
                    if(dr[8].ToString()!= "")
                    {
                        datatb += double.Parse(dr[8].ToString());
                    }
                    if (dr[9].ToString() != "")
                    {
                        datatb += double.Parse(dr[9].ToString());
                    }
                    if (dr[10].ToString() != "")
                    {
                        datatb += double.Parse(dr[10].ToString());
                    }
                    if (dr[11].ToString() != "")
                    {
                        datatb += double.Parse(dr[11].ToString());
                    }
                    if (dr[12].ToString() != "")
                    {
                        datatb += double.Parse(dr[12].ToString());
                    }
                    dr[13] = Math.Round((datatb / int.Parse(cmbSLMau.Text)),4);
                }
            }
        }
        public void CalculatorEst()//tinh est
        {
            if (dgvMeasureData.RowCount > 0)
            {
                for (int i = 0; i < dgvMeasureData.RowCount; i++)
                {
                    int estx = 0;
                    if (dgvMeasureData.Rows[i].Cells["data_1"].Style.BackColor == Color.Red) { ++estx; }
                    if (dgvMeasureData.Rows[i].Cells["data_2"].Style.BackColor == Color.Red) { ++estx; }
                    if (dgvMeasureData.Rows[i].Cells["data_3"].Style.BackColor == Color.Red) { ++estx; }
                    if (dgvMeasureData.Rows[i].Cells["data_4"].Style.BackColor == Color.Red) { ++estx; }
                    if (dgvMeasureData.Rows[i].Cells["data_5"].Style.BackColor == Color.Red) { ++estx; }

                    if(estx > 0)
                    {
                        dgvMeasureData.Rows[i].Cells["data_est"].Value = "X";
                    }

                    int esto = 0;
                    if (dgvMeasureData.Rows[i].Cells["data_1"].Value.ToString() != "" && dgvMeasureData.Rows[i].Cells["data_1"].Style.BackColor == SystemColors.Window) { esto++; }
                    if (dgvMeasureData.Rows[i].Cells["data_2"].Value.ToString() != "" && dgvMeasureData.Rows[i].Cells["data_2"].Style.BackColor == SystemColors.Window) { esto++; }
                    if (dgvMeasureData.Rows[i].Cells["data_3"].Value.ToString() != "" && dgvMeasureData.Rows[i].Cells["data_3"].Style.BackColor == SystemColors.Window) { esto++; }
                    if (dgvMeasureData.Rows[i].Cells["data_4"].Value.ToString() != "" && dgvMeasureData.Rows[i].Cells["data_4"].Style.BackColor == SystemColors.Window) { esto++; }
                    if (dgvMeasureData.Rows[i].Cells["data_5"].Value.ToString() != "" && dgvMeasureData.Rows[i].Cells["data_5"].Style.BackColor == SystemColors.Window) { esto++; }

                    if (estx == 0 && esto > 0)
                    {
                        dgvMeasureData.Rows[i].Cells["data_est"].Value = "O";
                    }
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
        }
        private void cmbDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tb = 0;
            if (dgvMeasureData.RowCount > 0)
            {
                IPQC_Motor.TfSQL tfSQL = new IPQC_Motor.TfSQL();
                string sqlUpdate = sqlUpdate = "update m_header set footer_result = '" + cmbDanhGia.Text + "' where page_id = " + pageid;
                int mau = 0;
                for (int i = 0; i < dgvMeasureData.RowCount; i++)
                {
                    if (tb == 1)
                    {
                        tb = 0;
                        break;
                    }
                    else
                    {
                        int slmau = int.Parse(cmbSLMau.Text);
                        for (int j = 8; j < slmau + 8; j++)
                        {
                            if (dgvMeasureData.Rows[i].Cells[j].Value.ToString() == "")
                            {
                                DialogResult Mess = MessageBox.Show("Hạng mục vẫn chưa đo xong !" + System.Environment.NewLine + "Bạn vẫn muốn lưu đánh giá ?", "Note", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                                if (DialogResult.Yes == Mess)//chưa hoàn thành cảnh báo
                                {
                                    tfSQL.sqlExecuteNonQuery(sqlUpdate, false);
                                }
                                tb = 1;
                                break;
                            }
                            if (dgvMeasureData.Rows[i].Cells[j].Style.BackColor == Color.Red)
                            {
                                mau++;
                            }
                            if (i == dgvMeasureData.RowCount - 1 && j == (slmau + 7))
                            {
                                if (cmbDanhGia.Text == "OK" && mau > 0)
                                {
                                    DialogResult Mess = MessageBox.Show("Có hạng mục NG !" + System.Environment.NewLine + "Bạn vẫn muốn lưu đánh giá ?", "Note", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                                    if (DialogResult.Yes == Mess)
                                    {
                                        tfSQL.sqlExecuteNonQuery(sqlUpdate, false);
                                    }
                                }
                                tb = 1;
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void btnNoiLuu_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.SelectedPath = "D:\\";
            if(folder.ShowDialog() == DialogResult.OK)
            {
                txtNoiLuu.Text = folder.SelectedPath;
            }
        }

        private void btnLuuXuat_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtNoiLuu.Text))
            {
                IPQC_Motor.ExcelClassFMS ex = new IPQC_Motor.ExcelClassFMS();
                IPQC_Motor.TfSQL tfSql = new IPQC_Motor.TfSQL();
                string model = tfSql.sqlExecuteScalarString("select model_cd from m_model where model_id = (select model_id from m_drawing where dwr_cd = '" + drawingcd + "')");
                string DocName = tfSql.sqlExecuteScalarString("select doc_name from m_drawing where dwr_cd = '" + drawingcd + "'");

                ex.exportExcel(model, drawingcd, DocName, cmbQuiTrinh.Text, int.Parse(cmbSLMau.Text), cmbPhuongThuc.Text, cmbKhuVuc.Text, cmbNgoaiQuan.Text, dgvMeasureData, cmbDanhGia.Text, dtpGiaCong.Value.ToString("yyyy-MM-dd"), txtLot.Text, dtpDoHang.Value.ToString("yyyy-MM-dd"), "", username, txtNoiLuu.Text + DocName);
            }

            else MessageBox.Show("Đường dẫn không hợp lệ !" + System.Environment.NewLine + "Hãy chọn lại thư mục lưu trữ ", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
