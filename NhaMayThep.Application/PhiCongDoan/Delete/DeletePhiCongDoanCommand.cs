using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhiCongDoan.Delete
{
    public class DeletePhiCongDoanCommand : IRequest<string>
    {
        public DeletePhiCongDoanCommand(string id)
        {
            ID = id;
        }

        public string ID { get; set; }
    }
}
