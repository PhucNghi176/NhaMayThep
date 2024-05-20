using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.BaoHiemNhanVien.GetById
{
    public class GetByIdQuery : IRequest<BaoHiemNhanVienDto>, IQuery
    {
        public GetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
