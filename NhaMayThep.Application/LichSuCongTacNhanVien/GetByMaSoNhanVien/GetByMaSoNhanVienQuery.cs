using MediatR;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.GetByMaSoNhanVien
{
    public class GetByMaSoNhanVienQuery : IRequest<List<LichSuCongTacNhanVienDto>>
    {
        public GetByMaSoNhanVienQuery() { }

        public GetByMaSoNhanVienQuery(string maSoNhanVien)
        {
            MaSoNhanVien = maSoNhanVien;
        }

        public string MaSoNhanVien { get; set; }
    }
}
