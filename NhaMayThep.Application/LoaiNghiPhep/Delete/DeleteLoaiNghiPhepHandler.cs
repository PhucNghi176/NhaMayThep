using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.Delete
{
    public class DeleteLoaiNghiPhepHandler : IRequestHandler<DeleteLoaiNghiPhepCommand, LoaiNghiPhepDto>
    {
        private readonly ILoaiNghiPhepRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _hanVienRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteLoaiNghiPhepHandler(ILoaiNghiPhepRepository repository, IMapper mapper, INhanVienRepository hanVienRepository, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _hanVienRepository = hanVienRepository;
            _currentUserService = currentUserService;
        }

        public async Task<LoaiNghiPhepDto> Handle(DeleteLoaiNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID not found.");
            }

            var loaiNghiPhep = await _repository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (loaiNghiPhep == null)
            {
                throw new NotFoundException("LoaiNghiPhep not found for deletion");
            }
            if (loaiNghiPhep.NgayXoa != null)
            {
                throw new InvalidOperationException("This id has been deleted");
            }
            // Soft delete: Set NguoiXoaID and NgayXoa
            loaiNghiPhep.NguoiXoaID = userId;
            loaiNghiPhep.NgayXoa = DateTime.UtcNow;

            _repository.Update(loaiNghiPhep);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return loaiNghiPhep.MapToLoaiNghiPhepDto(_mapper);
        }
    }
}
