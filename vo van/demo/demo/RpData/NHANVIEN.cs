namespace demo.RpData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [Key]
        [StringLength(10)]
        public string MANV { get; set; }

        [StringLength(50)]
        public string TENNV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYSINH { get; set; }

        [StringLength(10)]
        public string GIOITINH { get; set; }

        [StringLength(50)]
        public string DIACHI { get; set; }

        [StringLength(11)]
        public string SODT { get; set; }

        [StringLength(10)]
        public string SOCMND { get; set; }

        [StringLength(10)]
        public string MABP { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYVAOLAM { get; set; }

        public double? LUONG { get; set; }
    }
}
