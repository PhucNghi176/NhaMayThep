﻿using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities
{
    public class BaoHiemNhanVienBaoHiemChiTietEntity
    {
        public required int BHNV { get; set; }
        [ForeignKey(nameof(BHNV))]
        public required virtual BaoHiemNhanVienEntity BaoHiemNhanVienEntity { get; set; }
        public required string BHCT { get; set; }
        [ForeignKey(nameof(BHCT))]
        public required virtual ChiTietBaoHiemEntity ChiTietBaoHiemEntity { get; set; }
        public string? NguoiTaoID { get; set; }
        public DateTime? NgayTao { get; set; }

        public string? NguoiCapNhatID { get; set; }
        public DateTime? NgayCapNhat { get; set; }

        public string? NguoiXoaID { get; set; }
        public DateTime? NgayXoa { get; set; }
    }
}