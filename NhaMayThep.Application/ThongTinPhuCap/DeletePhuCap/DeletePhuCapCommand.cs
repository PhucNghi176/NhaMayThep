using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinPhuCap.DeletePhuCap
{
    public class DeletePhuCapCommand : IRequest<string>, ICommand
    {
        public DeletePhuCapCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
