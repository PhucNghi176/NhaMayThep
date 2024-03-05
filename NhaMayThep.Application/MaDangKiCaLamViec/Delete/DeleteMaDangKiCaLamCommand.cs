using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MaDangKiCaLamViec.Delete
{
    public class DeleteMaDangKiCaLamCommand : IRequest<string>, ICommand
    {
        public DeleteMaDangKiCaLamCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
