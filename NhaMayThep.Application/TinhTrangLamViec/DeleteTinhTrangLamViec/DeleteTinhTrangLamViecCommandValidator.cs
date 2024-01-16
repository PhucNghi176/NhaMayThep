using FluentValidation;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.DeleteTinhTrangLamViec
{
    public class DeleteTinhTrangLamViecCommandValidator : AbstractValidator<DeleteTinhTrangLamViecCommand>
    {
        private readonly ITinhTrangLamViec _repository;
        private readonly INhanVienRepository _nhanvien;
        public DeleteTinhTrangLamViecCommandValidator(ITinhTrangLamViec repository, INhanVienRepository nhanvien)
        {
            _repository = repository;
            _nhanvien = nhanvien;
            ConfigureValidationRules();
        }
        public void ConfigureValidationRules()
        {
            RuleFor(x => x.NguoiXoaID)
                .NotNull()
                .MustAsync(async (id, cancellationToken) => await _nhanvien.FindAsync(x => x.NguoiXoaID.Equals(id), cancellationToken) != null)
                .WithMessage("Người xóa không được bỏ trống hoặc không tồn tại.");
        }
    }
}
