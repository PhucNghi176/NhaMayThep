using MediatR;
using NhaMayThep.Application.LuongCongNhat;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongCongNhat.GetId
{
    public class GetLuongCongNhatByIdQuery : IRequest<LuongCongNhatDto>, ICommand
    {
        public string ID { get; set; }
        public GetLuongCongNhatByIdQuery(string iD)
        {
            ID = iD;
        }
        public GetLuongCongNhatByIdQuery() { }
    }
}
