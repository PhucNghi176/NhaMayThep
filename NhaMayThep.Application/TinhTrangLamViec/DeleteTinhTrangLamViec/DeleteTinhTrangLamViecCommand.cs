using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.DeleteTinhTrangLamViec
{
    public class DeleteTinhTrangLamViecCommand : IRequest<bool>,ICommand
    {
        public int Id { get; set; }
        public DeleteTinhTrangLamViecCommand() { }
        public DeleteTinhTrangLamViecCommand(int id)
        {
            this.Id = id;
        }
    }
}
