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
    public partial class UcKho : UserControl
    {
        BindingSource listKho = new BindingSource();

        public UcKho()
        {
            InitializeComponent();
            dtgvKho.DataSource = listKho;
            LoadListKho();
            addDichVuBinding();

        }

        public void addDichVuBinding()
        {
            txbMaKho.DataBindings.Add(new Binding("text", dtgvKho.DataSource, "MAKHO"));

            txbTenKho.DataBindings.Add(new Binding("text", dtgvKho.DataSource, "TENKHO"));

            txbViTri.DataBindings.Add(new Binding("text", dtgvKho.DataSource, "VITRI"));

  
        }
        public void LoadListKho()
        {
            dtgvKho.DataSource = KhoDAO.Instance.getDataKho();
        }
    }
}
