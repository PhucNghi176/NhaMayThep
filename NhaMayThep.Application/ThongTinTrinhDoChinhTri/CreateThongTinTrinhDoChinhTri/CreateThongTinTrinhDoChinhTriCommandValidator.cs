using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri.CreateThongTinTrinhDoChinhTri
{
    public class CreateThongTinTrinhDoChinhTriCommandValidator : AbstractValidator<CreateThongTinTrinhDoChinhTriCommand>
    {
        public CreateThongTinTrinhDoChinhTriCommandValidator()
        {
            RuleFor(x => x.TenTrinhDoChinhTri)
                .NotEmpty().WithMessage("Tên trình độ chính trị không được để trống.")
                .NotNull().WithMessage("Tên trình độ chính trị không được để rỗng.");
            RuleFor(x => x.TrinhDoChinhTri)
                .NotEmpty().WithMessage("Trình độ chính trị không được để trống.")
                .NotNull().WithMessage("Trình độ chính trị không được để rỗng."); ;
        }
    }
}
