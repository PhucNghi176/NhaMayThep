using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiCaLam.Delete
{
    public class DeleteDangKiCaLamCommandHandler : IRequestHandler<DeleteDangKiCaLamCommand, string>
    {
        private readonly IDangKiCaLamRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public DeleteDangKiCaLamCommandHandler(IDangKiCaLamRepository repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(DeleteDangKiCaLamCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var entity = await _repository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException($"DangKiCaLam with Id {request.Id} không tìm thấy.");
            }

            if (entity.NgayXoa != null)
            {
                throw new NotFoundException("DangKiCaLam này đã bị xóa.");
            }
            entity.NguoiXoaID = userId;
            entity.NgayXoa = DateTime.UtcNow;
            _repository.Update(entity);
            return await _repository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa Đăng Kí Ca Làm thành công" : "Xóa Đăng Kí Ca Làm thất bại";


        }
    }
}
