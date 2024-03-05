using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.Delete
{
    public class DeleteChinhSachNhanSuCommandHandler : IRequestHandler<DeleteChinhSachNhanSuCommand, string>
    {
        private readonly IChinhSachNhanSuRepository _chinhSachNhanSuRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeleteChinhSachNhanSuCommandHandler(IChinhSachNhanSuRepository chinhSachNhanSuRepository, ICurrentUserService currentUserService)
        {
            _chinhSachNhanSuRepository = chinhSachNhanSuRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteChinhSachNhanSuCommand command, CancellationToken cancellationToken)
        {
            var entity = await _chinhSachNhanSuRepository.FindAsync(x => x.ID == command.ID && x.NguoiXoaID == null);
            if(entity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            entity.NgayXoa = DateTime.UtcNow;
            entity.NguoiXoaID = _currentUserService.UserId;
            _chinhSachNhanSuRepository.Update(entity);
            return await _chinhSachNhanSuRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa thành công" : "Xóa thất bại";
        }
    }
}
