using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Delete
{
    public class DeleteChiTietNgayNghiPhepCommandHandler : IRequestHandler<DeleteChiTietNgayNghiPhepCommand, ChiTietNgayNghiPhepDto>
    {
        private readonly IChiTietNgayNghiPhepRepository _repo;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public DeleteChiTietNgayNghiPhepCommandHandler(IChiTietNgayNghiPhepRepository repo, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ChiTietNgayNghiPhepDto> Handle(DeleteChiTietNgayNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID không tìm thấy.");
            }
            var entity = await _repo.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException($"ChiTietNgayNghiPhep với ID {request.Id} không tìm thấy.");
            }
            if(entity.NgayXoa != null)
            {
                throw new NotFoundException("Id này đã xóa rồi ");
            }

            entity.NguoiXoaID = userId;
            entity.NgayXoa = DateTime.Now;

            _repo.Update(entity);
            await _repo.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ChiTietNgayNghiPhepDto>(entity);
        }
    }
}
