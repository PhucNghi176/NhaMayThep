﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.GetHangLoat.GetHangLoatNhanVien
{
    public class GetHangLoatNhanVienQuery : IRequest<Dictionary<string, List<KeyValuePair<int, string>>>>
    {
        public GetHangLoatNhanVienQuery()
        {

        }
    }
}
