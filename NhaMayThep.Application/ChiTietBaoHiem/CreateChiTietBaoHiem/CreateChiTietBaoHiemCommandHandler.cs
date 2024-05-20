using MediatR;
using Microsoft.EntityFrameworkCore;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ChiTietBaoHiem.CreateChiTietBaoHiem
{
    public class CreateChiTietBaoHiemCommandHandler : IRequestHandler<CreateChiTietBaoHiemCommand, string>
    {
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IBaoHiemRepository _baohiemRepository;
        private readonly IChiTietBaoHiemRepository _chitietbaohiemRepository;
        private readonly ICurrentUserService _currentUser;
        public CreateChiTietBaoHiemCommandHandler(
            INhanVienRepository nhanVienRepository,
            IBaoHiemRepository baoHiemRepository,
            IChiTietBaoHiemRepository chitietbaohiemRepository,
            ICurrentUserService currentUser)
        {
            _nhanvienRepository = nhanVienRepository;
            _baohiemRepository = baoHiemRepository;
            _chitietbaohiemRepository = chitietbaohiemRepository;
            _currentUser = currentUser;
        }
        public async Task<string> Handle(CreateChiTietBaoHiemCommand request, CancellationToken cancellationToken)
        {
            Func<IQueryable<ChiTietBaoHiemEntity>, IQueryable<ChiTietBaoHiemEntity>> options = query =>
            {
                if (request.LoaiBaoHiem != 0)
                {
                    query = query.Where(x => x.LoaiBaoHiem == request.LoaiBaoHiem);
                }
                if (!string.IsNullOrEmpty(request.NoiCap))
                {
                    query = query.Where(x => EF.Functions.Like(x.NoiCap!, request.NoiCap));
                }
                query = query.Where(x => x.NgayHieuLuc == request.NgayHieuLuc);
                query = query.Where(x => x.NgayKetThuc == request.NgayKetThuc);
                return query;
            };
            var chechEntityExist = await _chitietbaohiemRepository.FindAsync(options, cancellationToken);
            if (chechEntityExist != null && chechEntityExist.NgayXoa == null)
            {
                throw new DuplicationException("Đã tồn tại chi tiết bảo hiểm với các nội dung trên");
            }
            else if (chechEntityExist != null && chechEntityExist.NgayXoa != null)
            {
                throw new DuplicationException("Đã tồn tại chi tiết bảo hiểm với nội dung trên nhưng đã bị xóa trước đó");
            }
            var baohiem = await _baohiemRepository.FindAsync(x => x.ID.Equals(request.LoaiBaoHiem), cancellationToken);
            if (baohiem == null || baohiem.NgayXoa != null)
            {
                throw new NotFoundException("Không tồn tại loại bảo hiểm này");
            }
            var chitietbaohiem = new ChiTietBaoHiemEntity
            {
                LoaiBaoHiem = request.LoaiBaoHiem,
                NgayHieuLuc = request.NgayHieuLuc,
                NgayKetThuc = request.NgayKetThuc,
                BaoHiem = baohiem,
                NoiCap = request.NoiCap,
                NguoiTaoID = _currentUser.UserId,
                NgayTao = DateTime.Now,
            };
            _chitietbaohiemRepository.Add(chitietbaohiem);
            return await _chitietbaohiemRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo thành công" : "Tạo thất bại";
        }
    }
}
