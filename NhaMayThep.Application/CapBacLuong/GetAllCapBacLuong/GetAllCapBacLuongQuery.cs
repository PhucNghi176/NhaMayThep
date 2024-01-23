using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CapBacLuong.GetAllCapBacLuong
{
    public class GetAllCapBacLuongQuery : IRequest<List<CapbacLuongDto>>, IQuery
    {
        public GetAllCapBacLuongQuery() 
        {
            
        }
    }
}
