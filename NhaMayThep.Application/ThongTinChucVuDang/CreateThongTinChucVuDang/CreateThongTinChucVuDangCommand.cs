using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucVuDang.CreateThongTinChucVuDang
{
    public class CreateThongTinChucVuDangCommand : IRequest<string>, ICommand
    {
        public string TenChucVuDang { get; set; }
        public CreateThongTinChucVuDangCommand(string tenChucVuDang)
        {
            TenChucVuDang = tenChucVuDang;
        }
    }
}
