using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Mappings;

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
        public string HoVaTen { get; set; }
        public int LoaiQuaTrinhID { get; set; }
        public string LoaiQuaTrinh { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int PhongBanID { get; set; }
        public string PhongBan { get; set; }
        public int ChucVuID { get; set; }
        public string ChucVu { get; set; }
        public int ChucDanhID { get; set; }
        public string ChucDanh { get; set; }
        public string? GhiChu { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<QuaTrinhNhanSuEntity, QuaTrinhNhanSuDto>();
        }
    }
}
