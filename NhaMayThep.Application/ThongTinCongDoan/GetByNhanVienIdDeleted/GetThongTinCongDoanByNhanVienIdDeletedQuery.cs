using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongDoan.GetByNhanVienIdDeleted
{
    public class GetThongTinCongDoanByNhanVienIdDeletedQuery : IRequest<ThongTinCongDoanDto>, IQuery
    {
        public GetThongTinCongDoanByNhanVienIdDeletedQuery(string id)
        {
            Id = id;
        }
        public GetThongTinCongDoanByNhanVienIdDeletedQuery() { }
        public string Id { get; set; }
    }
}
