using MediatR;
using NhaMayThep.Application.Common.Interfaces;

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
