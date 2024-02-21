using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Application.ThongTinCongDoan
{
    public class ThongTinCongDoanDto : IMapFrom<ThongTinCongDoanEntity>
    {
        public string Id { get; set; } = null!;
        public string NhanVien { get; set; } = null!;
        public bool ThuKiCongDoan { get; set; }
        public DateTime NgayGiaNhap { get; set; }
        public static ThongTinCongDoanDto CreateThongTinCongDoan(string id, string nhanvien, bool thukycongdoan, DateTime ngaygianhap)
        {
            return new ThongTinCongDoanDto
            {
                Id = id,
                NhanVien = nhanvien,
                ThuKiCongDoan = thukycongdoan,
                NgayGiaNhap = ngaygianhap
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinCongDoanEntity, ThongTinCongDoanDto>();
        }
    }
}
