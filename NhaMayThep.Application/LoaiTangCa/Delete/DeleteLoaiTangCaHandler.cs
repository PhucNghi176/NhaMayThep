using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiTangCa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiTangCa.Delete
{
    public class DeleteLoaiTangCaHandler : IRequestHandler<DeleteLoaiTangCaCommand, LoaiTangCaDto>
    {
        private readonly ILoaiTangCaRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteLoaiTangCaHandler(ILoaiTangCaRepository repository, IMapper mapper, INhanVienRepository hanVienRepository, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _nhanVienRepository = hanVienRepository;
            _currentUserService = currentUserService;
        }

        public async Task<LoaiTangCaDto> Handle(DeleteLoaiTangCaCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID not found.");
            }

            var loaiTangCa = await _repository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (loaiTangCa == null)
            {
                throw new NotFoundException("LoaiTangCa not found for deletion");
            }
            if (loaiTangCa.NgayXoa != null)
            {
                throw new InvalidOperationException("This id has been deleted");
            }
            // Soft delete: Set NguoiXoaID and NgayXoa
            loaiTangCa.NguoiXoaID = userId;
            loaiTangCa.NgayXoa = DateTime.UtcNow;

            _repository.Update(loaiTangCa);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return loaiTangCa.MapToLoaiTangCaDto(_mapper);
        }
    }
}
