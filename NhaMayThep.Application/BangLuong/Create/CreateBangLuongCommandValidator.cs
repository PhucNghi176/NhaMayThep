using FluentValidation;

namespace NhaMayThep.Application.BangLuong.Create
{
    public class CreateBangLuongCommandValidator : AbstractValidator<CreateBangLuongCommand>
    {
        public CreateBangLuongCommandValidator()
        {
            RuleFor(x => x.MaSoNhanVien)
                .NotNull().WithMessage("MaSoNhanVien không được để trống.");

            RuleFor(x => x.NgayKhaiBao)
                .NotNull().WithMessage("NgayKhaiBao không được để trống.")
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("NgayKhaiBao lớn hơn hoặc bằng thời điểm hiện tại."); ;

            RuleFor(x => x.LuongNghiPhep)
                .NotNull().WithMessage("LuongNghiPhep không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("LuongNghiPhep phải lớn hoặc bằng 0");

            RuleFor(x => x.LuongTangCa)
                .NotNull().WithMessage("LuongTangCa không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("LuongTangCa phải lớn 0");


            RuleFor(x => x.LuongCoBan)
                .NotNull().WithMessage("LuongCoBan không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("LuongCoBan phải lớn hoặc bằng 0");



            RuleFor(x => x.TongNhanCoDinh)
                .NotNull().WithMessage("TongNhanCoDinh không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("TongNhanCoDinh phải lớn 0");

            RuleFor(x => x.NgayCong)
                .NotNull().WithMessage("NgayCong không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("NgayCong phải lớn 0");

            RuleFor(x => x.TongThuNhap)
                .NotNull().WithMessage("TongThuNhap không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("TongThuNhap phải lớn 0");

            RuleFor(x => x.LuongDongBH)
                .NotNull().WithMessage("LuongDongBH không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("LuongDongBH phải lớn 0");



            RuleFor(x => x.TongBaoHiem)
                .NotNull().WithMessage("TongBaoHiem không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("TongBaoHiem phải lớn 0");

            RuleFor(x => x.PhuCapCongDoanID)
                .NotNull().WithMessage("PhuCapCongDoanID không được để trống.");

            RuleFor(x => x.GiamTruNhanVienID)
                .NotNull().WithMessage("GiamTruNhanVienID không được để trống.");

            RuleFor(x => x.TamUng)
                .NotNull().WithMessage("TamUng không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("TamUng phải lớn 0");

            RuleFor(x => x.LuongThucLanh)
                .NotNull().WithMessage("LuongThucLanh không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("LuongThucLanh phải lớn 0");
        }
    }
}
