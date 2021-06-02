namespace demo.RpData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THUEDICHVU")]
    public partial class THUEDICHVU
    {
        public int id { get; set; }

        public int? MaPhieuThue { get; set; }

        public int? MaDichVu { get; set; }

        public int? SoLuong { get; set; }

        public virtual DICHVU DICHVU { get; set; }

        public virtual PHIEUTHUE PHIEUTHUE { get; set; }
    }
}
