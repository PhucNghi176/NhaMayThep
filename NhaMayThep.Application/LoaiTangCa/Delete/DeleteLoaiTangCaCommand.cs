using MediatR;
using NhaMayThep.Application.LoaiTangCa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiTangCa.Delete
{
    public class DeleteLoaiTangCaCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }


        public DeleteLoaiTangCaCommand(int id)
        {
            Id = id;
        }
    }
}
