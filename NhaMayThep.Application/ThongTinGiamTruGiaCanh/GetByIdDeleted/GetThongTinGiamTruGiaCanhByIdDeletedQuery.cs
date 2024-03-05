using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByIdDeleted
{
    public class GetThongTinGiamTruGiaCanhByIdDeletedQuery : IRequest<ThongTinGiamTruGiaCanhDto>, IQuery
    {
        public GetThongTinGiamTruGiaCanhByIdDeletedQuery(string id)
        {
            Id = id;
        }
        public GetThongTinGiamTruGiaCanhByIdDeletedQuery() { }
        public string Id { get; set; }
    }
}
