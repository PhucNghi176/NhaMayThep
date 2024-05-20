using FluentValidation;

namespace NhaMayThep.Application.ThongTinChucVuDang.CreateThongTinChucVuDang
{
    public class CreateThongTinChucVuDangCommandValidator : AbstractValidator<CreateThongTinChucVuDangCommand>
    {
        public CreateThongTinChucVuDangCommandValidator()
        {
            RuleFor(x => x.TenChucVuDang)
                .NotEmpty().WithMessage("Tên chức vụ đảng không được để trống.")
                .NotNull().WithMessage("Tên chức vụ đảng không được để rỗng.");
        }
    }
}
