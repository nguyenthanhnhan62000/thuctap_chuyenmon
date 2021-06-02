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
    public partial class UcNhanVien : UserControl
    {

        BindingSource ListNhanVIen = new BindingSource();
        public UcNhanVien()
        {
            InitializeComponent();
            dtgvNhanVien.DataSource = ListNhanVIen;
            loadNHanVien();
            addDichVuBinding();
        }
        public void addDichVuBinding()
        {
            txbMaNv.DataBindings.Add(new Binding("text", dtgvNhanVien.DataSource, "MANV"));

            txbTen.DataBindings.Add(new Binding("text", dtgvNhanVien.DataSource, "TENNV"));

            txbLuog.DataBindings.Add(new Binding("text", dtgvNhanVien.DataSource, "LUONG"));

            txbDiaChi.DataBindings.Add(new Binding("text", dtgvNhanVien.DataSource, "DIACHI"));

            txbGioiTinh.DataBindings.Add(new Binding("text", dtgvNhanVien.DataSource, "GIOITINH"));

            txbSdt.DataBindings.Add(new Binding("text", dtgvNhanVien.DataSource, "SODT"));

            dtpkNgay.DataBindings.Add(new Binding("value", dtgvNhanVien.DataSource, "NGAYSINH"));




        }


        public void loadNHanVien()
        {
            dtgvNhanVien.DataSource = NhanVienDAO.Instance.getDataNhanVien();
        }
    }

}
