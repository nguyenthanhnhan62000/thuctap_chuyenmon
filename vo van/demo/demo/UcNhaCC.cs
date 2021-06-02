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
    public partial class UcNhaCC : UserControl
    {

        BindingSource ListNhacc = new BindingSource();
        public UcNhaCC()
        {
            InitializeComponent();
            dtgvNhaCC.DataSource = ListNhacc;
            LoadListNhaCC();
            addDichVuBinding();
        }

        public void addDichVuBinding()
        {
            txbMaNcc.DataBindings.Add(new Binding("text", dtgvNhaCC.DataSource, "MaNhaCC"));

            txbTen.DataBindings.Add(new Binding("text", dtgvNhaCC.DataSource, "TenNhaCC"));

            txbSDT.DataBindings.Add(new Binding("text", dtgvNhaCC.DataSource, "sdt"));

            txbDiaChi.DataBindings.Add(new Binding("text", dtgvNhaCC.DataSource, "DiaChi"));

            txbTenNlH.DataBindings.Add(new Binding("text", dtgvNhaCC.DataSource, "TenNguoiLH"));

           


        }


        public void LoadListNhaCC()
        {
            dtgvNhaCC.DataSource = NhaCCDAO.Instance.getListNhaCC();
        }



        private void labelX2_Click(object sender, EventArgs e)
        {

        }
    }
}
