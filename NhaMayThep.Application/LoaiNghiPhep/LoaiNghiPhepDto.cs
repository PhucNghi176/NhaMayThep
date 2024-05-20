using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.LoaiNghiPhep
{
    public class LoaiNghiPhepDto : IMapFrom<LoaiNghiPhepEntity>
    {
        public int ID { get; set; }
        public string Name { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoaiNghiPhepEntity, LoaiNghiPhepDto>();
        }
    }
}
