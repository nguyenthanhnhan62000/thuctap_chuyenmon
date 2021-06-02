using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DTO
{
    class DichVu
    {
        private int MaDichVu;
        private String name;
        private int gia;

        public DichVu()
        {

        }
        public DichVu( int maDichVu, String name , int gia)
        {
            this.MaDichVu = maDichVu;
            this.name = name;
            this.gia = gia;
        }
        public DichVu(DataRow row)
        {
            this.MaDichVu = (int)row["MaDichVu"];
            this.name = (String)row["name"];
            this.gia = Convert.ToInt32( row["gia"]);

        }
        public int MaDichVu1 { get => MaDichVu; set => MaDichVu = value; }
        public string Name { get => name; set => name = value; }
        public int Gia { get => gia; set => gia = value; }
    }
}
