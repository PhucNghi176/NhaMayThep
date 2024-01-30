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
    public class GetLuongCongNhatByIDQuery : IRequest<LuongCongNhatDto>, ICommand
    {
        public string ID { get; set; }
        public GetLuongCongNhatByIDQuery(string iD)
        {
            ID = iD;
        }
        public GetLuongCongNhatByIDQuery() { }
    }
}
