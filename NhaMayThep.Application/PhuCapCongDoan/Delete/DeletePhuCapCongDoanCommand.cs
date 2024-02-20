using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NhaMayThep.Application.Common.Interfaces;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhuCapCongDoan.Delete
{
    public class DeletePhuCapCongDoanCommand : IRequest<string>, ICommand
    {
        public DeletePhuCapCongDoanCommand(string id)
        {
            ID = id;
        }
        public string ID { get; set; }
    }
}
