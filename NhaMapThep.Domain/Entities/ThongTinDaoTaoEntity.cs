using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("ThongTinDaoTao")]
    public class ThongTinDaoTaoEntity : Entity
    {
        public string NhanVienID { get; set; }
        [ForeignKey(nameof(NhanVienID))]
        public virtual NhanVienEntity NhanVien { get; set; }
        public int MaTrinhDoHocVanID { get; set; }
        [ForeignKey(nameof(MaTrinhDoHocVanID))]
        public virtual TrinhDoHocVanEntity TrinhDoHocVan { get; set; }
        public string TenTruong { get; set; }
        public string ChuyenNganh { get; set; }
        public DateTime NamTotNghiep { get; set; }
        public int TrinhDoVanHoa { get; set; }

    }
}
