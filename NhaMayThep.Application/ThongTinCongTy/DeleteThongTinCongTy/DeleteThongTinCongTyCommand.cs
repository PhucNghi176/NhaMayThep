using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongTy.DeleteThongTinCongTy
{
    public class DeleteThongTinCongTyCommand : IRequest<string>, ICommand
    {
        public DeleteThongTinCongTyCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
