﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.PhuCapCongDoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhuCapCongDoan.GetId
{
    public class GetPhuCapCongDoanByIdQuery : IRequest<PhuCapCongDoanDto>, IQuery
    {
        public GetPhuCapCongDoanByIdQuery(string id)
        {
            ID = id;
        }
        public string ID { get; set; }
    }
}