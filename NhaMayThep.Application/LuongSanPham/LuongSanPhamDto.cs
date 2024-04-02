using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongSanPham
{
    public class LuongSanPhamDto : IMapFrom<LuongSanPhamEntity>
    {
        public LuongSanPhamDto()
        {
        }

        public string ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public int SoSanPhamLam { get; set; }
        public string MucSanPhamID { get; set; }
        public decimal TongLuong { get; set; }
        public DateTime NgayKhaiBao { get; set; }

        public static LuongSanPhamDto Create(string id, string maSoNhanVien, int soSanPhamLam, string mucSanPhamId, decimal tongLuong, DateTime ngayKhaiBao)
        {
            return new LuongSanPhamDto
            {
                ID = id,
                MaSoNhanVien = maSoNhanVien,
                SoSanPhamLam = soSanPhamLam,
                MucSanPhamID = mucSanPhamId,
                TongLuong = tongLuong,
                NgayKhaiBao = ngayKhaiBao
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LuongSanPhamEntity, LuongSanPhamDto>();
        }
    }
}
