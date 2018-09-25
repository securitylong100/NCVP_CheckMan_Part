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
using System.Threading.Tasks;
using System.Management;
using System.Drawing.Drawing2D;
using Npgsql;

namespace IPQC_Part
{
    public partial class frmContinue : Form
    {
        public string DrawingCd;
        public string Username;
        // ƒRƒ“ƒXƒgƒ‰ƒNƒ^
        public frmContinue(string drawing_cd, string username_)
        {
            InitializeComponent();
            DrawingCd = drawing_cd;
            Username = username_;
        }
        private void frmContinue_Load(object sender, EventArgs e)
        {
            TreeView();
        }
        public DataTable dtTreeNode;
        //public DataTable dtChildNode;
        private void TreeView()
        {
            dtTreeNode = new DataTable();
            listTV.Nodes.Clear();
            IPQC_Motor.TfSQL tfSql = new IPQC_Motor.TfSQL();
            string sqlTV = @"select a.page_id, header_machine,footer_result, cast(a.registration_date_time as date) dates,a.registration_date_time date 
                            from m_header a left join m_data b on a.page_id = b.page_id left join m_item c on b.item_id = c.item_id 
                            where c.dwr_id = (select dwr_id from m_drawing where dwr_cd = '" + DrawingCd + "') group by a.page_id,a.registration_date_time, header_machine, footer_result ";
            tfSql.sqlDataAdapterFillDatatable(sqlTV, ref dtTreeNode);

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
                            from m_header a left join m_data b on a.page_id = b.page_id left join m_item c on b.item_id = c.item_id where c.dwr_id = (select dwr_id from m_drawing where dwr_cd = '" + DrawingCd + "') group by a.page_id,a.registration_date_time, header_machine, footer_result) tb where tb.dates = '" + headerN[i].Text + "'";
                    tfSql.sqlDataAdapterFillDatatable(sqlNodeChild, ref dtChildNode);

                    TreeNode[] headerchild = new TreeNode[dtChildNode.Rows.Count];
                    for (int j = 0; j < dtChildNode.Rows.Count; j++)
                    {
                        TreeNode childtree = new TreeNode
                        {
                            Text = dtChildNode.Rows[j]["header_machine"].ToString() + " " + dtChildNode.Rows[j]["footer_result"].ToString(),
                            Tag = dtChildNode.Rows[j]["page_id"].ToString(),
                            Checked = false,
                        };

                        headerchild[j] = childtree;
                        tree.Nodes.Add(childtree);
                        listTV.Nodes.Add(tree);
                        if (headerchild[j].Text.Substring(headerchild[j].Text.Length - 2, 2) == "OK")
                        {
                            listTV.Nodes.Remove(childtree);
                        }
                    }
                }
            }
        }
        public bool Page_id(string text)
        {
            bool a = false;
            int r = 0;
            if (int.TryParse(text,out r))
            {
                a = true;
            }
            else
            {
                a = false;
            }
            return a;
        }
        private void listTV_DoubleClick(object sender, EventArgs e)
        {
            if (Page_id(listTV.SelectedNode.Tag.ToString()))
            {
                IPQC_Motor.TfSQL tf = new IPQC_Motor.TfSQL();
                int pageId = int.Parse(listTV.SelectedNode.Tag.ToString());
                string tagNode = "select count(*) from m_header where page_id = " + pageId;
                long checkPage = tf.sqlExecuteScalarLong(tagNode);

                if (checkPage > 0)
                {
                    // MessageBox.Show(pageId.ToString());
                    frmFMS from = new frmFMS(pageId, Username, DrawingCd);
                    from.ShowDialog();
                }
            }
            else MessageBox.Show("Hãy chọn một mã máy !", "Note!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}