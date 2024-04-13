using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.BaoHiemNhanVien
{
    public class BaoHiemNhanVienDto : IMapFrom<BaoHiemNhanVienEntity>
    {
        public BaoHiemNhanVienDto() { }
        public string ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public int BaoHiem { get; set; }

        public static BaoHiemNhanVienDto CreateBaoHiemNhanVien(string Id, string maSoNhanVien, int baoHiem)
        {
            return new BaoHiemNhanVienDto()
            {
                ID = Id ,
                MaSoNhanVien = maSoNhanVien,
                BaoHiem = baoHiem
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BaoHiemNhanVienEntity, BaoHiemNhanVienDto>();
        }
    }
}
