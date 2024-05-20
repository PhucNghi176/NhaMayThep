using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu
{
    public class ThongTinQuaTrinhNhanSuDto : IMapFrom<ThongTinQuaTrinhNhanSuEntity>
    {
        public ThongTinQuaTrinhNhanSuDto()
        {

        }
        public int ID { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinQuaTrinhNhanSuEntity, ThongTinQuaTrinhNhanSuDto>();
        }
    }
}
