using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("MucSanPham")]
    public class MucSanPhamEntity : Entity
    {
        public required int MucSanPhamToiThieu { get; set; }
        public required int MucSanPhamToiDa { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public required decimal LuongMucSanPham { get; set; }
    }
}
