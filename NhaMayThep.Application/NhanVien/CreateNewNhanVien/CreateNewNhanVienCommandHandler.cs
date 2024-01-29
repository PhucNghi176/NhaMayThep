﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Exceptions;
using System.Net;

namespace NhaMayThep.Application.NhanVien.CreateNewNhanVienCommand
{
    public class CreateNewNhanVienCommandHandler : IRequestHandler<CreateNewNhanVienCommand, string>
    {
        private readonly INhanVienRepository _repository;

        public CreateNewNhanVienCommandHandler(INhanVienRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateNewNhanVienCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _repository.AnyAsync(x => x.Email == request.Email && x.NgayXoa == null);
            if (isExist)
            {

                throw new DuplicationException("Email đã tồn tại");
            }
            isExist = await _repository.AnyAsync(x => x.SoDienThoaiLienLac == request.SoDienThoaiLienLac && x.NgayXoa == null);
            if (isExist)
            {
                throw new DuplicationException("Số điện thoại đã tồn tại");
            }
            isExist = await _repository.AnyAsync(x => x.MaSoThue == request.MaSoThue && x.NgayXoa == null);
            if (isExist)
            {
                throw new DuplicationException("Mã số thuế đã tồn tại");
            }
            isExist = await _repository.AnyAsync(x => x.SoTaiKhoan == request.SoTaiKhoan && x.NgayXoa == null);
            if (isExist)
            {
                throw new DuplicationException("Số tài khoản đã tồn tại");
            }
            var password = _repository.GeneratePassword();
            var nv = new NhanVienEntity
            {
                ChucVuID = request.ChucVuID,
                DiaChiLienLac = request.DiaChiLienLac,
                Email = request.Email,
                HoVaTen = request.HoVaTen,
                MaSoThue = request.MaSoThue,
                NgayVaoCongTy = request.NgayVaoCongTy.Date,
                PasswordHash = _repository.HashPassword(password),
                SoDienThoaiLienLac = request.SoDienThoaiLienLac,
                SoNguoiPhuThuoc = request.SoNguoiPhuThuoc,
                SoTaiKhoan = request.SoTaiKhoan,
                TenNganHang = request.TenNganHang,
                TinhTrangLamViecID = request.TinhTrangLamViecID,
                DaCoHopDong = false
            };
            _repository.Add(nv);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return password;
        }
    }
}
