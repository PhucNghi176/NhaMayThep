using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetHoTenNhanVienByEmail
{
    public class GetHoTenNhanVienByEmailQueryValidator : AbstractValidator<GetHoTenNhanVienByEmailQuery>
    {
        public GetHoTenNhanVienByEmailQueryValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email không được để trống.")
                .EmailAddress().WithMessage("Email không hợp lệ. \n abcxyz@tlq.hhh");
        }
    }
}
