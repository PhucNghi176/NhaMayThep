using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHopDong.GetLoaiHopDongById
{
    public class GetLoaiHopDongByIdQuery : IRequest<LoaiHopDongDto>, IQuery
    {
        public GetLoaiHopDongByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
