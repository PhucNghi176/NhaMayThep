using FluentValidation;
using NhaMayThep.Application.LuongSanPham.GetId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
