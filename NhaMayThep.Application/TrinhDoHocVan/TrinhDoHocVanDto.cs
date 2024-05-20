using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.TrinhDoHocVan
{
    public class TrinhDoHocVanDto : IMapFrom<TrinhDoHocVanEntity>
    {
        public TrinhDoHocVanDto() { }

        public int Id { get; set; }
        public string tenTrinhDo { get; set; }



        public void Mapping(Profile profile)
        {
            profile.CreateMap<TrinhDoHocVanEntity, TrinhDoHocVanDto>()
                   .ForMember(dest => dest.tenTrinhDo, opt => opt.MapFrom(src => src.Name)); // Đảm bảo ánh xạ đúng tên property trong Entity
        }
    }
}
