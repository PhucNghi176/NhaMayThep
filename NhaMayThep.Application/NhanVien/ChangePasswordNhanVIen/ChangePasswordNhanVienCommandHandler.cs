using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NhanVien.ChangePasswordNhanVIen
{
    public class ChangePasswordNhanVienCommandHandler : IRequestHandler<ChangePasswordNhanVienCommand, string>
    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;

        public ChangePasswordNhanVienCommandHandler(INhanVienRepository nhanVienRepository, ICurrentUserService currentUserService)
        {
            _nhanVienRepository = nhanVienRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(ChangePasswordNhanVienCommand request, CancellationToken cancellationToken)
        {
            var nv = await _nhanVienRepository.FindAsync(x => x.ID == _currentUserService.UserId && x.NgayXoa == null, cancellationToken);
            if (nv == null)
            {
                throw new NotFoundException("Không tìm thấy nhân viên");
            }
            var verify = _nhanVienRepository.VerifyPassword(request.OldPassword, nv.PasswordHash);
            if (!verify)
            {
                return ("Mật khẩu cũ không đúng");
            }
            var newPassword = _nhanVienRepository.HashPassword(request.NewPassword);
            nv.PasswordHash = newPassword;
            _nhanVienRepository.Update(nv);
            var a = await _nhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return a > 0 ? "Đổi mật khẩu thành công" : "Đổi mật khẩu thất bại";

        }
    }
}
