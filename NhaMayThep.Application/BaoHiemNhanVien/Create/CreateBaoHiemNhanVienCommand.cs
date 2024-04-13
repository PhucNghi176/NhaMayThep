using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.BaoHiemNhanVien.Create
{
    public class CreateBaoHiemNhanVienCommand : IRequest<string>, ICommand
    {
        public CreateBaoHiemNhanVienCommand(string maSoNhanVien, int baoHiem)
        {
            MaSoNhanVien = maSoNhanVien;
            BaoHiem = baoHiem;
        }

        public string MaSoNhanVien { get; set; }
        public int BaoHiem { get; set; }
    }
}
