using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongDoan.GetByNhanVienId
{
    public class GetThongTinCongDoanByNhanVienIdQuery : IRequest<ThongTinCongDoanDto>, IQuery
    {
        public GetThongTinCongDoanByNhanVienIdQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
