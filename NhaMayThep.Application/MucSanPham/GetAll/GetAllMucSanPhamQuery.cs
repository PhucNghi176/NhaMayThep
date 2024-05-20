using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.MucSanPham.GetAll
{
    public class GetAllMucSanPhamQuery : IRequest<List<MucSanPhamDto>>, IQuery
    {

    }
}
