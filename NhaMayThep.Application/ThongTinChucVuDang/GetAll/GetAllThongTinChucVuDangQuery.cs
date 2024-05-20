using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucVuDang.GetAll
{
    public class GetAllThongTinChucVuDangQuery : IRequest<List<ThongTinChucVuDangDto>>, IQuery
    {
        public GetAllThongTinChucVuDangQuery() { }
    }
}
