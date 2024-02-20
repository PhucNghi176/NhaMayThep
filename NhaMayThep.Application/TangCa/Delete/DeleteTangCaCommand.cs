using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TangCa.Delete
{
    public class DeleteTangCaCommand : IRequest<string>
    {
        public DeleteTangCaCommand(string id)
        {
            ID = id;
        }

        public string ID { get; set; }
    }
}
