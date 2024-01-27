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
                .GreaterThanOrEqualTo(0).WithMessage("Năm phải là số không âm")
                .When(query => query.year < 0);

            RuleFor(query => query.month)
                .GreaterThanOrEqualTo(0).WithMessage("Tháng phải là số không âm")
                .When(query => query.month < 0);
        }
    }
}
