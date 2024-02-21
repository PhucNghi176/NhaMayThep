using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MucSanPham.Delete
{
    public class DeleteMucSanPhamCommand : IRequest<string>, ICommand
    {
        public DeleteMucSanPhamCommand(string id)
        {
            ID = id;
        }
        public string ID {  get; set; }
    }
}
