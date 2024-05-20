using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.GetAll
{
    public class GetAllChiTietNghiPhepQuery : IRequest<List<ChiTietNgayNghiPhepDto>>, IQuery
    {

    }
}