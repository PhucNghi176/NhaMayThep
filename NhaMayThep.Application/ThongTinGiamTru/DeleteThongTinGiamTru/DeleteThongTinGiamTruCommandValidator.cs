using FluentValidation;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.DeleteThongTinGiamTru
{
    public class DeleteThongTinGiamTruCommandValidator : AbstractValidator<DeleteThongTinGiamTruCommand>
    {
        public readonly IThongTinGiamTru _repository;
        public readonly INhanVienRepository _nhanvien;
        public DeleteThongTinGiamTruCommandValidator(INhanVienRepository nhanvien,IThongTinGiamTru repository)
        {
            _nhanvien = nhanvien;
            _repository = repository;
            ConfigureValidationRules();
        }
        public void ConfigureValidationRules()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .MustAsync(async (id, cancellationToken) => await _repository.GetThongTinGiamTruById(id, cancellationToken) != null)
                .WithMessage("ID is null or ID is not found");
            RuleFor(x => x.NguoiXoaID)
                .NotNull()
                .MustAsync(async (id, cancellationToken) => await _nhanvien.FindAsync(x => x.NguoiXoaID.Equals(id), cancellationToken) != null)
                .WithMessage("Người xóa không được null hoặc không tồn tại.");
        }
    }
}
