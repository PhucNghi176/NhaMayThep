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
        public UpdatePhiCongDoanCommand(string id, string maSoNhanVien, double phanTramDongBH, decimal luongDongBH)
        {
            ID = id;
            MaSoNhanVien = maSoNhanVien;
                PhanTramLuongDongBH = phanTramDongBH;
            LuongDongBH = luongDongBH;
        }
        public string ID { get; set; }
        public required string MaSoNhanVien { get; set; }
        public double PhanTramLuongDongBH { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal LuongDongBH { get; set; }
    }
}
