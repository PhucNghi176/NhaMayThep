using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongThoiGian.DeleteLuongThoiGian
{
    public class DeleteLuongThoiGianCommandValidator : AbstractValidator<DeleteLuongThoiGianCommand>
    {
        public DeleteLuongThoiGianCommandValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã lương thời gian không được để trống")
                .NotNull().WithMessage("Mã lương thời gian không được rỗng");
        }
    }
}
