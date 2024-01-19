using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongDoan.DeleteThongTinCongDoan
{
    public class DeleteThongTinCongDoanCommand : IRequest<string>, ICommand
    {
        public DeleteThongTinCongDoanCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
