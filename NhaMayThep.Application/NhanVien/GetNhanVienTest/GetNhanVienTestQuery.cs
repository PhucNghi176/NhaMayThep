using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NhanVien.GetNhanVienTest
{
    public class GetNhanVienTestQuery : IRequest<List<NhanVienDto>>, IQuery
    {
        public GetNhanVienTestQuery()
        {

        }
    }
}
