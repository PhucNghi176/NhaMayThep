using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("User")]
    public class NhanVienEntity : Auditable
    {
        [Key]
        [Column("MaSoNhanVien")]
        public Guid ID { get; set; }
       
        public required string Email { get; set; }
        public required string TaiKhoan { get; set; }
        public required string MatKhau { get; set; }
        public required string HoVaTen { get; set; }
       
        
        public required int ChucVuID { get; set; }
        public required virtual BangChucVuEntity ChucVu { get; set;}

        public required int TinhTrangLamViecID { get; set; }
        public required virtual BangTinhTrangLamViecEntity TinhTrangLamViec { get; set;}

    }
}
