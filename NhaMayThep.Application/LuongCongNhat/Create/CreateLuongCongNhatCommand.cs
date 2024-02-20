﻿using MediatR;
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
        public CreateLuongCongNhatCommand( string maSoNhanVien, double soGioLam, decimal luong1Gio, decimal tongLuong)
        {

            MaSoNhanVien = maSoNhanVien;
            SoGioLam = soGioLam;
            Luong1Gio = luong1Gio;
            TongLuong = tongLuong;
        }


        public string MaSoNhanVien { get; set; }
        public double SoGioLam { get; set; }

        public decimal Luong1Gio { get; set; }

        public decimal TongLuong { get; set; }

    }
}