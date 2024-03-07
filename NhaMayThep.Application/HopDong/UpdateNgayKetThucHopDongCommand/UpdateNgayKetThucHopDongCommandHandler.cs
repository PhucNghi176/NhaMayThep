using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var hopDong = await _hopDongRepository.FindAsync(x => x.ID == command.Id, cancellationToken);
            if (hopDong == null)
                return "Cập nhật ngày kết thúc thất bại";
            hopDong.NgayKetThuc = DateTime.Now;
            hopDong.ThoiHanHopDong = (int)((hopDong.NgayKetThuc - hopDong.NgayKy).Value.Days / 30.436875);
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
