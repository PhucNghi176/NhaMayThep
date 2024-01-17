using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.Delete
{
    public class DeleteKyLuatCommand : IRequest<KyLuatDto>, ICommand
    {
        public string Id {  get; set; }

        public DeleteKyLuatCommand(string id)
        {
            Id = id;
        }
    }
}
