using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiCaLam.Delete
{
    public class DeleteDangKiCaLamCommand : IRequest<string>,ICommand
    {
        public string Id { get; set; }

        public DeleteDangKiCaLamCommand(string id)
        {
            Id = id;
        }
    }
}
