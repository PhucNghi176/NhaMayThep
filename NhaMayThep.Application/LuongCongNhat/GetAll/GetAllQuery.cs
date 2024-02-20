using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiTangCa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongCongNhat.GetAll
{
    public class GetAllQuery : IRequest<List<LuongCongNhatDto>>, IQuery
    {

    }
}
