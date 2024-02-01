using FluentValidation;
using NhaMayThep.Application.ThongTinCongDoan.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.GetAllDeleted
{
    public class GetAllThongTinCongDoanDeletedQueryValidator : AbstractValidator<GetAllThongTinCongDoanDeletedQuery>
    {
        public GetAllThongTinCongDoanDeletedQueryValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.PageSize).NotEmpty()
                .NotNull()
                .WithMessage("PageSize không được null hoặc để trống");

            RuleFor(x => x.PageNumber).NotEmpty()
                .NotNull()
                .WithMessage("PageNumber không được null hoặc để trống");
        }
    }
}
