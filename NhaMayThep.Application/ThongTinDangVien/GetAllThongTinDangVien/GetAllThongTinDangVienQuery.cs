using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinDangVien.GetAllThongTinDangVien
{
    public class GetAllThongTinDangVienQuery : IRequest<List<ThongTinDangVienDto>>, IQuery
    {
        public GetAllThongTinDangVienQuery()
        {

        }
    }
}
