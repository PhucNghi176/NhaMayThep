using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.GetKhenThuongById
{
    public class GetKhenThuongByIDQueryValidator : AbstractValidator<GetKhenThuongByIDQuery>
    {
        public GetKhenThuongByIDQueryValidator() 
        {
            RuleFor(x => x.ID)
                .NotEmpty().NotNull()
                .WithMessage("ID không được để trống.");
        }
    }
}
