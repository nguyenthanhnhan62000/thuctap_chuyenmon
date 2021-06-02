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
    public partial class UcTienNghi : UserControl
    {


        BindingSource ListTN = new BindingSource();

        public UcTienNghi()
        {
            InitializeComponent();
            dtgvTienNghi.DataSource = ListTN;

            LoadListTienNghi();

            addDichVuBinding();
        }
        public void addDichVuBinding()
        {
            txbMa.DataBindings.Add(new Binding("text", dtgvTienNghi.DataSource, "MaTN"));

            txbTen.DataBindings.Add(new Binding("text", dtgvTienNghi.DataSource, "TenTN"));

            txbHienCo.DataBindings.Add(new Binding("text", dtgvTienNghi.DataSource, "SoLuong"));

            txbGia.DataBindings.Add(new Binding("text", dtgvTienNghi.DataSource, "Gia"));

            txbTinhTrang.DataBindings.Add(new Binding("text", dtgvTienNghi.DataSource, "TinhTrang1"));

        }

        public void LoadListTienNghi()
        {
            dtgvTienNghi.DataSource = TienNghiDAO.Instance.getListTienNghi();
        }
    }
}
