using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongDoan.RestoreThongTinCongDoan
{
    public class RestoreThongTinCongDoanCommand : IRequest<string>, ICommand
    {
        public RestoreThongTinCongDoanCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
