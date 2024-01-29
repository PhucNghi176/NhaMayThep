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
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILoaiNghiPhepRepository _loaiNghiPhepRepo;

        public CreateLichSuNghiPhepCommandHandler(IMapper mapper, ICurrentUserService currentUserService, ILichSuNghiPhepRepository repository, INhanVienRepository nhanVienRepository, ILoaiNghiPhepRepository loaiNghiPhepRepo)
        {
            _mapper = mapper;
            _repository = repository;
            _nhanVienRepository = nhanVienRepository;
            _loaiNghiPhepRepo = loaiNghiPhepRepo;
            _currentUserService = currentUserService;
        }

        public async Task<LichSuNghiPhepDto> Handle(CreateLichSuNghiPhepCommand request, CancellationToken cancellationToken)
        {
            // Validate LoaiNghiPhepID
            var loaiNghiPhepExists = await _loaiNghiPhepRepo.AnyAsync(x => x.ID == request.LoaiNghiPhepID, cancellationToken);
            if (!loaiNghiPhepExists)
            {
                throw new NotFoundException("LoaiNghiPhepId không tồn tại.");
            }

            // Validate MaSoNhanVien
            var nhanVien = await _nhanVienRepository.FindAnyAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);
            if (nhanVien == null || nhanVien.NgayXoa != null)
            {
                throw new NotFoundException("Nhan Vien không tồn tại hoặc đã bị xóa.");
            }

            // Validate NguoiDuyet
            var nhanvien2 = await _nhanVienRepository.FindAnyAsync(x => x.ID == request.NguoiDuyet && x.NgayXoa == null, cancellationToken);
            if (nhanvien2 == null)
            {
                throw new NotFoundException("Nguoi Duyet không tồn tại hoặc đã bị xóa.");
            }
            if(nhanVien.NgayXoa != null)
            {
                throw new NotFoundException("This user has been deleted");
            }
           

            var lsnp = new LichSuNghiPhepNhanVienEntity
            {
                NguoiTaoID = _currentUserService.UserId,
                MaSoNhanVien = request.MaSoNhanVien,
                LoaiNghiPhepID = request.LoaiNghiPhepID,
                NgayBatDau = request.NgayBatDau,
                NgayKetThuc = request.NgayKetThuc,
                LyDo = request.LyDo,
                NguoiDuyet = request.NguoiDuyet
            };

            _repository.Add(lsnp);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<LichSuNghiPhepDto>(lsnp);
        }
    }
}
