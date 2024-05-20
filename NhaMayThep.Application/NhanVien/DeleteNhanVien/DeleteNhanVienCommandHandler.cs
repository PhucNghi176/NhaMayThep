using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NhanVien.DeleteNhanVien
{
    public class DeleteNhanVienCommandHandler : IRequestHandler<DeleteNhanVienCommand, string>
    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IHopDongRepository _hopDongRepository;
        public DeleteNhanVienCommandHandler(INhanVienRepository nhanVienRepository, ICurrentUserService currentUserService, IHopDongRepository hopDongRepository)
        {
            _nhanVienRepository = nhanVienRepository;
            _currentUserService = currentUserService;
            _hopDongRepository = hopDongRepository;
        }
        public async Task<string> Handle(DeleteNhanVienCommand command, CancellationToken cancellationToken)
        {
            var isFound = await _nhanVienRepository.FindAsync(x => x.ID == command.Id && x.NgayXoa == null, cancellationToken) ?? throw new NotFoundException("Id nhân viên không tồn tại");
            var isHopDongConHieuLuc = await _hopDongRepository.AnyAsync(x => x.NhanVienID == command.Id && x.NgayXoa == null, cancellationToken);
            if (isHopDongConHieuLuc)
                return "Hợp đồng của nhân viên vẫn còn hiệu lực";
            var userDelete = await _nhanVienRepository.FindAsync(x => x.ID == _currentUserService.UserId && x.NgayXoa == null, cancellationToken);
            if (isFound.ChucVuID == 1 && userDelete.ChucVuID != 1)
                throw new UnauthorizedException("Không thể xoá tài khoản Admin với tài khoản nhân sự");
            isFound.NguoiXoaID = _currentUserService.UserId;
            isFound.NgayXoa = DateTime.Now;
            _nhanVienRepository.Update(isFound);
            if (await _nhanVienRepository.UnitOfWork.SaveChangesAsync() > 0)
                return "Xóa thành công";
            else
                return "Xóa thất bại";
        }
    }
}
