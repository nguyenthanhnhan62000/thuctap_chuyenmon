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
    public partial class UcHangHoa : UserControl
    {

        BindingSource listHangHoa = new BindingSource();

        public UcHangHoa()
        {
            InitializeComponent();
            dtgvHangHoa.DataSource = listHangHoa;

            LoadListHang();
            addDichVuBinding();

        }


        public void addDichVuBinding()
        {
            txbMaH.DataBindings.Add(new Binding("text", dtgvHangHoa.DataSource, "MaHang"));
            txbTenH.DataBindings.Add(new Binding("text", dtgvHangHoa.DataSource, "TenHang"));
            txbDvt.DataBindings.Add(new Binding("text", dtgvHangHoa.DataSource, "DonViTinh"));
            txbGia.DataBindings.Add(new Binding("text", dtgvHangHoa.DataSource, "Gia"));
            txbSoL.DataBindings.Add(new Binding("text", dtgvHangHoa.DataSource, "SoLuong"));
            txbMoT.DataBindings.Add(new Binding("text", dtgvHangHoa.DataSource, "MoTa"));

        }
        public void LoadListHang()
        {
            listHangHoa.DataSource = HangDAO.Instance.getListHang();
        }

        private void btnAddHang_Click(object sender, EventArgs e)
        {

            String maH = txbMaH.Text;
            String tenH = txbTenH.Text;
            String dvt = txbDvt.Text;
            int  soLuong = Convert.ToInt32(txbSoL.Text);
         
            float gia = (float)Convert.ToDouble(txbGia.Text);

            if (HangDAO.Instance.InsertHang(maH, tenH, dvt, gia,soLuong))
            {
                MessageBox.Show("Thêm thành công");
                LoadListHang();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnEditHang_Click(object sender, EventArgs e)
        {
            String maH = txbMaH.Text;
            String tenH = txbTenH.Text;
            String dvt = txbDvt.Text;
            int soLuong = Convert.ToInt32(txbSoL.Text);

            float gia = (float)Convert.ToDouble(txbGia.Text);

            if (HangDAO.Instance.EditHang(maH, tenH, dvt, gia, soLuong))
            {
                MessageBox.Show("Sửa thành công");
                LoadListHang();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnDeleteHang_Click(object sender, EventArgs e)
        {
            String maH = txbMaH.Text;
        
            if (HangDAO.Instance.DeleteHang(maH))
            {
                MessageBox.Show("xóa thành công");
                LoadListHang();
            }
            else
            {
                MessageBox.Show("xóa thất bại");
            }
        }
    }
}
