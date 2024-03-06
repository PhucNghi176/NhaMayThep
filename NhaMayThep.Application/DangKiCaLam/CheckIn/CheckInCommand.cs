using MediatR;
using System;

namespace NhaMayThep.Application.DangKiCaLam.CheckIn
{
    public class CheckInCommand : IRequest<DangKiCaLamDto>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }
}
