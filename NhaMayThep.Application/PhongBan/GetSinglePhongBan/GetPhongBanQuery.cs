using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhongBan.GetSinglePhongBan
{
    public class GetPhongBanQuery : IRequest<PhongBanDto>, IQuery
    {
        public GetPhongBanQuery(int id) 
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
