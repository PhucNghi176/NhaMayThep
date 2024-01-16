using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap.UpdatePhuCap
{
    public class UpdatePhuCapCommand : IRequest<PhuCapDto>, ICommand
    {
        public UpdatePhuCapCommand() { }
        public UpdatePhuCapCommand(int id, string tenPhuCap, double phanTramPhuCap)
        {
            Id = id;
            Name = tenPhuCap;
            PhanTramPhuCap = phanTramPhuCap;
        }

        public int Id { get; set; }
        public string Name {  get; set; }
        public double PhanTramPhuCap { get; set; }
    }
}
