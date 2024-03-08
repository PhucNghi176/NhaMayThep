using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCapDangVien
{
    public class ThongTinCapDangVienDto : IMapFrom<ThongTinCapDangVienEntity>
    {
        public ThongTinCapDangVienDto() { }
        public int Id { get; set; }
        public string TenCapDangVien { get; set; }
        public string CapDangVien { get; set; }
        public static ThongTinCapDangVienDto CreateThongTinCapDangVien(int id, string tenCapDangVien, string capDangVien)
        {
            return new ThongTinCapDangVienDto()
            {
                Id = id,
                TenCapDangVien = tenCapDangVien,
                CapDangVien = capDangVien
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinCapDangVienEntity, ThongTinCapDangVienDto>();
        }
    }
}
