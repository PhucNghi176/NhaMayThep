using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap.DeletePhuCap
{
    public class DeletePhuCapCommandValidator : AbstractValidator<DeletePhuCapCommand>
    {
        public DeletePhuCapCommandValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id must not be empty or null");
        }
    }
}
