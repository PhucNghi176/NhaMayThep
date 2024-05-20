using MediatR;

namespace NhaMayThep.Application.ThongTinDangVien.GetByNhanVienIDThongTinDangVien
{
    public class GetByNhanVienIDThongTinDangVienCommand : IRequest<List<ThongTinDangVienDto>>
    {
        public GetByNhanVienIDThongTinDangVienCommand(string nhanVienID)
        {
            NhanVienID = nhanVienID;
        }

        public string NhanVienID { get; set; }
    }
}
