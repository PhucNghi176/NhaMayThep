using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Delete
{
    public class DeleteKhaiBaoTangLuongCommandHandler : IRequestHandler<DeleteKhaiBaoTangLuongCommand, string>
    {
        private IKhaiBaoTangLuongRepository _KhaiBaoTangLuongRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public DeleteKhaiBaoTangLuongCommandHandler(IKhaiBaoTangLuongRepository KhaiBaoTangLuongRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _KhaiBaoTangLuongRepository = KhaiBaoTangLuongRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteKhaiBaoTangLuongCommand request, CancellationToken cancellationToken)
        {
            var KhaiBaoTangLuong = await this._KhaiBaoTangLuongRepository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (KhaiBaoTangLuong == null)
                return $"Không tìm thấy mục Khai Báo Tăng Lương với ID : {request.ID} hoặc mục này đã bị xóa.";

            KhaiBaoTangLuong.NguoiXoaID = _currentUserService.UserId;
            KhaiBaoTangLuong.NgayXoa = DateTime.Now;

            _KhaiBaoTangLuongRepository.Update(KhaiBaoTangLuong);
            return await _KhaiBaoTangLuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa Khai Báo Tăng Lương thành công" : "Xóa Khai Báo Tăng Lương thất bại";
        }
    }
}