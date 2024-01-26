using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.DeleteKyLuat
{
    public class DeleteKyLuatCommand : IRequest<bool>,ICommand
    {
        public string Id {  get; set; }
        public DeleteKyLuatCommand() { }
        public DeleteKyLuatCommand(string id) 
        {
            this.Id = id;
        }
    }
}
