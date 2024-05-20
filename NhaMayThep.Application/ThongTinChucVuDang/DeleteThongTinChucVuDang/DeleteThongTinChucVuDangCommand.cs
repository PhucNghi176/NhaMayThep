using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucVuDang.DeleteThongTinChucVuDang
{
    public class DeleteThongTinChucVuDangCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }
        public DeleteThongTinChucVuDangCommand(int id)
        {
            Id = id;
        }
    }
}
