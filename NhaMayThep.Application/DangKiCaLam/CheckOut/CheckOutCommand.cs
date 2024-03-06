using MediatR;
using System;

namespace NhaMayThep.Application.DangKiCaLam.CheckOut
{
    public class CheckOutCommand : IRequest<DangKiCaLamDto>
    {
        public string Id { get; set; }
    }
}
