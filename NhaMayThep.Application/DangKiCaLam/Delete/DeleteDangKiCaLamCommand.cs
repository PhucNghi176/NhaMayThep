using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.DangKiCaLam.Delete
{
    public class DeleteDangKiCaLamCommand : IRequest<string>, ICommand
    {
        public string Id { get; set; }

        public DeleteDangKiCaLamCommand(string id)
        {
            Id = id;
        }
    }
}
