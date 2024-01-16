using MediatR;
using System;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TrinhDoHocVan.Delete
{
    public class DeleteTrinhDoHocVanCommand : IRequest<bool>, ICommand
    {
        public DeleteTrinhDoHocVanCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
