using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.Create
{
    public class CreateBaoHiemNhanVienChiTietBaoHiemCommandHandler : IRequestHandler<CreateBaoHiemNhanVienChiTietBaoHiemCommand, string>
    {
        private readonly IBaoHiemNhanVienRepository _baohiemNhanVienRepository;
        private readonly IChiTietBaoHiemRepository _chitietBaoHiemRepository;
        private readonly IBaoHiemNhanVienBaoHiemChiTietRepository _baohiemNhanVienChiTietRepository;
        private readonly ICurrentUserService _currentUser;
        public CreateBaoHiemNhanVienChiTietBaoHiemCommandHandler(IBaoHiemNhanVienRepository baohiemNhanVienRepository,
            IChiTietBaoHiemRepository chitietBaoHiemRepository,
            IBaoHiemNhanVienBaoHiemChiTietRepository baohiemNhanVienChiTietRepository,
            ICurrentUserService currentUser)
        {
            _baohiemNhanVienRepository = baohiemNhanVienRepository;
            _chitietBaoHiemRepository = chitietBaoHiemRepository;
            _baohiemNhanVienChiTietRepository = baohiemNhanVienChiTietRepository;
            _currentUser = currentUser;
        }

        public async Task<string> Handle(CreateBaoHiemNhanVienChiTietBaoHiemCommand request, CancellationToken cancellationToken)
        {
            var checkExist = await _baohiemNhanVienChiTietRepository
                .FindAsync(x => x.BHNV == request.MaBHNV && x.BHCT == request.MaCTBH, cancellationToken);
            if (checkExist != null)
            {
                if (checkExist.NgayXoa.HasValue && !string.IsNullOrEmpty(checkExist.NguoiXoaID))
                {
                    throw new DuplicationException("Đã tồn tại bảo hiểm với các thông số trên");
                }
                else
                {
                    throw new DuplicationException("Đã có bảo hiểm với các thông số trên bị xóa trước đó");
                }
            }
            var checkBaoHiemNhanVien = await _baohiemNhanVienRepository
                .FindAsync(x => x.ID == request.MaBHNV && string.IsNullOrEmpty(x.NguoiXoaID) && !x.NgayXoa.HasValue, cancellationToken);
            if (checkBaoHiemNhanVien == null)
            {
                throw new NotFoundException($"Không tồn tại bảo hiểm nhân viên với Id {request.MaBHNV}");
            }
            var checkChiTietbaoHiem = await _chitietBaoHiemRepository
                .FindAsync(x => x.ID == request.MaCTBH && string.IsNullOrEmpty(x.NguoiXoaID) && !x.NgayXoa.HasValue, cancellationToken);
            if (checkChiTietbaoHiem == null)
            {
                throw new NotFoundException($"Không tồn tại chi tiết bảo hiểm với Id {request.MaCTBH}");
            }
            var entity = new BaoHiemNhanVienBaoHiemChiTietEntity
            {
                BHNV = request.MaBHNV,
                BHCT = request.MaCTBH,
                BaoHiemNhanVienEntity = checkBaoHiemNhanVien,
                ChiTietBaoHiemEntity = checkChiTietbaoHiem,
                NgayTao = DateTime.Now,
                NguoiTaoID = _currentUser.UserId,
            };
            _baohiemNhanVienChiTietRepository.Add(entity);
            var result = await _baohiemNhanVienChiTietRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return "Tạo thành công";
            }
            else
            {
                return "Tạo thất bại";
            }
        }
    }
}
