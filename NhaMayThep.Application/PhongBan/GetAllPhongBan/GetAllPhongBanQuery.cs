using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhongBan.GetAllPhongBan
{
    public class GetAllPhongBanQuery : IRequest<List<PhongBanDto>>, IQuery
    {
    }
}
