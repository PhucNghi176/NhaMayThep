using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.GetHangLoat
{
    public class GetHangLoatQuery : IRequest<Dictionary<string, Dictionary<int, string>>>
    {
        public GetHangLoatQuery()
        {

        }
    }
}
