using MediatR;
using NhaMayThep.Application.BangLuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.BangLuong.GetById
{
    public class GetBangLuongByIdQuery : IRequest<BangLuongDto>, ICommand
    {
        public string ID { get; set; }
        public GetBangLuongByIdQuery(string iD)
        {
            ID = iD;
        }
        public GetBangLuongByIdQuery() { }
    }
}
