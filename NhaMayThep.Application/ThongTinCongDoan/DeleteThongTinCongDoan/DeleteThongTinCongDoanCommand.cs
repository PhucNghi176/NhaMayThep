using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongDoan.DeleteThongTinCongDoan
{
    public class DeleteThongTinCongDoanCommand : IRequest<string>, ICommand
    {
        public DeleteThongTinCongDoanCommand(string id)
        {
            Id = id;
        }
        public void NguoiXoa(string value)
        {
            NguoiXoaId = value;
        }
        public string? NguoiXoaid
        {
            get { return NguoiXoaId; }
        }
        private string? NguoiXoaId;
        public string Id { get; set; }
    }
}
