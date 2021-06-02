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

namespace demo
{
    public partial class UcXemDuLieuHangVaTN : UserControl
    {
        public UcXemDuLieuHangVaTN()
        {
            InitializeComponent();
            LoadListHang();
            LoadListTN();
        }

        public void LoadListHang()
        {
            dtgvListHang.DataSource = HangDAO.Instance.getListHang();
        }
        public void LoadListTN()
        {
            dtgvListTN.DataSource = TienNghiDAO.Instance.getListTienNghi();
        }
        private void labelX1_Click(object sender, EventArgs e)
        {

        }

      

        private void txbFindHang_TextChanged(object sender, EventArgs e)
        {
            String TenHang = txbFindHang.Text;
            dtgvListHang.DataSource = HangDAO.Instance.findHang(TenHang);

        }

        private void txbFindTN_TextChanged(object sender, EventArgs e)
        {
            String TenTN = txbFindTN.Text;
            dtgvListTN.DataSource = TienNghiDAO.Instance.findTN(TenTN);

        }
    }
}
