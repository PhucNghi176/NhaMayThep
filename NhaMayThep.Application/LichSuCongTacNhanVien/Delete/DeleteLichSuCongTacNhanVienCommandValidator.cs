using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.Delete
{
    public class DeleteLichSuCongTacNhanVienCommandValidator : AbstractValidator<DeleteLichSuCongTacNhanVienCommand>
    {
        public DeleteLichSuCongTacNhanVienCommandValidator() 
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("ID lịch sử công tác nhân viên không được để trống");
        }
    }
}
