using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities
{
    [Table("GiamTruNhanVien")]
    public class GiamTruNhanVienEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }
        public required int GiamTruID { get; set; }
        [ForeignKey(nameof(GiamTruID))]
        public virtual GiamTruEntity GiamTru { get; set; }
    }
}
