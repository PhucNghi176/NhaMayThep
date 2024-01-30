using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhongBan.DeletePhongBan
{
    public class DeletePhongBanCommandHandler : IRequestHandler<DeletePhongBanCommand, string>
    {
        private readonly IPhongBanRepository _phongBanRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeletePhongBanCommandHandler(IPhongBanRepository phongBanRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _phongBanRepository = phongBanRepository;
        }
        public async Task<string> Handle(DeletePhongBanCommand command, CancellationToken cancellationToken)
        {
            var phongBan = await _phongBanRepository.FindAsync(x => x.ID == command.ID && x.NguoiXoaID == null);
            if (phongBan == null)
            {
                throw new NotFoundException("ID: " + command.ID + " không tồn tại");
            }
            phongBan.NgayXoa = DateTime.UtcNow;
            phongBan.NguoiXoaID = _currentUserService.UserId;
            _phongBanRepository.Update(phongBan);
            return await _phongBanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa thành công" : "Xóa thất bại";
        }
    }
}
