using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Delete
{
    public class DeleteChiTietNgayNghiPhepCommandValidator : AbstractValidator<DeleteChiTietNgayNghiPhepCommand>
    {
        public DeleteChiTietNgayNghiPhepCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(command => command.Id)
            .NotEmpty().WithMessage("ID is required for deletion.");

            RuleFor(command => command.NguoiXoaID)
                .NotEmpty().WithMessage("ID of the person performing the deletion is required.");
        }
    }
}
