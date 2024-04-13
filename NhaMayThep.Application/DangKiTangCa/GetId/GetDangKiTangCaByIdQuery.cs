using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiTangCa.GetId
{
    public class GetDangKiTangCaByIdQuery : IRequest<DangKiTangCaDto>
    {
        public string Id { get; set; }
    }
}
