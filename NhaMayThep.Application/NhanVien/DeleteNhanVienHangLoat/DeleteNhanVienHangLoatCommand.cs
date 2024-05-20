using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NhanVien.DeleteNhanVienHangLoat
{
    public class DeleteNhanVienHangLoatCommand : IRequest<string>, ICommand
    {
        public List<string> Ids { get; set; }

        public DeleteNhanVienHangLoatCommand(List<string> ids)
        {
            Ids = ids;
        }
    }
}
