using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.KhaiBaoTangLuong
{
    public class KhaiBaoTangLuongDto : IMapFrom<KhaiBaoTangLuongEntity>
    {
        public KhaiBaoTangLuongDto()
        {
        }

        public string ID { get; set; }
        public required string MaSoNhanVien { get; set; }
        public float PhanTramTang { get; set; }
        public DateTime NgayApDung { get; set; }
        public string LyDo { get; set; }

        public static KhaiBaoTangLuongDto Create(string id, string maSoNhanVien, float phanTramTang, DateTime ngayApDung, string lyDo)
        {
            return new KhaiBaoTangLuongDto
            {
                ID = id,
                MaSoNhanVien = maSoNhanVien,
                PhanTramTang = phanTramTang,
                NgayApDung = ngayApDung,
                LyDo = lyDo,
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<KhaiBaoTangLuongEntity, KhaiBaoTangLuongDto>();
        }
    }
}