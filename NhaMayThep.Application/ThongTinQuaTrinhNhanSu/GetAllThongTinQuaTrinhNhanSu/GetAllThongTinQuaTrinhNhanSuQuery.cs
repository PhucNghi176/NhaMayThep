using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.GetAllThongTinQuaTrinhNhanSu
{
    public class GetAllThongTinQuaTrinhNhanSuQuery : IRequest<List<ThongTinQuaTrinhNhanSuDto>>, IQuery
    {
    }
}
