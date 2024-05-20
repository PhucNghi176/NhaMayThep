using MediatR;
using NhaMayThep.Application.Common.Interfaces;

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
