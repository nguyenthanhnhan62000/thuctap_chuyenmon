using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DTO
{
    class Phong
    {

        private int MaPhong;
        private int SoPhong;
        private String TrangThai;
        private float DonGia;
       
        private int Tang;
        private String Loai;
        public Phong(int maphong, int sophong, String trangthai, float dongia,String loai,int tang)
        {
            this.MaPhong = maphong;
            this.SoPhong = sophong;
            this.TrangThai = trangthai;
            this.DonGia = dongia;
            this.Loai = loai;
            this.Tang = tang;
        }

        public Phong()
        {
           
        }

        public int MaPhong1 { get => MaPhong; set => MaPhong = value; }
        public int SoPhong1 { get => SoPhong; set => SoPhong = value; }
        public string TrangThai1 { get => TrangThai; set => TrangThai = value; }
        public float DonGia1 { get => DonGia; set => DonGia = value; }
        public string Loai1 { get => Loai; set => Loai = value; }
        public int Tang1 { get => Tang; set => Tang = value; }

        public Phong(DataRow row)
        {
            this.MaPhong =(int) row["MaPhong"];
            this.SoPhong =(int) row["SoPhong"];
            this.TrangThai = (String)row["TrangThai"];
            this.DonGia = (float)Convert.ToDouble(row["DonGia"]);


            if (row["Tang"] != null)
                this.Tang = Convert.ToInt32(row["Tang"]);

            if (row["Loai"] != null)
                this.Loai = (String)row["Loai"];


        }
    }
}
