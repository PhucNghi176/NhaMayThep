using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.KhaiBaoTangLuong.GetId
{
    public class GetKhaiBaoTangLuongByIdQuery : IRequest<KhaiBaoTangLuongDto>, ICommand
    {
        public string ID { get; set; }
        public GetKhaiBaoTangLuongByIdQuery(string iD)
        {
            ID = iD;
        }
        public GetKhaiBaoTangLuongByIdQuery() { }
    }
}
