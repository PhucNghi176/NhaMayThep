using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVuDang.CreateThongTinChucVuDang
{
    public class CreateThongTinChucVuDangCommandValidator : AbstractValidator<CreateThongTinChucVuDangCommand>
    {
        public CreateThongTinChucVuDangCommandValidator()
        {
            RuleFor(x => x.TenChucVuDang)
                .NotEmpty().WithMessage("Tên chức vụ đảng không được để trống.")
                .NotNull().WithMessage("Tên chức vụ đảng không được để rỗng.");
            RuleFor(x => x.ChucVuDang)
                .NotEmpty().WithMessage("Chức vụ đảng không được để trống.")
                .NotNull().WithMessage("Chức vụ đảng không được để rỗng."); ;
        }
    }
}
