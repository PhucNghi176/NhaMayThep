using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongDoan.GetByIdDeleted
{
    public class GetThongTinCongDoanByIdDeletedQuery : IRequest<ThongTinCongDoanDto>, IQuery
    {
        public GetThongTinCongDoanByIdDeletedQuery(string id)
        {
            Id = id;
        }
        public GetThongTinCongDoanByIdDeletedQuery() { }
        public string Id { get; set; }
    }
}
