using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiNghiPhep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiTangCa.Create
{
    public class CreateLoaiTangCaCommand : IRequest<string>, ICommand
    {

        public string Name { get; set; }

        public CreateLoaiTangCaCommand()
        {

        }

        public CreateLoaiTangCaCommand(string name)
        {
            Name = name;
        }
    }
}