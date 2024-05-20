using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TrangThaiDangKiCaLamViec.UpdateTrangThaiDangKiCaLamViec
{
    public class UpdateTrangThaiDangKiCaLamViecCommand : IRequest<string>, ICommand
    {
        public UpdateTrangThaiDangKiCaLamViecCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
