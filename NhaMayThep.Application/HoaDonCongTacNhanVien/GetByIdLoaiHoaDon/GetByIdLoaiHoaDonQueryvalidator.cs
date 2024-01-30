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
            RuleFor(query => query.idLoaiHoaDon)
             .GreaterThanOrEqualTo(0).WithMessage("IdLoaiHoaDon phải là số không âm");

            RuleFor(query => query.year)
                .Must((query, year) => year <= DateTime.Now.Year).WithMessage("Năm phải lớn hơn hoặc bằng năm hiện tại")
                .When(query => query.year > 0);

            RuleFor(query => query.month)
                .Must((query, month) => month >= 1 && month <= 12).WithMessage("Tháng phải từ 1 đến 12")
                .When(query => query.month > 0);
        }
    }
}