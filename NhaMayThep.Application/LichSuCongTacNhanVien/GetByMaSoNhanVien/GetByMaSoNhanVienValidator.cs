using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.GetByMaSoNhanVien
{
    public class GetByMaSoNhanVienValidator : AbstractValidator<GetByMaSoNhanVienQuery>
    {
        public GetByMaSoNhanVienValidator()
        {
            RuleFor(command => command.MaSoNhanVien).NotEmpty().WithMessage("Mã số nhân viên không được trống");
        }
    }
}
