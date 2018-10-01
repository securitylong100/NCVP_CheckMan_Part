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
namespace IPQC_Part
{
    public partial class frmMenu : Form
    {
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        frmFMS frmFms;
        public frmMenu(frmFMS frmfms_)
        {
            InitializeComponent();
            frmFms = frmfms_; 
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }
        public void SetColor(Button btn,int color)
        {
            if (color == 1)  { btn.BackColor = Color.Blue; }
        }
        public int item = 0;
        private void item1_btn_Click(object sender, EventArgs e)
        {
            item = 1;
            frmFms.readcsvFMS(8);
            frmFms.updateData(ref frmFms.dtInspectItems,frmFms.pageid,"FMS");
            SetColor(item1_btn, item);
        }

        private void item2_btn_Click(object sender, EventArgs e)
        {
            item = 1;
            frmFms.readcsvFMS(9);
            frmFms.updateData(ref frmFms.dtInspectItems, frmFms.pageid, "FMS");
            SetColor(item2_btn, item);
        }

        private void item3_btn_Click(object sender, EventArgs e)
        {
            item = 1;
            frmFms.readcsvFMS(10);
            frmFms.updateData(ref frmFms.dtInspectItems, frmFms.pageid, "FMS");
            SetColor(item3_btn, item);
        }

        private void item4_btn_Click(object sender, EventArgs e)
        {
            item = 1;
            frmFms.readcsvFMS(11);
            frmFms.updateData(ref frmFms.dtInspectItems, frmFms.pageid, "FMS");
            SetColor(item4_btn, item);
        }

        private void item5_btn_Click(object sender, EventArgs e)
        {
            item = 1;
            frmFms.readcsvFMS(12);
            frmFms.updateData(ref frmFms.dtInspectItems, frmFms.pageid, "FMS");
            SetColor(item5_btn, item);
        }
    }
}
