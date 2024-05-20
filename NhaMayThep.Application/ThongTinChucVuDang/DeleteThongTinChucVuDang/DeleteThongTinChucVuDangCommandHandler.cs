using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucVuDang.DeleteThongTinChucVuDang
{
    public class DeleteThongTinChucVuDangCommandHandler : IRequestHandler<DeleteThongTinChucVuDangCommand, string>
    {
        private readonly IThongTinChucVuDangRepository _thongTinChucVuDangRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeleteThongTinChucVuDangCommandHandler(IThongTinChucVuDangRepository thongTinChucVuDangRepository, ICurrentUserService currentUserService)
        {
            _thongTinChucVuDangRepository = thongTinChucVuDangRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteThongTinChucVuDangCommand request, CancellationToken cancellationToken)
        {
            var thongTinChucVuDang = await _thongTinChucVuDangRepository
                .FindAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (thongTinChucVuDang == null || (thongTinChucVuDang.NguoiXoaID != null && thongTinChucVuDang.NgayXoa.HasValue))
            {
                throw new NotFoundException("Thông tin chức vụ đảng không tồn tại hoặc đã bị vô hiệu hóa trước đó");
            }
            thongTinChucVuDang.NguoiXoaID = _currentUserService.UserId;
            thongTinChucVuDang.NgayXoa = DateTime.Now;
            _thongTinChucVuDangRepository.Update(thongTinChucVuDang);
            if (await _thongTinChucVuDangRepository.UnitOfWork.SaveChangesAsync() > 0)
                return "Xóa thành công";
            else
                return "Xóa thất bại";
        }
    }
}
