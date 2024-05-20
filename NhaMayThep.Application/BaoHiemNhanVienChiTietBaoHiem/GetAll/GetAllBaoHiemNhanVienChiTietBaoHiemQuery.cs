using MediatR;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.GetAll
{
    public class GetAllBaoHiemNhanVienChiTietBaoHiemQuery : IRequest<List<BaoHiemNhanVienChiTietBaoHiemDto>>
    {
        public GetAllBaoHiemNhanVienChiTietBaoHiemQuery() { }
    }
}
