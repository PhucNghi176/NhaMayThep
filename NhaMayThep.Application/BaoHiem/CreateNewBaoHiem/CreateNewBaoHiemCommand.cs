using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.BaoHiem.CreateNewBaoHiem
{
    public class CreateNewBaoHiemCommand : IRequest<string>, ICommand
    {
        public string TenLoaiBaoHiem { get; set; }
        public double PhantramKhauTru { get; set; }
        public CreateNewBaoHiemCommand(string tenLoaiBaoHiem, double phantramKhauTru)
        {
            TenLoaiBaoHiem = tenLoaiBaoHiem;
            PhantramKhauTru = phantramKhauTru;
        }
    }
}
