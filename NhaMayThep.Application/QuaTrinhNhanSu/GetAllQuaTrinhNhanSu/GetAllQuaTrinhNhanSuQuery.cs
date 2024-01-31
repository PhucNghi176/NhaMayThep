using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.QuaTrinhNhanSu.GetAllQuaTrinhNhanSu
{
    public class GetAllQuaTrinhNhanSuQuery : IRequest<List<QuaTrinhNhanSuDto>>, IQuery
    {
    }
}
