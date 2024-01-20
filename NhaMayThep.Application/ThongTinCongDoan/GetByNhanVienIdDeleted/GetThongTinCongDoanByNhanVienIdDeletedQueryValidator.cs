﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.GetByNhanVienIdDeleted
{
    public class GetThongTinCongDoanByNhanVienIdDeletedQueryValidator: AbstractValidator<GetThongTinCongDoanByNhanVienIdDeletedQuery>
    {
        public GetThongTinCongDoanByNhanVienIdDeletedQueryValidator()
        {
            RuleFor(x => x.Id)
               .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("Mã nhân viên không đúng định dạng");
        }
    }
}