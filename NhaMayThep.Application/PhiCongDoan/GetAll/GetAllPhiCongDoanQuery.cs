using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhiCongDoan.GetAll
{
    public class GetAllPhiCongDoanQuery : IRequest<List<PhiCongDoanDto>>, IQuery
    {

    }
}
