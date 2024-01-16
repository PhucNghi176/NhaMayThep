using FluentValidation;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhongBan.DeletePhongBan
{
    public class DeletePhongBanCommandValidator : AbstractValidator<DeletePhongBanCommand>
    {
        IPhongBanRepository _phongBanRepository;
        INhanVienRepository _nhanVienRepository;

        public DeletePhongBanCommandValidator(IPhongBanRepository phongBanRepository, INhanVienRepository nhanVienRepository)
        {
            _nhanVienRepository = nhanVienRepository;
            _phongBanRepository = phongBanRepository;
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ID)
                .NotNull().WithMessage("ID is require")
                .Must(ExistId).WithMessage("ID is not exist");
            RuleFor(v => v.NguoiXoaID)
               .Must(ExistNguoiXoa).WithMessage("Nguoi tao is not exist");
        }
        private bool ExistNguoiXoa(string id)
        {
            var nguoiXoa = _nhanVienRepository.FindAsync(x => x.ID == id).Result;
            if (nguoiXoa != null)
            {
                return nguoiXoa.NgayXoa == null ? true : false;
            }
            return false;
        }

        private bool ExistId(int id)
        {
            var phongBan = _phongBanRepository.FindAsync(x => x.ID == id).Result;
            if (phongBan.NgayXoa != null)
            {
                return false;
            }
            return phongBan == null ? false : true;
        }
    }
}
