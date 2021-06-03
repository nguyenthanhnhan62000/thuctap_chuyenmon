using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using demo.DTO;
using demo.DAO;
using DevComponents.DotNetBar;

namespace demo
{
    public partial class UcThuePhong : UserControl
    {
      
        BindingSource PhieuThueList = new BindingSource();
        BindingSource KhachHangList = new BindingSource();
        int setConvert = 0;


        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; }
        }

        public UcThuePhong(Account acc)
        {
            InitializeComponent();

            lbTatCaPhong.Enabled = false;

            loginAccount = acc;

            LoadData();
        }

        private void LoadData()
        {
            dtgvPhieuThue.DataSource = PhieuThueList;
            dtgvLoadDataKHT3.DataSource = KhachHangList;
            LoadNgay();
          
            LoadcbbMaPhieuThue();
            loadCbbNhanPhong();
            LoadCbbMaKhachHang();
            LoadDichVu();
            loadAllDataPhieuThue();
            LoadcbbMaPhieuThueDangAndCho();
            LoadKhachHang();
            LoadKhachHangT3();
            addKhachHangBinding();
            addPhieuThueBinding();
            LoadPhong();

        }

        #region mt

        public void addKhachHangBinding()
        {
            txbMaKhachHangT3.DataBindings.Add(new Binding("text", dtgvLoadDataKHT3.DataSource, "MaKH1"));
            txbTenKhachHangT3.DataBindings.Add(new Binding("text", dtgvLoadDataKHT3.DataSource, "TenKH1"));
            txbSdtT3.DataBindings.Add(new Binding("text", dtgvLoadDataKHT3.DataSource, "Sdt1"));

        }

        public void LoadKhachHangT3()
        {
            KhachHangList.DataSource = KhachHangDAO.Instance.getListKhachHang();
        }

        public void LoadKhachHang()
        {
            //DataTable data = KhachHangDAO.Instance.getDataKhachHang();
            //dtgvKhachHang.DataSource = data;
        }
        void addPhieuThueBinding()
        {
           
        }

        public void LoadCbbMaKhachHang()
        {
            List<KhachHang> listKhachHang = KhachHangDAO.Instance.getListKhachHang();
            cbbMaKhachHang.DataSource = listKhachHang;
            cbbMaKhachHang.DisplayMember = "MaKH1";

        }
        void LoadPhongTrong(List<Phong> listPhong,FlowLayoutPanel flpPhongTrong,FlowLayoutPanel flp2,FlowLayoutPanel flp3)
        {
            flpPhongTrong.Controls.Clear();
            flp2.Controls.Clear();
            flp3.Controls.Clear();
            foreach (Phong item in listPhong)
            {
                Button btn = new Button();
                btn.Font = new Font(new FontFamily("Times New Roman"), 12);
                //btn.Font = new Font(btn.Font, FontStyle.Bold);
                btn.Height = 90;
                btn.Width = 80;
                btn.Tag = item;
                btn.Text = "Phong " + item.SoPhong1 ;
                btn.BackColor = Color.FromArgb(0, 192, 0);
                btn.Tag = item;
                btn.Click += Btn_Click;

                switch (item.Tang1)
                {
                    case 1:
                        flpPhongTrong.Controls.Add(btn);
                        break;
                    case 2:
                        flp2.Controls.Add(btn);

                        break;
                    case 3:
                        flp3.Controls.Add(btn);

                        break;

                    default:
                        break;
                } 
            }
        }
        void LoadPhongTrong1(List<Phong> listPhong, FlowLayoutPanel flpPhongTrong)
        {
            flpPhongTrong.Controls.Clear();
            flpPhongOfTang2.Controls.Clear();
            flpPhongOfTang3.Controls.Clear();
            foreach (Phong item in listPhong)
            {

                LabelX lb1 = new LabelX() { Height = 90, Width = 40 };

                lb1.TextAlignment = StringAlignment.Center;
                lb1.ForeColor = Color.White;
                lb1.Text = item.SoPhong1.ToString();
                lb1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lb1.Font = new Font(new FontFamily("Times New Roman"), 15, FontStyle.Bold);

                LabelX lb = new LabelX() { Height = 90, Width = 140 };
                lb.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lb.TextAlignment = StringAlignment.Center;
                lb.Font = new Font(lb1.Font, FontStyle.Bold);
                lb.Font = new Font(new FontFamily("Times New Roman"), 11, FontStyle.Bold);

                lb1.ForeColor = Color.White;
                lb1.Text = item.SoPhong1.ToString();
                lb1.BackColor = Color.FromArgb(30, 156, 37);
                lb.BackColor = Color.FromArgb(219, 230, 210);
                lb.Text = item.TrangThai1;
                lb.ForeColor = Color.FromArgb(30, 156, 37);
                lb.Font = new Font(new FontFamily("Times New Roman"), 15, FontStyle.Bold);

                FlowLayoutPanel f = new FlowLayoutPanel() { Height = 90, Width = 180 };
                f.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
                f.Controls.Add(lb1);
                f.Controls.Add(lb);

                switch (item.Tang1)
                {
                    case 1:
                        flpPhongTrong.Controls.Add(f);
                        break;
                    case 2:
                        flpPhongOfTang2.Controls.Add(f);

                        break;
                    case 3:
                        flpPhongOfTang3.Controls.Add(f);

                        break;

                    default:
                        break;
                }

               

            }
            }

        void LoadPhongDaDatTab1(List<Phong> listPhong, FlowLayoutPanel flpPhongDaDat)
        {
            flpPhongDaDat.Controls.Clear();
            flpPhongOfTang2.Controls.Clear();
            flpPhongOfTang3.Controls.Clear();

            foreach (Phong item in listPhong)
            {
                Button btn = new Button();
                btn.Font = new Font(new FontFamily("Times New Roman"), 12);
                //btn.Font = new Font(btn.Font, FontStyle.Bold);
                btn.Height = 90;
                btn.Width = 80;
                btn.Tag = item;
                btn.Text = "Phong " + item.SoPhong1 + Environment.NewLine;
                btn.BackColor = Color.FromArgb(255, 128, 128);
                btn.Tag = item;
               

                switch (item.Tang1)
                {
                    case 1:
                        flpPhongDaDat.Controls.Add(btn);
                        break;
                    case 2:
                        flpPhongOfTang2.Controls.Add(btn);

                        break;
                    case 3:
                        flpPhongOfTang3.Controls.Add(btn);

                        break;

                    default:
                        break;
                }
            }
        }
        void LoadPhongDaDat(List<Phong> listPhong,FlowLayoutPanel flpPhongDaDat)
        {
            flpPhongDaDat.Controls.Clear();

            foreach (Phong item in listPhong)
            {
                Button btn = new Button();
                btn.Font = new Font(new FontFamily("Times New Roman"), 12);
                //btn.Font = new Font(btn.Font, FontStyle.Bold);
                btn.Height = 90;
                btn.Width = 80;
                btn.Tag = item;
                btn.Text = "Phong " + item.SoPhong1 + Environment.NewLine;
                btn.BackColor = Color.FromArgb(255, 128, 128);
                btn.Tag = item;
                btn.Click += Btn_ClickPhongDaDat;

                flpPhongDaDat.Controls.Add(btn);
            }
        }
        void LoadPhongDaDat1(List<Phong> listPhong, FlowLayoutPanel flpPhongDaDat)
        {
            flpPhongDaDat.Controls.Clear();
            flpPhongOfTang2.Controls.Clear();
            flpPhongOfTang3.Controls.Clear();

            foreach (Phong item in listPhong)
            {
                LabelX lb1 = new LabelX() { Height = 90, Width = 40 };

                lb1.TextAlignment = StringAlignment.Center;
                lb1.ForeColor = Color.White;
                lb1.Text = item.SoPhong1.ToString();
                lb1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lb1.Font = new Font(new FontFamily("Times New Roman"), 15, FontStyle.Bold);

                LabelX lb = new LabelX() { Height = 90, Width = 140 };
                lb.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lb.TextAlignment = StringAlignment.Center;
                lb.Font = new Font(lb1.Font, FontStyle.Bold);
                lb.Font = new Font(new FontFamily("Times New Roman"), 11, FontStyle.Bold);

                lb.Font = new Font(new FontFamily("Times New Roman"), 11, FontStyle.Bold);
                PhieuThue pt = PhieuThueDAO.Instance.getPhieuThueByMaPhong(item.MaPhong1);
                KhachHang kh = KhachHangDAO.Instance.getKhachHangByMaKh(pt.MaKH1);
                lb1.BackColor = Color.FromArgb(241, 71, 71);
                lb.BackColor = Color.FromArgb(230, 203, 203);
                String ngayDen = pt.NgayDen1.Day + "/" + pt.NgayDen1.Month + "/" + pt.NgayDen1.Year;
                String ngayDi = pt.NgayDi1.Day + "/" + pt.NgayDi1.Month + "/" + pt.NgayDi1.Year;

                lb.Text = ngayDen + "\n\n" + kh.TenKH1 + "\n\n" + ngayDi;
                lb.ForeColor = Color.FromArgb(241, 71, 71);

                FlowLayoutPanel f = new FlowLayoutPanel() { Height = 90, Width = 180 };
                f.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
                f.Controls.Add(lb1);
                f.Controls.Add(lb);

                switch (item.Tang1)
                {
                    case 1:
                        flpPhong.Controls.Add(f);
                        break;
                    case 2:
                        flpPhongOfTang2.Controls.Add(f);

                        break;
                    case 3:
                        flpPhongOfTang3.Controls.Add(f);

                        break;

                    default:
                        break;
                }


            }
        }

        private void Btn_ClickPhongDaDat(object sender, EventArgs e)
        {
            Phong p = (sender as Button).Tag as Phong;
            Button btn = sender as Button;

            if (btn.BackColor == Color.FromArgb(255, 128, 128))
            {
                btn.BackColor = Color.BlueViolet;
            }
            else if (btn.BackColor == Color.BlueViolet)
            {
                btn.BackColor = Color.FromArgb(255, 128, 128);
            }


            txbMaPhongDaDat.Text = "";
            foreach (Button item in flpPhongDaDat.Controls)
            {
                Phong p1 = item.Tag as Phong;
                if (item.BackColor == Color.BlueViolet)
                {
                    txbMaPhongDaDat.Text += p1.SoPhong1 + " ";
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {

            Phong p = (sender as Button).Tag as Phong;
            Button btn = sender as Button;

            if (btn.BackColor == Color.FromArgb(0, 192, 0))
            {
                btn.BackColor = Color.BlueViolet;
            }
            else if (btn.BackColor == Color.BlueViolet)
            {
                btn.BackColor = Color.FromArgb(0, 192, 0);
            }


            txbMaPhongDatTruoc.Text = "";
            foreach (Button item in flpPhongTrong.Controls)
            {

                    Phong p1 = item.Tag as Phong;
                    if (item.BackColor == Color.BlueViolet)
                    {
                        txbMaPhongDatTruoc.Text += p1.SoPhong1 + " ";
                    }
                
               
            }
            foreach (Button item in flpPhongTrongOfTang2.Controls)
            {

                Phong p1 = item.Tag as Phong;
                if (item.BackColor == Color.BlueViolet)
                {
                    txbMaPhongDatTruoc.Text += p1.SoPhong1 + " ";
                }
            }
            foreach (Button item in flpPhongTrongOfTang3.Controls)
            {

                Phong p1 = item.Tag as Phong;
                if (item.BackColor == Color.BlueViolet)
                {
                    txbMaPhongDatTruoc.Text += p1.SoPhong1 + " ";
                }
            }

        }
        public void NhanPhong(int maPhieuThue)
        {
            DataProvider.Instance.execQ("EXEC dbo.USP_nhanPhong @maPhieuThue = " + maPhieuThue + " ");
        }

        private void LoadcbbMaPhieuThue()
        {
            List<PhieuThue> ListPhieuThue = PhieuThueDAO.Instance.getListPhieuThueHSD();
            cbbMaPhieuThue.DataSource = ListPhieuThue;
            cbbMaPhieuThue.DisplayMember = "MaPhieuThue1";
        }
        private void LoadcbbMaPhieuThueDangAndCho()
        {
            List<PhieuThue> ListPhieuThue = PhieuThueDAO.Instance.getListPhieuThueDangAndCho();
            cbbPhieuThueDangAndCho.DataSource = ListPhieuThue;
            cbbPhieuThueDangAndCho.DisplayMember = "MaPhieuThue1";
        }
        public void loadCbbNhanPhong()
        {
            cbbNhanPhong.Controls.Clear();
            List<PhieuThue> listPhieuThue = PhieuThueDAO.Instance.getListPHieuThueByWait();
            cbbNhanPhong.DataSource = listPhieuThue;
            cbbNhanPhong.DisplayMember = "MaPhieuThue1";
        }

            void loadPhong0()
        {
            flpPhong.Controls.Clear();
            flpPhongOfTang2.Controls.Clear();
            flpPhongOfTang3.Controls.Clear();

            List<Phong> listPhong = PhongDAO.Instance.getListPhong();

            const String TAT_CA = "Tất Cả";
            lbTatCaPhong.Text = TAT_CA + "(" + listPhong.Count + ")";
            int iTrong = 0;
            int iCoNguoi = 0;
            foreach (Phong item in listPhong)
            {
                Button btn = new Button();

                btn.Font = new Font(new FontFamily("Times New Roman"), 12);
                btn.Font = new Font(btn.Font, FontStyle.Bold);
                btn.Height = 90;
                btn.Width = 80;
                btn.ForeColor = Color.Gainsboro;
                btn.Tag = item;
                btn.Click += Btn_ClickPhong;
                switch (item.TrangThai1)
                {
                    case "trống":
                        iTrong++;
                        btn.BackColor = Color.FromArgb(30, 156, 37);
                        btn.Text = "Phòng" + "\n" + item.SoPhong1.ToString();
                        break;
                    case "có người":
                        iCoNguoi++;
                        PhieuThue pt = PhieuThueDAO.Instance.getPhieuThueByMaPhong(item.MaPhong1);
                        btn.Text = pt.MaPhieuThue1 + "\n" + "Phòng " + item.SoPhong1;

                        btn.BackColor = Color.FromArgb(241, 71, 71);
                        break;
                    default:
                        break;
                }
                btn.Text +=  "\n" +item.Loai1;
                switch (item.Tang1)
                {
                    case 1:
                        flpPhong.Controls.Add(btn);
                        break;
                    case 2:
                        flpPhongOfTang2.Controls.Add(btn);

                        break;
                    case 3:
                        flpPhongOfTang3.Controls.Add(btn);

                        break;
                           
                    default:
                        break;
                }

               
            }
            String trong = "Trống";
            String coNguoi = "Có Người";
            lbTrong.Text = trong + "(" + iTrong + ")";
            lbCoNguoi.Text = coNguoi + "(" + iCoNguoi + ")";
        }

        void loadPhong1()
        {
            flpPhong.Controls.Clear();
            flpPhongOfTang2.Controls.Clear();
            flpPhongOfTang3.Controls.Clear();


            List<Phong> listPhong = PhongDAO.Instance.getListPhong();

            const String TAT_CA = "Tất Cả";
            lbTatCaPhong.Text = TAT_CA + "(" + listPhong.Count + ")";
            int iTrong = 0;
            int iCoNguoi = 0;
            foreach (Phong item in listPhong)
            {
             

                LabelX lb1 = new LabelX() { Height = 90, Width = 40 };
            
                lb1.TextAlignment = StringAlignment.Center;
                lb1.ForeColor = Color.White;
                lb1.Text = item.SoPhong1.ToString();
                lb1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lb1.Font = new Font(new FontFamily("Times New Roman"), 15, FontStyle.Bold);

                LabelX lb = new LabelX() { Height = 90, Width = 140 };
                lb.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lb.TextAlignment = StringAlignment.Center;
                lb.Font = new Font(lb1.Font, FontStyle.Bold);
                lb.Font = new Font(new FontFamily("Times New Roman"), 11, FontStyle.Bold);

                if (item.TrangThai1 == "trống")
                {
                    iTrong++;
                    lb1.ForeColor = Color.White;
                    lb1.Text = item.SoPhong1.ToString();
                    lb1.BackColor = Color.FromArgb(30, 156, 37);
                    lb.BackColor = Color.FromArgb(219, 230, 210);
                    lb.Text = item.TrangThai1;
                    lb.ForeColor = Color.FromArgb(30, 156, 37);
                    lb.Font = new Font(new FontFamily("Times New Roman"), 15, FontStyle.Bold);
                }
                else if (item.TrangThai1 == "có người")
                {
                    iCoNguoi++;
                    lb.Font = new Font(new FontFamily("Times New Roman"), 11, FontStyle.Bold);
                    PhieuThue pt = PhieuThueDAO.Instance.getPhieuThueByMaPhong(item.MaPhong1);
                    KhachHang kh = KhachHangDAO.Instance.getKhachHangByMaKh(pt.MaKH1);
                    lb1.BackColor = Color.FromArgb(241, 71, 71);
                    lb.BackColor = Color.FromArgb(230, 203, 203);
                    String ngayDen = pt.NgayDen1.Day + "/" + pt.NgayDen1.Month + "/" + pt.NgayDen1.Year;
                    String ngayDi = pt.NgayDi1.Day + "/" + pt.NgayDi1.Month + "/" + pt.NgayDi1.Year;

                    lb.Text = ngayDen + "\n\n"  + kh.TenKH1 +"\n\n"+ ngayDi;
                    lb.ForeColor = Color.FromArgb(241, 71, 71);
                }

                FlowLayoutPanel f = new FlowLayoutPanel() { Height = 90, Width = 180 };
                f.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
                f.Controls.Add(lb1);
                f.Controls.Add(lb);


                switch (item.Tang1)
                {
                    case 1:
                        flpPhong.Controls.Add(f);
                        break;
                    case 2:
                        flpPhongOfTang2.Controls.Add(f);

                        break;
                    case 3:
                        flpPhongOfTang3.Controls.Add(f);

                        break;

                    default:
                        break;
                }
            }
            String trong = "Trống";
            String coNguoi = "Có Người";
            lbTrong.Text = trong + "(" + iTrong + ")";
            lbCoNguoi.Text = coNguoi + "(" + iCoNguoi + ")";
        }

        private void LoadPhong()
        {
            if (setConvert == 0)
            {
                loadPhong0();
            }
            else
            {
                loadPhong1();
            }
           
        }

        void LoadCbbPhong(int MaPhieuThue)
        {
            List<Phong> listPhong = PhongDAO.Instance.getListPhongByMaPhieuThue(MaPhieuThue);
            List<Phong> listPhong1 = PhongDAO.Instance.getListPhongByMaPhieuThue(MaPhieuThue);

            cbbPhongHuy.DataSource = listPhong;
            cbbPhongHuy.DisplayMember = "SoPhong1";

            cbbPhongChuyen.DataSource = listPhong1;
            cbbPhongChuyen.DisplayMember = "SoPhong1";

        }
        void LoadNgay()
        {
            //dtpkDenNgay.Value = DateTime.Now;
            dtpkNgayDen.Value = DateTime.Now;
            dtpkNgayDi.Value = DateTime.Now;
            //dtpkTuNgay.Value = DateTime.Now;

            //dtpkDenNgay.MinDate = DateTime.Now;
            dtpkNgayDen.MinDate = DateTime.Now;
            dtpkNgayDi.MinDate = DateTime.Now;
            //dtpkTuNgay.MinDate = DateTime.Now;
        }

        void LoadCbbPhongChuyen(DateTime tuNgay, DateTime denNgay)
        {
            List<Phong> listPhong = PhongDAO.Instance.getListPhongTrong(tuNgay, denNgay);
            cbbPhongTrong.DataSource = listPhong;
            cbbPhongTrong.DisplayMember = "SoPhong1";

        }

        public void loadAllDataPhieuThue()
        {
            List<PhieuThue> listPhieuThue = PhieuThueDAO.Instance.getListAllPhieuThue();
            PhieuThueList.DataSource = listPhieuThue;
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
            float TienDichVu = 0;
            List<Menu_DV> ListMenu = PhieuThueDAO.Instance.getListMenuByMaPHieuThue(MaPhieuThue);
            foreach (var item in ListMenu)
            {
                ListViewItem listViewItem = new ListViewItem(item.Name);
                listViewItem.SubItems.Add(item.Count.ToString());
                listViewItem.SubItems.Add(item.Price.ToString());
                listViewItem.SubItems.Add(item.TotalPrice.ToString());
                TienDichVu += item.TotalPrice;
                lvDichVu.Items.Add(listViewItem);
            }
            txbTienDichVu.Text = TienDichVu.ToString();
        }

        #endregion
        private void Btn_ClickPhong(object sender, EventArgs e)
        {
            Phong p = (sender as Button).Tag as Phong;
            Button btn = sender as Button;

            if (btn.BackColor == Color.FromArgb(0, 192, 0))
            {
                btn.BackColor = Color.BlueViolet;
            }
            else if (btn.BackColor == Color.BlueViolet)
            {
                btn.BackColor = Color.FromArgb(0, 192, 0);
            }
            //txbMaPhong.Text = "";

            foreach (Button item in flpPhong.Controls)
            {
                Phong p1 = item.Tag as Phong;
                if (item.BackColor == Color.BlueViolet)
                {
                    //txbMaPhong.Text += p1.SoPhong1 + " ";
                }
            }

            PhieuThue pt = PhieuThueDAO.Instance.getPhieuThueByMaPhong(p.MaPhong1);

            int index = -1;
            int i = 0;
            foreach (PhieuThue item in cbbMaPhieuThue.Items)
            {
                if (pt.MaPhieuThue1 == item.MaPhieuThue1)
                {
                    index = i;
                }
                i++;
            }
            if (index > -1)
            {
                cbbMaPhieuThue.SelectedIndex = index;
            }
            else
            {
                cbbMaPhieuThue.SelectedIndex = -1;
            }

        }

        private void comboBoxEx3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbMaPhieuThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaPhieuThue.SelectedIndex != -1)
            {
                PhieuThue pt = cbbMaPhieuThue.SelectedItem as PhieuThue;

                KhachHang kh = KhachHangDAO.Instance.getKhachHangByMaPhieuThue(pt.MaPhieuThue1);

                txbTenKhachHang.Text = kh.TenKH1.ToString();

                object TienPhong = PhongDAO.Instance.getTienPhong(pt.MaPhieuThue1);

                if (TienPhong != null)
                {
                    txbTienPhong.Text = TienPhong.ToString();
                }

                LoadCbbPhong(pt.MaPhieuThue1);

                ShowLvDichVu(pt.MaPhieuThue1);
                LoadCbbPhongChuyen(pt.NgayDen1, pt.NgayDi1);

            }
        }

        private void btnHuyPhong_Click(object sender, EventArgs e)
        {
            if (cbbMaPhieuThue.SelectedItem != null)
            {
                if (cbbPhongHuy.SelectedItem != null)
                {
                    PhieuThue pt = cbbMaPhieuThue.SelectedItem as PhieuThue;
                    Phong p = cbbPhongHuy.SelectedItem as Phong;
                    ThuePhongDAO.Instance.DeleteThuePhong(pt.MaPhieuThue1, p.MaPhong1);
                    LoadPhong();
                    loadCbbNhanPhong();
                    LoadCbbPhong(pt.MaPhieuThue1);
                    LoadCbbPhongChuyen(pt.NgayDen1, pt.NgayDi1);
                }
            }
            else
            {
                MessageBox.Show("vui lòng chọn mã phiếu thuê");
            }
        }

        private void btnChuyenPhong_Click(object sender, EventArgs e)
        {
            if (cbbMaPhieuThue.SelectedItem != null)
            {
                if (cbbPhongChuyen.SelectedItem != null)
                {
                    if (cbbPhongTrong.SelectedItem!= null)
                    {
                        PhieuThue pt = cbbMaPhieuThue.SelectedItem as PhieuThue;
                        Phong p = cbbPhongChuyen.SelectedItem as Phong;
                        Phong p1 = cbbPhongTrong.SelectedItem as Phong;
                        ThuePhongDAO.Instance.ChuyenPhong(pt.MaPhieuThue1, p.MaPhong1, p1.MaPhong1);
                        LoadPhong();
                        loadCbbNhanPhong();
                        LoadCbbPhong(pt.MaPhieuThue1);
                        LoadCbbPhongChuyen(pt.NgayDen1, pt.NgayDi1);
                    }

                }
            }
            else
            {
                MessageBox.Show("vui lòng chọn mã phiếu thuê");
            }
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            //String maPhongs = txbMaPhong.Text.Trim();
            //if (cbbMaPhieuThue.SelectedItem != null)
            //{
            //    if (maPhongs != "")
            //    {
            //        PhieuThue pt = cbbMaPhieuThue.SelectedItem as PhieuThue;
            //        String[] str = maPhongs.Split(' ');
            //        foreach (String item in str)
            //        {
            //            Phong p = PhongDAO.Instance.getMaPhongBySoPhong(Convert.ToInt32(item));
            //            ThuePhongDAO.Instance.InsertPhongIntoThuePhong(pt.MaPhieuThue1, p.MaPhong1);

            //        }
            //        LoadPhong();
            //        loadCbbNhanPhong();
            //        LoadCbbPhong(pt.MaPhieuThue1);
            //        LoadCbbPhongChuyen(pt.NgayDen1, pt.NgayDi1);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("vui lòng chọn mã phiếu thuê");
            //}
        }

        private void labelX11_Click(object sender, EventArgs e)
        {

        }

        private void dtpkNgayDen_ValueChanged(object sender, EventArgs e)
        {
            DateTime NgayDen = dtpkNgayDen.Value;

            DateTime NgayDi = dtpkNgayDi.Value;

            List<Phong> listPhong = PhongDAO.Instance.getListPhongTrong(NgayDen, NgayDi);
            LoadPhongTrong(listPhong, flpPhongTrong,flpPhongTrongOfTang2,flpPhongTrongOfTang3);

        }

        private void dtpkNgayDi_ValueChanged(object sender, EventArgs e)
        {
            DateTime NgayDen = dtpkNgayDen.Value;

            DateTime NgayDi = dtpkNgayDi.Value;

            List<Phong> listPhong = PhongDAO.Instance.getListPhongTrong(NgayDen, NgayDi);

            LoadPhongTrong(listPhong, flpPhongTrong, flpPhongTrongOfTang2, flpPhongTrongOfTang3);
        }

        private void dtgvPhieuThue_Click(object sender, EventArgs e)
        {
            try
            {
                int maPhieuThue = Convert.ToInt32(dtgvPhieuThue.SelectedCells[0].OwningRow.Cells["MaPhieuThue1"].Value.ToString());
                int i = 0;
                int index = -1;
                List<PhieuThue> listPhieuThue = PhieuThueDAO.Instance.getListPhieuThueDangAndCho();
                foreach (PhieuThue item in listPhieuThue)
                {
                    if (maPhieuThue == item.MaPhieuThue1)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbbPhieuThueDangAndCho.SelectedIndex = index;

                DateTime NgayDen = Convert.ToDateTime(dtgvPhieuThue.SelectedCells[0].OwningRow.Cells["NgayDen1"].Value.ToString());
                DateTime NgayDi = Convert.ToDateTime(dtgvPhieuThue.SelectedCells[0].OwningRow.Cells["NgayDi1"].Value.ToString());
                try
                {
                    dtpkNgayDen.Value = NgayDen;
                    dtpkNgayDi.Value = NgayDi;
                }
                catch (Exception)
                {
                    dtpkNgayDen.Value = DateTime.Now;
                    try
                    {
                        dtpkNgayDi.Value = NgayDi;
                    }
                    catch (Exception)
                    {
                        dtpkNgayDi.Value = DateTime.Now;
                    }

                }
            }
            catch (Exception)
            {
            }
               
            
        }

        private void cbbPhieuThueDangAndCho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbPhieuThueDangAndCho.SelectedItem != null)

            {
                PhieuThue pt = cbbPhieuThueDangAndCho.SelectedItem as PhieuThue;

                List<Phong> listPhong = PhongDAO.Instance.getListPhongByMaPhieuThue(pt.MaPhieuThue1);

                try
                {
                    dtpkNgayDen.Value = pt.NgayDen1;
                    dtpkNgayDi.Value = pt.NgayDi1;
                }
                catch (Exception)
                {
                    try
                    {
                        dtpkNgayDen.Value = DateTime.Now;
                        dtpkNgayDi.Value = pt.NgayDi1;
                    }
                    catch (Exception)
                    {
                    }
                
                }
              

                LoadPhongDaDat(listPhong, flpPhongDaDat);
            
            }

        }

        private void btnDatPhongTab2_Click(object sender, EventArgs e)
        {
            String maPhongs = txbMaPhongDatTruoc.Text.Trim();
            if (cbbPhieuThueDangAndCho.SelectedItem != null)
            {
                if (maPhongs != "")
                {
                    PhieuThue pt = cbbPhieuThueDangAndCho.SelectedItem as PhieuThue;
                    String[] str = maPhongs.Split(' ');
                    foreach (String item in str)
                    {
                        Phong p = PhongDAO.Instance.getMaPhongBySoPhong(Convert.ToInt32(item));
                        ThuePhongDAO.Instance.InsertPhongIntoThuePhong(pt.MaPhieuThue1, p.MaPhong1);

                    }

                    List<Phong> listPhong = PhongDAO.Instance.getListPhongTrong(pt.NgayDen1, pt.NgayDi1);
                    LoadPhongTrong(listPhong, flpPhongTrong, flpPhongTrongOfTang2, flpPhongTrongOfTang3);

                    List<Phong> listPhong1 = PhongDAO.Instance.getListPhongByMaPhieuThue(pt.MaPhieuThue1);
                    LoadPhongDaDat(listPhong1, flpPhongDaDat);

                    PhieuThue pt1 = cbbMaPhieuThue.SelectedItem as PhieuThue;
                    LoadPhong();
                    loadCbbNhanPhong();
                    if (pt1 != null)
                    {
                        LoadCbbPhong(pt1.MaPhieuThue1);
                        LoadCbbPhongChuyen(pt1.NgayDen1, pt1.NgayDi1);

                    }



                    txbMaPhongDatTruoc.Text = "";

                }
            }
            else
            {
                MessageBox.Show("vui lòng chọn mã phiếu thuê");
            }
        }

        private void btnHuyPhongTab2_Click(object sender, EventArgs e)
        {
            String maPhongs = txbMaPhongDaDat.Text.Trim();
            if (cbbPhieuThueDangAndCho.SelectedItem != null)
            {
                if (maPhongs != "")
                {
                    PhieuThue pt = cbbPhieuThueDangAndCho.SelectedItem as PhieuThue;
                    String[] str = maPhongs.Split(' ');
                    foreach (String item in str)
                    {
                        Phong p = PhongDAO.Instance.getMaPhongBySoPhong(Convert.ToInt32(item));
                        ThuePhongDAO.Instance.DeleteThuePhong(pt.MaPhieuThue1,p.MaPhong1);

                    }

                    List<Phong> listPhong = PhongDAO.Instance.getListPhongTrong(pt.NgayDen1, pt.NgayDi1);
                    LoadPhongTrong(listPhong, flpPhongTrong,flpPhongTrongOfTang2, flpPhongTrongOfTang3);

                    List<Phong> listPhong1 = PhongDAO.Instance.getListPhongByMaPhieuThue(pt.MaPhieuThue1);
                    LoadPhongDaDat(listPhong1, flpPhongDaDat);

                    LoadPhong();

                    PhieuThue pt1 = cbbMaPhieuThue.SelectedItem as PhieuThue;
                    if (pt1 != null)
                    {
                        LoadCbbPhong(pt1.MaPhieuThue1);
                        LoadCbbPhongChuyen(pt1.NgayDen1, pt1.NgayDi1);
                    }
                    loadCbbNhanPhong();
                 

                    txbMaPhongDaDat.Text = "";

                }
            }
            else
            {
                MessageBox.Show("vui lòng chọn mã phiếu thuê");
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txbTienPhong != null && cbbMaPhieuThue.SelectedItem != null)
            {
              
                int maPhieuThue = (cbbMaPhieuThue.SelectedItem as PhieuThue).MaPhieuThue1;
                float tienPhong = (float)Convert.ToDouble(txbTienPhong.Text);
                float tienDichVu = (float)Convert.ToDouble(txbTienDichVu.Text);
                float tongTien = tienDichVu + tienPhong;

                if (MessageBox.Show(String.Format("Ban có thật sự muốn thanh toán ???\n\t  Mã Phiếu Thuê:{0} " ,maPhieuThue),
                    "Thanh Toán", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    HoaDonDAO.Instance.ThanhToanHoaDon(maPhieuThue, tienPhong, tienDichVu, tongTien, loginAccount.DisplayName);
                    flpPhong.Controls.Clear();
                    LoadPhong();
                    LoadcbbMaPhieuThue();
                    LoadcbbMaPhieuThueDangAndCho();

                    loadAllDataPhieuThue();
                    txbTienPhong.Text = "0";

                    fHoaDon f = new fHoaDon(maPhieuThue);
                    f.Show();
                }

            }
        }

        private void btnAddPhieuThue_Click(object sender, EventArgs e)
        {
            DateTime ngayDen = dtpkNgayDen.Value;
            DateTime ngayDi = dtpkNgayDi.Value;
            int maKH = (cbbMaKhachHang.SelectedItem as KhachHang).MaKH1;
            PhieuThueDAO.Instance.insertPhieuThue(ngayDen, ngayDi, maKH);
            loadAllDataPhieuThue();
            LoadCbbMaKhachHang();
            LoadcbbMaPhieuThueDangAndCho();
            LoadcbbMaPhieuThue();
            loadCbbNhanPhong();
        }

        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            if (cbbNhanPhong.SelectedItem != null)
            {
                int maPhieuThue = (cbbNhanPhong.SelectedItem as PhieuThue).MaPhieuThue1;
                PhieuThueDAO.Instance.NhanPhong(maPhieuThue);
                flpPhong.Controls.Clear();
                LoadPhong();
                LoadcbbMaPhieuThue();
                LoadcbbMaPhieuThueDangAndCho();
                loadCbbNhanPhong();
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
            //try
            //{
            //    int maKH = Convert.ToInt32(dtgvKhachHang.SelectedCells[0].OwningRow.Cells["MaKH"].Value.ToString());
            //    int i = 0;
            //    int index = -1;
            //    List<KhachHang> listKhachHang = KhachHangDAO.Instance.getListKhachHang();
            //    foreach (KhachHang item in listKhachHang)
            //    {
            //        if (maKH == item.MaKH1)
            //        {
            //            index = i;
            //            break;
            //        }
            //        i++;
            //    }
            //    cbbMaKhachHang.SelectedIndex = index;
            //}
            //catch (Exception)
            //{

               
            //}
           
        }

        private void lbTrong_Click(object sender, EventArgs e)
        {


            lbTatCaPhong.Enabled = true;

            List<Phong> listPhong = PhongDAO.Instance.getListTrong();

            String str = txbConvertFlp.Text.ToString();
            if (str.Equals("0"))
            {
                LoadPhongTrong(listPhong, flpPhong,flpPhongOfTang2,flpPhongOfTang3);
            }
            else
            {
                LoadPhongTrong1(listPhong, flpPhong);
            }
          
        }

        private void lbTatCaPhong_Click(object sender, EventArgs e)
        {
            lbTatCaPhong.Enabled = false;
            LoadPhong();
        }

        private void lbCoNguoi_Click(object sender, EventArgs e)
        {
            lbTatCaPhong.Enabled = true;
            List<Phong> listPhong = PhongDAO.Instance.getListCoNguoi();

         
            String str = txbConvertFlp.Text.ToString();
            if (str.Equals("0"))
            {
                LoadPhongDaDatTab1(listPhong, flpPhong);

            }
            else
            {
                LoadPhongDaDat1(listPhong, flpPhong);
            }


        }


        private void btnConvertFlpn_Click(object sender, EventArgs e)
        {
            if (setConvert == 0)
            {
                setConvert = 1;
                txbConvertFlp.Text = setConvert.ToString();
            }
            else
            {
                setConvert = 0;
                txbConvertFlp.Text = setConvert.ToString();
            }
        }

        private void txbConvertFlp_TextChanged(object sender, EventArgs e)
        {
            String str = txbConvertFlp.Text.ToString();
            if (str.Equals("0"))
            {
                loadPhong0();
            }
            else
            {
                loadPhong1();
            }

        }

        private void btnAddKh_Click(object sender, EventArgs e)
        {
            String TenKH = txbTenKhachHangT3.Text;
            int sdt = Convert.ToInt32(txbSdtT3.Text);
            if (KhachHangDAO.Instance.InsertKhachHang(TenKH, sdt))
            {
                MessageBox.Show("Thêm thành công");
                LoadKhachHang();
                LoadKhachHangT3();
                LoadCbbMaKhachHang();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnEditKh_Click(object sender, EventArgs e)
        {
            int maKH = Convert.ToInt32(txbMaKhachHangT3.Text);
            String TenKH = txbTenKhachHangT3.Text;
            int sdt = Convert.ToInt32(txbSdtT3.Text);

            if (KhachHangDAO.Instance.EditKhachHang(maKH, TenKH, sdt))
            {
                MessageBox.Show("Sửa thành công");
                LoadKhachHang();
                LoadKhachHangT3();
                LoadCbbMaKhachHang();
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
                LoadKhachHangT3();
                LoadCbbMaKhachHang();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

 
    }
}
