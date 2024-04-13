using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhuCapNhanVien.UpdatePhuCapNhanVien
{
    public class UpdatePhuCapNhanVienCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public int PhuCap { get; set; }
        public UpdatePhuCapNhanVienCommand(
            int id,
            string maSoNhanVien,
            int phuCap)
        {
            Id = id;
            MaSoNhanVien = maSoNhanVien;
            PhuCap = phuCap;
        }
    }
}
