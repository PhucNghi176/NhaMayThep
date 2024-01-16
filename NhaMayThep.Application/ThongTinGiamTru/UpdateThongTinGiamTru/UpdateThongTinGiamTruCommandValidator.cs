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
        private readonly IThongTinGiamTru _repository;
        private readonly INhanVienRepository _nhanvien;
        public UpdateThongTinGiamTruCommandValidator(INhanVienRepository nhanvien, IThongTinGiamTru repository) 
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
            RuleFor(x => x.NguoiCapNhatID)
                .NotNull()
                .MustAsync(async (id, cancellationToken) => await _nhanvien.FindAsync(x => x.NguoiCapNhatID.Equals(id), cancellationToken) != null)
                .WithMessage("người cập nhật không được bỏ trống hoặc không tồn tại.");
        }

    }
}
