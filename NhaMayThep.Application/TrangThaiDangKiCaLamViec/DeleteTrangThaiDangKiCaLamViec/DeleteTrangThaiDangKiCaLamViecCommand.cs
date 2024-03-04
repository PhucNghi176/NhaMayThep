using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TrangThaiDangKiCaLamViec.DeleteTrangThaiDangKiCaLamViec
{
    public class DeleteTrangThaiDangKiCaLamViecCommand : IRequest<string>, ICommand
    {
        public DeleteTrangThaiDangKiCaLamViecCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
