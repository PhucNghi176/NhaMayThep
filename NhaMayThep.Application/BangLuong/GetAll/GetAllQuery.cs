using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.BangLuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BangLuong.GetAll
{
    public class GetAllQuery : IRequest<List<BangLuongDto>>, IQuery
    {

    }
}
