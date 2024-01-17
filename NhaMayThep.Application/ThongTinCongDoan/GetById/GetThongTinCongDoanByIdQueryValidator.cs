﻿using FluentValidation;

namespace NhaMayThep.Application.ThongTinCongDoan.GetById
{
    public class GetThongTinCongDoanByIdQueryValidator : AbstractValidator<GetThongTinCongDoanByIdQuery>
    {
        public GetThongTinCongDoanByIdQueryValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id must not be empty")
               .NotNull().WithMessage("Id must not be null")
               .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("The ID is not correct");
        }
    }
}