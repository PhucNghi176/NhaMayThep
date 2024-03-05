using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiTangCa.Update
{
    public class UpdateDangKiTangCaCommandHandler : IRequestHandler<UpdateDangKiTangCaCommand, DangKiTangCaDto>
    {
        private readonly IMapper _mapper;
        private readonly IDangKiTangCaRepository _repository;
        private readonly ICurrentUserService _currentUserService;
        private readonly INhanVienRepository _nhanVienRepository;

        public UpdateDangKiTangCaCommandHandler(INhanVienRepository nhanVienRepository, IMapper mapper, ICurrentUserService currentUserService, IDangKiTangCaRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
            _currentUserService = currentUserService;
            _nhanVienRepository = nhanVienRepository;
        }

        public async Task<DangKiTangCaDto> Handle(UpdateDangKiTangCaCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID not found.");
            }

            // Validate MaSoNhanVien
            var nhanVienExists = await _nhanVienRepository.AnyAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);
            if (!nhanVienExists)
            {
                throw new NotFoundException("MaSoNhanVien does not exist or has been deleted.");
            }

            // Validate NguoiDuyet
            var nguoiDuyetExists = await _nhanVienRepository.AnyAsync(x => x.ID == request.NguoiDuyet, cancellationToken);
            if (!nguoiDuyetExists)
            {
                throw new NotFoundException("NguoiDuyet does not exist or has been deleted.");
            }

            // Validate DangKiTangCa exists
            var dangKiTangCa = await _repository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (dangKiTangCa == null)
            {
                throw new NotFoundException("DangKiTangCa does not exist or has been deleted.");
            }

            // Update entity
            _mapper.Map(request, dangKiTangCa);
            dangKiTangCa.NguoiCapNhatID = userId;
            dangKiTangCa.NgayCapNhatCuoi = DateTime.UtcNow;

            _repository.Update(dangKiTangCa);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DangKiTangCaDto>(dangKiTangCa);
        }
    }
}
