using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LichSuNghiPhep.GetAll
{
    public class GetAllLichSuNghiPhepQuery : IRequest<List<LichSuNghiPhepDto>>, IQuery
    {

    }
}
