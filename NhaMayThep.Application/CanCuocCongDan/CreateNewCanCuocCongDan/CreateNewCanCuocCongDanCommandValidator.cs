using FluentValidation;

namespace NhaMayThep.Application.CanCuocCongDan.CreateNewCanCuocCongDan
{
    public class CreateNewCanCuocCongDanCommandValidator : AbstractValidator<CreateNewCanCuocCongDanCommand>
    {
        public CreateNewCanCuocCongDanCommandValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(c => c.CanCuocCongDan)
                .NotEmpty().WithMessage("Căn cước công dân không để trống")
                .Length(12).WithMessage("Căn cước công dân phải 12 số")
                .Must(BeNumeric).WithMessage("Căn cước công dân chỉ được chứa số");
            RuleFor(c => c.NhanVienID)
                .NotEmpty().WithMessage("Mã nhân viên không để trống");
            RuleFor(c => c.HoVaTen)
                .NotEmpty().WithMessage("Họ và tên không để trống");
            RuleFor(c => c.NgaySinh)
                .NotEmpty().WithMessage("Ngày sinh không để trống");
            RuleFor(c => c.NgaySinh)
                   .Must(CheckAge).WithMessage("Ngày sinh không hợp lệ");

            RuleFor(c => c.QueQuan)
                .NotEmpty().WithMessage("Quên quán không để trống");
            RuleFor(c => c.DiaChiThuongTru)
                .NotEmpty().WithMessage("Địa chỉ thường trú không để trống");
            RuleFor(c => c.NgayCap)
               .NotEmpty().WithMessage("Ngày cấp không để trống");
            RuleFor(c => c.NgayCap)
                .LessThanOrEqualTo(DateTime.Now.Date).WithMessage("Ngày cấp không hợp lệ");
            RuleFor(c => c.NoiCap)
               .NotEmpty().WithMessage("Nơi cấp không để trống");
            RuleFor(c => c.TonGiao)
               .NotEmpty().WithMessage("Tôn giáo không để trống");
        }
        private bool BeNumeric(string canCuocCongDan)
        {
            return canCuocCongDan.All(char.IsDigit);
        }
        private bool CheckAge(DateTime ngaySinh)
        {
            DateTime now = DateTime.Now.Date;
            int age = now.Year - ngaySinh.Year;
            if (ngaySinh > now.AddYears(-age))
                age--;
            return age >= 14;
        }
    }
}
