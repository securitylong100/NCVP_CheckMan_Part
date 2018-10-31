using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Reflection;


namespace IPQC_Motor
{
    public class ExcelClassCut
    {
        public void exportExcel(string model, string Drawingcd, string DwrName, string SoMay, string QuiTrinh, DateTime KhungGio,string phuongthuc,string soluongmau, string KhuVucSX, string ngoaiquang, DataGridView dgv, string DanhGia, string DateGiaCong, string Lot, string DateKiemtra, string memXacNhan, string memKiemTra, string PathSave)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet; //sheet 2
            Excel.Range xlRangeCopy;
            //Excel.Worksheet xlWorkSheet1; //sheet 1
            object misValue = System.Reflection.Missing.Value;

            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(@"\\192.168.145.7\checkmanpart\FormCut.xlsx   ", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                #region Sheet 1
                //Add data in Sheet 1
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); //add data sheet1
                //header
                xlWorkSheet.Cells[3, 1] = DateKiemtra;//date đo hàng
                xlWorkSheet.Cells[6, 1] = model; //modelØ
                xlWorkSheet.Cells[6, 9] = Drawingcd; //Dwaring No
                xlWorkSheet.Cells[6, 13] = DwrName; //document name
                xlWorkSheet.Cells[6, 19] = SoMay; //So May
                xlWorkSheet.Cells[8, 1] = QuiTrinh; //Qui Trinh
                xlWorkSheet.Cells[8, 6] = phuongthuc;// phuong thuc
                xlWorkSheet.Cells[8, 11] = soluongmau;//so luong mau thu
                xlWorkSheet.Cells[8, 14] = KhuVucSX;//Khu Vuc SX
                
                xlWorkSheet.Cells[10, 10] = KhungGio.ToString("HH:mm"); //Khung gio

                //footer
                xlWorkSheet.Cells[44, 19] = DanhGia; //danhgia
                xlWorkSheet.Cells[45, 20] = DateGiaCong;//Ngay Gia cong
                xlWorkSheet.Cells[47, 20] = DateKiemtra; //lot
                xlWorkSheet.Cells[43, 10] = memKiemTra; //Nguoi danh gia

                xlWorkSheet.Range[xlWorkSheet.Cells[11, 11], xlWorkSheet.Cells[12, 11]] = ngoaiquang;//Ngoai Quang

                xlRangeCopy = xlWorkSheet.Range[xlWorkSheet.Cells[39, 1], xlWorkSheet.Cells[40, 21]];

                int MaxItem = dgv.Rows.Cast<DataGridViewRow>().Max(r => int.Parse(r.Cells["item_measure"].Value.ToString()));
                int RowAdd = MaxItem - 15;
                if ((MaxItem / 15) >= 1 && RowAdd > 0)
                {
                    for (int i = 1; i <= RowAdd; i++)
                    {
                        xlWorkSheet.Rows[41].Insert();
                        xlWorkSheet.Rows[41].Insert();
                        xlRangeCopy.Copy(xlWorkSheet.Range[xlWorkSheet.Cells[41, 1], xlWorkSheet.Cells[42, 21]]);
                    }
                }

                int rowExcel = 13;
                for (int i = 0; i < dgv.Rows.Count; i++) //dong
                {
                    xlWorkSheet.Cells[rowExcel, 1] = dgv.Rows[i].Cells["item_measure"].Value.ToString();
                    xlWorkSheet.Cells[rowExcel, 4] = dgv.Rows[i].Cells["item_spec_x"].Value.ToString();//spec X
                    double torUp; double torDown;
                    if (double.TryParse(dgv.Rows[i].Cells["tolerance_up"].Value.ToString(), out torUp) && double.TryParse(dgv.Rows[i].Cells["tolerances_low"].Value.ToString(), out torDown))
                    {
                        xlWorkSheet.Cells[rowExcel, 5] = torUp.ToString("#,###0.###");
                        xlWorkSheet.Cells[rowExcel + 1, 5] = torDown.ToString("#,###0.###");
                    }

                    xlWorkSheet.Cells[rowExcel, 6] = dgv.Rows[i].Cells["item_lower"].Value.ToString();
                    xlWorkSheet.Cells[rowExcel, 8] = dgv.Rows[i].Cells["item_upper"].Value.ToString();
                    xlWorkSheet.Cells[rowExcel, 9] = dgv.Rows[i].Cells["item_tool"].Value.ToString();

                    xlWorkSheet.Cells[rowExcel, 10] = dgv.Rows[i].Cells["data_1"].Value.ToString();
                    if (i < dgv.RowCount - 1 && dgv.Rows[i].Cells[0].Value.ToString() == dgv.Rows[i + 1].Cells[0].Value.ToString())//kiem tra dong thu 1 = dong 2 ko ?
                    {
                        xlWorkSheet.Cells[rowExcel + 1, 10] = dgv.Rows[i + 1].Cells["data_1"].Value.ToString();
                        i++;
                    }
                    else if (i < dgv.RowCount - 1 && dgv.Rows[i].Cells[0].Value.ToString() != dgv.Rows[i + 1].Cells[0].Value.ToString())
                    {
                        xlWorkSheet.Range[xlWorkSheet.Cells[rowExcel, 10], xlWorkSheet.Cells[rowExcel + 1, 10]].Merge();
                    }
                    rowExcel = rowExcel + 2;
                }
                #endregion
                if (File.Exists(@"D:\Book1.xlsx"))
                {
                    File.Delete(@"D:\Book1.xlsx");
                }
                xlWorkBook.SaveAs(@"D:\Book1.xlsx", Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                MessageBox.Show("Excel file created", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Workbooks.Open(@"D:\Book1.xlsx");
                xlApp.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error happened in the process." + ex.Message);
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
    }
}
