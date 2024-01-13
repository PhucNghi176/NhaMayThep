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
    [Table("ChiTietDangVien")]
    public class ChiTietDangVienEntity : Entity
    {
        public string DangVienID { get; set; }
        [ForeignKey(nameof(DangVienID))]
        public virtual required ThongTinDangVienEntity ThongTinDangVien { get; set; }
        public int DonViCongTacID { get; set; }
        [ForeignKey(nameof(DonViCongTacID))]
        public virtual required DonViCongTacEntity DonViCongTac { get; set; }
        public required string ChucVuDang { get; set; }
        public required string TrinhDoChinhTri { get; set; }
    }
}
