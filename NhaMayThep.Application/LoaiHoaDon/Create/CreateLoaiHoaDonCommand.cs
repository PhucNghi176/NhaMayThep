using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHoaDon.Create
{
    public class CreateLoaiHoaDonCommand : IRequest<LoaiHoaDonDto>
    {
        public CreateLoaiHoaDonCommand(string name) 
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
