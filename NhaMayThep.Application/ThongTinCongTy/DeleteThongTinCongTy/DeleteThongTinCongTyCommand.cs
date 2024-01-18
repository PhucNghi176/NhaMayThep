using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongTy.DeleteThongTinCongTy
{
    public class DeleteThongTinCongTyCommand : IRequest<string>, ICommand
    {
        public DeleteThongTinCongTyCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}