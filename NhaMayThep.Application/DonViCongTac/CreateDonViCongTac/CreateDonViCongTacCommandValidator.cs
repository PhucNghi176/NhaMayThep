using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DonViCongTac.CreateDonViCongTac
{
    public class CreateDonViCongTacCommandValidator : AbstractValidator<CreateDonViCongTacCommand>
    {
        public CreateDonViCongTacCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Tên không được để trống.");

        }
    }
}
