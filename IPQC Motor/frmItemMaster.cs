using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;
using System.Management;
using System.Drawing.Drawing2D;
using Npgsql;

namespace IPQC_Motor
{
    public partial class frmItemMaster : Form
    {
        public string Model;
        public int DrawingId;
        public string DrawingCd;
        public string DrawingName;
        public string DocName;
        public string User;
        // ƒRƒ“ƒXƒgƒ‰ƒNƒ^
        public frmItemMaster(int drawing_id, string drawing_cd,string drawing_name, string doc_name, string user)
        {
            InitializeComponent();
            DrawingId = drawing_id;
            DrawingCd = drawing_cd;
            DrawingName = drawing_name;
            DocName = doc_name;
            User = user;
        }
        
        private void Form7_2_Load(object sender, EventArgs e)
        {
            LoadItem();
        }
        public DataTable dt;
        DataGridViewButtonColumn colDel;
        public void LoadItem()
        {
            dgvTester.Columns.Clear();
            txtDwr.Text = DrawingCd;
            string sql = "select item_id,a.dwr_id , item_measure,  item_symbol,item_tool,item_row,item_detail,item_spec_x,  item_lower, item_upper  from m_item a left join m_drawing b on a.dwr_id = b.dwr_id where b.dwr_cd = '" + DrawingCd + "' order by item_measure,item_id asc ";
            TfSQL tfSql = new TfSQL();
            dt = new DataTable();
            tfSql.sqlDataAdapterFillDatatable(sql, ref dt);
            dgvTester.DataSource = dt;

            //add columns Delete
            colDel = new DataGridViewButtonColumn() { Text = "Delete", UseColumnTextForButtonValue = true };
            dgvTester.Columns.Add(colDel);

            //Fix DGV            
            dgvTester.Columns["item_id"].Visible = false;
            dgvTester.Columns["dwr_id"].Visible = false;
            dgvTester.Columns["item_measure"].HeaderText = "Item";
            dgvTester.Columns["item_symbol"].HeaderText = "Symbol";
            dgvTester.Columns["item_spec_x"].HeaderText = "Spec";
            dgvTester.Columns["item_lower"].HeaderText = "Lower";
            dgvTester.Columns["item_upper"].HeaderText = "Upper";
            dgvTester.Columns["item_tool"].HeaderText = "Tool";
            dgvTester.Columns["item_detail"].HeaderText = "Detail";
            dgvTester.Columns["item_row"].HeaderText = "Row";
            dgvTester.Columns[10].HeaderText = "Delete";
            
            dgvTester.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTester.Columns["item_measure"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            //Load Image to picture box
            string bytePic = tfSql.sqlExecuteScalarString("select dwr_image from m_drawing where dwr_cd = '" + DrawingCd + "'");
            ShowImage(bytePic, picbox);

            string bytePicMain = tfSql.sqlExecuteScalarString("select dwr_image_main from m_drawing where dwr_cd = '" + DrawingCd + "'");
            ShowImage(bytePicMain, picbox_main);
        }
        public void ShowImage(string bytePic, PictureBox picture)
        {
            if (bytePic != "")
            {
                byte[] imgBytes = Convert.FromBase64String(bytePic);
                MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                ms.Write(imgBytes, 0, imgBytes.Length);
                Image image = Image.FromStream(ms, true);

                picture.Image = image;
                picture.SizeMode = PictureBoxSizeMode.Zoom;

                ms.Close();
            }
        }
        int itemId;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvTester.ReadOnly = false;
            dgvTester.AllowUserToAddRows = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            TfSQL tf = new TfSQL();
            itemId = int.Parse(tf.sqlExecuteScalarString("select max(item_id) from m_item"));
        }

        // Šù‘¶ƒŒƒR[ƒh‚Ìíœ
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTester.Rows.Count > 0)
            {
                int rowIndex = dgvTester.CurrentRow.Index;
                DialogResult dialog = MessageBox.Show("Do you want to delete Measure item no " + dgvTester.Rows[rowIndex].Cells["item_measure"].Value.ToString(), "Note !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    TfSQL tfsql = new TfSQL();

                    int item_measure = int.Parse(dgvTester.Rows[rowIndex].Cells["item_measure"].Value.ToString());
                    string sqlDelete = @"delete from m_item where dwr_id = (select dwr_id from m_drawing where dwr_cd = '" + DrawingCd +
                        "') and item_measure = " + item_measure;
                    bool del = tfsql.sqlExecuteNonQuery(sqlDelete, true);
                    LoadItem();
                }
            }
        }

        // •Û‘¶
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
            }
        }
        private void dgvTester_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (btnAdd.Enabled == false)
            {
                itemId++;
                TfSQL tf = new TfSQL();
                //string itemId = tf.sqlExecuteScalarString("select max(item_id) +1 from m_item");
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
        public void SaveImage(PictureBox pic, string column)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Open Image File";
            file.Filter = "Image files|*.jpg;*.png";

            if (file.ShowDialog() == DialogResult.OK)
            {
                if (file.FileName != "")
                {
                    string fileName = file.FileName.ToString();
                    long size = new System.IO.FileInfo(fileName).Length / 1024;
                    bool doing = false;
                    if (size > 310)
                    {
                        DialogResult dialog = MessageBox.Show("File size is greater than 300 Kb !" + System.Environment.NewLine + "Do you want continue!", "Note!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialog == DialogResult.Yes)
                        {
                            doing = true;
                        }
                    }
                    else doing = true;

                    if (doing == true)
                    {
                        byte[] img = System.IO.File.ReadAllBytes(fileName);
                        MemoryStream meStream = new MemoryStream(img);

                        pic.Image = new Bitmap(meStream);
                        pic.SizeMode = PictureBoxSizeMode.Zoom;

                        FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                        byte[] picbyte = new byte[fs.Length];
                        fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
                        fs.Close();

                        TfSQL sql = new TfSQL();
                        int dwrId = int.Parse(sql.sqlExecuteScalarString("select dwr_id from m_drawing where dwr_cd = '" + DrawingCd + "'"));
                        string sqlEx = "update m_drawing set " + column + " = '" + Convert.ToBase64String(picbyte) + "' where dwr_id = " + dwrId;
                        sql.sqlExecuteNonQueryInt(sqlEx, false);

                        doing = false;
                    }
                }
                else
                {
                    MessageBox.Show("No file selected!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btn_imageMeasure_Click(object sender, EventArgs e)
        {
            SaveImage(picbox, "dwr_image");
        }

        private void btn_imageMain_Click(object sender, EventArgs e)
        {
            SaveImage(picbox_main, "dwr_image_main");
        }
        public bool Check()
        {
            if (txtDwr.Text == "") { return false; }
            return true;
        }

        private void dgvTester_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTester.RowCount > 0)
            {
                if (dgvTester.Columns[e.ColumnIndex] == colDel)
                {
                    TfSQL tf = new TfSQL();
                    int itemId = int.Parse(dgvTester.Rows[e.RowIndex].Cells["item_id"].Value.ToString());
                    string sqlDelete = "delete from m_item where item_id = " + itemId;

                    DialogResult dialog = MessageBox.Show("Do you want to delete Measure item no " + dgvTester.Rows[e.RowIndex].Cells["item_measure"].Value.ToString(), "Note !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialog == DialogResult.Yes)
                    {
                        tf.sqlExecuteNonQuery(sqlDelete, false);
                        LoadItem();
                    }
                }
            }
        }
    }
}