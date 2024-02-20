using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HopDong.CreateHopDongWithExcel
{
    public class CreateHopDongWithExcelCommandValidator : AbstractValidator<CreateHopDongWithExcelCommand>
    {
        public CreateHopDongWithExcelCommandValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.Files)
                .NotEmpty()
                .NotNull()
                .WithMessage("Xin vui lòng nhập file");
        }
    }
}
