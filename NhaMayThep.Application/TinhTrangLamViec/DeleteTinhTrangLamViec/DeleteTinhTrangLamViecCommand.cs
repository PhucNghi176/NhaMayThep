using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TinhTrangLamViec.DeleteTinhTrangLamViec
{
    public class DeleteTinhTrangLamViecCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }
        public DeleteTinhTrangLamViecCommand() { }
        public DeleteTinhTrangLamViecCommand(int id)
        {
            this.Id = id;
        }
    }
}
