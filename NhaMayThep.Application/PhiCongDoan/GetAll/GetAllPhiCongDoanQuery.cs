using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.PhiCongDoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhiCongDoan.GetAll
{
    public class GetAllPhiCongDoanQuery : IRequest<List<PhiCongDoanDto>>, IQuery
    {

    }
}
