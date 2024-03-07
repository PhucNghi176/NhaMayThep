using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVuDang.UpdateThongTinChucVuDang
{
    public class UpdateThongTinChucVuDangCommandValidator : AbstractValidator<UpdateThongTinChucVuDangCommand>
    {
        public UpdateThongTinChucVuDangCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã thông tin chức vụ đảng không được để trống")
                .NotNull().WithMessage("Mã thông tin chức vụ đảng không được rỗng");
            RuleFor(x => x.TenChucVuDang)
                .NotEmpty().WithMessage("Tên chức vụ đảng không được để trống")
                .NotNull().WithMessage("Tên chức vụ đảng không được rỗng");
            RuleFor(x => x.ChucVuDang)
                .NotEmpty().WithMessage("Thông tin chức vụ đảng không được để trống")
                .NotNull().WithMessage("Thông tin chức vụ đảng không được rỗng");
        }
    }
}
