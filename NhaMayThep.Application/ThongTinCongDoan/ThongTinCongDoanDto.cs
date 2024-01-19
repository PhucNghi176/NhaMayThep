using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan
{
    public class ThongTinCongDoanDto : IMapFrom<ThongTinCongDoanEntity>
    {
        public string Id { get; set; } = null!;
        public string NhanVienID { get; set; } = null!;
        public bool ThuKiCongDoan { get; set; }
        public DateTime NgayGiaNhap { get; set; }
        public static ThongTinCongDoanDto CreateThongTinCongDoan(string id, string nhanvienid, bool thukycongdoan, DateTime ngaygianhap)
        {
            return new ThongTinCongDoanDto
            {
                Id = id,
                NhanVienID = nhanvienid,
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
