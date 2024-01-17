using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.GetThongTinGiamTruById
{
    public class GetThongTinGiamTruByIdQuery : IRequest<ThongTinGiamTruDTO>,IQuery
    {
        public int Id { get; set; }
        public GetThongTinGiamTruByIdQuery(int id)
        {
            Id = id;
        }
    }
}
