using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities.ConfigTable
{
    [Table("PhuCap")]
    public class PhuCapEntity : BangMaGocEntity
    {
        [Column(TypeName = "decimal(18, 4)")]
        public required double KhoanPhuCap { get; set; }
    }
}
