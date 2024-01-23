using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongCongNhat
{
    public class LuongCongNhatDto : IMapFrom<LuongCongNhatEntity>
    {
        public LuongCongNhatDto()
        {
        }

        public string ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public double SoGioLam { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Luong1Gio { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal TongLuong { get; set; }

        public static LuongCongNhatDto Create(string id, string maSoNhanVien, double soGioLam, decimal luong1Gio, decimal tongLuong)
        {
            return new LuongCongNhatDto
            {
                ID = id,
                MaSoNhanVien = maSoNhanVien,
                SoGioLam = soGioLam,
                Luong1Gio = luong1Gio,
                TongLuong = tongLuong
        };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LuongCongNhatEntity, LuongCongNhatDto>();
        }
    }
}
