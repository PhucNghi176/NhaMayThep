using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;


namespace NhaMayThep.Application.NghiPhep.Delete
{
    public class DeleteNghiPhepCommand : IRequest<string>, ICommand
    {
        public DeleteNghiPhepCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
