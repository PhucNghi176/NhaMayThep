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
        private readonly INhanVienRepository _nhanvien;
        public UpdateTinhTrangLamViecCommandValidator(INhanVienRepository nhanvien)
        {
            _nhanvien = nhanvien;
            ConfigureValidationRules();
        }
        public void ConfigureValidationRules()
        {
            RuleFor(x => x.NguoiCapNhatID)
                .NotNull()
                .MustAsync(async (id, cancellationToken) => await _nhanvien.FindAsync(x => x.NguoiCapNhatID.Equals(id), cancellationToken) != null)
                .WithMessage("người cập nhật không được null hoặc không tồn tại");
        }
    }
}
