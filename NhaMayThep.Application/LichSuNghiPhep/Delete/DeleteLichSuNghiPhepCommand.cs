using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.Delete
{
    public class DeleteLichSuNghiPhepCommand : IRequest<LichSuNghiPhepDto>, ICommand
    {
        public string Id { get; set; }
        public string NguoiXoaID { get; set; }

        public DeleteLichSuNghiPhepCommand(string id)
        {
            Id = id;
        }
    }
}
