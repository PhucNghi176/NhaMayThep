﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.DeleteThongTinQuaTrinhNhanSu
{
    public class DeleteThongTinQuaTrinhNhanSuCommand : IRequest<string>, ICommand
    {
        public DeleteThongTinQuaTrinhNhanSuCommand(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}