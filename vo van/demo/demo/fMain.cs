using demo.DTO;
using DevComponents.DotNetBar;
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
    public partial class fMain : DevComponents.DotNetBar.Office2007RibbonForm
    {

        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; Type(loginAccount.Type); }
        }



        public fMain(Account acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
            Type(LoginAccount.Type);
        }
        public void Type(int type)
        {
            QuanLiToolStripMenuItem.Enabled = type == 1;
            TaiKhoanToolStripMenuItem.Text += "(" + loginAccount.DisplayName + ")";
        }


        private void buttonX1_Click(object sender, EventArgs e)
        {
           
        
        }

        private void btnCreateTabThemPhong_Click(object sender, EventArgs e)
        {
            UcThuePhong f = new UcThuePhong(loginAccount);

            AddNewTab(tabControl1, "Thue Phong", f);
        }
        public void AddNewTab(DevComponents.DotNetBar.TabControl tabContent, string Strtabname, UserControl uControl)
        {
            foreach (TabItem tabPage in tabContent.Tabs)
            {
                if (tabPage.Text == Strtabname)
                {
                    tabContent.SelectedTab = tabPage;
                    return;
                }
            }

            TabControlPanel newTabPanel = new DevComponents.DotNetBar.TabControlPanel();
            TabItem newTabPage = new TabItem();/*this.components);*/

            newTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            newTabPanel.Location = new System.Drawing.Point(0, 204);
            newTabPanel.Name = "Panel";
            newTabPanel.Padding = new System.Windows.Forms.Padding(1);
            newTabPanel.Size = new System.Drawing.Size(1132, 500);
            newTabPanel.TabIndex = 2;
            newTabPanel.TabItem = newTabPage;
            //---------------New Tab Page 
            Random r = new Random();
            newTabPage.Name = Strtabname + r.Next(100000) + r.Next(22342);
            newTabPage.AttachedControl = newTabPanel;
            newTabPage.Text = Strtabname;

            uControl.Dock = DockStyle.Fill;

            newTabPanel.Controls.Add(uControl);
            //---------------------
            tabContent.Controls.Add(newTabPanel);
            tabContent.Tabs.Add(newTabPage);
            tabContent.SelectedTab = newTabPage;
        }

        private void ribbonTabItem2_Click(object sender, EventArgs e)
        {

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            fThongKe_1 f = new fThongKe_1();
            f.ShowDialog();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccount__Click(object sender, EventArgs e)
        {
            UcAccount f = new UcAccount();

            AddNewTab(tabControl1, "Account", f);
        }

        private void btnNhapSanPham_Click(object sender, EventArgs e)
        {
            UcNhapHang f = new UcNhapHang();

            AddNewTab(tabControl1, "Nhập hàng", f);
        }

        private void btnXemDuLieu_Click(object sender, EventArgs e)
        {
            UcXemDuLieuHangVaTN f = new UcXemDuLieuHangVaTN();

            AddNewTab(tabControl1, "Xem Dữ Liệu", f);
        }

        private void btnQlPhong_Click(object sender, EventArgs e)
        {
            UcQuanLiPhong f = new UcQuanLiPhong();

            AddNewTab(tabControl1, "Quản Lí Phòng", f);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            UcNhanVien f = new UcNhanVien();

            AddNewTab(tabControl1, "Quản Lí Nhân Viên", f);
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            UcDichVu f = new UcDichVu();

            AddNewTab(tabControl1, "Quản Lí Dịch Vụ", f);
        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            UcHangHoa f = new UcHangHoa();

            AddNewTab(tabControl1, "Quản Lí Hàng Hóa", f);
        }

        private void btnTienNghi_Click(object sender, EventArgs e)
        {
            UcTienNghi f = new UcTienNghi();

            AddNewTab(tabControl1, "Quản Lí Tiện Nghi", f);
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            UcKho f = new UcKho();

            AddNewTab(tabControl1, "Quản Lí Kho", f);
        }

        private void fThongTinX_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(loginAccount);

            f.ShowDialog();
        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
