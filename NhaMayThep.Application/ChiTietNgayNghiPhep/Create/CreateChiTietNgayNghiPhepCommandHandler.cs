﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Create
{
    public class CreateChiTietNgayNghiPhepCommandHandler : IRequestHandler<CreateChiTietNgayNghiPhepCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IChiTietNgayNghiPhepRepository _repository;
        private readonly INhanVienRepository _hanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILoaiNghiPhepRepository _loaiNghiPhepRepo;
        public CreateChiTietNgayNghiPhepCommandHandler(IMapper mapper, IChiTietNgayNghiPhepRepository repository, INhanVienRepository hanVienRepository, ICurrentUserService currentUserService, ILoaiNghiPhepRepository loaiNghiPhepRepo)
        {
            _mapper = mapper;
            _repository = repository;
            _hanVienRepository = hanVienRepository;
            _currentUserService = currentUserService;
            _loaiNghiPhepRepo = loaiNghiPhepRepo;
        }

        public async Task<string> Handle(CreateChiTietNgayNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID không tìm thấy.");
            }

            var nhanVien = await _hanVienRepository.FindAsync(x => x.ID == request.NhanVienID, cancellationToken);
            if (nhanVien == null)
            {
                throw new NotFoundException("Nhan Vien không tồn tại.");
            }
            if (nhanVien.NgayXoa != null)
            {
                throw new NotFoundException("Không thể tạo ChiTietNgayNghiPhep vì NhanVien này đã bị xóa.");
            }
            var loaiNghiPhepExists = await _loaiNghiPhepRepo.AnyAsync(x => x.ID == request.LoaiNghiPhepID, cancellationToken);
            if (!loaiNghiPhepExists)
            {
                throw new NotFoundException("LoaiNghiPhepId không tồn tại.");
            }
            var ctnp = new ChiTietNgayNghiPhepEntity
            {
                NguoiTaoID = _currentUserService?.UserId,
                MaSoNhanVien = request.NhanVienID,
                LoaiNghiPhepID = request.LoaiNghiPhepID,
                TongSoGio = request.TongSoGio,
                SoGioDaNghiPhep = request.SoGioDaNghiPhep,
                SoGioConLai = request.SoGioConLai,
                NamHieuLuc = request.NamHieuLuc
            };

            _repository.Add(ctnp);
            if (await _repository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Tạo thành công";
            else
                return "Tạo thất bại";
        }
    }
}
