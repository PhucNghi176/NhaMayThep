using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HopDong.DeleteHopDongCommand
{
    public class DeleteHopDongCommand : IRequest<string>, ICommand
    {
        public DeleteHopDongCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
