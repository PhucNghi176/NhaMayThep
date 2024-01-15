using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep
{
    public class ChiTietNgayNghiPhepDto
    {
        public Guid MaSoNhanVien { get; set; }
        public int LoaiNghiPhep { get; set; }
        public int TongSoGio { get; set; }
        public int SoGioDaNghiPhep { get; set; }
        public int SoGioConLai { get; set; }
        public int NamHieuLuoc { get; set; }
    }
}
