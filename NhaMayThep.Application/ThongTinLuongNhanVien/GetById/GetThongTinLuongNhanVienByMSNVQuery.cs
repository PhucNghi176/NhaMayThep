﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.GetById
{
    public class GetThongTinLuongNhanVienByMSNVQuery : IRequest<ThongTinLuongNhanVienDto>, IQuery
    {
        public GetThongTinLuongNhanVienByMSNVQuery(string Id)
        {
            this.Id = Id;
        }
        public string Id { get; set; }
    }
}
