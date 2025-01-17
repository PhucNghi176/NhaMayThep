﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Create
{
    public class CreateKhaiBaoTangLuongCommand : IRequest<string>, ICommand
    {
        public CreateKhaiBaoTangLuongCommand(string maSoNhanVien, float phanTramTang, DateTime ngayApDung, string lyDo)
        {

            MaSoNhanVien = maSoNhanVien;
            PhanTramTang = phanTramTang;
            NgayApDung = ngayApDung;
            LyDo = lyDo;

        }


        public required string MaSoNhanVien { get; set; }
        public float PhanTramTang { get; set; }
        public DateTime NgayApDung { get; set; }
        public string LyDo { get; set; }
    }
}