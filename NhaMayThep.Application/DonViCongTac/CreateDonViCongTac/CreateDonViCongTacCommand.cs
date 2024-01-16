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
        public CreateDonViCongTacCommand(string name, string nguoiTaoId)
        {
            Name = name;
            NguoiTaoID = nguoiTaoId;

        }

        
        public string Name { get; set; }
        public string? NguoiTaoID { get; set; }
    }
}
