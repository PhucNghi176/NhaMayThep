using FluentValidation;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.Delete
{
    public class DeleteBaoHiemNhanVienChiTietBaoHiemCommandValidator : AbstractValidator<DeleteBaoHiemNhanVienChiTietBaoHiemCommand>
    {
        public DeleteBaoHiemNhanVienChiTietBaoHiemCommandValidator()
        {
            RuleFor(x => x.MaBHNV)
                .NotNull()
                .NotEmpty()
                .WithMessage("Mã bảo hiểm nhân viên không thể bỏ trống");
            RuleFor(x => x.MaCTBH)
                .NotNull()
                .NotEmpty()
                .WithMessage("Mã chi tiết bảo hiểm không thể bỏ trống");
        }
    }
}
