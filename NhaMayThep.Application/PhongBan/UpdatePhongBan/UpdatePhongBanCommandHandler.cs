using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System.Data;

namespace NhaMayThep.Application.PhongBan.UpdatePhongBan
{
    public class UpdatePhongBanCommandHandler : IRequestHandler<UpdatePhongBanCommand, string>
    {
        private readonly IPhongBanRepository _phongBanRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdatePhongBanCommandHandler(IPhongBanRepository phongBanRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _phongBanRepository = phongBanRepository;
        }

        public async Task<string> Handle(UpdatePhongBanCommand command, CancellationToken cancellationToken)
        {
            var entity = await _phongBanRepository.FindAsync(x => x.ID == command.ID && x.NguoiXoaID == null);
            if (entity == null)
            {
                throw new NotFoundException("ID: " + command.ID + " không tồn tại");
            }

            var otherE = await _phongBanRepository.AnyAsync(x => x.ID != command.ID && x.Name == command.Name && x.NguoiXoaID == null);
            if (otherE == true)
            {
                throw new DuplicateNameException("Tên phòng ban: " + command.Name + " đã tồn tại");
            }

            entity.Name = command.Name;
            entity.NguoiCapNhatID = _currentUserService.UserId;
            entity.NgayCapNhat = DateTime.UtcNow;
            _phongBanRepository.Update(entity);
            return await _phongBanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
