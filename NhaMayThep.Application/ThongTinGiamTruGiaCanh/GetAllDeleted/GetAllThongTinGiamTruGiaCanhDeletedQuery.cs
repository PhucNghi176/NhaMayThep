using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetAllDeleted
{
    public class GetAllThongTinGiamTruGiaCanhDeletedQuery: IRequest<List<ThongTinGiamTruGiaCanhDto>>, IQuery
    {
        public GetAllThongTinGiamTruGiaCanhDeletedQuery() { }
    }
}
