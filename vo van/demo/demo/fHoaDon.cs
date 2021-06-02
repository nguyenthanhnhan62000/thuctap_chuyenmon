using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using demo.RpData;
using Microsoft.Reporting.WinForms;

namespace demo
{
    public partial class fHoaDon : Form
    {
        int MaPhieuThue;
        public fHoaDon(int maPhieuThue)
        {
            InitializeComponent();

            this.MaPhieuThue = maPhieuThue;
        }

        private void fHoaDon_Load(object sender, EventArgs e)
        {

            hienthi(MaPhieuThue);
           
        }

        private void hienthi(int maPhieuThue)
        {
            using (var qlks = new qlks())
            {
                String query = "SELECT HOADON.MaPhieuThue,TienPhong,TienDichVu,TongTien,SoPhong,DonGia,HOADON.NgayLap,NgayDen,NgayDi, DATEDIFF(DAY,NgayDen,NgayDi) AS Ngayo,TENNV " +
                    "FROM dbo.HOADON,dbo.THUEPHONG,dbo.PHONG,dbo.PHIEUTHUE " +
                    "WHERE HOADON.MaPhieuThue = dbo.THUEPHONG.MaPhieuThue AND dbo.THUEPHONG.MaPhong = phong.MaPhong AND HOADON.MaPhieuThue = PHIEUTHUE.MaPhieuThue AND HOADON.MaPhieuThue = "+ maPhieuThue + "";
                List<HoaDon_1> danhsach = qlks.Database.SqlQuery<HoaDon_1>(query).ToList();
                this.reportViewer1.LocalReport.ReportPath = "rpHoaDon.rdlc";
                var reportDataSource = new ReportDataSource("DataSet1", danhsach);

                String query1 = "SELECT name,SoLuong,gia " +
                    "FROM dbo.PHIEUTHUE,dbo.THUEDICHVU,dbo.DICHVU " +
                    "WHERE dbo.PHIEUTHUE.MaPhieuThue=dbo.THUEDICHVU.MaPhieuThue AND PHIEUTHUE.MaPhieuThue = "+ maPhieuThue + " AND DICHVU.MaDichVu=THUEDICHVU.MaDichVu";
                List<HoaDon_2> danhsach1 = qlks.Database.SqlQuery<HoaDon_2>(query1).ToList();
                this.reportViewer1.LocalReport.ReportPath = "rpHoaDon.rdlc";
                var reportDataSource1 = new ReportDataSource("DataSet2", danhsach1);


                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);


                this.reportViewer1.RefreshReport();


            }
        }
    }
}
