using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using demo.DAO;

namespace demo
{
    public partial class UcAccount : UserControl
    {
        BindingSource listAccount = new BindingSource();
        public UcAccount()
        {
            InitializeComponent();

            dtgvAccount.DataSource = listAccount;
            load();

        }

        private void load()
        {
            LoadListAccount();
            loadBinding();

        }

        private void loadBinding()
        {
            addAccountBinding();
        }

        public void addAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("text", dtgvAccount.DataSource, "userName"));
            txbDisplayName.DataBindings.Add(new Binding("text", dtgvAccount.DataSource, "displayName"));
            nmType.DataBindings.Add(new Binding("value", dtgvAccount.DataSource, "type"));
        }
        public void LoadListAccount()
        {
            listAccount.DataSource = AccountDAO.Instance.getListAccount();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            String userName = txbUserName.Text;
            String disPlayName = txbDisplayName.Text;
            int type = (int)nmType.Value;

            if (AccountDAO.Instance.InsertAccount(type, disPlayName, userName))
            {
                MessageBox.Show("Thêm thành công");
                LoadListAccount();
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
                LoadListAccount();
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
                LoadListAccount();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void expandablePanel2_Click(object sender, EventArgs e)
        {

        }
    }
}
