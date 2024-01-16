using FluentValidation;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Create
{
    public class CreateChiTietNgayNghiPhepCommandValidator : AbstractValidator<CreateChiTietNgayNghiPhepCommand>
    {
        public CreateChiTietNgayNghiPhepCommandValidator()
        {
            RuleFor(command => command.MaSoNhanVien)
                .NotEmpty().WithMessage("Employee ID is required.");

            RuleFor(command => command.LoaiNghiPhepID)
                .GreaterThan(0).WithMessage("Leave type ID must be greater than zero.");

            RuleFor(command => command.TongSoGio)
                .GreaterThan(0).WithMessage("Total hours must be greater than zero.");

            RuleFor(command => command.SoGioDaNghiPhep)
                .GreaterThanOrEqualTo(0).WithMessage("Hours already taken cannot be negative.")
                .LessThanOrEqualTo(command => command.TongSoGio).WithMessage("Hours already taken cannot exceed total hours.");

            RuleFor(command => command.SoGioConLai)
                .GreaterThanOrEqualTo(0).WithMessage("Remaining hours cannot be negative.")
                .Must((command, soGioConLai) => soGioConLai <= command.TongSoGio - command.SoGioDaNghiPhep).WithMessage("Remaining hours must be less than or equal to the difference between total hours and hours already taken.");

            RuleFor(command => command.NamHieuLuc)
                .InclusiveBetween(DateTime.Now.Year - 5, DateTime.Now.Year + 5).WithMessage("Effective year must be within a reasonable range from the current year.");
        }
    }
}
