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
    public class DeleteLoaiNghiPhepHandler : IRequestHandler<DeleteLoaiNghiPhepCommand, string>
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

        public async Task<string> Handle(DeleteLoaiNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID không tìm thấy.");
            }

            var loaiNghiPhep = await _repository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (loaiNghiPhep == null)
            {
                throw new NotFoundException("LoaiNghiPhep không tìm thấy để xóa");
            }
            if (loaiNghiPhep.NgayXoa != null)
            {
                throw new NotFoundException("Id này đã bị xóa rồi");
            }
            // Soft delete: Set NguoiXoaID and NgayXoa
            loaiNghiPhep.NguoiXoaID = userId;
            loaiNghiPhep.NgayXoa = DateTime.UtcNow;

            _repository.Update(loaiNghiPhep);
            if (await _repository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Xóa thành công";
            else
                return "Xóa thất bại";
        }
    }
}
