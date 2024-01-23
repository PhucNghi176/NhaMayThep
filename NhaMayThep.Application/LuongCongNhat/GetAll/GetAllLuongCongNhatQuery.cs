using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LuongCongNhat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongCongNhat.GetAll
{
    public class GetAllLuongCongNhatQuery : IRequest<List<LuongCongNhatDto>>, IQuery
    {
        public GetAllLuongCongNhatQuery()
        {

        }
    }
}
