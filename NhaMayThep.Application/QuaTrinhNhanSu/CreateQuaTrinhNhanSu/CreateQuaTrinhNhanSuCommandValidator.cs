using FluentValidation;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.QuaTrinhNhanSu.CreateQuaTrinhNhanSu
{
    public class CreateQuaTrinhNhanSuCommandValidator : AbstractValidator<CreateQuaTrinhNhanSuCommand>
    {
        IQuaTrinhNhanSuRepository _quaTrinhNhanSuRepository;
        IChucVuRepository _chucVuRepository;
        IChucDanhRepository _chucDanhRepository;
        IThongTinQuaTrinhNhanSuRepository _thongTinQuaTrinhNhanSu;
        IPhongBanRepository _phongBanRepository;
        INhanVienRepository _nhanVienRepository;
        public CreateQuaTrinhNhanSuCommandValidator(IQuaTrinhNhanSuRepository quaTrinhNhanSuRepository
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

            RuleFor(v => v.MaSoNhanVien)
                .NotEmpty().WithMessage("MaSoNhanVien is not null or empty")
                .Must(ExistNhanVien).WithMessage("MaSoNhanVien is not exist");

            RuleFor(v => v.NgayBatDau)
                .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("NgayBatDau is not available");

            RuleFor(v => v.NgayKetThuc)
                .GreaterThan(x => x.NgayBatDau).WithMessage("NgayKetThuc can't end before NgayBatDau");
        }

        private bool ExistNhanVien(string maSo)
        {
            var nhanVien = _nhanVienRepository.FindAsync(x => x.ID == maSo).Result;
            return nhanVien == null ? false : true;
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
