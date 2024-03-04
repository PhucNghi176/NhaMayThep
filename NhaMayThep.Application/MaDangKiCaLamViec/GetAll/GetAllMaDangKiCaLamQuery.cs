using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MaDangKiCaLamViec.GetAll
{
    public class GetAllMaDangKiCaLamQuery : IRequest<List<MaDangKiCaLamViecDTO>>
    {
        public GetAllMaDangKiCaLamQuery() { }
    }
}
