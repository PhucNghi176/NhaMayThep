using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri.DeleteThongTinTrinhDoChinhTri
{
    public class DeleteThongTinTrinhDoChinhTriCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }
        public DeleteThongTinTrinhDoChinhTriCommand(int id)
        {
            Id = id;
        }
    }
}
