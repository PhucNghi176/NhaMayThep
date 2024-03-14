﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.GetAll
{
    public class GetAllThongTinLuongNhanVienQuery : IRequest<List<ThongTinLuongNhanVienDTO>>, IQuery
    {
        public GetAllThongTinLuongNhanVienQuery() { }
    }
}