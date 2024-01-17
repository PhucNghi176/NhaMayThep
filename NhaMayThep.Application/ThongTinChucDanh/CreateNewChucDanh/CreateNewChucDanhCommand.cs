using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucDanh.CreateNewChucDanh
{
    public class CreateNewChucDanhCommand : IRequest<int>, ICommand
    {
        public CreateNewChucDanhCommand(string tenChucDanh)
        {
            TenChucDanh = tenChucDanh;
        }
        public string TenChucDanh { get; set; }
    }
}
