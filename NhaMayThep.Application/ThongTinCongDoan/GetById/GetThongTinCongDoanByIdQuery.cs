using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongDoan.GetById
{
    public class GetThongTinCongDoanByIdQuery : IRequest<ThongTinCongDoanDto>, IQuery
    {
        public GetThongTinCongDoanByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
