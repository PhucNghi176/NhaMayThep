﻿using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("ChiTietBaoHiem")]
    public class ChiTietBaoHiemEntity : Entity
    {
        public int LoaiBaoHiem { get; set; }
        [ForeignKey(nameof(LoaiBaoHiem))]
        public required virtual BaoHiemEntity BaoHiem { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string? NoiCap { get; set; }
        public virtual ICollection<BaoHiemNhanVienBaoHiemChiTietEntity>? BaoHiemNhanViens { get; set; }

    }
}
