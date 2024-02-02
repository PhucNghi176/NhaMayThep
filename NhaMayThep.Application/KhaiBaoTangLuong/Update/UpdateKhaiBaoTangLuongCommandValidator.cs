using FluentValidation;
using NhaMayThep.Application.KhaiBaoTangLuong.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Update
{
    public class UpdateKhaiBaoTangLuongCommandValidator : AbstractValidator<UpdateKhaiBaoTangLuongCommand>
    {
        public UpdateKhaiBaoTangLuongCommandValidator()
        {



            RuleFor(x => x.PhanTramTang)
                .NotEmpty().WithMessage("PhanTramTang không được để trống.")
                .LessThanOrEqualTo(0).WithMessage("PhanTramTang phải lớn 0");

            RuleFor(x => x.NgayApDung)
                .NotEmpty().WithMessage("NgayApDung không được để trống.");

            RuleFor(x => x.LyDo)
                .NotEmpty().WithMessage("LyDo không được để trống.");
        }
    }
}
