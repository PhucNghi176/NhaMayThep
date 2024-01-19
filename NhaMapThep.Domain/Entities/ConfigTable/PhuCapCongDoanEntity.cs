using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities.ConfigTable
{
    [Table("PhuCapCongDoan")]
    public class PhuCapCongDoanEntity : BangMaGocEntity
    {
        public int SoLuongDoanVien {  get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public float HeSoPhuCap { get; set; }
        public string DonVi {  get; set; }

    }
}
