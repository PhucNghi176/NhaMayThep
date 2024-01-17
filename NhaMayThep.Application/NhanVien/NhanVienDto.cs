using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.NhanVien
{
    public class NhanVienDto : IMapFrom<NhanVienEntity>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NhanVienEntity, NhanVienDto>();
        }
        public NhanVienDto()
        {

        }

        public string Email { get; set; }
        public string ID { get; set; }
        public string ChucVu { get; set; }

        public static NhanVienDto Create(string email, string id, string chucVu)
        {
            return new NhanVienDto
            {
                Email = email,
                ID = id,
                ChucVu = chucVu
            };
        }
    }
}
