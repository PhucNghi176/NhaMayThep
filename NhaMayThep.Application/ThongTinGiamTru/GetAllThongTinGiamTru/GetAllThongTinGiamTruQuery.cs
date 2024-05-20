using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTru.GetAllThongTinGiamTru
{
    public class GetAllThongTinGiamTruQuery : IRequest<List<ThongTinGiamTruDTO>>, IQuery
    {

    }
}
