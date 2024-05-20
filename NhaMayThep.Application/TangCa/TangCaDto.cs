using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.TangCa
{
    public class TangCaDto : IMapFrom<TangCaEntity>
    {
        public TangCaDto()
        {

        }
        public string ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public double SoGioLamThem { get; set; }
        public int SoSanPhamLamThem { get; set; }
        public decimal LuongSanPham { get; set; }
        public decimal LuongCongNhat { get; set; }
        public int LoaiTangCaID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TangCaEntity, TangCaDto>();
        }
    }
}
