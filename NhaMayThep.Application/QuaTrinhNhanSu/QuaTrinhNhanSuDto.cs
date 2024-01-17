using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.QuaTrinhNhanSu
{
    public class QuaTrinhNhanSuDto : IMapFrom<QuaTrinhNhanSuEntity>
    {
        public QuaTrinhNhanSuDto()
        {

        }

        public string ID { get; set; }
        public DateTime NgayTao { get; set; }
        public string MaSoNhanVien { get; set; }
        public int LoaiQuaTrinhID { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int PhongBanID { get; set; }
        public int ChucVuID { get; set; }
        public int ChucDanhID { get; set; }
        public string? GhiChu { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<QuaTrinhNhanSuEntity, QuaTrinhNhanSuDto>();
        }
    }
}
