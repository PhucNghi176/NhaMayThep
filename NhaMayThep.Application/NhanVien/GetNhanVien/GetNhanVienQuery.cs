using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NhanVien.GetNhanVien
{
    public class GetNhanVienQuery : IRequest<NhanVienDto>, IQuery
    {
        public GetNhanVienQuery()
        {

        }
        public GetNhanVienQuery(string predicate)
        {
            Predicate = predicate;
        }

        public required string Predicate { get; set; }
    }
}
