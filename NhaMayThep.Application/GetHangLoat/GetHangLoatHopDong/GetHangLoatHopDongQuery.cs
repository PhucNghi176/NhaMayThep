﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.GetHangLoat.GetHangLoatHopDong
{
    public class GetHangLoatHopDongQuery : IRequest<Dictionary<string, Dictionary<int, string>>>
    {
        public GetHangLoatHopDongQuery()
        {
            
        }
    }
}
