 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities.Mapping
{
    public class NhanVienMapThongTinCanCuocCongDan
    {
        [Key]
        public int ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public virtual NhanVienEntity NhanVien { get; set; }
        public string CanCuocCongDan { get; set; }
        public virtual ThongTinGiamTruGiaCanhEntity ThongTinGiamTruGiaCanh { get; set; }
    }
}
