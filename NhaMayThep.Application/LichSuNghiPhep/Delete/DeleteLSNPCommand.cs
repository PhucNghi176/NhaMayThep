using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.Delete
{
    public class DeleteLSNPCommand : IRequest<string>,ICommand
    {
        public string Id { get; set; }


        public DeleteLSNPCommand(string id)
        {
            Id = id;
        }
    }
}
