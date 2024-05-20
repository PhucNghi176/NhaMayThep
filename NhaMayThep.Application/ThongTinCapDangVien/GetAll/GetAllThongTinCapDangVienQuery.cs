using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCapDangVien.GetAll
{
    public class GetAllThongTinCapDangVienQuery : IRequest<List<ThongTinCapDangVienDto>>, IQuery
    {
        public GetAllThongTinCapDangVienQuery() { }
    }
}
