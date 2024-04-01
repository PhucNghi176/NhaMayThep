using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.BaoHiemNhanVien.Create
{
    public class CreateBaoHiemNhanVienCommand : IRequest<string>, ICommand
    {
        public CreateBaoHiemNhanVienCommand(string maSoNhanVien)
        {
            MaSoNhanVien = maSoNhanVien;
        }

        public string MaSoNhanVien { get; set; }
    }
}
