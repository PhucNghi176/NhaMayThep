using FluentValidation;

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
            .NotEmpty().WithMessage("Employee ID phải điền .");

            RuleFor(cmd => cmd.LoaiNghiPhepID)
                .GreaterThan(0).WithMessage("Leave Type ID phải là con số.");

            RuleFor(cmd => cmd.NgayBatDau)
                .NotEmpty().WithMessage("Start Date không được để trống.");

            RuleFor(cmd => cmd.NgayKetThuc)
                .NotEmpty().WithMessage("End Date không được để trống.")
                .GreaterThanOrEqualTo(cmd => cmd.NgayBatDau).WithMessage("End Date không thể trước Start Date.");

            RuleFor(cmd => cmd.LyDo)
                .NotEmpty().WithMessage("Lí do không được để trống .")
                .MaximumLength(500).WithMessage("Lí do không được quá  500 từ.");

            RuleFor(cmd => cmd.NguoiDuyet)
                .NotEmpty().WithMessage("Người duyệt không được để trống.");

        }


    }
}
