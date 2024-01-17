using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongDoan.UpdateThongTinCongDoan
{
<<<<<<< HEAD
    public class UpdateThongTinCongDoanCommand: IRequest<string>, ICommand
=======
    public class UpdateThongTinCongDoanCommand : IRequest<ThongTinCongDoanDto>, ICommand
>>>>>>> origin/main
    {
        public UpdateThongTinCongDoanCommand(
            string id,
            string nhanvienid,
            bool thukycongdoan,
            DateTime? ngaygianhap)
        {
            Id = id;
            NhanVienId = nhanvienid;
            ThuKyCongDoan = thukycongdoan;
            NgayGiaNhap = ngaygianhap;
        }
        public string Id { get; set; }
        public string NhanVienId { get; set; }
        public bool ThuKyCongDoan { get; set; }
        public DateTime? NgayGiaNhap { get; set; }
    }
}
