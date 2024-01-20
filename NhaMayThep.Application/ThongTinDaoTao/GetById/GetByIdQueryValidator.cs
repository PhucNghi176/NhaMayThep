﻿using FluentValidation;
using NhaMayThep.Application.ThongTinDaoTao.GetById;

namespace NhaMayThep.Application.ThongTinDaoTao.GetById
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
        }
    }
}