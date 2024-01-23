using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CapBacLuong.UpdateCapBacLuong
{
    public class UpdateCapBacLuongCommand : IRequest<CapbacLuongDto>, Common.Interfaces.ICommand
    {

        public UpdateCapBacLuongCommand(float hesoluong, string name, int id) 
        {
            Id = id;
            Name = name;
            HeSoLuong = hesoluong;
        }
        public int Id { get; set; }

        public string Name { get; set;}
        public float HeSoLuong {  get; set;}
    }
}
