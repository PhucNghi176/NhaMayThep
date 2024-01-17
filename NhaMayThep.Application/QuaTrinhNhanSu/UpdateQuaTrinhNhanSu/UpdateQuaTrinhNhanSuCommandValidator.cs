using FluentValidation;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.QuaTrinhNhanSu.UpdateQuaTrinhNhanSu
{
    public class UpdateQuaTrinhNhanSuCommandValidator : AbstractValidator<UpdateQuaTrinhNhanSuCommand>
    {
        IQuaTrinhNhanSuRepository _quaTrinhNhanSuRepository;
        IChucVuRepository _chucVuRepository;
        IChucDanhRepository _chucDanhRepository;
        IThongTinQuaTrinhNhanSuRepository _thongTinQuaTrinhNhanSu;
        IPhongBanRepository _phongBanRepository;
        INhanVienRepository _nhanVienRepository;
        public UpdateQuaTrinhNhanSuCommandValidator(IQuaTrinhNhanSuRepository quaTrinhNhanSuRepository
            , IChucVuRepository chucVuRepository
            , IChucDanhRepository chucDanhRepository
            , IThongTinQuaTrinhNhanSuRepository thongTinQuaTrinhNhanSuRepository
            , IPhongBanRepository phongBanRepository
            , INhanVienRepository nhanVienRepository)
        {
            _nhanVienRepository = nhanVienRepository;
            _phongBanRepository = phongBanRepository;
            _chucVuRepository = chucVuRepository;
            _quaTrinhNhanSuRepository = quaTrinhNhanSuRepository;
            _chucDanhRepository = chucDanhRepository;
            _thongTinQuaTrinhNhanSu = thongTinQuaTrinhNhanSuRepository;
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ID)
                .NotEmpty().WithMessage("ID is require")
                .Must(ExistID).WithMessage("ID is not exist");

            RuleFor(v => v.ChucVuID)
                .NotNull().WithMessage("ChucVuId is require")
                .Must(ExistChuVu).WithMessage("ChucVuId is not exist");

            RuleFor(v => v.ChucDanhID)
                .NotNull().WithMessage("ChucDanhID is require")
                .Must(ExistChucDanh).WithMessage("ChucDanhID is not exist");

            RuleFor(v => v.LoaiQuaTrinhID)
                .NotNull().WithMessage("LoaiQuaTrinhID is require")
                .Must(ExistLoaiQuaTrinh).WithMessage("LoaiQuaTrinhID is not exist");

            RuleFor(v => v.PhongBanID)
                .NotNull().WithMessage("PhongBanID is require")
                .Must(ExistPhongBan).WithMessage("PhongBanID is not exist");

            RuleFor(v => v.NgayKetThuc)
                .GreaterThan(DateTime.Now).WithMessage("NgayKetThuc is not valid");
        }

        private bool ExistID(string id)
        {
            var quaTrinhNhanSu = _quaTrinhNhanSuRepository.FindAsync(x => x.ID == id).Result;
            return quaTrinhNhanSu == null ? false : true;
        }

        private bool ExistPhongBan(int phongBanId)
        {
            var phongBan = _phongBanRepository.FindAsync(x => x.ID == phongBanId).Result;
            return phongBan == null ? false : true;
        }

        private bool ExistLoaiQuaTrinh(int loaiQuaTrinhID)
        {
            var loaiQuaTrinh = _thongTinQuaTrinhNhanSu.FindAsync(x => x.ID == loaiQuaTrinhID).Result;
            return loaiQuaTrinh == null ? false : true;
        }

        private bool ExistChucDanh(int chucDanhID)
        {
            var chucDanh = _chucDanhRepository.FindAsync(x => x.ID == chucDanhID).Result;
            return chucDanh == null ? false : true;
        }

        private bool ExistChuVu(int chucVuId)
        {
            var chucVu = _chucVuRepository.FindAsync(x => x.ID == chucVuId).Result;
            return chucVu == null ? false : true;
        }
    }
}
