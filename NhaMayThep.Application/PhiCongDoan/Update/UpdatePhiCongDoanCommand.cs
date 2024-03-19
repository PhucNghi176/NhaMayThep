using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using NhaMayThep.Application.Common.Interfaces;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhiCongDoan.Update
{
    public class UpdatePhiCongDoanCommand : IRequest<string>, ICommand
    {
        public UpdatePhiCongDoanCommand(string id, string maSoNhanVien, double phanTramLuongDongBH, decimal luongDongBH)
        {
            Id = id;
            MaSoNhanVien = maSoNhanVien;
            PhanTramLuongDongBH = phanTramLuongDongBH;
            LuongDongBH = luongDongBH;
        }

        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public double PhanTramLuongDongBH { get; set; }

        public decimal LuongDongBH { get; set; }
    }

}
