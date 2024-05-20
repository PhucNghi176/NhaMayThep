using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.Restore
{
    public class RestoreBaoHiemNhanVienChiTietBaoHiemCommandHandler : IRequestHandler<RestoreBaoHiemNhanVienChiTietBaoHiemCommand, string>
    {
        private readonly IBaoHiemNhanVienBaoHiemChiTietRepository _baohiemNhanVienChiTietRepository;
        private readonly ICurrentUserService _currentUser;
        public RestoreBaoHiemNhanVienChiTietBaoHiemCommandHandler(IBaoHiemNhanVienBaoHiemChiTietRepository baohiemNhanVienChiTietRepository, ICurrentUserService currentUser)
        {
            _baohiemNhanVienChiTietRepository = baohiemNhanVienChiTietRepository;
            _currentUser = currentUser;
        }
        public async Task<string> Handle(RestoreBaoHiemNhanVienChiTietBaoHiemCommand request, CancellationToken cancellationToken)
        {
            var checkExist = await _baohiemNhanVienChiTietRepository
                           .FindAsync(x => x.BHNV == request.MaBHNV && x.BHCT == request.MaCTBH, cancellationToken);
            if (checkExist == null)
            {
                throw new NotFoundException("Không tìm thấy");
            }
            if (!checkExist.NgayXoa.HasValue && checkExist.NguoiXoaID == null)
            {
                throw new NotFoundException("Bảo hiểm này chưa bị xóa");
            }
            checkExist.NguoiXoaID = null;
            checkExist.NgayXoa = null;
            checkExist.NguoiCapNhatID = _currentUser.UserId; ;
            checkExist.NgayCapNhat = DateTime.Now;
            _baohiemNhanVienChiTietRepository.Update(checkExist);
            var result = await _baohiemNhanVienChiTietRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return "Phục hồi thành công";
            }
            else
            {
                return "Phục hồi thất bại";
            }
        }
    }
}
