using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.DangKiCaLam
{
    public class DangKiCaLamDto : IMapFrom<DangKiCaLamEntity>
    {
        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public DateTime NgayDangKi { get; set; }
        public int CaDangKi { get; set; }
        public DateTime ThoiGianCaLamBatDau { get; set; }
        public DateTime ThoiGianCaLamKetThuc { get; set; }
        public DateTime? ThoiGianChamCongBatDau { get; set; }
        public DateTime? ThoiGianChamCongKetThuc { get; set; }
        public int HeSoNgayCong { get; set; }
        public string MaSoNguoiQuanLy { get; set; }
        public int TrangThai { get; set; }
        public string GhiChu { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DangKiCaLamEntity, DangKiCaLamDto>();
        }
    }
}
