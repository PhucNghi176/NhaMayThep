using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDaoTao.GetById
{
    public class GetByIdQuery : IRequest<ThongTinDaoTaoDto>, IQuery
    {
        public GetByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
