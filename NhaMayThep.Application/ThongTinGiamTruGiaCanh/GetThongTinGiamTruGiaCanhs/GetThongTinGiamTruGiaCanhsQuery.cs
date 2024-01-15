using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetThongTinGiamTruGiaCanhs
{
    public class GetThongTinGiamTruGiaCanhsQuery: IRequest<List<ThongTinGiamTruGiaCanhDto>>, IQuery
    {
        public GetThongTinGiamTruGiaCanhsQuery()
        {

        }
    }
}
