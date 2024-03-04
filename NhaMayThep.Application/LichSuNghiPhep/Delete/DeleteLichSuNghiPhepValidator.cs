using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.Delete
{
    public class DeleteLichSuNghiPhepValidator: AbstractValidator<DeleteLichSuNghiPhepCommand>

    {

        public DeleteLichSuNghiPhepValidator()
        {
            ConfigureValidationRules();
        }


        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id không được để trống ");

          
        }
    }
}
