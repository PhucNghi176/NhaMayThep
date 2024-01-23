using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.Create
{
    public class CreateLichSuNghiPhepCommandHandler : IRequestHandler<CreateLichSuNghiPhepCommand, LichSuNghiPhepDto>
    {
        private readonly IMapper _mapper;
        private readonly ILichSuNghiPhepRepository _repository;
        private readonly INhanVienRepository _hanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILoaiNghiPhepRepository _loaiNghiPhepRepo;

        public CreateLichSuNghiPhepCommandHandler(IMapper mapper, ICurrentUserService currentUserService, ILichSuNghiPhepRepository repository, INhanVienRepository hanVienRepository, ILoaiNghiPhepRepository loaiNghiPhepRepo)
        {
            _mapper = mapper;
            _repository = repository;
            _hanVienRepository = hanVienRepository;
            _loaiNghiPhepRepo = loaiNghiPhepRepo;
            _currentUserService = currentUserService;
        }

        public async Task<LichSuNghiPhepDto> Handle(CreateLichSuNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID not found.");
            }

            // Validate LoaiNghiPhepID
            var loaiNghiPhepExists = await _loaiNghiPhepRepo.AnyAsync(x => x.ID == request.LoaiNghiPhepID, cancellationToken);
            if (!loaiNghiPhepExists)
            {
                throw new NotFoundException("LoaiNghiPhepId provided does not exist.");
            }

            // Validate MaSoNhanVien
            var nhanVien = await _hanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);
            if (nhanVien == null || nhanVien.NgayXoa != null)
            {
                throw new NotFoundException("Nhan Vien does not exist or has been deleted.");
            }

            // Validate NguoiDuyet
            var nhanvien2 = await _hanVienRepository.FindAsync(x => x.ID == request.NguoiDuyet, cancellationToken);
            if (nhanvien2 == null || nhanvien2.NgayXoa != null)
            {
                throw new NotFoundException("Nguoi Duyet does not exist or has been deleted.");
            }

            if (nhanVien.ID == nhanvien2.ID)
            {
                throw new InvalidOperationException("Nguoi Duyet cannot be the same as the requesting employee.");
            }

            var lsnp = new LichSuNghiPhepNhanVienEntity
            {
                NguoiTaoID = userId,
                MaSoNhanVien = request.MaSoNhanVien,
                LoaiNghiPhepID = request.LoaiNghiPhepID,
                NgayBatDau = request.NgayBatDau,
                NgayKetThuc = request.NgayKetThuc,
                LyDo = request.LyDo,
                NguoiDuyet = request.NguoiDuyet
            };

            _repository.Add(lsnp);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return lsnp.MapToLichSuNghiPhepDto(_mapper);
        }
    }
}
