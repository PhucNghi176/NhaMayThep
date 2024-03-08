using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CapBacLuong.DeleteCapBacLuong
{
    public class DeleteCapBacLuongCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }
        public DeleteCapBacLuongCommand(int id)
        {
            Id = id;
        }
    }
}
