using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.Delete
{
    public class DeleteBaoHiemNhanVienChiTietBaoHiemCommandHandler : IRequestHandler<DeleteBaoHiemNhanVienChiTietBaoHiemCommand, string>
    {
        private readonly IBaoHiemNhanVienBaoHiemChiTietRepository _baohiemNhanVienChiTietRepository;
        private readonly ICurrentUserService _currentUser;
        public DeleteBaoHiemNhanVienChiTietBaoHiemCommandHandler(IBaoHiemNhanVienBaoHiemChiTietRepository baohiemNhanVienChiTietRepository, ICurrentUserService currentUser)
        {
            _baohiemNhanVienChiTietRepository = baohiemNhanVienChiTietRepository;
            _currentUser = currentUser;
        }

        public async Task<string> Handle(DeleteBaoHiemNhanVienChiTietBaoHiemCommand request, CancellationToken cancellationToken)
        {
            var checkExist = await _baohiemNhanVienChiTietRepository
                .FindAsync(x => x.BHNV == request.MaBHNV && x.BHCT == request.MaCTBH, cancellationToken);
            if (checkExist == null)
            {
                throw new NotFoundException("Không tìm thấy");
            }
            if (checkExist.NgayXoa.HasValue && checkExist.NguoiXoaID != null)
            {
                throw new NotFoundException("Bảo hiểm này đã bị xóa trước đó");
            }
            checkExist.NguoiXoaID = _currentUser.UserId;
            checkExist.NgayXoa = DateTime.Now;
            _baohiemNhanVienChiTietRepository.Update(checkExist);
            var result = await _baohiemNhanVienChiTietRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return "Xóa thành công";
            }
            else
            {
                return "Xóa thất bại";
            }
        }
    }
}
