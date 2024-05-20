using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhuCapNhanVien.GetAll
{
    public class GetAllPhuCapNhanVienQuery : IRequest<List<PhuCapNhanVienDto>>, IQuery
    {
        public GetAllPhuCapNhanVienQuery() { }
    }
}
