using FluentValidation;

namespace NhaMayThep.Application.LuongSanPham.GetId
{
    public class GetLuongSanPhamByIdQueryValidator : AbstractValidator<GetLuongSanPhamByIdQuery>
    {
        public GetLuongSanPhamByIdQueryValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage("ID is required");
        }
    }
}
