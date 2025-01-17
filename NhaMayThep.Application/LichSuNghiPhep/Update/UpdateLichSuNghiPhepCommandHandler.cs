﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LichSuNghiPhep.Update;
public class UpdateLichSuNghiPhepCommandHandler : IRequestHandler<UpdateLichSuNghiPhepCommand, LichSuNghiPhepDto>
{
    private readonly ILichSuNghiPhepRepository _repo;
    private readonly IMapper _mapper;
    private readonly INhanVienRepository _nhanVienRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly ILoaiNghiPhepRepository _loaiNghiPhepRepo;

    public UpdateLichSuNghiPhepCommandHandler(ICurrentUserService currentUserService, ILoaiNghiPhepRepository loaiNghiPhepRepository, ILichSuNghiPhepRepository repo, IMapper mapper, INhanVienRepository nhanVienRepository)
    {
        _repo = repo;
        _mapper = mapper;
        _nhanVienRepository = nhanVienRepository;
        _currentUserService = currentUserService;
        _loaiNghiPhepRepo = loaiNghiPhepRepository;
    }

    public async Task<LichSuNghiPhepDto> Handle(UpdateLichSuNghiPhepCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        if (string.IsNullOrEmpty(userId))
        {
            throw new UnauthorizedAccessException("User ID không tìm thấy .");
        }

        // Validation for LoaiNghiPhepID
        var loaiNghiPhepExists = await _loaiNghiPhepRepo.AnyAsync(x => x.ID == request.LoaiNghiPhepID, cancellationToken);
        if (!loaiNghiPhepExists)
        {
            throw new NotFoundException("LoaiNghiPhepId không tồn tại .");
        }

        // Validation for MaSoNhanVien
        var existingNhanVien = await _nhanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);
        if (existingNhanVien == null || existingNhanVien.NgayXoa != null)
        {
            throw new NotFoundException("This NhanVien không tồn tại hoặc đã xóa.");
        }

        // Validation for NguoiDuyet
        var existingNhanVien2 = await _nhanVienRepository.FindAsync(x => x.ID == request.NguoiDuyet, cancellationToken);
        if (existingNhanVien2 == null || existingNhanVien2.NgayXoa != null)
        {
            throw new NotFoundException("Nguoi Duyet không tồn tại hoặc đã xóa.");
        }

        // Check if LichSuNghiPhep exists
        var existingLsnp = await _repo.FindAsync(x => x.ID == request.Id, cancellationToken);
        if (existingLsnp == null || existingLsnp.NgayXoa != null)
        {
            throw new NotFoundException("LichSuNghiPhep không tồn tại hoặc đã xóa.");
        }

        // Update properties
        existingLsnp.NguoiCapNhatID = userId;
        existingLsnp.LoaiNghiPhepID = request.LoaiNghiPhepID;
        existingLsnp.NgayBatDau = request.NgayBatDau;
        existingLsnp.NgayKetThuc = request.NgayKetThuc;
        existingLsnp.LyDo = request.LyDo;
        existingLsnp.NguoiDuyet = request.NguoiDuyet;
        existingLsnp.NgayCapNhatCuoi = DateTime.UtcNow;

        _repo.Update(existingLsnp);
        await _repo.UnitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<LichSuNghiPhepDto>(existingLsnp);
    }
}
