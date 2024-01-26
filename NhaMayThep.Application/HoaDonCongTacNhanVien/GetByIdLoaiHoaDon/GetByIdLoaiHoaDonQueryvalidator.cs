using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.GetByIdLoaiHoaDon
{
    public class GetByIdLoaiHoaDonQueryvalidator : AbstractValidator<GetByIdLoaiHoaDonQuery>
    {
        public GetByIdLoaiHoaDonQueryvalidator()
        {
            RuleFor(command => command.idLoaiHoaDon)
                .NotEmpty().WithMessage("idLoaiCongTac không được để trống.");

            RuleFor(command => command.year)
                .NotEmpty().WithMessage("năm không được để trống.")
                .Must(year => year.Length == 4 && int.TryParse(year, out _)).WithMessage("năm bạn nhập không hợp lệ");


            RuleFor(command => command.month)
                .NotEmpty().WithMessage("tháng không được để trống.")
                .Must(month => month >= 1 && month <= 12).WithMessage("tháng phải nằm trong khoảng từ 1 đến 12.");
        }
    }
}
