using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhongBan.CreatePhongBan
{
    public class CreatePhongBanCommand : IRequest<PhongBanDto>, ICommand
    {
        public CreatePhongBanCommand(string name, int id)
        {
            Name = name;
            ID = id;
        }
        public int ID { get; set; }
        public string Name {  get; set; }
    }
}
