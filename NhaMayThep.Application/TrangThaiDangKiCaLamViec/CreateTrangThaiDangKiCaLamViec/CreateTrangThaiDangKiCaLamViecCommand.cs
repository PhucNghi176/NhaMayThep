using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TrangThaiDangKiCaLamViec.CreateTrangThaiDangKiCaLamViec
{
    public class CreateTrangThaiDangKiCaLamViecCommand : IRequest<string>, ICommand
    {
        public CreateTrangThaiDangKiCaLamViecCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
