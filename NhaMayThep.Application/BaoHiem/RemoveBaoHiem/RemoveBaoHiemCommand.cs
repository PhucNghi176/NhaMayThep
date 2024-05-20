using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.BaoHiem.RemoveBaoHiem
{
    public class RemoveBaoHiemCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }
        public RemoveBaoHiemCommand(int id)
        {
            Id = id;
        }
    }
}
