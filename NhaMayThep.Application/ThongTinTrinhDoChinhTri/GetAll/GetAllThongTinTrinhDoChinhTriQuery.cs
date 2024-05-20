using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri.GetAll
{
    public class GetAllThongTinTrinhDoChinhTriQuery : IRequest<List<ThongTinTrinhDoChinhTriDto>>, IQuery
    {
        public GetAllThongTinTrinhDoChinhTriQuery() { }
    }
}
