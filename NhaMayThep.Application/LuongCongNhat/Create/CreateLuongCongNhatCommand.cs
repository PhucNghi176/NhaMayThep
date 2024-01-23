using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;
using NhaMapThep.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMayThep.Application.LuongCongNhat.Create
{
    public class CreateLuongCongNhatCommand : IRequest<string>, ICommand
    {
        public CreateLuongCongNhatCommand(string id, string maSoNhanVien, double soGioLam, decimal luong1Gio, decimal tongLuong)
        {
            ID = id;
            MaSoNhanVien = maSoNhanVien;
            SoGioLam = soGioLam;
            Luong1Gio = luong1Gio;
            TongLuong = tongLuong;
        }

        public string ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public double SoGioLam { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Luong1Gio { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal TongLuong { get; set; }

    }
}
