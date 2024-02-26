using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongSanPham.Delete
{
    public class DeleteLuongSanPhamCommand : IRequest<string>
    {
        public DeleteLuongSanPhamCommand(string id)
        {
            ID = id;
        }

        public string ID { get; set; }
    }
}