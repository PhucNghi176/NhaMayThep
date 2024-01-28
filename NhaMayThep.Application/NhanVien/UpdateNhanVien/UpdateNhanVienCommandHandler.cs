using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.UpdateNhanVien
{
    public class UpdateNhanVienCommandHandler : IRequestHandler<UpdateNhanVienCommand, string>
    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateNhanVienCommandHandler(INhanVienRepository nhanVienRepository, ICurrentUserService currentUserService)
        {
            _nhanVienRepository = nhanVienRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateNhanVienCommand command, CancellationToken cancellationToken)
        {
            var found = await _nhanVienRepository.FindAsync(x => x.ID == command.Id && x.NgayXoa == null, cancellationToken);
            if (found == null)
                throw new NotFoundException("Mã số nhân viên không tồn tại");
            found.Email = command.Email;
            found.HoVaTen = command.HoVaTen;
            found.ChucVuID = command.ChucVuID ?? found.ChucVuID;
            found.TinhTrangLamViecID = command.TinhTrangLamViecID;
            found.NgayVaoCongTy = command.NgayVaoCongTy;
            found.DiaChiLienLac = command.DiaChiLienLac;
            found.SoDienThoaiLienLac = command.SoDienThoaiLienLac;
            found.MaSoThue = command.MaSoThue;
            found.TenNganHang = command.TenNganHang;
            found.SoTaiKhoan = command.SoTaiKhoan;
            found.NguoiCapNhatID = _currentUserService.UserId;
            found.NgayCapNhatCuoi = DateTime.Now;
            _nhanVienRepository.Update(found);
            if (await _nhanVienRepository.UnitOfWork.SaveChangesAsync() > 0)
                return "Cập nhật thành công";
            else
                return "Cập nhật thất bại";
        }
    }
}
