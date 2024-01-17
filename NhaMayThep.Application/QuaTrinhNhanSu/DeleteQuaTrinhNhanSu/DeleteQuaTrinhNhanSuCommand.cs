using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.QuaTrinhNhanSu.DeleteQuaTrinhNhanSu
{
    public class DeleteQuaTrinhNhanSuCommand : IRequest<bool>, ICommand
    {
        public DeleteQuaTrinhNhanSuCommand(string id)
        {
            ID = id;
        }
        public string ID { get; set; }
    }
}
