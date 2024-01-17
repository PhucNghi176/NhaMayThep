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
        private readonly IThongTinGiamTruReposiyory _repository;
        private readonly INhanVienRepository _nhanvien;
        public CreateThongTinGiamTruCommandValidator(INhanVienRepository nhanvien,IThongTinGiamTruReposiyory repository)
        {
            _nhanvien = nhanvien;
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            ConfiguireValidationRules();
        }
        public void ConfiguireValidationRules()
        {
            
        }
    }
}
