using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DonViCongTac.CreateDonViCongTac
{
    public class CreateDonViCongTacCommand : IRequest<int>, ICommand
    {
        public CreateDonViCongTacCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
