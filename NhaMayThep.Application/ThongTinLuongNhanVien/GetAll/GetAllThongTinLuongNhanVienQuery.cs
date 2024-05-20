using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.GetAll
{
    public class GetAllThongTinLuongNhanVienQuery : IRequest<List<ThongTinLuongNhanVienDTO>>, IQuery
    {
        public GetAllThongTinLuongNhanVienQuery() { }
    }
}
