using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BangLuong.Delete
{
    public class DeleteBangLuongCommand : IRequest<string>
    {
        public DeleteBangLuongCommand(string id)
        {
            ID = id;
        }

        public string ID { get; set; }
    }
}
