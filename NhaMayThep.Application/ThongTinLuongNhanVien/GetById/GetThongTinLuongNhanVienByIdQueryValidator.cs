using FluentValidation;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.GetById
{
    public class GetThongTinLuongNhanVienByIdQueryValidator : AbstractValidator<GetThongTinLuongNhanVienByIdQuery>
    {
        public GetThongTinLuongNhanVienByIdQueryValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Id không được để trống.");
        }
    }
}
