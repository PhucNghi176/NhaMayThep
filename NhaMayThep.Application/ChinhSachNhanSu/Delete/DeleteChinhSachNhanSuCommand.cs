using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.Delete
{
    public class DeleteChinhSachNhanSuCommand : IRequest<ChinhSachNhanSuDto>, ICommand
    {
        public int Id { get; set; }

        public DeleteChinhSachNhanSuCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
