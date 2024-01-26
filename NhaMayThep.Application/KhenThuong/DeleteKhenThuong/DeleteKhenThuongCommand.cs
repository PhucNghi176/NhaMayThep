using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.DeleteKhenThuong
{
    public class DeleteKhenThuongCommand : IRequest<string>, ICommand
    {
        public string ID {  get; set; }
        public DeleteKhenThuongCommand(string iD)
        {
            ID = iD;
        }
        public DeleteKhenThuongCommand() { }
    }
}
