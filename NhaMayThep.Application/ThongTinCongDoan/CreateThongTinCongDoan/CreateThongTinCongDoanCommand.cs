using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongDoan.CreateThongTinCongDoan
{
    public class CreateThongTinCongDoanCommand : IRequest<string>, ICommand
    {
        public CreateThongTinCongDoanCommand(
            string nhanVienID,
            bool thuKyCongDoan,
            DateTime ngaygianhap)
        {
            NhanVienID = nhanVienID;
            ThuKyCongDoan = thuKyCongDoan;
            NgayGiaNhap = ngaygianhap;
        }
        public string NhanVienID { get; set; }
        public bool ThuKyCongDoan { get; set; }
        public DateTime NgayGiaNhap { get; set; }
    }
}
