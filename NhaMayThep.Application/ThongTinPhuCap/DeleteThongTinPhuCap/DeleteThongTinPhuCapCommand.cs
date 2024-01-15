using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap.DeleteThongTinPhuCap
{
    public class DeleteThongTinPhuCapCommand : IRequest<ThongTinPhuCapDTO>,ICommand
    {
        public int Id { get; set; }
        public DeleteThongTinPhuCapCommand(int id) 
        {
            Id = id;
        }
    }
}
