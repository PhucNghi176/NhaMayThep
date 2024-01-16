using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap.DeletePhuCap
{
    public class DeletePhuCapCommand :IRequest<string>, ICommand
    {
        public DeletePhuCapCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
