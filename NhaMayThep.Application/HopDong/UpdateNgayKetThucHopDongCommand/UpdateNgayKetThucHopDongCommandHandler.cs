using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.HopDong.UpdateNgayKetThucHopDongCommand
{
    public class UpdateNgayKetThucHopDongCommandHandler : IRequestHandler<UpdateNgayKetThucHopDongCommand, string>
    {
        private readonly IHopDongRepository _hopDongRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateNgayKetThucHopDongCommandHandler(IHopDongRepository hopDongRepository, ICurrentUserService currentUserService)
        {
            _hopDongRepository = hopDongRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(UpdateNgayKetThucHopDongCommand command, CancellationToken cancellationToken)
        {
            var hopDong = await _hopDongRepository.FindAsync(x => x.ID == command.Id && x.NgayXoa == null, cancellationToken);
            if (hopDong == null)
                return "Cập nhật ngày kết thúc thất bại";
            hopDong.NgayKetThuc = DateTime.Now;
            hopDong.NguoiCapNhatID = _currentUserService.UserId;
            hopDong.NgayCapNhatCuoi = DateTime.Now;
            _hopDongRepository.Update(hopDong);
            if (await _hopDongRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Cập nhật thành công";
            else
                return "Cập nhật thất bại";
        }
    }
}
