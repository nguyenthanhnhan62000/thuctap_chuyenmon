namespace demo.RpData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        public int id { get; set; }

        public int? MaPhieuThue { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }

        public double? TongTien { get; set; }

        public int? TrangThai { get; set; }

        public double? TienPhong { get; set; }

        public double? TienDichVu { get; set; }

        public virtual PHIEUTHUE PHIEUTHUE { get; set; }
    }
}
