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
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String userName = txbUserName.Text;
            String passWord = txbPassWord.Text;
            Account ac = AccountDAO.Instance.getAccountByUserName(userName);
            if (AccountDAO.Instance.checkLogin(userName, passWord))
            {
                fPhieuthue pt = new fPhieuthue(ac);
                fMain f = new fMain(ac);


                this.Hide();
                pt.ShowDialog();
                f.ShowDialog();
                this.Show();

                
               
            }
            else
            {
                MessageBox.Show("Sai Tên or mật Khẩu");
            }

          
        }

        private void btnExitLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
