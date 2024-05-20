using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TangCa.GetId
{
    public class GetTangCaByIdQuery : IRequest<TangCaDto>, ICommand
    {
        public string ID { get; set; }
        public GetTangCaByIdQuery(string iD)
        {
            ID = iD;
        }
        public GetTangCaByIdQuery() { }
    }
}
