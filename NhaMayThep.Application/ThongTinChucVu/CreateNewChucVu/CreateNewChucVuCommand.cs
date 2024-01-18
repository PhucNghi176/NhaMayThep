using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucVu.CreateNewChucVu
{
    public class CreateNewChucVuCommand : IRequest<int>, ICommand
    {
        public CreateNewChucVuCommand(string tenChucVu)
        {
            TenChucVu = tenChucVu;
        }
        public string TenChucVu { get; set; }
    }
}
