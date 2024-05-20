using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.KhenThuong.GetAllKhenThuong
{
    public class GetAllKhenThuongQuery : IRequest<List<KhenThuongDTO>>, IQuery
    {
    }
}
