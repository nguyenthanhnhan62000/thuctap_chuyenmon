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
    public partial class UcHangHoa : UserControl
    {

        BindingSource listHangHoa = new BindingSource();

        public UcHangHoa()
        {
            InitializeComponent();
            dtgvHangHoa.DataSource = listHangHoa;

            LoadListHang();
            addDichVuBinding();

        }


        public void addDichVuBinding()
        {
            txbMaH.DataBindings.Add(new Binding("text", dtgvHangHoa.DataSource, "MaHang"));
            txbTenH.DataBindings.Add(new Binding("text", dtgvHangHoa.DataSource, "TenHang"));
            txbDvt.DataBindings.Add(new Binding("text", dtgvHangHoa.DataSource, "DonViTinh"));
            txbGia.DataBindings.Add(new Binding("text", dtgvHangHoa.DataSource, "Gia"));
            txbSoL.DataBindings.Add(new Binding("text", dtgvHangHoa.DataSource, "SoLuong"));
            txbMoT.DataBindings.Add(new Binding("text", dtgvHangHoa.DataSource, "MoTa"));

        }
        public void LoadListHang()
        {
            dtgvHangHoa.DataSource = HangDAO.Instance.getListHang();
        }

    }
}
