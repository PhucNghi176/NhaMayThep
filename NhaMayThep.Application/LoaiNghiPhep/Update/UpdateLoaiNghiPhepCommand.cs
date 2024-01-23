using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.Update
{
    public class UpdateLoaiNghiPhepCommand : IRequest<LoaiNghiPhepDto>, ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public UpdateLoaiNghiPhepCommand()
        {
            
        }
        public UpdateLoaiNghiPhepCommand(int id, string name, int sgnp)
        {

            Id = id;
            Name = name;
           

        }

    }
}