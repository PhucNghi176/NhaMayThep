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

        public decimal Luong1Gio { get; set; }

        public decimal TongLuong { get; set; }

        public DateTime NgayKhaiBao {  get; set; }

        public static LuongCongNhatDto Create(string id, string maSoNhanVien, double soGioLam, decimal luong1Gio, decimal tongLuong, DateTime ngayKhaiBao)
        {
            return new LuongCongNhatDto
            {
                ID = id,
                MaSoNhanVien = maSoNhanVien,
                SoGioLam = soGioLam,
                Luong1Gio = luong1Gio,
                TongLuong = tongLuong,
                NgayKhaiBao = ngayKhaiBao
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LuongCongNhatEntity, LuongCongNhatDto>();
        }
    }
}
