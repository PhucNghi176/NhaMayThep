using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.UpdateKhenThuong
{
    public class UpdateKhenThuongCommandValidator : AbstractValidator<UpdateKhenThuongCommand>
    {
        public UpdateKhenThuongCommandValidator() 
        {
            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().NotNull()
                .WithMessage("Mã số nnhnaan viên không được để trống.");
            RuleFor(x => x.ChinhSachNhanSuID)
                .NotEmpty().NotNull()
                .WithMessage("Chính sách nhân sự không được để trống.");
            RuleFor(x => x.TongThuong)
                .NotEmpty().NotNull()
                .WithMessage("Tổng Thưởng không được để trống.");
        }
    }
}
