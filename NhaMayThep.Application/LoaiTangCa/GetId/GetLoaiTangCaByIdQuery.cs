using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiTangCa.GetId
{
    public class GetLoaiTangCaByIdQuery : IRequest<LoaiTangCaDto>, IQuery
    {
        public int id;
        public GetLoaiTangCaByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
