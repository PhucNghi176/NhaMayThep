using MediatR;
using NhaMayThep.Application.LoaiTangCa;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiTangCa.Update
{
    public class UpdateLoaiTangCaCommand : IRequest<LoaiTangCaDto>, ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public UpdateLoaiTangCaCommand()
        {

        }
        public UpdateLoaiTangCaCommand(int id, string name, int sgnp)
        {

            Id = id;
            Name = name;
        }

    }
}
