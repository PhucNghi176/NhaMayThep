using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucDanh.UpdateChucDanh
{
    public class UpdateChucDanhCommandValidator : AbstractValidator<UpdateChucDanhCommand>
    {
        public UpdateChucDanhCommandValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id must not be null or empty");
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Ten chuc danh must not be null or empty");
        }
    }
}
