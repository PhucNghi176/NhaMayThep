using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhuCapNhanVien.CreatePhuCapNhanVien
{
    public class CreatePhuCapNhanVienCommand : IRequest<string>, ICommand
    {
        public CreatePhuCapNhanVienCommand(
            string maSoNhanVien,
            int phuCap)
        {
            MaSoNhanVien = maSoNhanVien;
            PhuCap = phuCap;

        }
        public string MaSoNhanVien { get; set; }
        public int PhuCap { get; set; }

    }
}
