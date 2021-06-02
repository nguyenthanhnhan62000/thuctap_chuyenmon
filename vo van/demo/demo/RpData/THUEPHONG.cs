namespace demo.RpData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THUEPHONG")]
    public partial class THUEPHONG
    {
        public int id { get; set; }

        public int? MaPhieuThue { get; set; }

        public int? MaPhong { get; set; }

        public int? status { get; set; }

        public virtual PHIEUTHUE PHIEUTHUE { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
