using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace IPQC_Motor
{
    public class ExcelClassFMS
    {
        public void exportExcel(string model, string Drawingcd, string DocName, string QuiTrinh, int SlMau, string PhuongThuc, string KhuVucSX, string ngoaiquang,DataGridView dgv, string DanhGia, string DateGiaCong, string Lot, string DateKiemtra, string memXacNhan, string memKiemTra, string PathSave)
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
                xlWorkBook = xlApp.Workbooks.Open(@"D:\Form.xls", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                #region Sheet 1
                //Add data in Sheet 1
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); //add data sheet1
                //header
                xlWorkSheet.Cells[6, 1] = model; //model
                xlWorkSheet.Cells[6, 5] = Drawingcd; //Model
                xlWorkSheet.Cells[6, 12] = DocName; //document name
                xlWorkSheet.Cells[8, 1] = QuiTrinh; //Process
                xlWorkSheet.Cells[8, 12] = SlMau; //soluong mau

                //footer
                xlWorkSheet.Cells[39, 13] = DanhGia; //danhgia
                xlWorkSheet.Cells[41, 12] = DateGiaCong;//Ngay Gia cong
                xlWorkSheet.Cells[42, 12] = Lot; //lot
                xlWorkSheet.Cells[43, 12] = DateKiemtra;//Ngay kiêm tra
                xlWorkSheet.Cells[41, 15] = memXacNhan;//member xac nhân
                xlWorkSheet.Cells[41, 16] = memKiemTra;//member kiểm tra


                //if (PhuongThuc == "Ngẫu Nhiên") //Ngẫu Nhiên Toàn Bộ
                //{
                //    xlWorkSheet.Cells[8, 5] = "全 数 ・ 抜 取" + System.Environment.NewLine + " £Toàn bộ -RNgẫu nhiên";
                //}
                //else
                //{
                //    xlWorkSheet.Cells[8, 5] = "全 数 ・ 抜 取" + System.Environment.NewLine + " RToàn bộ -£Ngẫu nhiên";
                //}
                //全 数 ・ 抜 取 £Toàn bộ -RNgẫu nhiên

                
                if (ngoaiquang.ToString() == "OK")
                {
                    xlWorkSheet.Range[xlWorkSheet.Cells[11, 12], xlWorkSheet.Cells[13, 16]] = "OK";
                }
                else xlWorkSheet.Range[xlWorkSheet.Cells[11, 12], xlWorkSheet.Cells[13, 16]] = "NG";

                xlRangeCopy = xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[44, 20]];
                
                int MaxItem = dgv.Rows.Cast<DataGridViewRow>().Max(r => int.Parse(r.Cells["item_measure"].Value.ToString()));
                int CopyRange = MaxItem / 11;
                if ((MaxItem % 11) > 0)
                {
                    CopyRange++;
                }

                if (CopyRange > 1)
                {
                    for (int i = 1; i < CopyRange; i++)
                    {
                        xlRangeCopy.Copy(xlWorkSheet.Range[xlWorkSheet.Cells[i * 45, 1], xlWorkSheet.Cells[(i * 45) + 43, 20]]);
                    }
                }

                //datagridw
                int rowExcel = 15;
                int rowBreak = 12;
                for (int i = 0; i < dgv.Rows.Count; i++) //dong
                {
                    if (dgv.Rows[i].Cells["item_measure"].Value.ToString() == rowBreak.ToString())
                    {
                        rowExcel = rowExcel + 22;
                    }

                    xlWorkSheet.Cells[rowExcel, 1] = dgv.Rows[i].Cells["item_measure"].Value.ToString();
                    xlWorkSheet.Cells[rowExcel, 2] = "Kích Thước Dimension " + dgv.Rows[i].Cells["item_measure"].Value.ToString();

                    xlWorkSheet.Cells[rowExcel, 7] = dgv.Rows[i].Cells["item_spec_x"].Value.ToString();
                    xlWorkSheet.Cells[rowExcel + 1, 6] = dgv.Rows[i].Cells["item_lower"].Value.ToString();
                    xlWorkSheet.Cells[rowExcel + 1, 8] = dgv.Rows[i].Cells["item_upper"].Value.ToString();
                    xlWorkSheet.Cells[rowExcel, 10] = dgv.Rows[i].Cells["tolerance_up"].Value.ToString();
                    xlWorkSheet.Cells[rowExcel + 1, 10] = dgv.Rows[i].Cells["tolerances_low"].Value.ToString();
                    xlWorkSheet.Cells[rowExcel, 11] = dgv.Rows[i].Cells["item_tool"].Value.ToString();

                    xlWorkSheet.Cells[rowExcel, 12] = dgv.Rows[i].Cells["data_1"].Value.ToString();
                    xlWorkSheet.Cells[rowExcel, 13] = dgv.Rows[i].Cells["data_2"].Value.ToString();
                    xlWorkSheet.Cells[rowExcel, 14] = dgv.Rows[i].Cells["data_3"].Value.ToString();
                    xlWorkSheet.Cells[rowExcel, 15] = dgv.Rows[i].Cells["data_4"].Value.ToString();
                    xlWorkSheet.Cells[rowExcel, 16] = dgv.Rows[i].Cells["data_5"].Value.ToString();
                    if (i < dgv.RowCount - 1 && dgv.Rows[i].Cells[0].Value.ToString() == dgv.Rows[i + 1].Cells[0].Value.ToString())//kiem tra dong thu 1 = dong 2 ko ?
                    {
                        xlWorkSheet.Cells[rowExcel, 4] = dgv.Rows[i].Cells["item_detail"].Value.ToString();
                        xlWorkSheet.Cells[rowExcel + 1, 4] = dgv.Rows[i + 1].Cells["item_detail"].Value.ToString();
                        xlWorkSheet.Cells[rowExcel + 1, 12] = dgv.Rows[i + 1].Cells["data_1"].Value.ToString();
                        xlWorkSheet.Cells[rowExcel + 1, 13] = dgv.Rows[i + 1].Cells["data_2"].Value.ToString();
                        xlWorkSheet.Cells[rowExcel + 1, 14] = dgv.Rows[i + 1].Cells["data_3"].Value.ToString();
                        xlWorkSheet.Cells[rowExcel + 1, 15] = dgv.Rows[i + 1].Cells["data_4"].Value.ToString();
                        xlWorkSheet.Cells[rowExcel + 1, 16] = dgv.Rows[i + 1].Cells["data_5"].Value.ToString();
                        rowExcel = rowExcel + 2;
                        if (i < dgv.RowCount - 2 && dgv.Rows[i + 1].Cells[0].Value.ToString() == dgv.Rows[i + 2].Cells[0].Value.ToString())//kiem tra dong thu 2 = dong 3 ko ?
                        {
                            xlWorkSheet.Rows[rowExcel - 1].Insert();

                            xlWorkSheet.Cells[rowExcel - 1, 4] = dgv.Rows[i + 1].Cells["item_detail"].Value.ToString();
                            xlWorkSheet.Cells[rowExcel - 1, 12] = dgv.Rows[i + 1].Cells["data_1"].Value.ToString();
                            xlWorkSheet.Cells[rowExcel - 1, 13] = dgv.Rows[i + 1].Cells["data_2"].Value.ToString();
                            xlWorkSheet.Cells[rowExcel - 1, 14] = dgv.Rows[i + 1].Cells["data_3"].Value.ToString();
                            xlWorkSheet.Cells[rowExcel - 1, 15] = dgv.Rows[i + 1].Cells["data_4"].Value.ToString();
                            xlWorkSheet.Cells[rowExcel - 1, 16] = dgv.Rows[i + 1].Cells["data_5"].Value.ToString();
                            
                            xlWorkSheet.Cells[rowExcel, 4] = dgv.Rows[i + 2].Cells["item_detail"].Value.ToString();
                            xlWorkSheet.Cells[rowExcel, 12] = dgv.Rows[i + 2].Cells["data_1"].Value.ToString();
                            xlWorkSheet.Cells[rowExcel, 13] = dgv.Rows[i + 2].Cells["data_2"].Value.ToString();
                            xlWorkSheet.Cells[rowExcel, 14] = dgv.Rows[i + 2].Cells["data_3"].Value.ToString();
                            xlWorkSheet.Cells[rowExcel, 15] = dgv.Rows[i + 2].Cells["data_4"].Value.ToString();
                            xlWorkSheet.Cells[rowExcel, 16] = dgv.Rows[i + 2].Cells["data_5"].Value.ToString();
                            rowExcel++;
                            i++;
                        }                        
                        i++;
                    }
                    else if (i < dgv.RowCount - 1 && dgv.Rows[i].Cells[0].Value.ToString() != dgv.Rows[i + 1].Cells[0].Value.ToString())
                    {
                        xlWorkSheet.Range[xlWorkSheet.Cells[rowExcel, 12], xlWorkSheet.Cells[rowExcel + 1, 12]].Merge();
                        xlWorkSheet.Range[xlWorkSheet.Cells[rowExcel, 13], xlWorkSheet.Cells[rowExcel + 1, 13]].Merge();
                        xlWorkSheet.Range[xlWorkSheet.Cells[rowExcel, 14], xlWorkSheet.Cells[rowExcel + 1, 14]].Merge();
                        xlWorkSheet.Range[xlWorkSheet.Cells[rowExcel, 15], xlWorkSheet.Cells[rowExcel + 1, 15]].Merge();
                        xlWorkSheet.Range[xlWorkSheet.Cells[rowExcel, 16], xlWorkSheet.Cells[rowExcel + 1, 16]].Merge();

                        xlWorkSheet.Cells[rowExcel, 12] = dgv.Rows[i].Cells["data_1"].Value.ToString();
                        xlWorkSheet.Cells[rowExcel, 13] = dgv.Rows[i].Cells["data_2"].Value.ToString();
                        xlWorkSheet.Cells[rowExcel, 14] = dgv.Rows[i].Cells["data_3"].Value.ToString();
                        xlWorkSheet.Cells[rowExcel, 15] = dgv.Rows[i].Cells["data_4"].Value.ToString();
                        xlWorkSheet.Cells[rowExcel, 16] = dgv.Rows[i].Cells["data_5"].Value.ToString();

                        rowExcel = rowExcel + 2;
                    }
                }
                    #endregion

                    xlWorkBook.SaveAs(PathSave + "a.xls", Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                            misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    MessageBox.Show("Excel file created, you can find in the folder D:\\Database IPQC", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Workbooks.Open(PathSave + "a.xls");
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
