using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinPhuCap.UpdatePhuCap
{
    public class UpdatePhuCapCommand : IRequest<string>, ICommand
    {
        public UpdatePhuCapCommand() { }
        public UpdatePhuCapCommand(int id, string tenPhuCap, double phanTramPhuCap)
        {
            Id = id;
            Name = tenPhuCap;
            PhanTramPhuCap = phanTramPhuCap;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double PhanTramPhuCap { get; set; }
    }
}
