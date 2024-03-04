using FluentValidation;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.QuaTrinhNhanSu.CreateQuaTrinhNhanSu
{
    public class CreateQuaTrinhNhanSuCommandValidator : AbstractValidator<CreateQuaTrinhNhanSuCommand>
    {
        
        public CreateQuaTrinhNhanSuCommandValidator()
        {
            ConfigureValidationRules();       
        }
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ChucVuID)
                .NotNull().WithMessage("ChucVuId is require");

            RuleFor(v => v.ChucDanhID)
                .NotNull().WithMessage("ChucDanhID is require");

            RuleFor(v => v.LoaiQuaTrinhID)
                .NotNull().WithMessage("LoaiQuaTrinhID is require");

            RuleFor(v => v.PhongBanID)
                .NotNull().WithMessage("PhongBanID is require");

            RuleFor(v => v.MaSoNhanVien)
                .NotEmpty().WithMessage("MaSoNhanVien is not null or empty");

            RuleFor(v => v.NgayBatDau)
                .NotEmpty().WithMessage("NgayBatDau is not null or empty");

            RuleFor(v => v.NgayKetThuc)
                .GreaterThan(x => x.NgayBatDau).WithMessage("NgayKetThuc can't end before NgayBatDau");
        }   
    }
}
