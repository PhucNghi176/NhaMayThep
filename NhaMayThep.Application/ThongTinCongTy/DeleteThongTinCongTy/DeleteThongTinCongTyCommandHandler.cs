using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongTy.DeleteThongTinCongTy
{
    public class DeleteThongTinCongTyCommandHandler : IRequestHandler<DeleteThongTinCongTyCommand, string>
    {
        private readonly IThongTinCongTyRepository _thongtinCongTyRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeleteThongTinCongTyCommandHandler(
            IThongTinCongTyRepository thongTinCongTyRepository,
            ICurrentUserService currentUserService)
        {
            _thongtinCongTyRepository = thongTinCongTyRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteThongTinCongTyCommand request, CancellationToken cancellationToken)
        {
            var thongTinCongTy = await _thongtinCongTyRepository
                .FindAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (thongTinCongTy == null || (thongTinCongTy.NguoiXoaID != null && thongTinCongTy.NgayXoa.HasValue))
            {
                throw new NotFoundException("Thông tin công ty không tồn tại hoặc đã bị vô hiệu hóa trước đó");
            }
            thongTinCongTy.NguoiXoaID = _currentUserService.UserId;
            thongTinCongTy.NgayXoa = DateTime.Now;
            _thongtinCongTyRepository.Update(thongTinCongTy);
            await _thongtinCongTyRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Xóa thông tin công ty thành công";
        }
    }
}
