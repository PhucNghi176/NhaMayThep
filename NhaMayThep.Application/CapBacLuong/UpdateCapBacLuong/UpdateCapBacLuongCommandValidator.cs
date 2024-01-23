using FluentValidation;
using NhaMayThep.Application.CapBacLuong.CreateCapBacLuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CapBacLuong.UpdateCapBacLuong
{
    public class UpdateCapBacLuongCommandValidator : AbstractValidator<CreateCapBacLuongCommand>
    {
        public UpdateCapBacLuongCommandValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name không được để trống.")
                .MaximumLength(50).WithMessage("Name không vượt quá 50 kí tự.");

            RuleFor(x => x.HeSoLuong)
                .NotEmpty().WithMessage("Hệ Số Lương không được để trống.")
                .GreaterThanOrEqualTo(1).WithMessage("Hệ số lương phải lớn hơn hoặc bằng 1.");
        }

    }
}
