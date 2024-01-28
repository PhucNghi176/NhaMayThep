using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.UpdateNhanVien
{
    public class UpdateNhanVienCommandValidator : AbstractValidator<UpdateNhanVienCommand>
    {
        public UpdateNhanVienCommandValidator() 
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.Id).NotEmpty()
                .NotNull().WithMessage("Id không hợp lệ");
            RuleFor(x => x.Email).NotEmpty()
                .NotNull().WithMessage("Email không hợp lệ");
            RuleFor(x => x.HoVaTen).NotEmpty()
                .NotNull().WithMessage("Họ và tên không hợp lệ");
            RuleFor(x => x.TinhTrangLamViecID).NotEmpty()
                .NotNull().WithMessage("Tình trạng làm việc không hợp lệ");
            RuleFor(x => x.NgayVaoCongTy).NotEmpty()
                .NotNull().WithMessage("Ngày vào công ty không hợp lệ");
            RuleFor(x => x.DiaChiLienLac).NotEmpty()
                .NotNull().WithMessage("Địa chỉ liên lạc không hợp lệ");
            RuleFor(x => x.SoDienThoaiLienLac).NotEmpty()
                .NotNull().WithMessage("Số điện thoại không hợp lệ");
            RuleFor(x => x.MaSoThue).NotEmpty()
                .NotNull().WithMessage("Mã số thuế không hợp lệ");
            RuleFor(x => x.TenNganHang).NotEmpty()
                .NotNull().WithMessage("Tên ngân hàng không hợp lệ");
            RuleFor(x => x.SoTaiKhoan).NotEmpty()
                .NotNull().WithMessage("Số tài khoản không hợp lệ");
            
        }
    }
}
