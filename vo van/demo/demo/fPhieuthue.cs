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
    public partial class fPhieuthue : Form
    {
        BindingSource KhachHangList = new BindingSource();
        BindingSource PhieuThueList = new BindingSource();
        BindingSource PhongTrongList = new BindingSource();
        private Account loginAccount;

        public Account LoginAccount {  get { return loginAccount; }
                            set { loginAccount = value; Type(loginAccount.Type);} }

        public fPhieuthue(Account acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
            Type(LoginAccount.Type);
            LoadData();
        }
        #region method

        public void LoadData()
        {
            dtgvLoadDataKHT3.DataSource = KhachHangList;
            dtgvPhieuThue.DataSource = PhieuThueList;
            dtgvPhongTrong.DataSource = PhongTrongList;
            LoadPhong();
            LoadCbbMaPhieuThue();
            LoadDichVu();
            LoadCbbMaKhachHang();
            LoadKhachHang();
            loadPhongTrong();
            loadAllDataPhieuThue();
            loadCbbNhanPhong();
            LoadKhachHangT3();
            addKhachHangBinding();
            addPhieuThueBinding();
            LoadNgay();


         }
        void LoadNgay()
        {
            dtpkDenNgay.Value = DateTime.Now;
            dtpkNgayDen.Value = DateTime.Now;
            dtpkNgayDi.Value = DateTime.Now;
            dtpkTuNgay.Value = DateTime.Now;

            dtpkDenNgay.MinDate = DateTime.Now;
            dtpkNgayDen.MinDate = DateTime.Now;
            dtpkNgayDi.MinDate = DateTime.Now;
            dtpkTuNgay.MinDate = DateTime.Now;
        }
         void addPhieuThueBinding()
        {
            txbMaPhieuThueDatTruoc.DataBindings.Add("text", dtgvPhieuThue.DataSource, "MaPhieuThue1");
            txbMaPhongDatTruoc.DataBindings.Add("text", dtgvPhongTrong.DataSource, "MaPhong1");
        }

        public void Type(int type)
        {
            QuanLiToolStripMenuItem.Enabled = type ==1;
            TaiKhoanToolStripMenuItem.Text += "(" + loginAccount.DisplayName + ")";
        }
        public void LoadKhachHangT3()
        {
            KhachHangList.DataSource = KhachHangDAO.Instance.getListKhachHang();
        }

        public void addKhachHangBinding()
        {
            txbMaKhachHangT3.DataBindings.Add(new Binding("text", dtgvLoadDataKHT3.DataSource, "MaKH1"));
            txbTenKhachHangT3.DataBindings.Add(new Binding("text",dtgvLoadDataKHT3.DataSource,"TenKH1"));
            txbSdtT3.DataBindings.Add(new Binding("text", dtgvLoadDataKHT3.DataSource, "Sdt1"));

        }
        public void loadCbbNhanPhong()
        {
            cbbNhanPhong.Controls.Clear();
            List<PhieuThue> listPhieuThue = PhieuThueDAO.Instance.getListPHieuThueByWait();
            cbbNhanPhong.DataSource = listPhieuThue;
            cbbNhanPhong.DisplayMember = "MaPhieuThue1";
        }
        public void loadAllDataPhieuThue()
        {
            List<PhieuThue> listPhieuThue = PhieuThueDAO.Instance.getListAllPhieuThue();
            PhieuThueList.DataSource = listPhieuThue;
        }
        public void loadPhongTrong()
        {
            List<Phong> listPhong = PhongDAO.Instance.getListPhong();
            PhongTrongList.DataSource = listPhong;
        }

        public void LoadKhachHang()
        {
            DataTable data = KhachHangDAO.Instance.getDataKhachHang();
            dtgvKhachHang.DataSource = data;
        }
        public void LoadCbbMaKhachHang()
        {
            List<KhachHang> listKhachHang = KhachHangDAO.Instance.getListKhachHang();
            cbbMaKhachHang.DataSource = listKhachHang;
            cbbMaKhachHang.DisplayMember = "MaKH1";

        }

        
        public void LoadDichVu()
        {
            List<DichVu> listDV = DichVuDAO.Instance.getListDichVu();

            cbbDichVu.DataSource = listDV;

            cbbDichVu.DisplayMember = "name";

        }
        

        public void ShowLvDichVu(int MaPhieuThue)
        {
            lvDichVu.Items.Clear();
            float TienDichVu= 0;
            List<Menu_DV> ListMenu = PhieuThueDAO.Instance.getListMenuByMaPHieuThue(MaPhieuThue);
            foreach (var item in ListMenu)
            {
                ListViewItem listViewItem = new ListViewItem(item.Name);
                listViewItem.SubItems.Add( item.Count.ToString());
                listViewItem.SubItems.Add(item.Price.ToString());
                listViewItem.SubItems.Add(item.TotalPrice.ToString());
                TienDichVu += item.TotalPrice;
                lvDichVu.Items.Add(listViewItem);
            }
            txbTienDichVu.Text = TienDichVu.ToString();
        }
        public void LoadCbbMaPhieuThue()
        {
            List<PhieuThue> ListPhieuThue = PhieuThueDAO.Instance.getListPhieuThueHSD();
            cbbMaPhieuThue.DataSource = ListPhieuThue;
            cbbMaPhieuThue.DisplayMember = "MaPhieuThue1";
        }
        public void LoadPhong()
        {
            List<Phong> listPhong = PhongDAO.Instance.getListPhong();
            foreach (Phong item in listPhong)
            {
                Button btn = new Button();

                btn.Height = 50;
                btn.Width = 75;
                btn.Text = "Phong " + item.SoPhong1 + Environment.NewLine + item.TrangThai1;
                btn.Tag = item;
                btn.Click += Btn_Click;
                switch (item.TrangThai1)
                {
                    case "trống":
                        btn.BackColor = Color.Green;
                        break;
                    default:
                        btn.BackColor = Color.Blue;
                        break;
                }
                flpPhong.Controls.Add(btn);
            }

        }

        #endregion

        #region event
        private void Btn_Click(object sender, EventArgs e)
        {
            Phong p = (sender as Button).Tag as Phong;
            flpPhong.Tag = p;
            txbMaPhong.Text = p.MaPhong1.ToString();

            PhieuThue pt = PhieuThueDAO.Instance.getPhieuThueByMaPhong(p.MaPhong1);

            int index = -1;
            int i = 0;
            foreach (PhieuThue item in cbbMaPhieuThue.Items)
            {
                if(pt.MaPhieuThue1 == item.MaPhieuThue1)
                {
                    index = i;
                }
                i++;
            }
            if(index > -1)
            {
                cbbMaPhieuThue.SelectedIndex = index;
            }


        }

        private void cbbMaPhieuThue_SelectedValueChanged(object sender, EventArgs e)
        {
            int Index = Convert.ToInt32(cbbMaPhieuThue.SelectedIndex.ToString());

            List<PhieuThue> listPhieuThue = PhieuThueDAO.Instance.getListPhieuThueHSD();

            if (Index != -1)
            {
                int maPhieuThue = listPhieuThue[Index].MaPhieuThue1;

                ShowLvDichVu(maPhieuThue);

                KhachHang kh = KhachHangDAO.Instance.getKhachHangByMaPhieuThue(maPhieuThue);

                txbTenKhachHang.Text = kh.TenKH1.ToString();

                object TienPhong = PhongDAO.Instance.getTienPhong(maPhieuThue);

                if( TienPhong != null)
                {
                    txbTienPhong.Text = TienPhong.ToString();
                }
            }
        }

        private void addPhong_Click(object sender, EventArgs e)
        {

            Phong p = flpPhong.Tag as Phong;
            if (p != null && p.TrangThai1 == "trống")
            {
                flpPhong.Controls.Clear();
                int MaPhong = Convert.ToInt32(p.MaPhong1);
                int MaPhieuThue = (cbbMaPhieuThue.SelectedItem as PhieuThue).MaPhieuThue1;
                ThuePhongDAO.Instance.InsertPhongIntoThuePhong(MaPhieuThue, MaPhong);
                LoadPhong();
            }
            else
            {
                MessageBox.Show("phòng đã có người");
            }


        }

        private void addDichVu_Click(object sender, EventArgs e)
        {
            if (cbbMaPhieuThue.SelectedItem != null)
            {
                int maPhieuThue = (cbbMaPhieuThue.SelectedItem as PhieuThue).MaPhieuThue1;
                int maDichVu = (cbbDichVu.SelectedItem as DichVu).MaDichVu1;
                int soLuong = Convert.ToInt32(nmSlDV.Value.ToString());
                DichVuDAO.Instance.insertDichVuIntoPhieuThue(maPhieuThue, maDichVu, soLuong);
                ShowLvDichVu(maPhieuThue);
            }
        }


        private void dtgvKhachHang_Click(object sender, EventArgs e)
        {
            int maKH = Convert.ToInt32( dtgvKhachHang.SelectedCells[0].OwningRow.Cells["MaKH"].Value.ToString());
            int i = 0;
            int index = -1;
            List<KhachHang> listKhachHang = KhachHangDAO.Instance.getListKhachHang();
            foreach (KhachHang item in listKhachHang)
            {
                if(maKH == item.MaKH1)
                {
                    index = i;
                    break;
                }
                i++;
            }
            cbbMaKhachHang.SelectedIndex = index;

        }

        private void btnLoadPhongTrong_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpkTuNgay.Value;
            DateTime denNgay = dtpkDenNgay.Value;
            List<Phong> listPhong = PhongDAO.Instance.getListPhongTrong(tuNgay, denNgay);
            PhongTrongList.DataSource = listPhong;
        }

        private void btnAddPhieuThue_Click(object sender, EventArgs e)
        {
            DateTime ngayDen = dtpkNgayDen.Value;
            DateTime ngayDi = dtpkNgayDi.Value;
            int maKH = (cbbMaKhachHang.SelectedItem as KhachHang).MaKH1;
            PhieuThueDAO.Instance.insertPhieuThue(ngayDen, ngayDi, maKH);
            loadAllDataPhieuThue();
            LoadCbbMaPhieuThue();
            loadCbbNhanPhong();

        }

        private void txbMaPhieuThueDatTruoc_TextChanged(object sender, EventArgs e)
        {
            if(txbMaPhieuThueDatTruoc.Text != "")
            {
                int maPhieuThue = Convert.ToInt32(txbMaPhieuThueDatTruoc.Text.ToString());
                DataTable data = ThuePhongDAO.Instance.LoadThuePhongByMaPhieuThue(maPhieuThue);
                dtgvThuePhong.DataSource = data;
            }
       

        }

        private void btnDatTruoc_Click(object sender, EventArgs e)
        {
            int maPHieuThue = (Convert.ToInt32(txbMaPhieuThueDatTruoc.Text));
            int maPhong = Convert.ToInt32(txbMaPhongDatTruoc.Text);

            ThuePhongDAO.Instance.InsertPhongIntoThuePhong(maPHieuThue,maPhong);

            if (txbMaPhieuThueDatTruoc.Text != "")
            {
                DataTable data = ThuePhongDAO.Instance.LoadThuePhongByMaPhieuThue(maPHieuThue);
                dtgvThuePhong.DataSource = data;
            }

        }

        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            if (cbbNhanPhong.SelectedItem != null)
            {
                int maPhieuThue = (cbbNhanPhong.SelectedItem as PhieuThue).MaPhieuThue1;
                PhieuThueDAO.Instance.NhanPhong(maPhieuThue);
                flpPhong.Controls.Clear();
                LoadPhong();
                LoadCbbMaPhieuThue();
                loadCbbNhanPhong();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txbTienPhong != null && cbbMaPhieuThue.SelectedItem!=null)
            {
                int maPhieuThue = (cbbMaPhieuThue.SelectedItem as PhieuThue).MaPhieuThue1;
                float tienPhong = (float)Convert.ToDouble(txbTienPhong.Text);
                float tienDichVu = (float)Convert.ToDouble(txbTienDichVu.Text);
                float tongTien = tienDichVu + tienPhong;

                if (MessageBox.Show(String.Format("Ban có thật sự muốn thanh toán ??? \n Mã Phiếu Thuê: {0}\n Tiền Phòng = {1}\n " +
                    "Tiền Dịch Vụ = {2} \n Tổng Tiền = {1} + {2} = {3}", maPhieuThue, tienPhong, tienDichVu, tongTien),
                    "Thanh toán", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    HoaDonDAO.Instance.ThanhToanHoaDon(maPhieuThue, tienPhong, tienDichVu, tongTien,loginAccount.DisplayName);
                    flpPhong.Controls.Clear();
                    LoadPhong();
                    LoadCbbMaPhieuThue();
                    loadAllDataPhieuThue();
                    txbTienPhong.Text = "0";
                }
            }
        }

        private void btnLoadKh_Click(object sender, EventArgs e)
        {
            LoadKhachHangT3();
        }
        #endregion

        private void btnAddKh_Click(object sender, EventArgs e)
        {
            String TenKH = txbTenKhachHangT3.Text;
            int sdt = Convert.ToInt32(txbSdtT3.Text);
            if (KhachHangDAO.Instance.InsertKhachHang(TenKH, sdt))
            {
                MessageBox.Show("Thêm thành công");
                LoadKhachHang();
                LoadCbbMaKhachHang();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnEditKh_Click(object sender, EventArgs e)
        {
            int maKH =Convert.ToInt32( txbMaKhachHangT3.Text);
            String TenKH = txbTenKhachHangT3.Text;
            int sdt = Convert.ToInt32(txbSdtT3.Text);

            if (KhachHangDAO.Instance.EditKhachHang(maKH,TenKH, sdt))
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnDeleteKh_Click(object sender, EventArgs e)
        {
            int maKH = Convert.ToInt32(txbMaKhachHangT3.Text);

            if (KhachHangDAO.Instance.DeleteKhachHang(maKH))
            {
                MessageBox.Show("Xóa thành Công");
                LoadKhachHang();
                LoadCbbMaKhachHang();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }


        private void QuanLiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLi f = new fQuanLi();
            f.ShowDialog();
        }

        private void DatHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNhapHang f = new fNhapHang();
            f.ShowDialog();
        }

        private void xemDuLieuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fXemDataHangAndTN f = new fXemDataHangAndTN();
            f.ShowDialog();
        }

        private void ThongTinCaNhanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(LoginAccount);
            f.ShowDialog();
        }

        private void ThoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
