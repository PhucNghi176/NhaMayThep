﻿using FluentValidation;

namespace NhaMapThep.Application.TrinhDoHocVan.Commands
{
    public class CreateTrinhDoHocVanCommandValidator : AbstractValidator<CreateTrinhDoHocVanCommand>
    {
        public CreateTrinhDoHocVanCommandValidator()
        {
            RuleFor(x => x.TenTrinhDo).NotEmpty().MaximumLength(255);
        }
    }
}