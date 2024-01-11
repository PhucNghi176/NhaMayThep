using AutoMapper;

namespace NhaMapThep.Application.Common.Mappings
{
    interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}
