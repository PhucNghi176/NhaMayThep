using MediatR;
using NhaMapThep.Application.Common.Validation;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Exceptions;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.Admin.AdminAccount.Create
{
    public class CreateAdminAccountCommandHandler : IRequestHandler<CreateAdminAccountCommand, string>
    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;



        public CreateAdminAccountCommandHandler(INhanVienRepository nhanVienRepository, ICurrentUserService currentUserService)
        {
            _nhanVienRepository = nhanVienRepository;
            _currentUserService = currentUserService;

        }

        public async Task<string> Handle(CreateAdminAccountCommand request, CancellationToken cancellationToken)
        {
            var nhanVien = await _nhanVienRepository.FindAsync(_ => _.Email == request.Email && _.NgayXoa == null, cancellationToken);
            if (nhanVien is not null)
            {
                throw new DuplicationException("Email đã tồn tại");
            }
            var acc = new NhanVienEntity
            {
                Email = request.Email,
                PasswordHash = _nhanVienRepository.HashPassword(request.Password),
                HoVaTen = "Admin",
                ChucVuID = 1,
                TinhTrangLamViecID = 1,
                NgayVaoCongTy = DateTime.Now,
                DiaChiLienLac = "Admin",
                SoDienThoaiLienLac = "0000000000",
                MaSoThue = "0000000000",
                TenNganHang = "Admin",
                SoTaiKhoan = "0000000000",
                DaCoHopDong = true,
                NgayTao = DateTime.Now,
                NguoiTaoID = _currentUserService.UserId,

            };
            _nhanVienRepository.Add(acc);


            return await _nhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo thành công" : "Tạo thất bại";



        }
    }
}
