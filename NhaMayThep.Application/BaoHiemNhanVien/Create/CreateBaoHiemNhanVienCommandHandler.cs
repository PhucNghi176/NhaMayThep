﻿using AutoMapper;
using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMapThep.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.BaoHiemNhanVien.Create
{
    public class CreateBaoHiemNhanVienCommandHandler : IRequestHandler<CreateBaoHiemNhanVienCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IBaoHiemNhanVienRepository _baoHiemNhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IBaoHiemRepository _baoHiemRepository;

        public CreateBaoHiemNhanVienCommandHandler(ICurrentUserService currentUserService, IMapper mapper, IBaoHiemNhanVienRepository baoHiemNhanVienRepository, INhanVienRepository nhanVienRepository, IBaoHiemRepository baoHiemRepository)
        {
            _mapper = mapper;
            _baoHiemNhanVienRepository = baoHiemNhanVienRepository;
            _currentUserService = currentUserService;
            _nhanVienRepository = nhanVienRepository;
            _baoHiemRepository = baoHiemRepository;
        }

        public async Task<string> Handle(CreateBaoHiemNhanVienCommand request, CancellationToken cancellationToken)
        {
            var existingNhanVien = await _nhanVienRepository.AnyAsync(x => x.ID == request.MaSoNhanVien && x.NgayXoa == null, cancellationToken);
            if (!existingNhanVien)
            {
                return "Thất Bại! Nhân viên không tồn tại.";
            }

            var existingBaoHiem = await _baoHiemRepository.AnyAsync(x => x.ID == request.BaoHiem && x.NgayXoa == null, cancellationToken);
            if (!existingBaoHiem)
            {
                return "Thất Bại! Bảo hiểm không tồn tại.";
            }

            var existingBaoHiemNhanVien = await _baoHiemNhanVienRepository.AnyAsync(x => x.MaSoNhanVien == request.MaSoNhanVien && x.BaoHiem == request.BaoHiem && x.NgayXoa == null, cancellationToken);
            if (existingBaoHiemNhanVien)
            {
                return "Thất Bại! Bảo hiểm đã tồn tại cho nhân viên này.";
            }

            var baoHiemNhanVien = new BaoHiemNhanVienEntity
            {
                MaSoNhanVien = request.MaSoNhanVien,
                BaoHiem = request.BaoHiem,
                NguoiTaoID = _currentUserService.UserId
            };

            _baoHiemNhanVienRepository.Add(baoHiemNhanVien);

            return await _baoHiemNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Thành Công!" : "Thất Bại!";
        }
    }
}