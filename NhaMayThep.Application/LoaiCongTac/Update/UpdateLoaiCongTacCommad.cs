﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiCongTac.Update
{
    public class UpdateLoaiCongTacCommad : IRequest<LoaiCongTacDto>, ICommand
    {
        public UpdateLoaiCongTacCommad(int id, string name) 
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

    }
}
