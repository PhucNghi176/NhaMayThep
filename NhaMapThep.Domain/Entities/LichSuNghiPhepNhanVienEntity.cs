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
    public class LichSuNghiPhepNhanVienEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }
        public required int LoaiNghiPhepID { get; set; }
        [ForeignKey(nameof(LoaiNghiPhepID))]
        public virtual LoaiNghiPhepEntity LoaiNghiPhep { get; set; }
        public required DateTime NgayBatDau { get; set; }
        public required DateTime NgayKetThuc { get; set; }
        public required string LyDo { get; set; }   
        public required string NguoiDuyet { get; set; }
        [ForeignKey(nameof(NguoiDuyet))]
        public virtual NhanVienEntity NguoiDuyetNhanVien { get; set; }


    }
}
