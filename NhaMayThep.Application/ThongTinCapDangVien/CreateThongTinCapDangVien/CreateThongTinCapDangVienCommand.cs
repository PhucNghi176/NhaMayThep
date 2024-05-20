using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCapDangVien.CreateThongTinCapDangVien
{
    public class CreateThongTinCapDangVienCommand : IRequest<string>, ICommand
    {
        public string TenCapDangVien { get; set; }
        public CreateThongTinCapDangVienCommand(string tenCapDangVien)
        {
            TenCapDangVien = tenCapDangVien;
        }
    }
}
