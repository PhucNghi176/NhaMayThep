using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiTangCa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiTangCa.GetId
{
    public class GetLoaiTangCaByIdQuery : IRequest<LoaiTangCaDto>, IQuery
    {
        public int id;
        public GetLoaiTangCaByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
