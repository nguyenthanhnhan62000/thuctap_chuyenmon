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
    public partial class UcTienNghi : UserControl
    {


        BindingSource ListTN = new BindingSource();

        public UcTienNghi()
        {
            InitializeComponent();
            dtgvTienNghi.DataSource = ListTN;

            LoadListTienNghi();

            addDichVuBinding();
        }
        public void addDichVuBinding()
        {
            txbMa.DataBindings.Add(new Binding("text", dtgvTienNghi.DataSource, "MaTN"));

            txbTen.DataBindings.Add(new Binding("text", dtgvTienNghi.DataSource, "TenTN"));

            txbHienCo.DataBindings.Add(new Binding("text", dtgvTienNghi.DataSource, "SoLuong"));

            txbGia.DataBindings.Add(new Binding("text", dtgvTienNghi.DataSource, "Gia"));

            txbTinhTrang.DataBindings.Add(new Binding("text", dtgvTienNghi.DataSource, "TinhTrang1"));

        }

        public void LoadListTienNghi()
        {
            ListTN.DataSource = TienNghiDAO.Instance.getListTienNghi();
        }

        private void btnAddTN_Click(object sender, EventArgs e)
        {
            String maTN = txbMa.Text;
            String tenTN = txbTen.Text;
            String tinhTrang = txbTinhTrang.Text;

            int soLuong = Convert.ToInt32(txbHienCo.Text);
            int gia = Convert.ToInt32(txbGia.Text);

     
            if (TienNghiDAO.Instance.InsertTN(maTN, tenTN, tinhTrang,soLuong,gia))
            {
                MessageBox.Show("Thêm thành công");
                LoadListTienNghi();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnEditTN_Click(object sender, EventArgs e)
        {
            String maTN = txbMa.Text;
            String tenTN = txbTen.Text;
            String tinhTrang = txbTinhTrang.Text;

            int soLuong = Convert.ToInt32(txbHienCo.Text);
            int gia = Convert.ToInt32(txbGia.Text);


            if (TienNghiDAO.Instance.EditTN(maTN, tenTN, tinhTrang, soLuong, gia))
            {
                MessageBox.Show("Sửa thành công");
                LoadListTienNghi();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnDeleteTN_Click(object sender, EventArgs e)
        {
            String maTN = txbMa.Text;

            if (TienNghiDAO.Instance.DeleteTN(maTN))
            {
                MessageBox.Show("Xóa thành công");
                LoadListTienNghi();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
    }
}
