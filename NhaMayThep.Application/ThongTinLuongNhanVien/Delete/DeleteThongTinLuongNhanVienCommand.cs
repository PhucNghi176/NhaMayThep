using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Delete
{
    public class DeleteThongTinLuongNhanVienCommand : IRequest<string>, ICommand
    {
        public DeleteThongTinLuongNhanVienCommand(string Id)
        {
            this.Id = Id;
        }
        public string Id { get; set; }
    }
}
