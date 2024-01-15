using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiNghiPhep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.GetAll
{
    public class GetAllLSNPQuery : IRequest<List<LichSuNghiPhepDto>>, IQuery
    {

    }
}
