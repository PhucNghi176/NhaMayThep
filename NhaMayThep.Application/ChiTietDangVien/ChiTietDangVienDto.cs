using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.ThongTinDangVien;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietDangVien
{
    public class ChiTietDangVienDto : IMapFrom<ThongTinDangVienEntity>
    {
        public ChiTietDangVienDto()
        {
        }

        public string ID { get; set; }
        public string HoVaTen { get; set; } 
        public string DonViCongTacName { get; set; }
        public string ChucVuDang { get; set; }
        public string TrinhDoChinhTri { get; set; }

        public static ChiTietDangVienDto Create(string id, string hoVaTen, string donViCongTacName, string chucVuDang, string trinhDoChinhTri)
        {
            return new ChiTietDangVienDto
            {
                ID = id,
                HoVaTen = hoVaTen,
                DonViCongTacName = donViCongTacName,
                ChucVuDang = chucVuDang,
                TrinhDoChinhTri = trinhDoChinhTri,
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChiTietDangVienEntity, ChiTietDangVienDto>()
                .ForMember(dest => dest.HoVaTen, opt => opt.MapFrom(src => src.ThongTinDangVien.NhanVien.HoVaTen))
                .ForMember(dest => dest.DonViCongTacName, opt => opt.MapFrom(src => src.DonViCongTac.Name));
        }
    }
}
