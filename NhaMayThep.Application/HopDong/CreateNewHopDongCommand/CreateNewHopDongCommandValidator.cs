using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HopDong.CreateNewHopDongCommand
{
    public class CreateNewHopDongCommandValidator : AbstractValidator<CreateNewHopDongCommand>  
    {
        public CreateNewHopDongCommandValidator() 
        {
            Configure();
        }

        public void Configure()
        {
            RuleFor(x => x.MaSoNhanVien).NotEmpty().WithMessage("Ma so nhan vien must not empty");
            RuleFor(x => x.LoaiHopDongId).NotEmpty().WithMessage("Loai hop dong must not empty");
            RuleFor(x => x.NgayKyHopDong).NotEmpty().WithMessage("Ngay ky hop dong must not empty");
            RuleFor(x => x.DiaDiemLamViec).NotEmpty().WithMessage("Dia diem lam viec must not empty");
            RuleFor(x => x.BoPhanLamViec).NotEmpty().WithMessage("Bo phan lam viec must not empty");
            RuleFor(x => x.ChucDanhId).NotEmpty().WithMessage("Chuc danh must not empty");
            RuleFor(x => x.ChucVuId).NotEmpty().WithMessage("Chuc vu must not empty");
            RuleFor(x => x.LuongCoBan).NotEmpty().WithMessage("Luong co ban must not empty");
            RuleFor(x => x.HeSoLuongId).NotEmpty().WithMessage("He so luong must not empty");
            RuleFor(x => x.PhuCapId).NotEmpty().WithMessage("Phu cap must not empty");
        }
    }
}
