using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("CanCuocCongDan")]
    public class CanCuocCongDanEntity : Entity
    {
        [MaxLength(12)]
        public required string CanCuocCongDan { get; set; }
        public required string NhanVienID { get; set; }
        [ForeignKey(nameof(NhanVienID))]
        public virtual ICollection<NhanVienEntity>? NhanVien { get; set; }
        public required string HoVaTen { get; set; }
        public required DateTime NgaySinh { get; set; }
        public required bool GioiTinh { get; set; }
        public string QuocTich { get; set; } = "Viet Nam";
        public required string QueQuan { get; set; }
        public required string DiaChiThuongTru { get; set; }
        public required DateTime NgayCap { get; set; }
        public required string NoiCap { get; set; }
        [MaxLength(10)]
        public string DanToc { get; set; } = "Kinh";
        public required string TonGiao { get; set; }

    }
}
