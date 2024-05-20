using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.DangKiTangCa
{
    public class DangKiTangCaDto : IMapFrom<DangKiTangCaEntity>
    {
        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public DateTime NgayLamTangCa { get; set; }
        public int CaDangKi { get; set; }
        public string LiDoTangCa { get; set; }
        public DateTime ThoiGianCaLamBatDau { get; set; }
        public DateTime ThoiGianCaLamKetThuc { get; set; }
        public TimeSpan SoGioTangCa { get; set; }
        public decimal HeSoLuongTangCa { get; set; }
        public string NguoiDuyet { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<DangKiTangCaEntity, DangKiTangCaDto>();
        }
    }

}
