using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Delete
{
    public class DeleteKhaiBaoTangLuongCommand : IRequest<string>
    {
        public DeleteKhaiBaoTangLuongCommand(string id)
        {
            ID = id;
        }

        public string ID { get; set; }
    }
}
