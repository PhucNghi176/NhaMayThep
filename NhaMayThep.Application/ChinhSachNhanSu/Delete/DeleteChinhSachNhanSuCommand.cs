using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.Delete
{
    public class DeleteChinhSachNhanSuCommand : IRequest<string>, ICommand
    {
        public DeleteChinhSachNhanSuCommand(int id)
        {

            ID = id;
        }
        public int ID { get; set; }
    }
}
