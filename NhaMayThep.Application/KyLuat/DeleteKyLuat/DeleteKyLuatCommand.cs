using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.KyLuat.DeleteKyLuat
{
    public class DeleteKyLuatCommand : IRequest<string>, ICommand
    {
        public string Id { get; set; }
        public DeleteKyLuatCommand() { }
        public DeleteKyLuatCommand(string id)
        {
            this.Id = id;
        }
    }
}
