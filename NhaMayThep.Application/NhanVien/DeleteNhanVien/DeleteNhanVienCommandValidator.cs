using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.DeleteNhanVien
{
    public class DeleteNhanVienCommandValidator : AbstractValidator<DeleteNhanVienCommand>
    {
        public DeleteNhanVienCommandValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.Id).NotEmpty()
                .NotNull()
                .WithMessage("Id nhân viên không được null");
        }
    }
}
