using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.CreateNewNhanVienByExcel
{
    public class CreateNewNhanVienByExcelCommandValidator : AbstractValidator<CreateNewNhanVienByExcelCommand>
    {
        public CreateNewNhanVienByExcelCommandValidator() 
        {
            Configure();
        }

        public void Configure()
        {
            RuleFor(x => x.InputFiles).NotEmpty()
                .NotNull()
                .WithMessage("Vui lòng không được để trống các files excel");
        }
    }
}
