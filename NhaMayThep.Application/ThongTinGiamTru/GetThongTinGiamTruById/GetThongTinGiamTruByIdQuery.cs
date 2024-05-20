using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTru.GetThongTinGiamTruById
{
    public class GetThongTinGiamTruByIdQuery : IRequest<ThongTinGiamTruDTO>, IQuery
    {
        public int Id { get; set; }
        public GetThongTinGiamTruByIdQuery(int id)
        {
            Id = id;
        }
    }
}
