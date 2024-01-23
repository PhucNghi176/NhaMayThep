using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinPhuCap.CreateNewPhuCap
{
    public class CreateNewPhuCapCommand : IRequest<string>, ICommand
    {
        public CreateNewPhuCapCommand(string tenPhuCap, double phanTramPhuCap)
        {
            TenPhuCap = tenPhuCap;
            PhanTramPhuCap = phanTramPhuCap;
        }
        public string TenPhuCap { get; set; }
        public double PhanTramPhuCap { get; set; }
    }
}
