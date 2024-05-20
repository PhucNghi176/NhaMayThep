using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities.ConfigTable
{
    [Table("BaoHiem")]
    public class BaoHiemEntity : BangMaGocEntity
    {
        public required double PhanTramKhauTru { get; set; }
    }
}
