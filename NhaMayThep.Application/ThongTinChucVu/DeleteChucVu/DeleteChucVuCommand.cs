using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucVu.DeleteChucVu
{
    public class DeleteChucVuCommand : IRequest<string>, ICommand
    {
        public DeleteChucVuCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
