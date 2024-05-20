using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCapDangVien.DeleteThongTinCapDangVien
{
    public class DeleteThongTinCapDangVienCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }
        public DeleteThongTinCapDangVienCommand(int id)
        {
            Id = id;
        }
    }
}
