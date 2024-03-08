﻿using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities.ConfigTable
{
    [Table("ThongTinCapDangVien")]
    public class ThongTinCapDangVienEntity : BangMaGocEntity
    {
        public required string CapDangVien { get; set; }
    }
}