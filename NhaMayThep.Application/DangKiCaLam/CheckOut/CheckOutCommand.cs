using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;

namespace NhaMayThep.Application.DangKiCaLam.CheckOut
{
    public class CheckOutCommand : IRequest<string>,ICommand
    {
        public string Id { get; set; }
    }
}
