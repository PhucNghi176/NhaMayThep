using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CanCuocCongDan.GetCanCuocCongDanById
{
    public class GetCanCuocCongDanByIdQuery : IRequest<CanCuocCongDanDto>, IQuery
    {
        public GetCanCuocCongDanByIdQuery(string canCuocCongDan)
        {
            CanCuocCongDan = canCuocCongDan;
        }

        public string CanCuocCongDan { get; set; }
    }
}
