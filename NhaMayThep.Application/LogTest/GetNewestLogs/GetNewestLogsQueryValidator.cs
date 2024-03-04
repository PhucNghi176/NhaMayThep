using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.Logs.GetNewestLogs
{
    public class GetNewestLogsQueryValidator : AbstractValidator<GetNewestLogsQuery>
    {
        public GetNewestLogsQueryValidator()
        {
            RuleFor(x => x.lineCount)
            .NotEmpty().WithMessage("Số dòng không được để trống")
            .NotNull().WithMessage("Số dòng không được để trống")
            .GreaterThan(0).WithMessage("Số dòng phải lớn hơn 0");
        }
    }
}
