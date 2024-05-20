using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucVuDang.UpdateThongTinChucVuDang
{
    public class UpdateThongTinChucVuDangCommandHandler : IRequestHandler<UpdateThongTinChucVuDangCommand, string>
    {
        private readonly IThongTinChucVuDangRepository _thongTinChucVuDangRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateThongTinChucVuDangCommandHandler(IThongTinChucVuDangRepository thongTinChucVuDangRepository, ICurrentUserService currentUserService)
        {
            _thongTinChucVuDangRepository = thongTinChucVuDangRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateThongTinChucVuDangCommand request, CancellationToken cancellationToken)
        {
            var thongTinChucVuDang = await _thongTinChucVuDangRepository.FindAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (thongTinChucVuDang == null || (thongTinChucVuDang.NguoiXoaID != null && thongTinChucVuDang.NgayXoa.HasValue))
            {
                throw new NotFoundException("Thông tin chức vụ đảng không tồn tại hoặc đã bị vô hiệu hóa");
            }

            var checkDuplicatoion = await _thongTinChucVuDangRepository.AnyAsync(x => x.Name == request.TenChucVuDang && x.NgayXoa == null, cancellationToken);
            if (checkDuplicatoion)
                throw new DuplicationException("Tên chức vụ đảng đã tồn tại");

            thongTinChucVuDang.Name = request.TenChucVuDang;
            thongTinChucVuDang.NguoiCapNhatID = _currentUserService.UserId;
            thongTinChucVuDang.NgayCapNhat = DateTime.Now;
            _thongTinChucVuDangRepository.Update(thongTinChucVuDang);
            if (await _thongTinChucVuDangRepository.UnitOfWork.SaveChangesAsync() > 0)
                return "Cập nhật thành công";
            else
                return "Cập nhật thất bại";
        }
    }
}
