using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhuCapNhanVien.DeletePhuCapNhanVien
{
    public class DeletePhuCapNhanVienCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }
        public DeletePhuCapNhanVienCommand(int id)
        {
            Id = id;
        }
    }
}
