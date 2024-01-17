using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByNhanVienIdDeleted
{
    public class GetThongTinGiamTruGiaCanhByNhanVienIdDeletedQuery: IRequest<List<ThongTinGiamTruGiaCanhDto>>, IQuery
    {
        public GetThongTinGiamTruGiaCanhByNhanVienIdDeletedQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
