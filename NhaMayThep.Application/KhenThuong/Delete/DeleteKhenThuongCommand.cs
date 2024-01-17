using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.Delete
{
    public class DeleteKhenThuongCommand : IRequest<KhenThuongDto>, ICommand
    {
        public string Id { get; set; }

        public DeleteKhenThuongCommand(string id)
        {
            Id = id;
        }
    }
}
