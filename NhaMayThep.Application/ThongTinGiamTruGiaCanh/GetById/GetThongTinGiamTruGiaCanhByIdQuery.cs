using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetById
{
    public class GetThongTinGiamTruGiaCanhByIdQuery : IRequest<ThongTinGiamTruGiaCanhDto>, IQuery
    {
        public GetThongTinGiamTruGiaCanhByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
