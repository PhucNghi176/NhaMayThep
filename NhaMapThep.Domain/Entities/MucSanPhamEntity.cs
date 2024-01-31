using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities
{
    [Table("MucSanPham")]
    public class MucSanPhamEntity : BangMaGocEntity
    {
        public required int MucSanPhamToiThieu { get; set; }
        public required int MucSanPhamToiDa { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public required decimal LuongMucSanPham { get; set; }
    }
}
