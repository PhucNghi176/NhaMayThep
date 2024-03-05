﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;

namespace NhaMayThep.Application.DangKiTangCa.Update
{
    public class UpdateDangKiTangCaCommand : IRequest<DangKiTangCaDto>, ICommand
    {
        public string Id { get; set; }
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
