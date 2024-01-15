using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetThongTinGiamTruGiaCanh
{
    public class GetThongTinGiamTruGiaCanhQuery: IRequest<ThongTinGiamTruGiaCanhDto>, IQuery
    {
        public GetThongTinGiamTruGiaCanhQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
