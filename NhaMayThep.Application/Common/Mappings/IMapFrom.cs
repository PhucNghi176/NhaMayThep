using AutoMapper;

namespace NhaMayThep.Application.Common.Mappings
{
    interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}
