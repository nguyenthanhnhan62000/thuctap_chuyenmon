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
    public partial class UcKho : UserControl
    {
        BindingSource listKho = new BindingSource();

        public UcKho()
        {
            InitializeComponent();
            dtgvKho.DataSource = listKho;
            LoadListKho();
            addDichVuBinding();

        }

        public void addDichVuBinding()
        {
            txbMaKho.DataBindings.Add(new Binding("text", dtgvKho.DataSource, "MAKHO"));

            txbTenKho.DataBindings.Add(new Binding("text", dtgvKho.DataSource, "TENKHO"));

            txbViTri.DataBindings.Add(new Binding("text", dtgvKho.DataSource, "VITRI"));

            txbMoTa.DataBindings.Add(new Binding("text", dtgvKho.DataSource, "MOTA"));

        }
        public void LoadListKho()
        {
            listKho.DataSource = KhoDAO.Instance.getDataKho();
        }

        private void btnAddKho_Click(object sender, EventArgs e)
        {
            String maKho = txbMaKho.Text;
            String tenKho = txbTenKho.Text;
            String vitri = txbViTri.Text;
            String mota = txbMoTa.Text;


            if (KhoDAO.Instance.InsertKho(maKho, tenKho, vitri, mota))
            {
                MessageBox.Show("Thêm thành công");
                LoadListKho();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnEditKho_Click(object sender, EventArgs e)
        {
            String maKho = txbMaKho.Text;
            String tenKho = txbTenKho.Text;
            String vitri = txbViTri.Text;
            String mota = txbMoTa.Text;


            if (KhoDAO.Instance.EditKho(maKho, tenKho, vitri, mota))
            {
                MessageBox.Show("Sửa thành công");
                LoadListKho();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnDeleteKho_Click(object sender, EventArgs e)
        {
            String maKho = txbMaKho.Text;

            if (KhoDAO.Instance.DeleteKho(maKho))
            {
                MessageBox.Show("Xóa thành công");
                LoadListKho();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
    }
}
