using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NghiPhep.Delete
{
    public class DeleteNghiPhepCommand : IRequest<string>
    {
        public DeleteNghiPhepCommand(string id)
        {
            ID = id;
        }

        public string ID { get; set; }
    }
}
