using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongTy.DeleteThongTinCongTy
{
    public class DeleteThongTinCongTyCommandHandler : IRequestHandler<DeleteThongTinCongTyCommand, string>
    {
        private readonly IThongTinCongTyRepository _thongTinCongTyRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteThongTinCongTyCommandHandler(IThongTinCongTyRepository thongTinCongTyRepository, ICurrentUserService currentUserService)
        {
            _thongTinCongTyRepository = thongTinCongTyRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(DeleteThongTinCongTyCommand request, CancellationToken cancellationToken)
        {
            var thongTinCongTy = await _thongTinCongTyRepository.FindAsync(t => t.ID == request.Id && t.NgayXoa == null,cancellationToken);

            if (thongTinCongTy is null)
                throw new NotFoundException($"Khong tim thay Id {request.Id}");

            thongTinCongTy.NgayXoa = DateTime.Now;
            thongTinCongTy.NguoiXoaID = _currentUserService.UserId;
            _thongTinCongTyRepository.Update(thongTinCongTy);

            return await _thongTinCongTyRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xoa thanh cong" : "Xoa that bai";
        }
    }
}