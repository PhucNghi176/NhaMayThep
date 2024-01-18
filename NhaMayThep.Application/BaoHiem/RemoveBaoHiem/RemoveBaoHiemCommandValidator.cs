using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiem.RemoveBaoHiem
{
    public class RemoveBaoHiemCommandValidator : AbstractValidator<RemoveBaoHiemCommand>
    {
        public RemoveBaoHiemCommandValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.Id).NotEmpty()
                .NotNull()
                .WithMessage("Id must not null or empty");
        }
    }
}
