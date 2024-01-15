using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.DeleteThongTinCongDoan
{
    public class DeleteThongTinCongDoanCommand: IRequest<bool> , ICommand
    {
        public DeleteThongTinCongDoanCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
