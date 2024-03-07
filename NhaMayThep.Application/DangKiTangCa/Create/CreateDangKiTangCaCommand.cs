﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiTangCa.Create
{
    public class CreateDangKiTangCaCommand : IRequest<DangKiTangCaDto>,ICommand
    {
        public string MaSoNhanVien { get; set; }
        public DateTime NgayLamTangCa { get; set; }
        public int CaDangKi { get; set; }
        public string LiDoTangCa { get; set; }
        public DateTime ThoiGianCaLamBatDau { get; set; }
        public DateTime ThoiGianCaLamKetThuc { get; set; }
        public TimeSpan SoGioTangCa { get; set; }
        public decimal HeSoLuongTangCa { get; set; }
        public int TrangThaiDuyet { get; set; }
        public string NguoiDuyet { get; set; }
    }
}