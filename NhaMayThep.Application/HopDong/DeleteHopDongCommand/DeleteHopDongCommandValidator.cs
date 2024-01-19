using FluentValidation;
using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HopDong.DeleteHopDongCommand
{
    public class DeleteHopDongCommandValidator : AbstractValidator<DeleteHopDongCommand>
    {
        public DeleteHopDongCommandValidator()
        {
            Configure();
        }

        public void Configure()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id must not empty");
        }
    }
}
