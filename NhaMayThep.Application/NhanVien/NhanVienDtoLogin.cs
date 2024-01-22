using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.NhanVien
{
    public class NhanVienDtoLogin : IMapFrom<NhanVienEntity>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NhanVienEntity, NhanVienDtoLogin>();
        }      

        public string Email { get; set; }
        public string ID { get; set; }
        public string ChucVu { get; set; }

        public static NhanVienDtoLogin Create(string email, string id, string chucVu)
        {
            return new NhanVienDtoLogin
            {
                Email = email,
                ID = id,
                ChucVu = chucVu
            };
        }
    }
}
