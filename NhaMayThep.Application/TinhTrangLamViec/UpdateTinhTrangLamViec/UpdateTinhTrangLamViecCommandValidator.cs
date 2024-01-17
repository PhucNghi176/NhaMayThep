using FluentValidation;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.UpdateTinhTrangLamViec
{
    public class UpdateTinhTrangLamViecCommandValidator : AbstractValidator<UpdateTinhTrangLamViecCommand>
    {
        public UpdateTinhTrangLamViecCommandValidator()
        {
            ConfigureValidationRules();
        }
        public void ConfigureValidationRules()
        {
        }
    }
}
