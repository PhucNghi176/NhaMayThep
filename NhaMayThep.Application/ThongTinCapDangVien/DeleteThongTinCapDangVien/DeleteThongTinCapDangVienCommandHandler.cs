using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCapDangVien.DeleteThongTinCapDangVien
{
    public class DeleteThongTinCapDangVienCommandHandler : IRequestHandler<DeleteThongTinCapDangVienCommand, string>
    {
        private readonly IThongTinCapDangVienRepository _thongTinCapDangVienRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeleteThongTinCapDangVienCommandHandler(IThongTinCapDangVienRepository thongTinCapDangVienRepository, ICurrentUserService currentUserService)
        {
            _thongTinCapDangVienRepository = thongTinCapDangVienRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteThongTinCapDangVienCommand request, CancellationToken cancellationToken)
        {
            var thongTinCapDangVien = await _thongTinCapDangVienRepository
                .FindAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (thongTinCapDangVien == null || (thongTinCapDangVien.NguoiXoaID != null && thongTinCapDangVien.NgayXoa.HasValue))
            {
                throw new NotFoundException("Thông tin cấp đảng viên không tồn tại hoặc đã bị vô hiệu hóa trước đó");
            }
            thongTinCapDangVien.NguoiXoaID = _currentUserService.UserId;
            thongTinCapDangVien.NgayXoa = DateTime.Now;
            _thongTinCapDangVienRepository.Update(thongTinCapDangVien);
            if (await _thongTinCapDangVienRepository.UnitOfWork.SaveChangesAsync() > 0)
                return "Xóa thành công";
            else
                return "Xóa thất bại";
        }
    }
}
