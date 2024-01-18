using FluentValidation;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.UpdateThongTinGiamTru
{
    public class UpdateThongTinGiamTruCommandValidator : AbstractValidator<UpdateThongTinGiamTruCommand>
    {
        private readonly IThongTinGiamTruRepository _repository;
        private readonly INhanVienRepository _nhanvien;
        public UpdateThongTinGiamTruCommandValidator(INhanVienRepository nhanvien, IThongTinGiamTruRepository repository) 
        {
            _nhanvien = nhanvien;
            _repository = repository;
            ConfigureValidationRules();
        }
        public void ConfigureValidationRules()
        {
            RuleFor(x => x.ID)
                .NotNull()
                .MustAsync(async (id, cancellationToken) => await _repository.GetThongTinGiamTruById(id, cancellationToken) != null)
                .WithMessage("ID is null or not found.");
        }

    }
}
