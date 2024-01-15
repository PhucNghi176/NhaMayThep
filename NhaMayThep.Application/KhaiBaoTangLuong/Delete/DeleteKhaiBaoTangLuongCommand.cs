using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Delete
{
    public class DeleteKhaiBaoTangLuongCommand : IRequest<KhaiBaoTangLuongDto>, ICommand
    {
        public DeleteKhaiBaoTangLuongCommand(Guid Id)
        {
            this.Id = Id.ToString();
        }
        public string Id { get; set; }
    }
}
