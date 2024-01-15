using FluentValidation;
using NhaMayThep.Application.LichSuNghiPhep.Update;

public class UpdateLSNPValidator : AbstractValidator<UpdateLSNPCommand>
{
    public UpdateLSNPValidator()
    {
        // Define validation rules for your properties here
        RuleFor(command => command.MaSoNhanVien)
            .NotEmpty().WithMessage("MaSoNhanVien is required.");

        RuleFor(command => command.LoaiNghiPhepID)
            .GreaterThan(0).WithMessage("LoaiNghiPhepID must be greater than 0.");

        RuleFor(command => command.NgayBatDau)
            .NotEmpty().WithMessage("NgayBatDau is required.")
            .LessThanOrEqualTo(command => command.NgayKetThuc).WithMessage("NgayBatDau must be less than or equal to NgayKetThuc.");

        RuleFor(command => command.LyDo)
            .NotEmpty().WithMessage("LyDo is required.");

        RuleFor(command => command.NguoiDuyet)
            .NotEmpty().WithMessage("NguoiDuyet is required.");
    }
}
