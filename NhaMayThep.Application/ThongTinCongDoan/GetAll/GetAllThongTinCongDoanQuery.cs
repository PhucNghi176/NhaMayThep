using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongDoan.GetAll
{
    public class GetAllThongTinCongDoanQuery : IRequest<List<ThongTinCongDoanDto>>, IQuery
    {
        public GetAllThongTinCongDoanQuery() { }
    }
}
