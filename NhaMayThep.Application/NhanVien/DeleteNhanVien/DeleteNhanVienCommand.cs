using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NhanVien.DeleteNhanVien
{
    public class DeleteNhanVienCommand : IRequest<string>, ICommand
    {
        public string Id { get; set; }
        public DeleteNhanVienCommand(string id)
        {
            Id = id;
        }
    }
}
