using FluentValidation;
using NhaMayThep.Application.ThongTinDangVien.CreateThongTinDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DonViCongTac.UpdateDonViCongTac
{
    public class UpdateDonViCongTacCommandValidator : AbstractValidator<UpdateDonViCongTacCommand>
    {
        public UpdateDonViCongTacCommandValidator()
        {
            RuleFor(x => x.ID)
            .NotEmpty().WithMessage("ID không được để trống.");

            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Tên không được để trống.");

        }
    }
}
