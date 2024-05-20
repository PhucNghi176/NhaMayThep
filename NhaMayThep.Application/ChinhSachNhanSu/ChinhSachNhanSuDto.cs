using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.ChinhSachNhanSu
{
    public class ChinhSachNhanSuDto : IMapFrom<ChinhSachNhanSuEntity>
    {
        public ChinhSachNhanSuDto()
        {

        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string MucDo { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public string NoiDung { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChinhSachNhanSuEntity, ChinhSachNhanSuDto>();
        }
    }
}
