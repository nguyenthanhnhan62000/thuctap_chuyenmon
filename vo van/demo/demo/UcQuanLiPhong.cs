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
    public partial class UcQuanLiPhong : UserControl
    {
        BindingSource listPhong = new BindingSource();
        public UcQuanLiPhong()
        {
            InitializeComponent();
            dtgvPhong.DataSource = listPhong;
            loadListPhong();
            addPhongBinding();
        }
        public void loadListPhong()
        {
            listPhong.DataSource = PhongDAO.Instance.getListPhong();
        }
        public void addPhongBinding()
        {
            txbMaPhong.DataBindings.Add(new Binding("text", dtgvPhong.DataSource, "MaPhong1"));
            txbSoPhong.DataBindings.Add(new Binding("text", dtgvPhong.DataSource, "SoPhong1"));
            //txbTinhTrangPhong.DataBindings.Add(new Binding("text", dtgvPhong.DataSource, "TrangThai1"));
            txbDonGiaPhong.DataBindings.Add(new Binding("text", dtgvPhong.DataSource, "DonGia1"));
            //cbbTang.DataBindings.Add(new Binding("SelectedText", dtgvPhong.DataBindings, "Tang1"));

        }

        private void btnAddPhong_Click(object sender, EventArgs e)
        {
            if (cbbLoai.SelectedItem !=null && cbbTang.SelectedItem != null)
            {
                int SoPhong = Convert.ToInt32(txbSoPhong.Text);
                float donGia = (float)Convert.ToDouble(txbDonGiaPhong.Text);
                int tang = Convert.ToInt32(cbbTang.SelectedItem.ToString());
                String loai = cbbLoai.SelectedItem.ToString();


                if (PhongDAO.Instance.InsertPhong(SoPhong, "trống", donGia, tang, loai))
                {
                    MessageBox.Show("Thêm thành công");
                    loadListPhong();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
          
        }

        private void btnDeletePhong_Click(object sender, EventArgs e)
        {
            int MaPhong = Convert.ToInt32(txbMaPhong.Text);

            if (PhongDAO.Instance.DeletePhong(MaPhong))
            {
                MessageBox.Show("Xóa thành công");
                loadListPhong();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnEditPhong_Click(object sender, EventArgs e)
        {
            if (cbbLoai.SelectedItem != null && cbbTang.SelectedItem != null)
            {
                int MaPhong = Convert.ToInt32(txbMaPhong.Text);
                int soPhong = Convert.ToInt32(txbSoPhong.Text);
                float donGia = (float)Convert.ToDouble(txbDonGiaPhong.Text);
                int tang = Convert.ToInt32(cbbTang.SelectedItem.ToString());
                String loai = cbbLoai.SelectedItem.ToString();

                if (PhongDAO.Instance.EditPhong(MaPhong, soPhong, donGia, tang, loai))
                {
                    MessageBox.Show("Sửa thành công");
                    loadListPhong();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
        }

        private void txbFindPhong_TextChanged(object sender, EventArgs e)
        {
            String SoPhong =txbFindPhong.Text;
            dtgvPhong.DataSource = PhongDAO.Instance.FindPhong(SoPhong);
        }
    }
    
}
