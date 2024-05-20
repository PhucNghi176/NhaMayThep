using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.GetAll
{
    public class GetAllHoaDonCongTacNhanVienQuery : IRequest<List<HoaDonCongTacNhanVienDto>>, IQuery
    {
        public GetAllHoaDonCongTacNhanVienQuery()
        {

        }
    }
}
