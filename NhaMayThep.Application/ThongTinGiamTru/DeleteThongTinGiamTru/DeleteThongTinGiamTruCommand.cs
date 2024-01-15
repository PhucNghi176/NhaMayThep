using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.DeleteThongTinGiamTru
{
    public class DeleteThongTinGiamTruCommand : IRequest<ThongTinGiamTruDTO>,ICommand
    {
        public int Id { get; set; }
        public DeleteThongTinGiamTruCommand(int id)
        {
            Id = id;
        }
    }
}
