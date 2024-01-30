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
        public required string MaSoNhanVien { get; set; }
        public int SoSanPhamLam { get; set; }
        public required int MucSanPhamID { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal TongLuong { get; set; }

        public static LuongSanPhamDto Create(string id, string maSoNhanVien, int soSanPham, int mucSanPhamID, decimal tongLuong)
        {
            return new LuongSanPhamDto
            {
                ID = id,
                MaSoNhanVien = maSoNhanVien,
                SoSanPhamLam = soSanPham,
                MucSanPhamID = mucSanPhamID,
                TongLuong = tongLuong,
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LuongSanPhamEntity, LuongSanPhamDto>();
        }
    }
}
