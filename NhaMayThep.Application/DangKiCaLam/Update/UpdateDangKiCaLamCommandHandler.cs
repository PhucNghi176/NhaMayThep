using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.DangKiTangCa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiCaLam.Update
{
    public class UpdateDangKiCaLamCommandHandler : IRequestHandler<UpdateDangKiCaLamCommand, DangKiCaLamDto>
    {
        private readonly IMapper _mapper;
        private readonly IDangKiCaLamRepository _repository;
        private readonly ICurrentUserService _currentUserService;
        private readonly INhanVienRepository _nhanVienRepository;


        public UpdateDangKiCaLamCommandHandler(IMapper mapper, IDangKiCaLamRepository repository, ICurrentUserService currentUserService, INhanVienRepository nhanVienRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _currentUserService = currentUserService;
            _nhanVienRepository = nhanVienRepository;
        }

        public async Task<DangKiCaLamDto> Handle(UpdateDangKiCaLamCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID not found.");
            }


            var nhanVienExists = await _nhanVienRepository.AnyAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);
            if (!nhanVienExists)
            {
                throw new NotFoundException("MaSoNhanVien does not exist or has been deleted.");
            }


            var nguoiDuyetExists = await _nhanVienRepository.AnyAsync(x => x.ID == request.MaSoNguoiQuanLy, cancellationToken);
            if (!nguoiDuyetExists)
            {
                throw new NotFoundException("NguoiDuyet does not exist or has been deleted.");
            }
            var dangKiTangCa = await _repository.FindAsync(x => x.MaCaLamViec == request.MaCaLamViec, cancellationToken);
            if (dangKiTangCa == null)
            {
                throw new NotFoundException("MaCaLamViec does not exist or has been deleted.");
            }

            _mapper.Map(request, dangKiTangCa);
            dangKiTangCa.NguoiCapNhatID = userId;
            dangKiTangCa.NgayCapNhatCuoi = DateTime.UtcNow;

            _repository.Update(dangKiTangCa);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DangKiCaLamDto>(dangKiTangCa);
        }
    }
}
