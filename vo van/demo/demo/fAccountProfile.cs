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
    public partial class fAccountProfile : Form
    {
        private Account acc;
        public fAccountProfile(Account account)
        {
            InitializeComponent();
            this.acc = account;
            showAccount();
        }
        void showAccount()
        {
            txbUserName.Text = acc.UserName;
            txbDisplayName.Text = acc.DisplayName;
           
        }

        public Account Acc { get => acc; set => acc = value; }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (txbPassWord.Text == acc.PassWord)
            {
                if(txbNewPassword.Text == txbReEnterPass.Text)
                {
                    String userName = txbUserName.Text;
                    String passWordNew = txbNewPassword.Text;
                    String displayName = txbDisplayName.Text;
                    if (AccountDAO.Instance.updateAccount(passWordNew,displayName,userName))
                    {
                        MessageBox.Show("update thành công");
                    }
                    else
                    {
                        MessageBox.Show("update Không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("mật khẩu mới và nhập lại không trùng nhau");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu sai");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
