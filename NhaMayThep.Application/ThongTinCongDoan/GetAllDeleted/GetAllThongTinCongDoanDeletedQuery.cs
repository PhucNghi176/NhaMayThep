using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongDoan.GetAllDeleted
{
    public class GetAllThongTinCongDoanDeletedQuery : IRequest<List<ThongTinCongDoanDto>>, IQuery
    {
        public GetAllThongTinCongDoanDeletedQuery() { }
    }
}
