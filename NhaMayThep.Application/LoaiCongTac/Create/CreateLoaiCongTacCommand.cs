using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiCongTac.Create
{
    public class CreateLoaiCongTacCommand : IRequest<string>, ICommand
    {

        public CreateLoaiCongTacCommand(string name) 
        {
            Name = name;
        }
        public string Name { get; set; }

    }
}
