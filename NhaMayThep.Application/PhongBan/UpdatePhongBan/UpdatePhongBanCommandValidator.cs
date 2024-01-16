using FluentValidation;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhongBan.UpdatePhongBan
{
    public class UpdatePhongBanCommandValidator : AbstractValidator<UpdatePhongBanCommand>
    {
        IPhongBanRepository _phongBanRepository;
        INhanVienRepository _nhanVienRepository;

        public UpdatePhongBanCommandValidator(IPhongBanRepository phongBanRepository, INhanVienRepository nhanVienRepository)
        {
            _nhanVienRepository = nhanVienRepository;
            _phongBanRepository = phongBanRepository;
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ID)
                .NotNull().WithMessage("ID is require")
                .Must(ExistID).WithMessage("Phong Ban is not exist");
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is require")
                .Must(AvailableName).WithMessage("This name is already exist");
            RuleFor(v => v.NguoiCapNhatID)
               .Must(ExistNguoiCapNhat).WithMessage("Nguoi tao is not exist");
        }

        private bool ExistNguoiCapNhat(string id)
        {
            var nguoiCapNhat = _nhanVienRepository.FindAsync(x => x.ID == id).Result;
            if (nguoiCapNhat != null)
            {
                return nguoiCapNhat.NgayXoa == null ? true : false;
            }
            return false;
        }

        private bool AvailableName(string name)
        {
            var phongBan = _phongBanRepository.FindAsync(x => x.Name == name).Result;
            return phongBan == null ? true : false;
        }

        private bool ExistID(int id)
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
