using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap.CreateNewPhuCap
{
    public class CreateNewPhuCapCommand : IRequest<string>, ICommand
    {
        public CreateNewPhuCapCommand(string tenPhuCap, double phanTramPhuCap)
        {
            TenPhuCap = tenPhuCap;
            PhanTramPhuCap = phanTramPhuCap;
        }
        public string TenPhuCap {  get; set; }
        public double PhanTramPhuCap { get; set; }
    }
}
