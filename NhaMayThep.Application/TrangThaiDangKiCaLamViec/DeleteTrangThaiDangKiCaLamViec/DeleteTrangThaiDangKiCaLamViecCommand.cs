using MediatR;
using NhaMayThep.Application.Common.Interfaces;

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
