using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.RestoreThongTinCongDoan
{
    public class RestoreThongTinCongDoanCommand : IRequest<ThongTinCongDoanDto>, ICommand
    {
        public RestoreThongTinCongDoanCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
