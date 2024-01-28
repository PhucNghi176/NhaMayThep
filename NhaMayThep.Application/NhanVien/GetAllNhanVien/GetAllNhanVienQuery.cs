﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetAllNhanVien
{
    public class GetAllNhanVienQuery : IRequest<List<NhanVienDto>>,IQuery 
    {
        public GetAllNhanVienQuery()
        {
            
        }
    }
}