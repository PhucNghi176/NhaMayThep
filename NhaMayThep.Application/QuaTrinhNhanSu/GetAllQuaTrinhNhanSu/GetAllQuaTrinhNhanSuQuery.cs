using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.QuaTrinhNhanSu.GetAllQuaTrinhNhanSu
{
    public class GetAllQuaTrinhNhanSuQuery : IRequest<List<QuaTrinhNhanSuDto>>, IQuery
    {
    }
}
