using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Delete
{
    public class DeleteChiTietNgayNghiPhepCommand : IRequest<string>, ICommand
    {
        public string Id { get; set; }

        public DeleteChiTietNgayNghiPhepCommand(string id)
        {
            Id = id;
        }
    }
}
