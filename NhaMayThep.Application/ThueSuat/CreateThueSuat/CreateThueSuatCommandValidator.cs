using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThueSuat.CreateThueSuat
{
    public class CreateThueSuatCommandValidator : AbstractValidator<CreateThueSuatCommand>
    {
        public CreateThueSuatCommandValidator() 
        {
            RuleFor(x => x.BacThue)
                .NotEmpty().NotNull()
                .WithMessage("Bậc thuế không được để trống");
            RuleFor(x => x.ThuNhapTinhThueTrenThang)
                .NotEmpty().NotNull()
                .WithMessage("Thu nhập tính thuế trên tháng không được để trống");
            RuleFor(x => x.ThuNhapTinhThueTrenNam)
                .NotEmpty().NotNull()
                .WithMessage("Thu nhập tính thuế trên năm không được để trống");
            RuleFor(x => x.PhanTramThueSuat)
                .NotEmpty().NotNull()
                .WithMessage("Phần trăm thuế suất không được để trống");
        }   
    }
}
