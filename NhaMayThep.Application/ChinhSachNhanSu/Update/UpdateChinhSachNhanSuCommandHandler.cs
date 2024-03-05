using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.Update
{
    public class UpdateChinhSachNhanSuCommandHandler : IRequestHandler<UpdateChinhSachNhanSuCommand, string>
    {
        private readonly IChinhSachNhanSuRepository _chinhSachNhanSuRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateChinhSachNhanSuCommandHandler(IChinhSachNhanSuRepository chinhSachNhanSuRepository, ICurrentUserService currentUserService)
        {
            _chinhSachNhanSuRepository = chinhSachNhanSuRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateChinhSachNhanSuCommand command, CancellationToken cancellationToken)
        {
            var entity = await _chinhSachNhanSuRepository.FindAsync(x => x.ID == command.ID && x.NguoiXoaID == null);
            if (entity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            entity.Name = command.Name;
            entity.MucDo = command.MucDo;
            entity.NgayHieuLuc = command.NgayHieuLuc;
            entity.NoiDung = command.NoiDung;
            entity.NguoiCapNhatID = _currentUserService.UserId;
            entity.NgayCapNhat = DateTime.UtcNow;
            _chinhSachNhanSuRepository.Update(entity);
            return await _chinhSachNhanSuRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
