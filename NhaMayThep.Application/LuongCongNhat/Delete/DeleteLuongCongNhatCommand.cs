using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongCongNhat.Delete
{
    public class DeleteLuongCongNhatCommand : IRequest<string>
    {
        public DeleteLuongCongNhatCommand(string id)
        {
            ID = id;
        }

        public string ID { get; set; }
    }
}
