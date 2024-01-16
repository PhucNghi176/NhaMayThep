using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities
{
    [Table("ChinhSachNhanSu")]
    public class ChinhSachNhanSuEntity : BangMaGocEntity
    {
        public required string MucDo { get; set; }

        public DateTime NgayHieuLuc { get; set; }
        public string? NoiDung { get; set; }
    }
}
