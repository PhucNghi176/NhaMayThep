using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.DangKiTangCa.Delete
{
    public class DeleteDangKiTangCaHandler : IRequestHandler<DeleteDangKiTangCaCommand, string>
    {
        private readonly IDangKiTangCaRepository _repo;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public DeleteDangKiTangCaHandler(IDangKiTangCaRepository repo, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repo = repo;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(DeleteDangKiTangCaCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID không tồn tại .");
            }


            var lsnp = await _repo.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (lsnp == null)
            {
                throw new NotFoundException($"DangKiTangCA với Id  {request.Id} không tìm thấy .");
            }

            if (lsnp.NgayXoa != null)
            {
                throw new NotFoundException("DangKiTangCA này đã bị xóa ");
            }
            lsnp.NguoiXoaID = userId;
            lsnp.NgayXoa = DateTime.Now;

            _repo.Update(lsnp);

            return await _repo.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa Đăng Kí Tăng Ca thành công" : "Xóa Đăng Kí Tăng Ca  thất bại";
        }
    }
}
