using demo.DAO;
using demo.DTO;
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
    public partial class UcNhapHang : UserControl
    {
        BindingSource listHang = new BindingSource();
        BindingSource listTn = new BindingSource();
        public UcNhapHang()
        {
            InitializeComponent();

            dtgvPhieuNhapHang.DataSource = listHang;
            dtgvPhieuNhapTN.DataSource = listTn;
            loadCbbMaNcc_Hang();
            LoadCbbMacc_TienNghi();
            LoadCbbTenHang();
            LoadCbbTenTN();
        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void btnCreatePNHang_Click(object sender, EventArgs e)
        {
            String maNhaCC = (cbbMaNcc_Hang.SelectedItem as NhaCC).MaNhaCC;
            if (listHang.DataSource == null)
            {
                if (PhieuNhapHangDAO.Instance.insetPhieuNhapHang(maNhaCC))
                {
                    LoadListPhieuNhapHang();
                    addBindingMaHang();

                }
            }
            else
            {
                if (PhieuNhapHangDAO.Instance.insetPhieuNhapHang(maNhaCC))
                {
                    LoadListPhieuNhapHang();
                }
            }
        }
        void addBindingMaHang()
        {
            txbMaPhieuThue_Hang.DataBindings.Add("text", dtgvPhieuNhapHang.DataSource, "MaPhieuNhap");


        }
        void addBindingMaTn()
        {
            txbMaPhieuThue_TN.DataBindings.Add("text", dtgvPhieuNhapTN.DataSource, "MaPhieuNhap");

        }

        public void LoadListTienNghi()
        {
            listTn.DataSource = PhieuNhapTienNghiDAO.Instance.getListPhieuNhapTN();
        }
        public void LoadCbbTenTN()
        {
            cbbTenTN.DataSource = TienNghiDAO.Instance.getListTienNghi();
            cbbTenTN.DisplayMember = "TenTN";
        }
        public void LoadCbbTenHang()
        {
            cbbTenHang.DataSource = HangDAO.Instance.getListHang();
            cbbTenHang.DisplayMember = "tenHang";
        }
        public void LoadCbbMacc_TienNghi()
        {
            cbb_maNcc_TienNghi.DataSource = NhaCCDAO.Instance.getListNhaCC();
            cbb_maNcc_TienNghi.DisplayMember = "MaNhacc";
        }
        public void loadCbbMaNcc_Hang()
        {
            cbbMaNcc_Hang.DataSource = NhaCCDAO.Instance.getListNhaCC();
            cbbMaNcc_Hang.DisplayMember = "MaNhacc";
        }
        public void LoadListPhieuNhapHang()
        {
            listHang.DataSource = PhieuNhapHangDAO.Instance.getListPhieuNhapHang();

        }
        void UpdateMaPhieuNhap()
        {
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            int soLuong = 0;
            if (txbSoLuong_Hang.Text != "" && txbMaPhieuThue_Hang.Text != "")
            {
                soLuong = Convert.ToInt32(txbSoLuong_Hang.Text);
                int maPhieuThue = Convert.ToInt32(txbMaPhieuThue_Hang.Text);
                String maHang = (cbbTenHang.SelectedItem as Hang).MaHang;

                if (CT_phieuNhapHangDAO.Instance.InsertCt_phieuNhapHang(maPhieuThue, maHang, soLuong))
                {
                    dtgvCT_datHang.DataSource = CT_phieuNhapHangDAO.Instance.getDatabyMaPhieuThue(maPhieuThue);
                      PhieuNhapHangDAO.Instance.updateTongTienNhapHang(maPhieuThue);
                       LoadListPhieuNhapHang();

                }
            }
        }

        private void btnCreate_PhieuTienNghi_Click(object sender, EventArgs e)
        {
            String maNhaCC = (cbb_maNcc_TienNghi.SelectedItem as NhaCC).MaNhaCC;
            if (listTn.DataSource == null)
            {
                if (PhieuNhapTienNghiDAO.Instance.insetPhieuNhapTN(maNhaCC))
                {
                    LoadListTienNghi();
                    addBindingMaTn();
                }
            }
            else
            {
                if (PhieuNhapTienNghiDAO.Instance.insetPhieuNhapTN(maNhaCC))
                {
                    LoadListTienNghi();
                }

            }
        }

        private void btnDatTN_Click(object sender, EventArgs e)
        {
            int soLuong = 0;
            if (txbSoLuong_TN.Text != "" && txbMaPhieuThue_TN.Text != "")
            {
                soLuong = Convert.ToInt32(txbSoLuong_TN.Text);
                int maPhieuThue = Convert.ToInt32(txbMaPhieuThue_TN.Text);
                String maTN = (cbbTenTN.SelectedItem as TienNghi).MaTN;

                if (CT_phieuNhapTNDAO.Instance.InsertCt_phieuNhapTN(maPhieuThue, maTN, soLuong))
                {
                    dtgvCT_datTN.DataSource = CT_phieuNhapTNDAO.Instance.getDatabyMaPhieuThue(maPhieuThue);
                    PhieuNhapTienNghiDAO.Instance.updateTongTienNhapTN(maPhieuThue);
                    LoadListTienNghi();

                }
            }
        }
    }
}
