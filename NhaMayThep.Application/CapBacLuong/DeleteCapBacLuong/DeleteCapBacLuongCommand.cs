using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NhaMayThep.Application.CapBacLuong.DeleteCapBacLuong
{
    public class DeleteCapBacLuongCommand : IRequest<string>, Common.Interfaces.ICommand
    {
        public int Id { get; set; }

        public DeleteCapBacLuongCommand(int id) 
        {
            Id = id;
        }
    }
}
