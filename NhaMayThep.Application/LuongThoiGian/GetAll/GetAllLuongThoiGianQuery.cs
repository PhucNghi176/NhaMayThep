using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongThoiGian.GetAll
{
    public class GetAllLuongThoiGianQuery : IRequest<List<LuongThoiGianDto>>, IQuery
    {
        public GetAllLuongThoiGianQuery() { }
    }
}
