using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.DonViCongTac;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien
{
    public class ThongTinDangVienDto : IMapFrom<ThongTinDangVienEntity>
    {
        public ThongTinDangVienDto()
        {
        }

        public string ID { get; set; }
        public string HoVaTen { get; set; }
        public string DonViCongTac { get; set; }
        public string ChucVuDang { get; set; }
        public string TrinhDoChinhTri { get; set; }
        public DateTime NgayVaoDang { get; set; }
        public string CapDangVien { get; set; }


        public static ThongTinDangVienDto Create(string id, string hoVaTen, DateTime ngayVaoDang, string capDangVien, string donViCongTac, string chucVuDang, string trinhDoChinhTri)
        {
            return new ThongTinDangVienDto
            {
               ID = id,
               HoVaTen = hoVaTen,
               DonViCongTac = donViCongTac,
               ChucVuDang = chucVuDang,
               TrinhDoChinhTri = trinhDoChinhTri,
               NgayVaoDang = ngayVaoDang,
               CapDangVien = capDangVien,
                
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinDangVienEntity, ThongTinDangVienDto>()
                .ForMember(dest => dest.HoVaTen, opt => opt.MapFrom(src => src.NhanVien.HoVaTen));

            profile.CreateMap<ThongTinDangVienEntity, ThongTinDangVienDto>()
                .ForMember(dest => dest.DonViCongTac, opt => opt.MapFrom(src => src.DonViCongTac.Name));
        }
    }
}
