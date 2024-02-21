using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.Create
{
    public class CreateLoaiNghiPhepCommand : IRequest<string>, ICommand
    {

        public string Name { get; set; }

        public CreateLoaiNghiPhepCommand()
        {

        }

        public CreateLoaiNghiPhepCommand(string name)
        {

            Name = name;
        }
    }
}
