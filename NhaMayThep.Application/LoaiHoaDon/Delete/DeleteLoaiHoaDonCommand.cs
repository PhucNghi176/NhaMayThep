using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHoaDon.Delete
{
    public class DeleteLoaiHoaDonCommand : IRequest<string>
    {
        public DeleteLoaiHoaDonCommand(int id) 
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
