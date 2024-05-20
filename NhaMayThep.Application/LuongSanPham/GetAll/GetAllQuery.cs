using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LuongSanPham.GetAll
{
    public class GetAllQuery : IRequest<List<LuongSanPhamDto>>, IQuery
    {

    }
}
