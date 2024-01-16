using FluentValidation;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.Create
{
    public class CreateLichSuNghiPhepValidator : AbstractValidator<CreateLichSuNghiPhepCommand>
    {
        public CreateLichSuNghiPhepValidator()
        {
           
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(cmd => cmd.MaSoNhanVien)
            .NotEmpty().WithMessage("Employee ID is required.");

            RuleFor(cmd => cmd.LoaiNghiPhepID)
                .GreaterThan(0).WithMessage("Leave Type ID must be a valid integer.");

            RuleFor(cmd => cmd.NgayBatDau)
                .NotEmpty().WithMessage("Start Date is required.")
                .GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("Start Date cannot be in the past.");

            RuleFor(cmd => cmd.NgayKetThuc)
                .NotEmpty().WithMessage("End Date is required.")
                .GreaterThanOrEqualTo(cmd => cmd.NgayBatDau).WithMessage("End Date cannot be before the Start Date.");

            RuleFor(cmd => cmd.LyDo)
                .NotEmpty().WithMessage("Reason is required.")
                .MaximumLength(500).WithMessage("Reason cannot be more than 500 characters long.");

            RuleFor(cmd => cmd.NguoiDuyet)
                .NotEmpty().WithMessage("Approver is required.");

        }


    }
}
