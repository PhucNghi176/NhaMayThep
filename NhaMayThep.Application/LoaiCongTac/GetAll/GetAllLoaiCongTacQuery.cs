using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiCongTac.GetAll
{
    public class GetAllLoaiCongTacQuery : IRequest<List<LoaiCongTacDto>>, IQuery
    {
        public GetAllLoaiCongTacQuery() { }
    }
}
