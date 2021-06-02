using demo.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using app = Microsoft.Office.Interop.Excel.Application;

namespace demo
{
    public partial class fThongKe_1 : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public fThongKe_1()
        {
            InitializeComponent();
            loadNgay();
            LoadHDTheoThang();
            loadTongTienTheoThang();

            loadChart(2021);
        }

        private void loadChart(int nam)
        {
            chart1.Series["Doanh Thu"].Points.Clear();
            try
            {
                DataTable data = HoaDonDAO.Instance.GetDoanhThueTheoThang(nam);

                chart1.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";
                chart1.ChartAreas["ChartArea1"].AxisY.Title = "Doanh Thu";
                chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    chart1.Series["Doanh Thu"].Points.AddXY(data.Rows[i]["thang"], data.Rows[i]["tongtien"]);

                }
            }
            catch (Exception)
            {
              
                
            }
      
        }

        void loadNgay()
        {
            dtpkFromDate.Value = DateTime.Now;
            dtpkToDate.Value = DateTime.Now;
            DateTime now = DateTime.Now;
            dtpkFromDate.Value = new DateTime(now.Year, now.Month, 1);
            DateTime tg = dtpkFromDate.Value;
            dtpkToDate.Value = tg.AddMonths(1).AddDays(-1);
        }

        void loadTongTienTheoThang()
        {
            DateTime fromDate = dtpkFromDate.Value;
            DateTime toDate = dtpkToDate.Value;
            txbTongTienThang.Text = PhieuThueDAO.Instance.getTongTienByThang(fromDate, toDate).ToString();
        }
        void LoadHDTheoThang()
        {
            DateTime fromDate = dtpkFromDate.Value;
            DateTime toDate = dtpkToDate.Value;

            dtgvPhieuThue.DataSource = PhieuThueDAO.Instance.getHoaDonByThang(fromDate, toDate);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadHDTheoThang();
            loadTongTienTheoThang();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog openDlg = new SaveFileDialog();
            openDlg.InitialDirectory = @"C:\";
            openDlg.FileName = "*.xlsx";
            openDlg.DefaultExt = "xlsx";
            openDlg.RestoreDirectory = true;
            openDlg.Filter = "|*.xlsx";

            //string path = openDlg.FileName;

            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                app obj = new app();
                obj.Application.Workbooks.Add(Type.Missing);
                obj.Columns.ColumnWidth = 18;
                obj.StandardFontSize = 13;
                Console.WriteLine(dtgvPhieuThue.RowCount);
                obj.Cells[1, 1] = "QUAN LY RAP CHIEU PHIM";
                obj.Cells[2, 1] = "450 Lê Văn Việt Quận 9 tp.Hồ chí Minh";
                obj.Cells[3, 1] = "Số điện thoại: 0974345678";
                obj.Cells[5, 3] = "THÔNG TIN HÓA ĐƠN";

                obj.Rows[1].Font.Bold = true;
                obj.Rows[2].Font.Bold = true;
                obj.Rows[3].Font.Bold = true;
                obj.Rows[5].Font.Bold = true;
                obj.Rows[6].Font.Bold = true;
                if (dtgvPhieuThue.Rows.Count > 0)
                {
                    for (int i = 1; i < dtgvPhieuThue.Columns.Count + 1; i++)
                    {
                        obj.Cells[6, i] = dtgvPhieuThue.Columns[i - 1].HeaderText;

                    }
                    for (int i = 0; i < dtgvPhieuThue.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtgvPhieuThue.Columns.Count; j++)
                        {
                            if (dtgvPhieuThue.Rows[i].Cells[j].Value != null)
                            {
                                obj.Cells[7 + i, j + 1] = dtgvPhieuThue.Rows[i].Cells[j].Value.ToString();
                                //obj.Rows[7 + 1, j + 1] = data.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                obj.Cells[i + 7, j + 1] = "";
                            }
                        }
                    }
                    obj.ActiveWorkbook.SaveAs(openDlg.FileName);
                    //obj.ActiveWorkbook.SaveAs(); 
                    obj.ActiveWorkbook.Saved = true;
                    MessageBox.Show(" xuat thah cong");
                }
            }
        }

        private void cbbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbNam.SelectedIndex != -1)
            {
                int nam = Convert.ToInt32(cbbNam.SelectedItem.ToString());
                loadChart(nam);
            }
        }
    }
}
