using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhuCapCongDoan.GetAll
{
    public class GetAllPhuCapCongDoanQuery : IRequest<List<PhuCapCongDoanDto>>, IQuery
    {

    }
}
