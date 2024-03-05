using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LichSuNghiPhep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiTangCa.Delete
{
    public class DeleteDangKiTangCaCommand : IRequest<DangKiTangCaDto>, ICommand

    {
        public string Id { get; set; }


        public DeleteDangKiTangCaCommand(string id)
        {
            Id = id;
        }
    }
}
