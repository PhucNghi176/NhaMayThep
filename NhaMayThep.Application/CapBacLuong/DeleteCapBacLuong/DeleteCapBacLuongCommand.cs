using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.CapBacLuong.DeleteCapBacLuong
{
    public class DeleteCapBacLuongCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }
        public DeleteCapBacLuongCommand(int id)
        {
            Id = id;
        }
    }
}
