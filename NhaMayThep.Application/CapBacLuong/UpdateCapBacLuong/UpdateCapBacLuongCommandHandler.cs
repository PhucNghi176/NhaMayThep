using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.CapBacLuong.UpdateCapBacLuong
{
    public class UpdateCapBacLuongCommandHandler : IRequestHandler<UpdateCapBacLuongCommand, string>
    {
        private readonly ICapBacLuongRepository _capBacLuongRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateCapBacLuongCommandHandler(ICapBacLuongRepository capBacLuongRepository, ICurrentUserService currentUserService)
        {
            _capBacLuongRepository = capBacLuongRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateCapBacLuongCommand request, CancellationToken cancellationToken)
        {
            var capBacLuong = await _capBacLuongRepository.FindAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (capBacLuong == null || (capBacLuong.NguoiXoaID != null && capBacLuong.NgayXoa.HasValue))
            {
                throw new NotFoundException("Cấp bậc lương không tồn tại hoặc đã bị vô hiệu hóa");
            }

            var checkDuplicatoion = await _capBacLuongRepository.AnyAsync(x => x.Name == request.TenCapBac && x.NgayXoa == null, cancellationToken);
            if (checkDuplicatoion)
                throw new DuplicationException("Tên cấp bậc lương đã tồn tại");

            capBacLuong.Name = request.TenCapBac;
            capBacLuong.HeSoLuong = request.HeSoLuong;
            capBacLuong.TrinhDo = request.TrinhDo;
            capBacLuong.NguoiCapNhatID = _currentUserService.UserId;
            capBacLuong.NgayCapNhat = DateTime.Now;
            _capBacLuongRepository.Update(capBacLuong);
            if (await _capBacLuongRepository.UnitOfWork.SaveChangesAsync() > 0)
                return "Cập nhật thành công";
            else
                return "Cập nhật thất bại";
        }
    }
}
