using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep
{
    public class ChiTietNgayNghiPhepDto : IMapFrom<ChiTietNgayNghiPhepEntity>
    {
        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public int LoaiNghiPhepID { get; set; }
        public double TongSoGio { get; set; }
        public double SoGioDaNghiPhep { get; set; }
        public double SoGioConLai { get; set; }
        public int NamHieuLuc { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChiTietNgayNghiPhepEntity, ChiTietNgayNghiPhepDto>();

        }
    }
}
