﻿using FluentValidation;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.DeleteThongTinGiamTruGiaCanh
{
    public class DeleteThongTinGiamTruGiaCanhCommandValidator : AbstractValidator<DeleteThongTinGiamTruGiaCanhCommand>
    {
        public DeleteThongTinGiamTruGiaCanhCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id must not be empty")
               .NotNull().WithMessage("Id must not be null")
               .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("The ID is not correct");
        }
    }
}