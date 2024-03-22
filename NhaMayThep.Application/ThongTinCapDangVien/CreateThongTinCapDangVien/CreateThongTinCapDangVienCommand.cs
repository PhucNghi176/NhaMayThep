﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCapDangVien.CreateThongTinCapDangVien
{
    public class CreateThongTinCapDangVienCommand : IRequest<string>, ICommand
    {
        public string TenCapDangVien {  get; set; }
        public CreateThongTinCapDangVienCommand(string tenCapDangVien) 
        {
            TenCapDangVien = tenCapDangVien;
        }
    }
}
