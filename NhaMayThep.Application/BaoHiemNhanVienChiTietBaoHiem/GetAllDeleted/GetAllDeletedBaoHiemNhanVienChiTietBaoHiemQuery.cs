using MediatR;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.GetAllDeleted
{
    public class GetAllDeletedBaoHiemNhanVienChiTietBaoHiemQuery : IRequest<List<BaoHiemNhanVienChiTietBaoHiemDto>>
    {
        public GetAllDeletedBaoHiemNhanVienChiTietBaoHiemQuery() { }
    }
}
