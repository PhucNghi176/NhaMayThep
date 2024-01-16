using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVu.CreateNewChucVu
{
    public class CreateNewChucDanhCommandValidator : AbstractValidator<CreateNewChucVuCommand>
    {
        public CreateNewChucDanhCommandValidator()
        {
            Configure();
        }

        public void Configure()
        {
            RuleFor(x => x.TenChucVu).NotEmpty().NotNull().WithMessage("Ten chuc vu must not be null or empty");
        }
    }
}
