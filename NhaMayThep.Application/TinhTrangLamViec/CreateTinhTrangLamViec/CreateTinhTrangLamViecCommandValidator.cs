using FluentValidation;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.CreateTinhTrangLamViec
{
    public class CreateTinhTrangLamViecCommandValidator : AbstractValidator<CreateTinhTrangLamViecCommand>
    {
        public readonly ITinhTrangLamViec _repository;
        public readonly INhanVienRepository _nhanvien;
        public CreateTinhTrangLamViecCommandValidator(INhanVienRepository nhanvien, ITinhTrangLamViec repository)
        {
            _nhanvien = nhanvien;
            _repository = repository;
            ConfigureValidationRules();
        }
        public async void ConfigureValidationRules()
        {
            RuleFor(x => x.NguoiTaoID)
                .NotNull()
                .MustAsync(async (id, cancellationToken) => await _nhanvien.FindAsync(x => x.NguoiTaoID.Equals(id), cancellationToken) != null)
                .WithMessage("Người tạo không được để trống hoặc không tồn tại.");
        }
    }
}
