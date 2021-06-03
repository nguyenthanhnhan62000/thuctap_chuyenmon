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
    public partial class UcNhanVien : UserControl
    {

        BindingSource ListNhanVIen = new BindingSource();
        public UcNhanVien()
        {
            InitializeComponent();
            dtgvNhanVien.DataSource = ListNhanVIen;
            loadNHanVien();
            addDichVuBinding();
        }
        public void addDichVuBinding()
        {
            txbMaNv.DataBindings.Add(new Binding("text", dtgvNhanVien.DataSource, "MANV"));

            txbTen.DataBindings.Add(new Binding("text", dtgvNhanVien.DataSource, "TENNV"));

            txbLuog.DataBindings.Add(new Binding("text", dtgvNhanVien.DataSource, "LUONG"));

            txbDiaChi.DataBindings.Add(new Binding("text", dtgvNhanVien.DataSource, "DIACHI"));

            txbGioiTinh.DataBindings.Add(new Binding("text", dtgvNhanVien.DataSource, "GIOITINH"));

            txbSdt.DataBindings.Add(new Binding("text", dtgvNhanVien.DataSource, "SODT"));

            dtpkNgay.DataBindings.Add(new Binding("value", dtgvNhanVien.DataSource, "NGAYSINH"));




        }


        public void loadNHanVien()
        {
            ListNhanVIen.DataSource = NhanVienDAO.Instance.getDataNhanVien();
        }

        private void btnAddNhanVien_Click(object sender, EventArgs e)
        {
            String maNv = txbMaNv.Text;
            String teNv = txbTen.Text;
            String diaCHi = txbDiaChi.Text;
            String gioiTInh = txbGioiTinh.Text;
            float luong =(float)Convert.ToDouble(txbLuog.Text);
            DateTime ngaySInh = dtpkNgay.Value;
            String sdt = txbSdt.Text;


            if (NhanVienDAO.Instance.InsertNhanVien(maNv,teNv,ngaySInh,gioiTInh,diaCHi,sdt,luong))
            {
                MessageBox.Show("Thêm thành công");
                loadNHanVien();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnEditNhanVien_Click(object sender, EventArgs e)
        {
            String maNv = txbMaNv.Text;
            String teNv = txbTen.Text;
            String diaCHi = txbDiaChi.Text;
            String gioiTInh = txbGioiTinh.Text;
            float luong = (float)Convert.ToDouble(txbLuog.Text);
            DateTime ngaySInh = dtpkNgay.Value;
            String sdt = txbSdt.Text;


            if (NhanVienDAO.Instance.editNhanVien(maNv, teNv, ngaySInh, gioiTInh, diaCHi, sdt, luong))
            {
                MessageBox.Show("Sửa thành công");
                loadNHanVien();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnDeleteNhanVIen_Click(object sender, EventArgs e)
        {
            String maNv = txbMaNv.Text;

            if (NhanVienDAO.Instance.deleteNhanVien(maNv))
            {
                MessageBox.Show("Xóa thành công");
                loadNHanVien();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
    }

}
