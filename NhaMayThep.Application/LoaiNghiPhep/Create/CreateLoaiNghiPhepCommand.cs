using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.Create
{
    public class CreateLoaiNghiPhepCommand : IRequest<LoaiNghiPhepDto>, ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SoGioNghiPhep { get; set; }
        public CreateLoaiNghiPhepCommand()
        {

        }

        public CreateLoaiNghiPhepCommand(int id, string name, int soGioNghiPhep)
        {
            Id = id;
            Name = name;
            SoGioNghiPhep = soGioNghiPhep;
        }
    }
}
