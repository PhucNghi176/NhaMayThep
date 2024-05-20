using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.BaoHiemNhanVien.GetAll
{
    public class GetAllQuery : IRequest<List<BaoHiemNhanVienDto>>, IQuery
    {
        public GetAllQuery() { }
    }
}
