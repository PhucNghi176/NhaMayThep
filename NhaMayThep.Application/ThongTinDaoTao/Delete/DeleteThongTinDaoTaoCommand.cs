using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinDaoTao.Delete
{
    public class DeleteThongTinDaoTaoCommand : IRequest<string>, ICommand
    {
        public DeleteThongTinDaoTaoCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
