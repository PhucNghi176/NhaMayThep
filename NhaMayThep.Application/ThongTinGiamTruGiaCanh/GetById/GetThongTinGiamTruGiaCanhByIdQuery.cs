using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetById
{
    public class GetThongTinGiamTruGiaCanhByIdQuery : IRequest<ThongTinGiamTruGiaCanhDto>, IQuery
    {
        public GetThongTinGiamTruGiaCanhByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
