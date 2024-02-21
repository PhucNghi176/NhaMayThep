using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThueSuat.DeleteThueSuat
{
    public class DeleteThueSuatCommand : IRequest<string>, ICommand
    {
        public int ID { get; set; }
        public DeleteThueSuatCommand(int iD)
        {
            ID = iD;
        }
        public DeleteThueSuatCommand() { }
    }
}
