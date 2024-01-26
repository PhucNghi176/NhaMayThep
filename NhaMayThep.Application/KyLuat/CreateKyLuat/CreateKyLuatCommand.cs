using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.CreateKyLuat
{
    public class CreateKyLuatCommand : IRequest<KyLuatDTO>,ICommand
    {
        public string MaSoNhanVien { get; set; }
        public int ChinhSachNhanSuID { get; set; }
        public string TenDotKyLuat { get; set; }
        public decimal TongPhat { get; set; }
        public CreateKyLuatCommand() { }
        public CreateKyLuatCommand( string nhanvienDI, int chinhsachnhansuID, string tendotkyluat, decimal total) 
        {
            this.MaSoNhanVien = nhanvienDI;
            this.ChinhSachNhanSuID = chinhsachnhansuID;
            this.TenDotKyLuat = tendotkyluat;
            this.TongPhat = total;
        }

    }
}
