using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiCongTac.GetAll
{
    public class GetAllLoaiCongTacQuery : IRequest<List<LoaiCongTacDto>>, IQuery
    {
        public GetAllLoaiCongTacQuery() { }
    }
}
