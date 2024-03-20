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
        public int DonViCongTacID { get; set; }
        public int ChucVuDangID { get; set; }
        public string ChucVuDang { get; set; }
        public int TrinhDoChinhTriID { get; set; }
        public string TrinhDoChinhTri { get; set; }
        public DateTime NgayVaoDang { get; set; }
        public int CapDangVienID { get; set; }
        public string CapDangVien { get; set; }


        public static ThongTinDangVienDto Create(string id, string hoVaTen, DateTime ngayVaoDang, int capDangVienID, string capDangVien, string donViCongTac, int chucVuDangID, string chucVuDang, int trinhDoChinhTriID, string trinhDoChinhTri)
        {
            return new ThongTinDangVienDto
            {
               ID = id,
               HoVaTen = hoVaTen,
               DonViCongTac = donViCongTac,
               ChucVuDangID = chucVuDangID,
               ChucVuDang = chucVuDang,
               TrinhDoChinhTriID = trinhDoChinhTriID,
               TrinhDoChinhTri = trinhDoChinhTri,
               NgayVaoDang = ngayVaoDang,
               CapDangVienID = capDangVienID,  
               CapDangVien = capDangVien
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinDangVienEntity, ThongTinDangVienDto>()
                .ForMember(dest => dest.HoVaTen, opt => opt.MapFrom(src => src.NhanVien.HoVaTen))
                .ForMember(dest => dest.DonViCongTac, opt => opt.MapFrom(src => src.DonViCongTac.Name))
                .ForMember(dest => dest.ChucVuDangID, opt => opt.MapFrom(src => src.ThongTinChucVuDang.ID))
                .ForMember(dest => dest.ChucVuDang, opt => opt.MapFrom(src => src.ThongTinChucVuDang.Name))
                .ForMember(dest => dest.TrinhDoChinhTriID, opt => opt.MapFrom(src => src.ThongTinTrinhDoChinhTri.ID))
                .ForMember(dest => dest.TrinhDoChinhTri, opt => opt.MapFrom(src => src.ThongTinTrinhDoChinhTri.Name))
                .ForMember(dest => dest.CapDangVienID, opt => opt.MapFrom(src => src.ThongTinCapDangVien.ID))
                .ForMember(dest => dest.CapDangVien, opt => opt.MapFrom(src => src.ThongTinCapDangVien.Name));
        }
    }
}
