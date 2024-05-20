using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetAllDeleted
{
    public class GetAllThongTinGiamTruGiaCanhDeletedQuery : IRequest<List<ThongTinGiamTruGiaCanhDto>>, IQuery
    {
        public GetAllThongTinGiamTruGiaCanhDeletedQuery() { }
    }
}
