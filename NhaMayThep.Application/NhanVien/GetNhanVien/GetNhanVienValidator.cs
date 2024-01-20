using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetNhanVien
{
    public class GetNhanVienValidator : AbstractValidator<GetNhanVienQuery>
    {
        public GetNhanVienValidator()
        {

            //predicate is required and must be a string or and type email
            RuleFor(x => x.Predicate).NotEmpty();



            

        }
    }
}
