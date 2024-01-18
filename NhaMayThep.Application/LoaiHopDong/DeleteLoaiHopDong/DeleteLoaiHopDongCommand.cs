using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiHopDong.DeleteLoaiHopDong
{
    public class DeleteLoaiHopDongCommand : IRequest<string>, ICommand
    {
        public DeleteLoaiHopDongCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
