﻿using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("ChiTietNgayNghiPhep")]
    public class ChiTietNgayNghiPhepEntity : Entity
    {

        [ForeignKey("NhanVien")]
        public string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }
        public int LoaiNghiPhepID { get; set; }
        [ForeignKey(nameof(LoaiNghiPhepID))]

        public virtual LoaiNghiPhepEntity LoaiNghiPhep { get; set; }
        public required double TongSoGio { get; set; }

        public required double SoGioDaNghiPhep { get; set; }

        public required double SoGioConLai { get; set; }

        public required int NamHieuLuc { get; set; }



    }
}
