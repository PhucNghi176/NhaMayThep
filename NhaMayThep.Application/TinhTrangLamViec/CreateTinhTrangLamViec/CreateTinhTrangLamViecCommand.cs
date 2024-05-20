using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TinhTrangLamViec.CreateTinhTrangLamViec
{
    public class CreateTinhTrangLamViecCommand : IRequest<string>, ICommand
    {
        public string Name { get; set; }
        public CreateTinhTrangLamViecCommand() { }
        public CreateTinhTrangLamViecCommand(int iD, string name, string nguoiTaoID)
        {
            Name = name;
        }
    }
}
