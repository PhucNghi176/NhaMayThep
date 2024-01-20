﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.CreateThongTinGiamTru
{
    public class CreateThongTinGiamTruCommand : IRequest<ThongTinGiamTruDTO>,ICommand
    {
        public string Name { get; set; }
        public decimal SoTienGiamTru { get; set; }
        public CreateThongTinGiamTruCommand() { }
        public CreateThongTinGiamTruCommand(string idUser,int id, string name, decimal soTienGiamTru)
        {
            this.Name = name;
            this.SoTienGiamTru = soTienGiamTru;
        }
    }
}