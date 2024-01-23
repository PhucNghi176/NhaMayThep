using MediatR;
using NhaMayThep.Application.LoaiTangCa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiTangCa.Delete
{
    public class DeleteLoaiTangCaCommand : IRequest<LoaiTangCaDto>, ICommand
    {
        public int Id { get; set; }
        public string NguoiXoaID { get; set; }

        public DeleteLoaiTangCaCommand(int id)
        {
            Id = id;
        }
    }
}
