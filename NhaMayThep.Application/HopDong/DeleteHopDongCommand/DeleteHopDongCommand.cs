using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.HopDong.DeleteHopDongCommand
{
    public class DeleteHopDongCommand : IRequest<string>, ICommand
    {
        public DeleteHopDongCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
