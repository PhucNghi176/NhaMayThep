using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.KyLuat.CreateKyLuat
{
    public class CreateKyLuatCommand : IRequest<string>, ICommand
    {
        public string MaSoNhanVien { get; set; }
        public int ChinhSachNhanSuID { get; set; }
        public string TenDotKyLuat { get; set; }
        public decimal TongPhat { get; set; }
        public CreateKyLuatCommand() { }
        public CreateKyLuatCommand(string nhanvienDI, int chinhsachnhansuID, string tendotkyluat, decimal total)
        {
            this.MaSoNhanVien = nhanvienDI;
            this.ChinhSachNhanSuID = chinhsachnhansuID;
            this.TenDotKyLuat = tendotkyluat;
            this.TongPhat = total;
        }

    }
}
