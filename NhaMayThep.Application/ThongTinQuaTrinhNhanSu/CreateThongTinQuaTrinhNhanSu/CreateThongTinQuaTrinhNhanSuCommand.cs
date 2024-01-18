using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.CreateThongTinQuaTrinhNhanSu
{
    public class CreateThongTinQuaTrinhNhanSuCommand : IRequest<string>, ICommand
    {
        public CreateThongTinQuaTrinhNhanSuCommand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
