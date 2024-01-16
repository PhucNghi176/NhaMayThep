using FluentValidation;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.CreateThongTinGiamTru
{
    public class CreateThongTinGiamTruCommandValidator : AbstractValidator<ThongTinGiamTruDTO>
    {
        private readonly IThongTinGiamTru _repository;
        private readonly INhanVienRepository _nhanvien;
        public CreateThongTinGiamTruCommandValidator(INhanVienRepository nhanvien,IThongTinGiamTru repository)
        {
            _nhanvien = nhanvien;
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            ConfiguireValidationRules();
        }
        public void ConfiguireValidationRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .MustAsync(async (id, cancellationToken) => await _repository.GetThongTinGiamTruById(id, cancellationToken) != null)
                .WithMessage("ID is not null or ID was exist.");
            RuleFor(x => x.NguoiTaoID)
                .NotNull()
                .MustAsync(async (id, cancellationToken) => await _nhanvien.FindAsync(x => x.NguoiTaoID.Equals(id),cancellationToken) != null)
                .WithMessage("Người tạo không được null hoặc không tồn tại.");
        }
    }
}
