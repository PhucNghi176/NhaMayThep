﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.GetTinhTrangLamViecByID
{
    public class GetTinhTrangLamViecByIDQuery : IRequest<TinhTrangLamViecDTO>,IQuery
    {
        public int id {  get; set; }
        public GetTinhTrangLamViecByIDQuery(int id)
        {
            this.id = id;
        }
    }
}