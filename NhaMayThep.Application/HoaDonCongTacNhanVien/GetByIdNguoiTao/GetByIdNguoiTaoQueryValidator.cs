using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.GetByIdNguoiTao
{
    public class GetByIdNguoiTaoQueryValidator : AbstractValidator<GetByIdNguoiTaoQuery>
    {
        public GetByIdNguoiTaoQueryValidator() 
        {
            RuleFor(command => command.idNguoiTao)
               .NotEmpty().WithMessage("idNguoiTao không được để trống.");
        }
    }
}
