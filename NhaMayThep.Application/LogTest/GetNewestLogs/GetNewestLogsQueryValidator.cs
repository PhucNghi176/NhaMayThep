using FluentValidation;

namespace NhaMayThep.Application.LogTest.GetNewestLogs
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
