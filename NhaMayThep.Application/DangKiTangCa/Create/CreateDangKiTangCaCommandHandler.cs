﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.DangKiTangCa.Create
{
    public class CreateDangKiTangCaCommandHandler : IRequestHandler<CreateDangKiTangCaCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IDangKiTangCaRepository _repository;
        private readonly ICurrentUserService _currentUserService;
        private readonly INhanVienRepository _nhanVienRepository;

        public CreateDangKiTangCaCommandHandler(IMapper mapper, ICurrentUserService currentUserService, IDangKiTangCaRepository repository, INhanVienRepository nhanVienRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _currentUserService = currentUserService;
            _nhanVienRepository = nhanVienRepository;

        }


        public async Task<string> Handle(CreateDangKiTangCaCommand request, CancellationToken cancellationToken)
        {
            // Validate MaSoNhanVien
            var nhanVien = await _nhanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);
            if (nhanVien == null || nhanVien.NgayXoa != null)
            {
                throw new NotFoundException("Nhan Vien không tồn tại hoặc đã bị xóa.");
            }

            // Validate NguoiDuyet
            var nhanvien2 = await _nhanVienRepository.FindAsync(x => x.ID == request.NguoiDuyet && x.NgayXoa == null, cancellationToken) ?? throw new NotFoundException("Nguoi Duyet không tồn tại hoặc đã bị xóa.");
            var dangKiTangCa = new DangKiTangCaEntity
            {
                MaSoNhanVien = request.MaSoNhanVien,
                NgayLamTangCa = request.NgayLamTangCa,
                CaDangKi = request.CaDangKi,
                LiDoTangCa = request.LiDoTangCa,
                ThoiGianCaLamBatDau = request.ThoiGianCaLamBatDau,
                ThoiGianCaLamKetThuc = request.ThoiGianCaLamKetThuc,
                SoGioTangCa = request.SoGioTangCa,
                HeSoLuongTangCa = request.HeSoLuongTangCa,
                TrangThaiDuyet = request.TrangThaiDuyet,
                NguoiDuyet = request.NguoiDuyet,
                NguoiTaoID = _currentUserService.UserId,
            };

            _repository.Add(dangKiTangCa);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return await _repository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Dang Tang Ca thành công" : "Dang Tang Ca  thất bại";
        }
    }
}
