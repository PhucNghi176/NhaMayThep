using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.CapBacLuong.CreateCapBacLuong
{
    public class CreateCapBacLuongCommand : IRequest<string>, Common.Interfaces.ICommand
    {
        public CreateCapBacLuongCommand()
        {
        }
        public CreateCapBacLuongCommand(int id, string name, string nguoitaoid, DateTime ngaytao, string nguoicapnhatid, DateTime ngaycapnhat, string nguoixoaid, DateTime ngayxoa, float hesoluong)
        {
            HeSoLuong = hesoluong;
            Name = name;
        }


        public string Name { get; set; }
        public float HeSoLuong { get; set; }

    }
}
