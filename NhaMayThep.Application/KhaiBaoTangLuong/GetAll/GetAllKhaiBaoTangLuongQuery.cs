﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.KhaiBaoTangLuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.GetAll
{
    public class GetAllKhaiBaoTangLuongQuery : IRequest<List<KhaiBaoTangLuongDto>>, IQuery
    {
        public GetAllKhaiBaoTangLuongQuery()
        {

        }
    }
}