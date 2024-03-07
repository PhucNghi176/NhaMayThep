using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;

namespace NhaMayThep.Application.DangKiCaLam.CheckIn
{
    public class CheckInCommand : IRequest<string>,ICommand
    {
        public string Id { get; set; }
        
    }
}
