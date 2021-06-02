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
    public partial class fQuanLi : Form
    {

        BindingSource listPhong = new BindingSource();
        BindingSource listDichVu = new BindingSource();
        BindingSource listAccount = new BindingSource();
        public fQuanLi()
        {
           
            InitializeComponent();
            dtgvPhong.DataSource = listPhong;
            dtgvDichVu.DataSource = listDichVu;
            dtgvAccount.DataSource = listAccount;
            load();
        }
        public void load()
        {
            loadListPhong();
            LoadListDichVu();
            loadNHanVien();
            LoadListAccount();
            LoadListHang();
            LoadListNhaCC();
            LoadListKho();
            LoadListTienNghi();
            loadBinding();
        }
        public void loadBinding()
        {
            addPhongBinding();
            addDichVuBinding();
            addAccountBinding();
        }
        public void addAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("text", dtgvAccount.DataSource, "userName"));
            txbDisplayName.DataBindings.Add(new Binding("text", dtgvAccount.DataSource, "displayName"));
            nmType.DataBindings.Add(new Binding("value", dtgvAccount.DataSource, "type"));
        }
        public void LoadListKho()
        {
            dtgvKho.DataSource = KhoDAO.Instance.getDataKho();
        }


        public void LoadListNhaCC()
        {
            dtgvNhaCC.DataSource = NhaCCDAO.Instance.getListNhaCC();
        }
        public void LoadListTienNghi()
        {
            dtgvTienNghi.DataSource = TienNghiDAO.Instance.getListTienNghi();
        }
        public void LoadListHang()
        {
            dtgvHangHoa.DataSource = HangDAO.Instance.getListHang();
        }
        public void LoadListAccount()
        {
            listAccount.DataSource = AccountDAO.Instance.getListAccount();
        }

        public void loadNHanVien() 
        {
            dtgvNhanVien.DataSource = NhanVienDAO.Instance.getDataNhanVien();
        }


        #region methods

        public void addDichVuBinding()
        {
            txbMaDichVu.DataBindings.Add(new Binding("text", dtgvDichVu.DataSource, "MaDichVu1"));
            txbTenDichVu.DataBindings.Add(new Binding("text", dtgvDichVu.DataSource, "Name"));
            txbGiaDichVu.DataBindings.Add(new Binding("text", dtgvDichVu.DataSource, "Gia"));
        }

        public void LoadListDichVu()
        {
            listDichVu.DataSource = DichVuDAO.Instance.getListDichVu();
        }

        public void addPhongBinding()
        {
            txbMaPhong.DataBindings.Add(new Binding("text", dtgvPhong.DataSource, "MaPhong1"));
            txbSoPhong.DataBindings.Add(new Binding("text", dtgvPhong.DataSource, "SoPhong1"));
            txbTinhTrangPhong.DataBindings.Add(new Binding("text", dtgvPhong.DataSource, "TrangThai1"));
            txbDonGiaPhong.DataBindings.Add(new Binding("text", dtgvPhong.DataSource, "DonGia1"));
        }
        public void loadListPhong()
        {
           listPhong.DataSource = PhongDAO.Instance.getListPhong();
        }
        #endregion

        #region events
        private void btnLoadPhong_Click(object sender, EventArgs e)
        {
            loadListPhong();
        }

        #endregion

        private void btnAddPhong_Click(object sender, EventArgs e)
        {
            int SoPhong = Convert.ToInt32( txbSoPhong.Text);
            float donGia = (float)Convert.ToDouble(txbDonGiaPhong.Text);

            if (PhongDAO.Instance.InsertPhong(SoPhong,"trống",donGia,1,""))
            {
                MessageBox.Show("Thêm thành công");    
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnDeletePhong_Click(object sender, EventArgs e)
        {
            int MaPhong = Convert.ToInt32(txbMaPhong.Text);

            if (PhongDAO.Instance.DeletePhong(MaPhong))
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnEditPhong_Click(object sender, EventArgs e)
        {
            int MaPhong = Convert.ToInt32(txbMaPhong.Text);
            int soPhong = Convert.ToInt32(txbSoPhong.Text);
            float donGia= (float)Convert.ToDouble(txbDonGiaPhong.Text);

            if (PhongDAO.Instance.EditPhong(MaPhong,soPhong,donGia,1,""))
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }

        }

        private void btnDeleteDichVu_Click(object sender, EventArgs e)
        {
            int MaDichVu = Convert.ToInt32(txbMaDichVu.Text);

            if (DichVuDAO.Instance.deleteDichVu(MaDichVu))
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }

        }

        private void btnAddDichVu_Click(object sender, EventArgs e)
        {
            String name = txbTenDichVu.Text;
            float gia = (float)Convert.ToDouble( txbGiaDichVu.Text);

            if (DichVuDAO.Instance.InsertDichVu(name,gia))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnEditDichVu_Click(object sender, EventArgs e)
        {
            int maDichVu = Convert.ToInt32( txbMaDichVu.Text);
            String name = txbTenDichVu.Text;
            float gia = (float)Convert.ToDouble(txbGiaDichVu.Text);

            if (DichVuDAO.Instance.editDichVu(maDichVu,name,gia))
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

     

        private void btnLoadDichVu_Click_1(object sender, EventArgs e)
        {
            LoadListDichVu();
        }
        #region account
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            String userName = txbUserName.Text;
            String disPlayName = txbDisplayName.Text;
            int type = (int)nmType.Value;

            if (AccountDAO.Instance.InsertAccount(type, disPlayName, userName))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            String userName = txbUserName.Text;
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            String userName = txbUserName.Text;
            String disPlayName = txbDisplayName.Text;
            int type = (int)nmType.Value;

            if (AccountDAO.Instance.EditAccount(type, disPlayName, userName))
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnLoadAccount_Click(object sender, EventArgs e)
        {
            LoadListAccount();
        }

        private void btnSetPassWord_Click(object sender, EventArgs e)
        {
            String userName = txbUserName.Text;
            if (AccountDAO.Instance.resetPassword(userName))
            {
                MessageBox.Show("reset thành công");
            }
            else
            {
                MessageBox.Show("reset thất bại");
            }
        }
        #endregion

    }
}
