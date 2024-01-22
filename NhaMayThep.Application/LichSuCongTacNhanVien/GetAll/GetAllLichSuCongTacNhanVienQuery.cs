using MediatR;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.GetAll
{
    public class GetAllLichSuCongTacNhanVienQuery : IRequest<List<LichSuCongTacNhanVienDto>>
    {
        public GetAllLichSuCongTacNhanVienQuery() { }
    }
}
