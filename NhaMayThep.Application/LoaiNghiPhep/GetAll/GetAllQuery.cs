using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiNghiPhep.GetAll
{
    public class GetAllQuery : IRequest<List<LoaiNghiPhepDto>>, IQuery
    {

    }
}