using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVuDang.DeleteThongTinChucVuDang
{
    public class DeleteThongTinChucVuDangCommandValidator : AbstractValidator<DeleteThongTinChucVuDangCommand>
    {
        public DeleteThongTinChucVuDangCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã thông tin chức vụ đảng không được để trống")
                .NotNull().WithMessage("Mã thông tin chức vụ đảng không được rỗng");
        }
    }
}
