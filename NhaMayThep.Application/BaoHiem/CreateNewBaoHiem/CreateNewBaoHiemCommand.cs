﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiem.CreateNewBaoHiem
{
    public class CreateNewBaoHiemCommand : IRequest<string>, ICommand
    {
        public string TenLoaiBaoHiem {  get; set; }
        public double PhantramKhauTru { get; set; }
        public CreateNewBaoHiemCommand(string tenLoaiBaoHiem, double phantramKhauTru)
        {
            TenLoaiBaoHiem = tenLoaiBaoHiem;
            PhantramKhauTru = phantramKhauTru;
        }
    }
}