using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using NhaMayThep.Application.Common.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhiCongDoan.Create
{
    public class CreatePhiCongDoanCommand : IRequest<string>, ICommand
    {
        public CreatePhiCongDoanCommand(string maSoNhanVien, double phanTramDongBH, decimal luongDongBH)
        {
            MaSoNhanVien = maSoNhanVien;
            PhanTramLuongDongBH = phanTramDongBH;
            LuongDongBH = luongDongBH;
        }


        public required string MaSoNhanVien { get; set; }
        public double PhanTramLuongDongBH { get; set; }

        public decimal LuongDongBH { get; set; }
    }
}
