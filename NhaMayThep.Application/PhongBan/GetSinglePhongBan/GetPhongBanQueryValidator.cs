using FluentValidation;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhongBan.GetSinglePhongBan
{
    public class GetPhongBanQueryValidator : AbstractValidator<GetPhongBanQuery>
    {
        IPhongBanRepository _phongBanRepository;
        public GetPhongBanQueryValidator(IPhongBanRepository phongBanRepository)
        {
            _phongBanRepository = phongBanRepository;
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ID)
                .NotNull().WithMessage("ID is require")
                .Must(ExistID).WithMessage("Phong Ban is not exist");
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
