using FluentValidation;

namespace NhaMayThep.Application.LuongCongNhat.Create
{
    public class CreateLuongCongNhatCommandValidator : AbstractValidator<CreateLuongCongNhatCommand>
    {
        public CreateLuongCongNhatCommandValidator()
        {




            RuleFor(x => x.SoGioLam)
                .NotNull().WithMessage("SoGioLam không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("SoGioLam phải lớn 0");

            RuleFor(x => x.Luong1Gio)
                .NotNull().WithMessage("Luong1Gio không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("Luong1Gio phải lớn 0");

            RuleFor(x => x.TongLuong)
                .NotNull().WithMessage("TongLuong không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("TongLuong phải lớn 0");

            RuleFor(x => x.NgayKhaiBao)
                .NotEmpty().WithMessage("Ngày khai báo không được để trống")
                .NotNull().WithMessage("Ngày khai báo không hợp lệ");
        }
    }
}