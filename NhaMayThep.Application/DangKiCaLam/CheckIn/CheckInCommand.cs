using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.DangKiCaLam.CheckIn
{
    public class CheckInCommand : IRequest<string>, ICommand
    {
        public string Id { get; set; }

    }
}
