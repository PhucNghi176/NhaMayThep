using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
