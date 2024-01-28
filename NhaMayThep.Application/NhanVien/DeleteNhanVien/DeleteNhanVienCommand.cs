using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.DeleteNhanVien
{
    public class DeleteNhanVienCommand : IRequest<string>, ICommand
    {
        public string Id { get; set; }
        public DeleteNhanVienCommand(string id)
        {
            Id = id;
        }
    }
}
