using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhuCapNhanVien.UpdatePhuCapNhanVien
{
    public class UpdatePhuCapNhanVienCommand : IRequest<string>, ICommand
    {
        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public int PhuCap { get; set; }
        public UpdatePhuCapNhanVienCommand(
            string id,
            string maSoNhanVien,
            int phuCap)
        {
            Id = id;
            MaSoNhanVien = maSoNhanVien;
            PhuCap = phuCap;
        }
    }
}
