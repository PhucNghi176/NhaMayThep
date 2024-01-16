using FluentValidation;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NhaMayThep.Application.PhongBan.CreatePhongBan
{
    public class CreatePhongBanCommandValidator : AbstractValidator<CreatePhongBanCommand>
    {
        IPhongBanRepository _phongBanRepository;
        INhanVienRepository _nhanVienRepository;
        public CreatePhongBanCommandValidator(IPhongBanRepository phongBanRepository, INhanVienRepository nhanVienRepository)
        {
            _phongBanRepository = phongBanRepository;
            _nhanVienRepository = nhanVienRepository;
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ID)
                .NotNull().WithMessage("ID is require")
                .Must(AvailableID).WithMessage("ID is already exist");

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is require")
                //.MinimumLength(5).WithMessage("Name must be at least 5 character")
                .Must(AvailableName).WithMessage("Phong ban is already exist");

            RuleFor(v => v.NguoiTaoID)
                .Must(ExistNguoiTao).WithMessage("Nguoi tao is not exist");
                
        }

        private bool ExistNguoiTao(string id)
        {
            var nguoiTao = _nhanVienRepository.FindAsync(x => x.ID == id).Result;
            if (nguoiTao != null)
            { 
                return nguoiTao.NgayXoa == null ? true : false;
            }
            return false;
        }

        private bool AvailableID(int id)
        {
            var phongBan = _phongBanRepository.FindAsync(x => x.ID == id).Result;
            return phongBan == null ? true : false;
        }

        private bool AvailableName(string name)
        {
            var phongBan = _phongBanRepository.FindAsync(x => x.Name.Equals(name)).Result;
            return phongBan == null ? true : false;
        }
    }
}
