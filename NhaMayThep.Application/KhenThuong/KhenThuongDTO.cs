using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.KhenThuong
{
    public class KhenThuongDTO : IMapFrom<KhenThuongEntity>
    {
        public string MaSoNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string ID { get; set; }
        public int ChinhSachNhanSuID { get; set; }
        public string ChinhSachNhanSu { get; set; }
        public string TenDotKhenThuong { get; set; }
        public DateTime NgayKhenThuong { get; set; }
        public decimal TongThuong { get; set; }
        public KhenThuongDTO() { }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<KhenThuongEntity, KhenThuongDTO>();
        }
    }
}
