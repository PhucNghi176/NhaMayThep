using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.QuaTrinhNhanSu.GetSingleQuaTrinhNhanSu
{
    public class GetQuaTrinhNhanSuQuery : IRequest<QuaTrinhNhanSuDto?>, IQuery
    {
        public GetQuaTrinhNhanSuQuery(string id)
        {
            ID = id;
        }
        public string ID { get; set; }
    }
}
