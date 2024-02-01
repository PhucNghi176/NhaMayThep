using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MucSanPham.Delete
{
    public class DeleteMucSanPhamCommandValidator : AbstractValidator<DeleteMucSanPhamCommand>
    {
        public DeleteMucSanPhamCommandValidator()
        {
            ConfigureValidationRule();
        }

        private void ConfigureValidationRule()
        {
            RuleFor(v => v.ID)
                .NotEmpty().WithMessage("ID không được để trống");
        }
    }
}
