using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.PhiCongDoan
{
    public class PhiCongDoanDto : IMapFrom<PhiCongDoanEntity>
    {
        public PhiCongDoanDto()
        {
        }

        public string ID { get; set; }
        public required string MaSoNhanVien { get; set; }
        public double PhanTramLuongDongBH { get; set; }

        public decimal LuongDongBH { get; set; }

        public static PhiCongDoanDto Create(string id, string maSoNhanVien, double phanTramLuongDongBH, decimal luongDongBH)
        {
            return new PhiCongDoanDto
            {
                ID = id,
                MaSoNhanVien = maSoNhanVien,
                PhanTramLuongDongBH = phanTramLuongDongBH,
                LuongDongBH = luongDongBH,
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PhiCongDoanEntity, PhiCongDoanDto>();
        }
    }
}
