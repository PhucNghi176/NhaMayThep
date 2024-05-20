using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities.ConfigTable
{
    [Table("MaDangKiCaLam")]
    public class MaDangKiCaLamEntity : BangMaGocEntity
    {
        public DateTime ThoiGianCaLamBatDau { get; set; }
        public DateTime ThoiGianCaLamKetThuc { get; set; }
    }
}
