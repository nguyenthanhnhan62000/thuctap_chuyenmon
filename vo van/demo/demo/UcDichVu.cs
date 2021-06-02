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
    public partial class UcDichVu : UserControl
    {
        BindingSource listDichVu = new BindingSource();
        
        public UcDichVu()
        {
            InitializeComponent();
            dtgvDichVu.DataSource = listDichVu;
            LoadListDichVu();
            addDichVuBinding();
        }

        public void LoadListDichVu()
        {
            listDichVu.DataSource = DichVuDAO.Instance.getListDichVu();
        }
        public void addDichVuBinding()
        {
            txbMaDichVu.DataBindings.Add(new Binding("text", dtgvDichVu.DataSource, "MaDichVu1"));
            txbTenDichVu.DataBindings.Add(new Binding("text", dtgvDichVu.DataSource, "Name"));
            txbGiaDichVu.DataBindings.Add(new Binding("text", dtgvDichVu.DataSource, "Gia"));
        }

        private void btnAddDichVu_Click(object sender, EventArgs e)
        {
            String name = txbTenDichVu.Text;
            float gia = (float)Convert.ToDouble(txbGiaDichVu.Text);

            if (DichVuDAO.Instance.InsertDichVu(name, gia))
            {
                MessageBox.Show("Thêm thành công");
                LoadListDichVu();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnEditDV_Click(object sender, EventArgs e)
        {
            int maDichVu = Convert.ToInt32(txbMaDichVu.Text);
            String name = txbTenDichVu.Text;
            float gia = (float)Convert.ToDouble(txbGiaDichVu.Text);

            if (DichVuDAO.Instance.editDichVu(maDichVu, name, gia))
            {
                MessageBox.Show("Sửa thành công");
                LoadListDichVu();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnDeleteDV_Click(object sender, EventArgs e)
        {
            int MaDichVu = Convert.ToInt32(txbMaDichVu.Text);

            if (DichVuDAO.Instance.deleteDichVu(MaDichVu))
            {
                MessageBox.Show("Xóa thành công");
                LoadListDichVu();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
    }
}
