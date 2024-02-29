using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongThoiGian.DeleteLuongThoiGian
{
    public class DeleteLuongThoiGianCommand : IRequest<string>, ICommand
    {
        public string Id { get; set; }
        public DeleteLuongThoiGianCommand(string id) 
        {
            Id = id;
        }
    }
}
