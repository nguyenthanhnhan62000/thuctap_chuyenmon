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

namespace demo.DTO
{
    public partial class fXemDataHangAndTN : Form
    {
        public fXemDataHangAndTN()
        {
            InitializeComponent();
            LoadListHang();
            LoadListTN();
        }
        public void LoadListHang()
        {
            dtgvListHang.DataSource = HangDAO.Instance.getListHang();
        }
        public void LoadListTN()
        {
            dtgvListTN.DataSource =TienNghiDAO.Instance.getListTienNghi();
        }

    }
}
