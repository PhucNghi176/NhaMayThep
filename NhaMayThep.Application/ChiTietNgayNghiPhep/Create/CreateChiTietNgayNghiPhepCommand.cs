﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Create
{
    public class CreateChiTietNgayNghiPhepCommand : IRequest<ChiTietNgayNghiPhepDto>, ICommand
    {

        public string MaSoNhanVien { get; set; }
        public int LoaiNghiPhepID { get; set; }
        public double TongSoGio { get; set; }
        public double SoGioDaNghiPhep { get; set; }
        public double SoGioConLai { get; set; }
        public int NamHieuLuc { get; set; }


        public CreateChiTietNgayNghiPhepCommand( string maSoNhanVien, int loaiNghiPhepID, double tongSoGio, double soGioDaNghiPhep, double soGioConLai, int namHieuLuc)
        {
            
            MaSoNhanVien = maSoNhanVien;
            LoaiNghiPhepID = loaiNghiPhepID;
            TongSoGio = tongSoGio;
            SoGioDaNghiPhep = soGioDaNghiPhep;
            SoGioConLai = soGioConLai;
            NamHieuLuc = namHieuLuc;
        }
    }
}