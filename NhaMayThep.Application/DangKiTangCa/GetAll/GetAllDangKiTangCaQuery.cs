using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LichSuNghiPhep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiTangCa.GetAll
{
    public class GetAllDktcQuery : IRequest<List<DangKiTangCaDto>>, IQuery
    {
    }
}
