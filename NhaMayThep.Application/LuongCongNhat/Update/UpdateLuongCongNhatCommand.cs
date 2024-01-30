using MediatR;
using NhaMayThep.Application.ThongTinDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMayThep.Application.LuongCongNhat.Update
{
    public class UpdateLuongCongNhatCommand : IRequest<LuongCongNhatDto>, ICommand
    {
        public UpdateLuongCongNhatCommand(string maSoNhanVien, double soGioLam, decimal luong1Gio, decimal tongLuong)
        {
            MaSoNhanVien = maSoNhanVien;
            SoGioLam = soGioLam;
            Luong1Gio = luong1Gio;
            TongLuong = tongLuong;
        }
        public string MaSoNhanVien { get; set; }
        public double SoGioLam { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Luong1Gio { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal TongLuong { get; set; }
    }
}
